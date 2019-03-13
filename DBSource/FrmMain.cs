using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using DevExpress.Data.PLinq.Helpers;

namespace DBSource
{
    public partial class FrmMain : Form
    {
        private readonly DataSet.ConnectionListDataTable _connectionList = new DataSet.ConnectionListDataTable();
        private readonly DataSet.DbObjectTypesDataTable _objectTypes = new DataSet.DbObjectTypesDataTable();
        private readonly DataSet.DbObjectsDataTable _objects = new DataSet.DbObjectsDataTable();
        private DbConnection _con;
        private string _filterObjects = "";
        private string _filterDate = "";
        private string _path = "";
        private bool _byFolders = false;
        private int _backgroundWorkerTaskId;

        public FrmMain()
        {
            ReadConfig();
            InitializeComponent();
        }

        private void ReadConfig()
        {
            try
            {
                using (TextReader S = new StringReader(Properties.Settings.Default["Config"].ToString()))
                {
                    _connectionList.ReadXml(S);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
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
            _byFolders = row.ByFolders;

            var par = new Dictionary<string, string>();
            var type = "";

            if (row.Type == "Oracle")
            {
                if (row.IsDirect)
                {
                    par.Add("user", row.User);
                    par.Add("password", Crypt.Decrypt(row.Password));
                    par.Add("protocol", row.Protocol);
                    par.Add("host", row.Host);
                    par.Add("port", row.Port.ToString());
                    par.Add("sid", row.SID);
                    type = "direct";
                }
                else
                {
                    par.Add("user", row.User);
                    par.Add("password", Crypt.Decrypt(row.Password));
                    par.Add("tns", row.TNS);
                    type = "notdirect";
                }

                _con = new DbConnectionOracle(type, par);
            }
       
            if (row.Type == "MSSQL")
            {

                if (row.WinLogin)
                {
                    par.Add("server", row.Server);
                    type = "direct";
                }
                else
                {
                    par.Add("server", row.Server);
                    par.Add("user", row.User);
                    par.Add("password", Crypt.Decrypt(row.Password));
                    type = "notdirect";
                }
                _con = new DBConnectionMSSQl(type, par);
                if (_con.State() != ConnectionState.Open)
                    return;
            }
            
            button_control_connect(true);

            _con.GetDBObjectTypes(_objectTypes);

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

            SaveConfig();

        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_con != null)
            {
                if (_con.State() != ConnectionState.Closed)
                    _con.Close();
            }

            SaveConfig();
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            button_GetSource_Stop_Click(sender, e);
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

        private void SaveConfig()
        {
            try
            {
                using (TextWriter S = new StringWriter())
                {
                    _connectionList.WriteXml(S);
                    Properties.Settings.Default["Config"] = S.ToString();
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }


        }

        private void button_loadObjects_Click(object sender, EventArgs e)
        {
            if (checkedListBox_objectTypes.CheckedItems.Count == 0) return;
            try
            {
                button_control_connect(true);
                {
                   _con.GetDBObjectNames(_objects, new Filter(_filterObjects,_filterDate), checkBox_currentSchema.Checked, 
                       checkedListBox_objectTypes.CheckedItems.OfType<string>().ToList());
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
            _filterObjects = Helpers.ShowDialog("Set filter for objects names search:", "Edit filter", _filterObjects);
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
                    //button_control_connect(true);
                    button_getSource.Text = "Load Objects";
                    Application.DoEvents();
                    backgroundWorker3.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    button_control_connect(false);
                }
                finally
                {
                    button_getSource.Text = "Start";
                }

                int i = 0;

                while (backgroundWorker3.IsBusy)
                {
                    button_getSource.Text = new String(' ', i) + "Load Objects" + new String('.', i);
                    System.Threading.Thread.Sleep(500);
                    Application.DoEvents();
                    i++;
                    if(i>=3)
                        i = 0;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double progress = 0;
            var errors = new List<string>();
            e.Result = errors;
            try
            {
                backgroundWorker1.ReportProgress((int)(Math.Round(progress)));
                {
                    var query = (from obj in _objects
                        where (checkedListBox_objects.CheckedItems.Contains(obj.NAME) && !checkBox_loadAll.Checked) ||
                              (checkBox_loadAll.Checked)
                        select obj);

                    if (checkBox_LoadMode.Checked)
                        query = (from obj in _objects
                            select obj);

                    var step = (double) 100 / query.Count();

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
                                
                                var path = _path + _con.GetPath(obj.OBJECT_TYPE, obj.NAME, _byFolders);
                                var ddl = _con.GetDDL(obj);
                                if (ddl == "")
                                {
                                    return;
                                }

                                var fileName = _con.GetFileName(obj.OBJECT_TYPE, obj.NAME, !_byFolders);
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);
                                File.WriteAllText(path + Helpers.CheckForIllegalChar(fileName), ddl);

                                progress += step;
                                backgroundWorker1.ReportProgress((int) (Math.Round(progress)));
                            }
                            catch (Exception ex)
                            {
                                errors.Add("Can't save object [" + obj.OBJECT_TYPE + "].[" + obj.OBJECT_NAME + "]" + " Error: " + ex.Message);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errors.Add(" Error: " + ex.Message);
            }
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
                button_control_connect(false);
            }
            else
            {
                resultText = "Done!";
            }

            var errors = (e.Result as List<string>);
            if (errors.Any())
            {
                resultText = resultText + @" There were errors! Save Log? ";
                var frm = MessageBox.Show(resultText, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (frm == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);      
                    saveFileDialog1.Title = @"Save Log";
                    saveFileDialog1.FileName = @"DBSource_" + DateTime.Now.ToString("yyyyMMdd_hhmmss");
                    saveFileDialog1.DefaultExt = "txt";
                    saveFileDialog1.Filter =
                        @"Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, string.Join("\r\n", errors));
                        var frm2 = MessageBox.Show("Open Log?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                        if (frm2 == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(resultText, Text, MessageBoxButtons.OK, messageIcon);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            button_getSource.Text = (e.ProgressPercentage.ToString() + @"%");
        }

        private void button_GetSource_Stop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                if (backgroundWorker1.WorkerSupportsCancellation == true)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker1.CancelAsync();
                }
            }

            if (backgroundWorker2.IsBusy)
            {
                if (backgroundWorker2.WorkerSupportsCancellation == true)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker2.CancelAsync();
                }
            }

            if (backgroundWorker3.IsBusy)
            {
                if (backgroundWorker3.WorkerSupportsCancellation == true)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker3.CancelAsync();
                }
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

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _con.GetDBObjectNames(_objects, new Filter(_filterObjects, _filterDate) , checkBox_currentSchema.Checked);
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            
        }

        private void buttonGIT_Click(object sender, EventArgs e)
        {
            GIT.GITCommit(_path, false);
        }

        private void button_addDateFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
