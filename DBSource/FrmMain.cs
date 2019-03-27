using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.DXCore.Controls.XtraEditors;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using BaseCheckedListBoxControl = DevExpress.XtraEditors.BaseCheckedListBoxControl;

namespace DBSource
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        private DbConnection _con;
        private string _filterObjects = "";
        private string _filterDate = "";
        private string _path = "";
        private bool _byFolders = false;
        private int _backgroundWorkerTaskId;
        private bool _currentSchema = true;
        private bool _loadAll = false;
        private bool _subscribedConn = false;
        private bool _subscribedDisc = false;

        private enum ButtonConnect
        {
            Connect,
            Disconnect,
            Broken,
            Init
        }

        public FrmMain()
        {           
            InitializeComponent();
        }

        private void ReadConfig()
        {
            try
            {
                using (TextReader s = new StringReader(Properties.Settings.Default["Config"].ToString()))
                {
                    dataSet.ConnectionList.ReadXml(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonConnect_subsConn(bool enabled)
        {
            if (!enabled) button_connect.Click -= buttonConnect_Click;
            else if (!_subscribedConn)
                button_connect.Click += buttonConnect_Click;
            _subscribedConn = enabled;
        }

        private void buttonConnect_subsDisc(bool enabled)
        {
            if (!enabled) button_connect.Click -= button_disconnect_Click;
            else if (!_subscribedDisc)
                button_connect.Click += button_disconnect_Click;
            _subscribedDisc = enabled;
        }

        private void buttonConnect_Style(ButtonConnect e)
        {
            Image img;
            var tip = "";

            switch (e)
            {
                case ButtonConnect.Connect:
                    img = Properties.Resources.icons8_connected_32;
                    tip = "Press to connect";
                    buttonConnect_subsConn(true);
                    buttonConnect_subsDisc(false);
                    break;
                case ButtonConnect.Disconnect:
                    img = Properties.Resources.icons8_connected_failed_32;
                    tip = "Press to disconnect";
                    buttonConnect_subsConn(false);
                    buttonConnect_subsDisc(true);
                    break;
                case ButtonConnect.Broken:
                    img = Properties.Resources.icons8_broken_link_filled_32;
                    tip = "Broken. Press to connect";
                    buttonConnect_subsConn(true);
                    buttonConnect_subsDisc(false);
                    break;
                case ButtonConnect.Init:
                default:
                    img = Properties.Resources.icons8_link_32;
                    tip = "Choose connection.";
                    buttonConnect_subsConn(false);
                    buttonConnect_subsDisc(false);
                    break;
            }

            button_connect.ToolTip = tip;
            button_connect.Image = img;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(FrmWait));
                if (comboBox_Connections.Text == "")
                {
                    return;
                }

                var row = (from connection in dataSet.ConnectionList
                    where connection.Name == comboBox_Connections.Text
                    select connection).First();

                _path = row.Path;
                _byFolders = row.ByFolders;

                var par = new Dictionary<string, string>();
                var type = "";

                switch (row.Type)
                {
                    case "Oracle":
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
                        break;
                    }
                    case "MSSQL":
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
                        {
                            buttonConnect_Style(ButtonConnect.Broken);
                            return;
                        }

                        break;
                    }
                }


                _con.GetDBObjectTypes(dataSet.DbObjectTypes);

                _backgroundWorkerTaskId = 1;
                backgroundWorker2.RunWorkerAsync();
                button_control_connect(true);
                buttonConnect_Style(ButtonConnect.Disconnect);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                buttonConnect_Style(ButtonConnect.Broken);
                throw;
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ReadConfig();
            dataSet.ConnectionList.RowChanged += comboBox_Connections_Refresh;
            dataSet.ConnectionList.ConnectionListRowDeleted += comboBox_Connections_Refresh;
            comboBox_Connections_Refresh(sender, e);
        }

        private void comboBox_Connections_Refresh(object sender, EventArgs e)
        {
            comboBox_Connections.Properties.Items.Clear();
            var query = from connection in dataSet.ConnectionList
                        orderby connection.Name ascending
                select connection.Name;

            foreach (var r in query.ToList())
            {
                comboBox_Connections.Properties.Items.Add(r);
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
            buttonConnect_Style(ButtonConnect.Connect);
            dataSet.DbObjectTypes.Clear();
            dataSet.DbObjects.Clear();
            button_control_connect(false);
        }

        private void button_control_connect(bool isConnected)
        {
            comboBox_Connections.Enabled = !isConnected;
            barSubItem_Connection.Enabled = !isConnected;
            button_loadObjects.Enabled = isConnected;
            button_getSource.Enabled = isConnected;
            _currentSchema = isConnected;
            comboBox_Connections.Enabled = !isConnected;
            if (isConnected) return;
            checkedListBox_objectTypes.Items.Clear();
            checkedListBox_objects.Items.Clear();
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(@"Are you sure you want to delete " + comboBox_Connections.Text + @"?", Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var query = dataSet.ConnectionList.AsEnumerable()
                    .Where(r => r.Field<string>("Name") == comboBox_Connections.Text);
                foreach (var r in query.ToList())
                {
                    r.Delete();
                    comboBox_Connections.Text = "";
                }
            }
        }

        private void barButtonItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (comboBox_Connections.Text == "") return;
            var frm = new FrmAddConnection(true, comboBox_Connections.Text)
            {
                ConnectionList = dataSet.ConnectionList,
                Text = @"Edit connection"
            };
            frm.ShowDialog();
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmAddConnection
            {
                ConnectionList = dataSet.ConnectionList,
                Text = @"New connection"
            };
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                comboBox_Connections.SelectedItem = frm.GetConnectionName();
            }
        }

        private void SaveConfig()
        {
            try
            {
                using (TextWriter s = new StringWriter())
                {
                    dataSet.ConnectionList.WriteXml(s);
                    Properties.Settings.Default["Config"] = s.ToString();
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_loadObjects_Click(object sender, EventArgs e)
        {
            if (checkedListBox_objectTypes.CheckedItems.Count == 0)
            {
                checkedListBox_objects.Items.Clear();
                return;
            }
            try
            {
                SplashScreenManager.ShowForm(typeof(FrmWait));
                button_control_connect(true);
                {
                    var items = (from int item in checkedListBox_objectTypes.CheckedIndices
                        select checkedListBox_objectTypes.GetItemText(item)).ToList();
                    _con.GetDBObjectNames(dataSet.DbObjects, new Filter(_filterObjects, _filterDate), _currentSchema,
                        items);
                    _backgroundWorkerTaskId = 2;
                    backgroundWorker2.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                buttonConnect_Style(ButtonConnect.Broken);
                button_control_connect(false);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void button_addFilter_Click(object sender, EventArgs e)
        {
            _filterObjects = Helpers.ShowDialog("Set filter for objects names search:", "Edit filter", _filterObjects);
            button_addFilter.ButtonStyle = _filterObjects != "" ? BorderStyles.Flat : BorderStyles.Default;
        }

        private void button_getSource_Click(object sender, EventArgs e)
        {
            if (checkedListBox_objects.CheckedItems.Count == 0 && !_loadAll) return;

            button_getSource.Enabled = false;
            is_load_All();
            button_GetSource_Stop.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void is_load_All()
        {
            if (!_loadAll) return;
            try
            {
                button_getSourceView(new Bitmap(Properties.Resources.icons8_downloads_folder_30));
                Application.DoEvents();
                backgroundWorker3.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                buttonConnect_Style(ButtonConnect.Broken);
                button_control_connect(false);
            }
            finally
            {
                button_getSourceView(new Bitmap(Properties.Resources.icons8_start_30));
            }

            var i = 0;

            while (backgroundWorker3.IsBusy)
            {
                button_getSourceView(new Bitmap(Properties.Resources.icons8_downloads_folder_30));
                System.Threading.Thread.Sleep(500);
                Application.DoEvents();
                i++;
                if (i >= 3)
                    i = 0;
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double progress = 0;
            var errors = new List<string>();
            e.Result = errors;
            try
            {
                backgroundWorker1.ReportProgress((int) (Math.Round(progress)));
                {
                    var items = (from int item in checkedListBox_objects.CheckedIndices
                        select checkedListBox_objects.GetItemText(item)).ToList();

                    var query = (from obj in dataSet.DbObjects
                        where (items.Contains(obj.NAME) && !_loadAll) ||
                              (_loadAll)
                        select obj);

                    var step = (double) 100 / query.Count();

                    foreach (var obj in query)
                    {
                        if (backgroundWorker1.CancellationPending)
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
                                    continue;
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
                                errors.Add("Can't save object [" + obj.OBJECT_TYPE + "].[" + obj.OBJECT_NAME + "]" +
                                           " Error: " + ex.Message);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://temabit.com/");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender,
            System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            button_GetSource_Stop.Enabled = false;
            //button_getSource.Text = "Start";
            button_getSourceView(new Bitmap(Properties.Resources.icons8_start_30));
            button_getSource.Enabled = true;

            string resultText;
            var messageIcon = MessageBoxIcon.Information;

            if (e.Cancelled)
            {
                resultText = "Canceled!";
            }
            else
            {
                if (e.Error != null)
                {
                    resultText = "Error: " + e.Error.Message;
                    messageIcon = MessageBoxIcon.Error;
                    buttonConnect_Style(ButtonConnect.Broken);
                    button_control_connect(false);
                }
                else
                {
                    resultText = @"Done! Saved " + dataSet.DbObjects.Count.ToString() + @" objects";

                    var errors = e.Result as List<string>;
                    if (errors.Any())
                    {
                        resultText = resultText + @" There were errors! Save Log? ";
                        var frm = MessageBox.Show(resultText, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (frm == DialogResult.Yes)
                        {
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog
                            {
                                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                Title = @"Save Log",
                                FileName = @"DBSource_" + DateTime.Now.ToString("yyyyMMdd_hhmmss"),
                                DefaultExt = "txt",
                                Filter = @"Text files (*.txt)|*.txt|All files (*.*)|*.*",
                                CheckPathExists = true,
                                RestoreDirectory = true
                            };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllText(saveFileDialog1.FileName, string.Join("\r\n", errors));
                                var frm2 = MessageBox.Show(@"Open Log?", Text, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Hand);
                                if (frm2 == DialogResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show(resultText, Text, MessageBoxButtons.OK, messageIcon);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            button_getSourceView(e.ProgressPercentage.ToString() + @"%");
        }

        private void button_GetSource_Stop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                if (backgroundWorker1.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker1.CancelAsync();
                }
            }

            if (backgroundWorker2.IsBusy)
            {
                if (backgroundWorker2.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker2.CancelAsync();
                }
            }

            if (backgroundWorker3.IsBusy)
            {
                if (backgroundWorker3.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker3.CancelAsync();
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var chList = new CheckedListBoxControl();
            switch (_backgroundWorkerTaskId)
            {
                case 1:
                    //fill_checkedListBox_objectTypes
                    foreach (var obj in dataSet.DbObjectTypes)
                    {
                        chList.Items.Add(obj.NAME);
                    }

                    break;
                case 2:
                    //fill_checkedListBox_objects()
                    foreach (var obj in dataSet.DbObjects)
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
            var items = (e.Result as CheckedListBoxControl).Items.OfType<string>().ToArray();
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
            _con.GetDBObjectNames(dataSet.DbObjects, new Filter(_filterObjects, _filterDate), _currentSchema);
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender,
            System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        private void buttonGIT_Click(object sender, EventArgs e)
        {
            GIT.GITCommit(_path, false);
        }

        private void button_addDateFilter_Click(object sender, EventArgs e)
        {
            _filterDate = Helpers.ShowDialog("Date", "Recent object changes from:",
                _filterDate == "" ? DateTime.Now.ToString("dd/MM/yyyy 00:00") : _filterDate,
                new DateTimePicker() {Format = DateTimePickerFormat.Custom, CustomFormat = @"dd/MM/yyyy HH:mm"});
            button_addDateFilter.ButtonStyle = _filterDate != "" ? BorderStyles.Flat : BorderStyles.Default;
        }

        private static void CheckBoxElements(BaseCheckedListBoxControl checkedList, bool check)
        {
            for (var i = 0; i < checkedList.ItemCount; i++)
            {
                checkedList.SetItemChecked(i, check);
            }
        }

        private void button_currentSchema_Click(object sender, EventArgs e)
        {
            _currentSchema = !_currentSchema;
            button_currentSchema.ButtonStyle = _currentSchema ? BorderStyles.Flat : BorderStyles.Default;
        }

        private void button_getSourceView(Image img)
        {
            button_getSource.Text = "";
            button_getSource.Image = img;
        }

        private void button_getSourceView(string txt)
        {
            button_getSource.Image = null;
            button_getSource.Text = txt;
        }

        private void SetTips()
        {
            button_getSource.ToolTip = @"Start";
            button_GetSource_Stop.ToolTip = @"Stop";
            button_addDateFilter.ToolTip = @"Date Filter";
            button_addFilter.ToolTip = @"Name Filter";
            button_currentSchema.ToolTip = @"Current Schema";
            button_loadAll.ToolTip = @"Load All Server Objects";
            button_loadObjects.ToolTip = @"Load Objects List";
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            SetTips();
            buttonConnect_Style(ButtonConnect.Init);
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinPopupMenu(barSubItem_DevStyle);
            UserLookAndFeel.Default.StyleChanged +=
                delegate
                {
                    Properties.Settings.Default.SkinName = UserLookAndFeel.Default.SkinName;
                    Properties.Settings.Default.Save();
                };
        }

        private void button_loadAll_Click(object sender, EventArgs e)
        {
            _loadAll = !_loadAll;
            checkedListBox_objectTypes.Enabled = !_loadAll;
            checkedListBox_objects.Enabled = !_loadAll;
            button_loadObjects.Enabled = !_loadAll;
            button_loadAll.ButtonStyle = _loadAll ? BorderStyles.Flat : BorderStyles.Default;
        }

        private void barButtonItem_page_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/illia-miatka/DBSource");
        }

        private void barButtonItem_Wiki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = currentDir + @"Manual\DBSource_Manual.htm";
            System.Diagnostics.Process.Start(fullPath);
        }

        private void comboBox_Connections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Connections.SelectedIndex != -1)
            {
                buttonConnect_Style(ButtonConnect.Connect);
            }
            else
            {
                buttonConnect_Style(ButtonConnect.Init);
            }
        }

        private void checkedListBox_objectTypes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && checkedListBox_objectTypes.Enabled)
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void bbCh1_Clear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckBoxElements(checkedListBox_objectTypes, false);
        }

        private void bbCh1_SelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckBoxElements(checkedListBox_objectTypes, true);

        }

        private void bbCh2_SelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckBoxElements(checkedListBox_objects, true);
        }

        private void bbCh2_Clear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckBoxElements(checkedListBox_objects, false);
        }

        private void checkedListBox_objects_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && checkedListBox_objects.Enabled)
            {
                popupMenu2.ShowPopup(MousePosition);
            }
        }

        private void comboBox_Connections_Leave(object sender, EventArgs e)
        {
            var q = dataSet.ConnectionList.Where(con => con.Name == comboBox_Connections.Text).Select(con => con.Name);
            if (!q.Any())
            {
                comboBox_Connections.SelectedIndex = -1;
            }
        }
    }
}

