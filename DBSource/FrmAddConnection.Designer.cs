namespace DBSource
{
    partial class FrmAddConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddConnection));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_path = new System.Windows.Forms.Button();
            this.label_path = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageOracle = new DevExpress.XtraTab.XtraTabPage();
            this.label_TNS = new System.Windows.Forms.Label();
            this.textBox_TNS = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.panel_DC = new System.Windows.Forms.Panel();
            this.numericUpDown_Port = new System.Windows.Forms.NumericUpDown();
            this.label_SID = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_Host = new System.Windows.Forms.Label();
            this.label_Protocol = new System.Windows.Forms.Label();
            this.textBox_SID = new System.Windows.Forms.TextBox();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.textBox_Protocol = new System.Windows.Forms.TextBox();
            this.checkBox_DC = new System.Windows.Forms.CheckBox();
            this.xtraTabPageMSSQL = new DevExpress.XtraTab.XtraTabPage();
            this.label_Password2 = new System.Windows.Forms.Label();
            this.textBox_Password_MS = new System.Windows.Forms.TextBox();
            this.label_User2 = new System.Windows.Forms.Label();
            this.textBox_User_MS = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.textBox_Server_MS = new System.Windows.Forms.TextBox();
            this.checkBox_WinLog_MS = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageOracle.SuspendLayout();
            this.panel_DC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Port)).BeginInit();
            this.xtraTabPageMSSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button_path);
            this.splitContainer1.Panel1.Controls.Add(this.label_path);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_path);
            this.splitContainer1.Panel1.Controls.Add(this.button_Cancel);
            this.splitContainer1.Panel1.Controls.Add(this.button_Save);
            this.splitContainer1.Panel1.Controls.Add(this.label_Name);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Name);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(561, 261);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DBSource.Properties.Resources.Oracle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(217, 59);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(23, 20);
            this.button_path.TabIndex = 74;
            this.button_path.Text = "...";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.button_path_Click);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(12, 63);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(29, 13);
            this.label_path.TabIndex = 73;
            this.label_path.Text = "Path";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(70, 60);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(155, 20);
            this.textBox_path.TabIndex = 72;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(181, 198);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(79, 48);
            this.button_Cancel.TabIndex = 64;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(181, 89);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(79, 103);
            this.button_Save.TabIndex = 63;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(12, 34);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(35, 13);
            this.label_Name.TabIndex = 62;
            this.label_Name.Text = "Name";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(70, 31);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(170, 20);
            this.textBox_Name.TabIndex = 61;
            this.textBox_Name.Text = "Connection";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageOracle;
            this.xtraTabControl1.Size = new System.Drawing.Size(293, 261);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageOracle,
            this.xtraTabPageMSSQL});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPageOracle
            // 
            this.xtraTabPageOracle.Controls.Add(this.label_TNS);
            this.xtraTabPageOracle.Controls.Add(this.textBox_TNS);
            this.xtraTabPageOracle.Controls.Add(this.label_Password);
            this.xtraTabPageOracle.Controls.Add(this.textBox_Password);
            this.xtraTabPageOracle.Controls.Add(this.label_User);
            this.xtraTabPageOracle.Controls.Add(this.textBox_User);
            this.xtraTabPageOracle.Controls.Add(this.panel_DC);
            this.xtraTabPageOracle.Controls.Add(this.checkBox_DC);
            this.xtraTabPageOracle.Name = "xtraTabPageOracle";
            this.xtraTabPageOracle.Size = new System.Drawing.Size(287, 233);
            this.xtraTabPageOracle.Text = "Oracle";
            // 
            // label_TNS
            // 
            this.label_TNS.AutoSize = true;
            this.label_TNS.Location = new System.Drawing.Point(3, 66);
            this.label_TNS.Name = "label_TNS";
            this.label_TNS.Size = new System.Drawing.Size(29, 13);
            this.label_TNS.TabIndex = 70;
            this.label_TNS.Text = "TNS";
            // 
            // textBox_TNS
            // 
            this.textBox_TNS.Location = new System.Drawing.Point(61, 63);
            this.textBox_TNS.Name = "textBox_TNS";
            this.textBox_TNS.Size = new System.Drawing.Size(203, 20);
            this.textBox_TNS.TabIndex = 69;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(3, 40);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 68;
            this.label_Password.Text = "Password";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(61, 37);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(203, 20);
            this.textBox_Password.TabIndex = 67;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(3, 11);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(29, 13);
            this.label_User.TabIndex = 66;
            this.label_User.Text = "User";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(61, 8);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(203, 20);
            this.textBox_User.TabIndex = 65;
            // 
            // panel_DC
            // 
            this.panel_DC.Controls.Add(this.numericUpDown_Port);
            this.panel_DC.Controls.Add(this.label_SID);
            this.panel_DC.Controls.Add(this.label_Port);
            this.panel_DC.Controls.Add(this.label_Host);
            this.panel_DC.Controls.Add(this.label_Protocol);
            this.panel_DC.Controls.Add(this.textBox_SID);
            this.panel_DC.Controls.Add(this.textBox_Host);
            this.panel_DC.Controls.Add(this.textBox_Protocol);
            this.panel_DC.Enabled = false;
            this.panel_DC.Location = new System.Drawing.Point(3, 112);
            this.panel_DC.Name = "panel_DC";
            this.panel_DC.Size = new System.Drawing.Size(277, 106);
            this.panel_DC.TabIndex = 62;
            // 
            // numericUpDown_Port
            // 
            this.numericUpDown_Port.Location = new System.Drawing.Point(58, 55);
            this.numericUpDown_Port.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_Port.Name = "numericUpDown_Port";
            this.numericUpDown_Port.Size = new System.Drawing.Size(203, 20);
            this.numericUpDown_Port.TabIndex = 30;
            // 
            // label_SID
            // 
            this.label_SID.AutoSize = true;
            this.label_SID.Location = new System.Drawing.Point(0, 84);
            this.label_SID.Name = "label_SID";
            this.label_SID.Size = new System.Drawing.Size(25, 13);
            this.label_SID.TabIndex = 26;
            this.label_SID.Text = "SID";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(0, 57);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(26, 13);
            this.label_Port.TabIndex = 25;
            this.label_Port.Text = "Port";
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Location = new System.Drawing.Point(0, 32);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(29, 13);
            this.label_Host.TabIndex = 24;
            this.label_Host.Text = "Host";
            // 
            // label_Protocol
            // 
            this.label_Protocol.AutoSize = true;
            this.label_Protocol.Location = new System.Drawing.Point(0, 6);
            this.label_Protocol.Name = "label_Protocol";
            this.label_Protocol.Size = new System.Drawing.Size(46, 13);
            this.label_Protocol.TabIndex = 23;
            this.label_Protocol.Text = "Protocol";
            // 
            // textBox_SID
            // 
            this.textBox_SID.Location = new System.Drawing.Point(58, 81);
            this.textBox_SID.Name = "textBox_SID";
            this.textBox_SID.Size = new System.Drawing.Size(203, 20);
            this.textBox_SID.TabIndex = 21;
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(58, 29);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(203, 20);
            this.textBox_Host.TabIndex = 20;
            // 
            // textBox_Protocol
            // 
            this.textBox_Protocol.Location = new System.Drawing.Point(58, 3);
            this.textBox_Protocol.Name = "textBox_Protocol";
            this.textBox_Protocol.Size = new System.Drawing.Size(203, 20);
            this.textBox_Protocol.TabIndex = 19;
            // 
            // checkBox_DC
            // 
            this.checkBox_DC.AutoSize = true;
            this.checkBox_DC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_DC.Location = new System.Drawing.Point(3, 89);
            this.checkBox_DC.Name = "checkBox_DC";
            this.checkBox_DC.Size = new System.Drawing.Size(111, 17);
            this.checkBox_DC.TabIndex = 61;
            this.checkBox_DC.Text = "Direct Connection";
            this.checkBox_DC.UseVisualStyleBackColor = true;
            this.checkBox_DC.CheckedChanged += new System.EventHandler(this.checkBox_DC_CheckedChanged);
            // 
            // xtraTabPageMSSQL
            // 
            this.xtraTabPageMSSQL.Controls.Add(this.label_Password2);
            this.xtraTabPageMSSQL.Controls.Add(this.textBox_Password_MS);
            this.xtraTabPageMSSQL.Controls.Add(this.label_User2);
            this.xtraTabPageMSSQL.Controls.Add(this.textBox_User_MS);
            this.xtraTabPageMSSQL.Controls.Add(this.label_Server);
            this.xtraTabPageMSSQL.Controls.Add(this.textBox_Server_MS);
            this.xtraTabPageMSSQL.Controls.Add(this.checkBox_WinLog_MS);
            this.xtraTabPageMSSQL.Name = "xtraTabPageMSSQL";
            this.xtraTabPageMSSQL.Size = new System.Drawing.Size(287, 233);
            this.xtraTabPageMSSQL.Text = "MSSQL";
            // 
            // label_Password2
            // 
            this.label_Password2.AutoSize = true;
            this.label_Password2.Location = new System.Drawing.Point(3, 40);
            this.label_Password2.Name = "label_Password2";
            this.label_Password2.Size = new System.Drawing.Size(53, 13);
            this.label_Password2.TabIndex = 75;
            this.label_Password2.Text = "Password";
            // 
            // textBox_Password_MS
            // 
            this.textBox_Password_MS.Location = new System.Drawing.Point(61, 37);
            this.textBox_Password_MS.Name = "textBox_Password_MS";
            this.textBox_Password_MS.PasswordChar = '*';
            this.textBox_Password_MS.Size = new System.Drawing.Size(203, 20);
            this.textBox_Password_MS.TabIndex = 74;
            // 
            // label_User2
            // 
            this.label_User2.AutoSize = true;
            this.label_User2.Location = new System.Drawing.Point(3, 11);
            this.label_User2.Name = "label_User2";
            this.label_User2.Size = new System.Drawing.Size(29, 13);
            this.label_User2.TabIndex = 73;
            this.label_User2.Text = "User";
            // 
            // textBox_User_MS
            // 
            this.textBox_User_MS.Location = new System.Drawing.Point(61, 8);
            this.textBox_User_MS.Name = "textBox_User_MS";
            this.textBox_User_MS.Size = new System.Drawing.Size(203, 20);
            this.textBox_User_MS.TabIndex = 72;
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(3, 94);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(38, 13);
            this.label_Server.TabIndex = 71;
            this.label_Server.Text = "Server";
            // 
            // textBox_Server_MS
            // 
            this.textBox_Server_MS.Location = new System.Drawing.Point(61, 91);
            this.textBox_Server_MS.Name = "textBox_Server_MS";
            this.textBox_Server_MS.Size = new System.Drawing.Size(203, 20);
            this.textBox_Server_MS.TabIndex = 70;
            // 
            // checkBox_WinLog_MS
            // 
            this.checkBox_WinLog_MS.AutoSize = true;
            this.checkBox_WinLog_MS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_WinLog_MS.Location = new System.Drawing.Point(3, 68);
            this.checkBox_WinLog_MS.Name = "checkBox_WinLog_MS";
            this.checkBox_WinLog_MS.Size = new System.Drawing.Size(99, 17);
            this.checkBox_WinLog_MS.TabIndex = 69;
            this.checkBox_WinLog_MS.Text = "Windows Login";
            this.checkBox_WinLog_MS.UseVisualStyleBackColor = true;
            this.checkBox_WinLog_MS.CheckedChanged += new System.EventHandler(this.checkBox_WinLog_MS_CheckedChanged);
            // 
            // FrmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 261);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAddConnection";
            this.Text = "New connection";
            this.Shown += new System.EventHandler(this.Frm_AddConnection_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageOracle.ResumeLayout(false);
            this.xtraTabPageOracle.PerformLayout();
            this.panel_DC.ResumeLayout(false);
            this.panel_DC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Port)).EndInit();
            this.xtraTabPageMSSQL.ResumeLayout(false);
            this.xtraTabPageMSSQL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_path;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Name;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageOracle;
        private System.Windows.Forms.Label label_TNS;
        private System.Windows.Forms.TextBox textBox_TNS;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Panel panel_DC;
        private System.Windows.Forms.NumericUpDown numericUpDown_Port;
        private System.Windows.Forms.Label label_SID;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.Label label_Protocol;
        private System.Windows.Forms.TextBox textBox_SID;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.TextBox textBox_Protocol;
        private System.Windows.Forms.CheckBox checkBox_DC;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMSSQL;
        private System.Windows.Forms.Label label_Password2;
        private System.Windows.Forms.TextBox textBox_Password_MS;
        private System.Windows.Forms.Label label_User2;
        private System.Windows.Forms.TextBox textBox_User_MS;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.TextBox textBox_Server_MS;
        private System.Windows.Forms.CheckBox checkBox_WinLog_MS;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}