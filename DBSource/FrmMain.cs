using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DBSource
{
    public partial class FrmMain : Form
    {
        private readonly DataSet.ConnectionListDataTable _connectionList = new DataSet.ConnectionListDataTable();
        private readonly DataSet.DbObjectTypesDataTable _objectTypes = new DataSet.DbObjectTypesDataTable();
        private readonly DataSet.DbObjectsDataTable _objects = new DataSet.DbObjectsDataTable();
        private readonly DataSet.OBJDataTable _ddl = new DataSet.OBJDataTable();
        private DBConnection _con;
        private string _filterObjects = "";
        private string _path = "";
        private int _backgroundWorkerTaskId;

        public FrmMain()
        {
            _connectionList.ReadXml("config");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox_Connections.Text == "")
            {
                return;
            }

            var row = (from connection in _connectionList
                where connection.Name == comboBox_Connections.Text
                select connection).First();

            _path = row.Path;

            if (row.IsDirect)
            {
                _con = new DBConnection(row.User, Crypt.Decrypt(row.Password), row.Protocol, row.Host,
                    row.Port, row.SID);
            }
            else
            {
                _con = new DBConnection(row.User, Crypt.Decrypt(row.Password), row.TNS);
            }

            button_control_connect(true);

            var stringCmd = "SELECT DISTINCT OBJECT_TYPE AS NAME FROM ALL_OBJECTS WHERE OBJECT_TYPE<>'LOB' " +
                            "UNION " +
                            "SELECT DISTINCT OBJECT_TYPE FROM USER_OBJECTS WHERE OBJECT_TYPE<>'LOB' ";
            _con.GetQueryResult(stringCmd, _objectTypes);

            _backgroundWorkerTaskId = 1;
            backgroundWorker2.RunWorkerAsync();

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            _connectionList.RowChanged += comboBox_Connections_Refresh;
            _connectionList.ConnectionListRowDeleted += comboBox_Connections_Refresh;
            comboBox_Connections_Refresh(sender, e);
        }

        private void comboBox_Connections_Refresh(object sender, EventArgs e)
        {
            comboBox_Connections.Items.Clear();
            var query = from connection in _connectionList
                orderby connection.Name ascending
                select connection.Name;

            foreach (var r in query.ToList())
            {
                comboBox_Connections.Items.Add(r);
            }

            comboBox_Connections.Refresh();

            save_Data();

        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_con != null)
            {
                if (_con.State() != ConnectionState.Closed)
                    _con.Close();
            }

            save_Data();
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            _con.Close();
            button_control_connect(false);
        }

        private void button_control_connect(bool isConnected)
        {
            button_disconnect.Enabled = isConnected;
            button_connect.Enabled = !isConnected;

            comboBox_Connections.Enabled = !isConnected;
            addToolStripMenuItem.Enabled = !isConnected;
            deleteToolStripMenuItem.Enabled = !isConnected;
            editToolStripMenuItem.Enabled = !isConnected;
            button_loadObjects.Enabled = isConnected;
            button_getSource.Enabled = isConnected;
            checkBox_currentSchema.Enabled = isConnected;

            if (isConnected) return;
            checkedListBox_objectTypes.Items.Clear();
            checkedListBox_objects.Items.Clear();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddConnection
            {
                ConnectionList = _connectionList,
                Text = @"New connection"
            };
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Are you sure you want to delete " + comboBox_Connections.Text + @"?", Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var query = _connectionList.AsEnumerable()
                    .Where(r => r.Field<string>("Name") == comboBox_Connections.Text);
                foreach (var r in query.ToList())
                {
                    r.Delete();
                    comboBox_Connections.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox_Connections.Text == "") return;
            var frm = new FrmAddConnection(true, comboBox_Connections.Text)
            {
                ConnectionList = _connectionList,
                Text = @"Edit connection"
            };
            frm.ShowDialog();
        }

        private void save_Data()
        {
            try
            {
                _connectionList.WriteXml("config");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void button_loadObjects_Click(object sender, EventArgs e)
        {
            if (checkedListBox_objectTypes.CheckedItems.Count == 0) return;
            try
            {
                button_control_connect(true);
                {
                    string stringCmd =
                        "SELECT DISTINCT '[' || OBJECT_TYPE || ']' || OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE " +
                        "FROM ( " +
                        "SELECT DISTINCT OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE " +
                        "FROM ALL_OBJECTS ";
                    if (checkBox_currentSchema.Checked)
                    {
                        stringCmd += "WHERE OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA') ";
                    }

                    stringCmd += "UNION " +
                                 "SELECT DISTINCT OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE " +
                                 "FROM USER_OBJECTS" +
                                 ") t " +
                                 "WHERE OBJECT_TYPE IN(";

                    if (checkedListBox_objectTypes.CheckedItems.Count == 1)
                        stringCmd = stringCmd.Replace("'[' || OBJECT_TYPE || ']' ||", "");

                    foreach (var type in checkedListBox_objectTypes.CheckedItems)
                    {
                        stringCmd += "'" + type + "',";
                    }

                    stringCmd = stringCmd.Remove(stringCmd.Length - 1);
                    stringCmd += ") ";
                    stringCmd += _filterObjects != "" ? "AND OBJECT_NAME LIKE ('%" + _filterObjects + "%') " : "";
                    stringCmd += "ORDER BY 1";

                    _con.GetQueryResult(stringCmd, _objects);
                    _backgroundWorkerTaskId = 2;
                    backgroundWorker2.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                button_control_connect(false);
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox_LoadMode_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox_objects.Enabled = !checkBox_LoadMode.Checked;
        }

        private void button_addFilter_Click(object sender, EventArgs e)
        {
            _filterObjects = Addons.ShowDialog("Set filter for objects names search:", "Edit filter", _filterObjects);
            button_addFilter.BackColor = _filterObjects == "" ? default(Color) : Color.LightBlue;
        }

        private void button_getSource_Click(object sender, EventArgs e)
        {
            if (checkedListBox_objects.CheckedItems.Count == 0 && !checkBox_LoadMode.Checked &&
                !checkBox_loadAll.Checked) return;

            button_getSource.Enabled = false;
            is_load_All();
            button_GetSource_Stop.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void is_load_All()
        {
            if (checkBox_loadAll.Checked)
            {
                try
                {
                    button_control_connect(true);
                    {
                        var stringCmd = "SELECT DISTINCT OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE "
                                        + "FROM ALL_OBJECTS ";
                        if (checkBox_currentSchema.Checked)
                        {
                            stringCmd += "WHERE OWNER=SYS_CONTEXT('USERENV','CURRENT_SCHEMA') AND OBJECT_TYPE<>'LOB' " +
                                         "AND SUBSTR(OBJECT_NAME,1,4) <> 'SYS_'";
                        }

                        stringCmd += "UNION " +
                                     "SELECT DISTINCT OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE " +
                                     "FROM  USER_OBJECTS " +
                                     "WHERE OBJECT_TYPE<>'LOB' AND SUBSTR(OBJECT_NAME,1,4) <> 'SYS_'";
                        _con.GetQueryResult(stringCmd, _objects);
                    }
                }
                catch (Exception ex)
                {
                    button_control_connect(false);
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double progress = 0;

            try
            {
                {
                    var query = (from obj in _objects
                        where (checkedListBox_objects.CheckedItems.Contains(obj.NAME) && !checkBox_loadAll.Checked) ||
                              (checkBox_loadAll.Checked)
                        select obj);

                    if (checkBox_LoadMode.Checked)
                        query = (from obj in _objects
                            select obj);

                    var step = (double) 100 / query.Count();
                    _ddl.Clear();

                    foreach (var obj in query)
                    {
                        if (backgroundWorker1.CancellationPending == true)
                        {
                            e.Cancel = true;
                            break;
                        }
                        else
                        {
                            try
                            {
                                var stringCmd = "SELECT dbms_metadata.get_ddl('" +
                                                Get_type(obj.OBJECT_TYPE).Replace(' ', '_') +
                                                "', '" + obj.OBJECT_NAME + "') AS DDL, '" + obj.OBJECT_NAME +
                                                "' as OBJECT_NAME, '" + obj.OBJECT_TYPE + "' as OBJECT_TYPE  FROM DUAL";
                                _con.GetQueryResult(stringCmd, _ddl);
                                var ddl = (from d in _ddl
                                    select d).First();

                                var path = _path + @"\" +
                                           (ddl.OBJECT_TYPE == "PACKAGE BODY" ? "PACKAGE" : ddl.OBJECT_TYPE) + @"S\";
                                Directory.CreateDirectory(path);
                                path += ddl.OBJECT_NAME + get_object_file_type(ddl.OBJECT_TYPE);
                                File.WriteAllText(path, ddl.DDL);
                                progress += step;
                                backgroundWorker1.ReportProgress((int) (Math.Round(progress)));
                            }
                            catch (Exception ex)
                            {
                                if (
                                    MessageBox.Show(
                                        "Can't save object [" + obj.OBJECT_TYPE + "].[" + obj.OBJECT_NAME +
                                        "]. Continue?", @"Error", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    MessageBox.Show(
                                        @"Message: " + ex.Message,
                                        @"Error:" + @"[" + obj.OBJECT_TYPE + @"].[" + obj.OBJECT_NAME + @"]",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    button_control_connect(false);
                                    return;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                button_control_connect(false);
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string Get_type(string objectType)
        {
            if (objectType == "PACKAGE") objectType = "PACKAGE_SPEC";
            if (objectType == "JOB" || objectType == "SCHEDULE") objectType = "PROCOBJ";
            if (objectType == "LOB") objectType = "TABLE";
            if (objectType == "DATABASE LINK") objectType = "DB_LINK";
            return objectType;
        }

        private void editExportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private static string get_object_file_type(string objTypeName)
        {
            var val = ".sql";
            switch (objTypeName)
            {
                case "PROCEDURE":
                    val = ".prc";
                    break;
                case "VIEW":
                    val = ".vw";
                    break;
                case "PACKAGE_SPEC":
                case "PACKAGE":
                    val = ".pks";
                    break;
                case "PACKAGE BODY":
                    val = ".pkb";
                    break;
                case "TRIGGER":
                    val = ".trg";
                    break;
            }

            return val;
        }

        private void checkBox_loadAll_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox_objectTypes.Enabled = !checkBox_loadAll.Checked;
            checkedListBox_objects.Enabled = !checkBox_loadAll.Checked;
            checkBox_loadAll.Enabled = !checkBox_LoadMode.Checked;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://temabit.com/");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender,
            System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            button_GetSource_Stop.Enabled = false;
            button_getSource.Text = "Start";
            button_getSource.Enabled = true;

            string resultText;
            var messageIcon = MessageBoxIcon.Information;

            if (e.Cancelled == true)
            {
                resultText = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultText = "Error: " + e.Error.Message;
                messageIcon = MessageBoxIcon.Error;
            }
            else
            {
                resultText = "Done!";
            }

            MessageBox.Show(resultText, Text, MessageBoxButtons.OK, messageIcon);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            button_getSource.Text = (e.ProgressPercentage.ToString() + @"%");
        }

        private void button_GetSource_Stop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var chList = new CheckedListBox();
            switch (_backgroundWorkerTaskId)
            {
                case 1:
                    //fill_checkedListBox_objectTypes
                    foreach (var obj in _objectTypes)
                    {
                        chList.Items.Add(obj.NAME);
                    }

                    break;
                case 2:
                    //fill_checkedListBox_objects()
                    foreach (var obj in _objects)
                    {
                        chList.Items.Add(obj.NAME);
                    }

                    break;
            }

            e.Result = chList;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender,
            System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var items = (e.Result as CheckedListBox).Items;
            switch (_backgroundWorkerTaskId)
            {
                case 1:
                    //fill_checkedListBox_objectTypes
                    checkedListBox_objectTypes.Items.Clear();
                    checkedListBox_objectTypes.Items.AddRange(items);
                    checkedListBox_objectTypes.Refresh();
                    break;
                case 2:
                    //fill_checkedListBox_objects()
                    checkedListBox_objects.Items.Clear();
                    checkedListBox_objects.Items.AddRange(items);
                    checkedListBox_objects.Refresh();
                    break;
            }
        }
    }
}
