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
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.checkBox_DC = new System.Windows.Forms.CheckBox();
            this.panel_DC = new System.Windows.Forms.Panel();
            this.numericUpDown_Port = new System.Windows.Forms.NumericUpDown();
            this.label_SID = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_Host = new System.Windows.Forms.Label();
            this.label_Protocol = new System.Windows.Forms.Label();
            this.textBox_SID = new System.Windows.Forms.TextBox();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.textBox_Protocol = new System.Windows.Forms.TextBox();
            this.label_TNS = new System.Windows.Forms.Label();
            this.textBox_TNS = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_path = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_path = new System.Windows.Forms.Button();
            this.panel_DC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Port)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(197, 47);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(102, 128);
            this.button_Save.TabIndex = 0;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(197, 181);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(102, 46);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(9, 21);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(35, 13);
            this.label_Name.TabIndex = 15;
            this.label_Name.Text = "Name";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(67, 18);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 20);
            this.textBox_Name.TabIndex = 14;
            this.textBox_Name.Text = "Connection";
            // 
            // checkBox_DC
            // 
            this.checkBox_DC.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_DC.AutoSize = true;
            this.checkBox_DC.Location = new System.Drawing.Point(197, 18);
            this.checkBox_DC.Name = "checkBox_DC";
            this.checkBox_DC.Size = new System.Drawing.Size(102, 23);
            this.checkBox_DC.TabIndex = 19;
            this.checkBox_DC.Text = "Direct Connection";
            this.checkBox_DC.UseVisualStyleBackColor = true;
            this.checkBox_DC.CheckedChanged += new System.EventHandler(this.checkBox_DC_CheckedChanged);
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
            this.panel_DC.Location = new System.Drawing.Point(3, 69);
            this.panel_DC.Name = "panel_DC";
            this.panel_DC.Size = new System.Drawing.Size(176, 106);
            this.panel_DC.TabIndex = 20;
            // 
            // numericUpDown_Port
            // 
            this.numericUpDown_Port.Location = new System.Drawing.Point(64, 55);
            this.numericUpDown_Port.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_Port.Name = "numericUpDown_Port";
            this.numericUpDown_Port.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown_Port.TabIndex = 30;
            // 
            // label_SID
            // 
            this.label_SID.AutoSize = true;
            this.label_SID.Location = new System.Drawing.Point(6, 84);
            this.label_SID.Name = "label_SID";
            this.label_SID.Size = new System.Drawing.Size(25, 13);
            this.label_SID.TabIndex = 26;
            this.label_SID.Text = "SID";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(6, 58);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(26, 13);
            this.label_Port.TabIndex = 25;
            this.label_Port.Text = "Port";
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Location = new System.Drawing.Point(6, 32);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(29, 13);
            this.label_Host.TabIndex = 24;
            this.label_Host.Text = "Host";
            // 
            // label_Protocol
            // 
            this.label_Protocol.AutoSize = true;
            this.label_Protocol.Location = new System.Drawing.Point(6, 6);
            this.label_Protocol.Name = "label_Protocol";
            this.label_Protocol.Size = new System.Drawing.Size(46, 13);
            this.label_Protocol.TabIndex = 23;
            this.label_Protocol.Text = "Protocol";
            // 
            // textBox_SID
            // 
            this.textBox_SID.Location = new System.Drawing.Point(64, 81);
            this.textBox_SID.Name = "textBox_SID";
            this.textBox_SID.Size = new System.Drawing.Size(100, 20);
            this.textBox_SID.TabIndex = 21;
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(64, 29);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(100, 20);
            this.textBox_Host.TabIndex = 20;
            // 
            // textBox_Protocol
            // 
            this.textBox_Protocol.Location = new System.Drawing.Point(64, 3);
            this.textBox_Protocol.Name = "textBox_Protocol";
            this.textBox_Protocol.Size = new System.Drawing.Size(100, 20);
            this.textBox_Protocol.TabIndex = 19;
            // 
            // label_TNS
            // 
            this.label_TNS.AutoSize = true;
            this.label_TNS.Location = new System.Drawing.Point(9, 47);
            this.label_TNS.Name = "label_TNS";
            this.label_TNS.Size = new System.Drawing.Size(29, 13);
            this.label_TNS.TabIndex = 34;
            this.label_TNS.Text = "TNS";
            // 
            // textBox_TNS
            // 
            this.textBox_TNS.Location = new System.Drawing.Point(67, 44);
            this.textBox_TNS.Name = "textBox_TNS";
            this.textBox_TNS.Size = new System.Drawing.Size(100, 20);
            this.textBox_TNS.TabIndex = 33;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(9, 210);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 38;
            this.label_Password.Text = "Password";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(67, 207);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(100, 20);
            this.textBox_Password.TabIndex = 37;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(9, 184);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(29, 13);
            this.label_User.TabIndex = 36;
            this.label_User.Text = "User";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(67, 181);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(100, 20);
            this.textBox_User.TabIndex = 35;
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(9, 235);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(29, 13);
            this.label_path.TabIndex = 40;
            this.label_path.Text = "Path";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(67, 232);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(214, 20);
            this.textBox_path.TabIndex = 39;
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(276, 231);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(23, 20);
            this.button_path.TabIndex = 41;
            this.button_path.Text = "...";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.button_path_Click);
            // 
            // FrmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 278);
            this.Controls.Add(this.button_path);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label_TNS);
            this.Controls.Add(this.textBox_TNS);
            this.Controls.Add(this.panel_DC);
            this.Controls.Add(this.checkBox_DC);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAddConnection";
            this.Text = "New connection";
            this.Load += new System.EventHandler(this.Frm_AddConnection_Load);
            this.Shown += new System.EventHandler(this.Frm_AddConnection_Shown);
            this.panel_DC.ResumeLayout(false);
            this.panel_DC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.CheckBox checkBox_DC;
        private System.Windows.Forms.Panel panel_DC;
        private System.Windows.Forms.NumericUpDown numericUpDown_Port;
        private System.Windows.Forms.Label label_SID;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.Label label_Protocol;
        private System.Windows.Forms.TextBox textBox_SID;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.TextBox textBox_Protocol;
        private System.Windows.Forms.Label label_TNS;
        private System.Windows.Forms.TextBox textBox_TNS;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_path;
    }
}