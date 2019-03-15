using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DBSource
{
    public partial class FrmAddConnection : Form
    {
        public DataSet.ConnectionListDataTable ConnectionList;
        private readonly bool _isEditMode;

        public FrmAddConnection(bool isEditMode = false, string name = "Connection")
        {
            InitializeComponent();
            _isEditMode = isEditMode;
            textBox_Name.Text = name;
            this.DialogResult = DialogResult.Cancel;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(!Helpers.CheckPath(textBox_path.Text))
                return;

            if (_isEditMode)
            {
                var query = ConnectionList.AsEnumerable().Where(r => r.Field<string>("Name") == textBox_Name.Text);
                foreach (var r in query.ToList())
                {
                    r.Delete();
                }
            }
            else
            {

                var chk = (from connection in ConnectionList
                    where connection.Name == textBox_Name.Text
                    select connection.Name).ToList().Count;
                if (chk > 0)
                {
                    MessageBox.Show(@"Уже существует подключение с таким именем", @"Внимание", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            var newRow = ConnectionList.NewConnectionListRow();
            newRow.Type = xtraTabControl1.SelectedTabPage.Text;
            newRow.Name = textBox_Name.Text;
            newRow.Path = textBox_path.Text;
            newRow.ByFolders = cbObjPath.Checked;

            if (newRow.Type == "Oracle")
            {                                              
                newRow.IsDirect = checkBox_DC.Checked;
                newRow.User = textBox_User.Text;
                newRow.Password = Crypt.Encrypt(textBox_Password.Text);
                newRow.Path = textBox_path.Text;
                if (!checkBox_DC.Checked)
                {
                    newRow.TNS = textBox_TNS.Text;
                }
                else
                {
                    newRow.Protocol = textBox_Protocol.Text;
                    newRow.Host = textBox_Host.Text;
                    newRow.Port = (int) numericUpDown_Port.Value;
                    newRow.SID = textBox_SID.Text;
                }
            }

            if (newRow.Type == "MSSQL")
            {
                newRow.WinLogin = checkBox_WinLog_MS.Checked;
                newRow.Server = textBox_Server_MS.Text;

                if (!newRow.WinLogin)
                {
                    newRow.User = textBox_User_MS.Text;
                    newRow.Password = Crypt.Encrypt(textBox_Password_MS.Text);
                }
            }

            ConnectionList.AddConnectionListRow(newRow);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void checkBox_DC_CheckedChanged(object sender, EventArgs e)
        {
            panel_DC.Enabled = checkBox_DC.Checked;
            textBox_TNS.Enabled = !checkBox_DC.Checked;
        }

        private void Frm_AddConnection_Set_Edit_Mode()
        {
            if (!_isEditMode) return;
            textBox_Name.Enabled = !_isEditMode;
            var load = (from connection in ConnectionList
                where connection.Name == textBox_Name.Text
                select connection).First();

            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.First(x => x.Text == load.Type);
            textBox_Name.Text = load.Name;
            textBox_path.Text = load.Path;
            cbObjPath.Checked = load.ByFolders;

            switch (load.Type)
            {
                case "Oracle":
                    checkBox_DC.Checked = load.IsDirect;
                    textBox_User.Text = load.User;
                    textBox_Password.Text = Crypt.Decrypt(load.Password);
                    if (load.IsDirect)
                    {
                        textBox_Protocol.Text = load.Protocol;
                        textBox_Host.Text = load.Host;
                        numericUpDown_Port.Value = load.Port;
                        textBox_SID.Text = load.SID;
                    }
                    else
                    {
                        textBox_TNS.Text = load.TNS;
                    }

                    break;
                case "MSSQL":
                    checkBox_WinLog_MS.Checked = load.WinLogin;
                    textBox_Server_MS.Text = load.Server;
                    if (checkBox_WinLog_MS.Checked) return;
                    textBox_User_MS.Text = load.User;
                    textBox_Password_MS.Text = Crypt.Decrypt(load.Password);
                    break;
            }
        }

        private void Frm_AddConnection_Shown(object sender, EventArgs e)
        {
            Frm_AddConnection_Set_Edit_Mode();
        }

        private void button_path_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                if (dialog.SelectedPath != "")
                textBox_path.Text = dialog.SelectedPath;
            }
        }

        private void checkBox_WinLog_MS_CheckedChanged(object sender, EventArgs e)
        {
            textBox_User_MS.Enabled = !checkBox_WinLog_MS.Checked;
            textBox_Password_MS.Enabled = !checkBox_WinLog_MS.Checked;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Oracle")
            {
                pictureBox1.Image = Properties.Resources.Oracle;
            }
            if (xtraTabControl1.SelectedTabPage.Text == "MSSQL")
            {
                pictureBox1.Image = Properties.Resources.MSSQL;
            }
        }

        public string getConnectionName()
        {
            return textBox_Name.Text;
        }
    }
}
