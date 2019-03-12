namespace DBSource
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.button_connect = new System.Windows.Forms.Button();
            this.comboBox_Connections = new System.Windows.Forms.ComboBox();
            this.checkedListBox_objectTypes = new System.Windows.Forms.CheckedListBox();
            this.label_objectTypes = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_connection = new System.Windows.Forms.Label();
            this.checkedListBox_objects = new System.Windows.Forms.CheckedListBox();
            this.label_objects = new System.Windows.Forms.Label();
            this.button_loadObjects = new System.Windows.Forms.Button();
            this.button_addFilter = new System.Windows.Forms.Button();
            this.checkBox_currentSchema = new System.Windows.Forms.CheckBox();
            this.checkBox_LoadMode = new System.Windows.Forms.CheckBox();
            this.button_getSource = new System.Windows.Forms.Button();
            this.checkBox_loadAll = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button_GetSource_Stop = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(212, 60);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(194, 23);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_Connections
            // 
            this.comboBox_Connections.Location = new System.Drawing.Point(12, 62);
            this.comboBox_Connections.Name = "comboBox_Connections";
            this.comboBox_Connections.Size = new System.Drawing.Size(194, 21);
            this.comboBox_Connections.TabIndex = 1;
            // 
            // checkedListBox_objectTypes
            // 
            this.checkedListBox_objectTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox_objectTypes.FormattingEnabled = true;
            this.checkedListBox_objectTypes.Location = new System.Drawing.Point(12, 125);
            this.checkedListBox_objectTypes.Name = "checkedListBox_objectTypes";
            this.checkedListBox_objectTypes.Size = new System.Drawing.Size(194, 394);
            this.checkedListBox_objectTypes.TabIndex = 4;
            // 
            // label_objectTypes
            // 
            this.label_objectTypes.AutoSize = true;
            this.label_objectTypes.Location = new System.Drawing.Point(12, 109);
            this.label_objectTypes.Name = "label_objectTypes";
            this.label_objectTypes.Size = new System.Drawing.Size(73, 13);
            this.label_objectTypes.TabIndex = 35;
            this.label_objectTypes.Text = "Object Types:";
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(412, 60);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(194, 23);
            this.button_disconnect.TabIndex = 36;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editExportToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // editExportToolStripMenuItem
            // 
            this.editExportToolStripMenuItem.Name = "editExportToolStripMenuItem";
            this.editExportToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.editExportToolStripMenuItem.Text = "Edit Export";
            // 
            // label_connection
            // 
            this.label_connection.AutoSize = true;
            this.label_connection.Location = new System.Drawing.Point(9, 46);
            this.label_connection.Name = "label_connection";
            this.label_connection.Size = new System.Drawing.Size(64, 13);
            this.label_connection.TabIndex = 39;
            this.label_connection.Text = "Connection:";
            // 
            // checkedListBox_objects
            // 
            this.checkedListBox_objects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox_objects.FormattingEnabled = true;
            this.checkedListBox_objects.Location = new System.Drawing.Point(308, 125);
            this.checkedListBox_objects.Name = "checkedListBox_objects";
            this.checkedListBox_objects.Size = new System.Drawing.Size(348, 394);
            this.checkedListBox_objects.TabIndex = 41;
            // 
            // label_objects
            // 
            this.label_objects.AutoSize = true;
            this.label_objects.Location = new System.Drawing.Point(305, 109);
            this.label_objects.Name = "label_objects";
            this.label_objects.Size = new System.Drawing.Size(46, 13);
            this.label_objects.TabIndex = 42;
            this.label_objects.Text = "Objects:";
            // 
            // button_loadObjects
            // 
            this.button_loadObjects.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_loadObjects.Enabled = false;
            this.button_loadObjects.Location = new System.Drawing.Point(212, 315);
            this.button_loadObjects.Name = "button_loadObjects";
            this.button_loadObjects.Size = new System.Drawing.Size(93, 23);
            this.button_loadObjects.TabIndex = 43;
            this.button_loadObjects.Text = "===>";
            this.button_loadObjects.UseVisualStyleBackColor = true;
            this.button_loadObjects.Click += new System.EventHandler(this.button_loadObjects_Click);
            // 
            // button_addFilter
            // 
            this.button_addFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_addFilter.Location = new System.Drawing.Point(212, 286);
            this.button_addFilter.Name = "button_addFilter";
            this.button_addFilter.Size = new System.Drawing.Size(93, 23);
            this.button_addFilter.TabIndex = 44;
            this.button_addFilter.Text = "Filter";
            this.button_addFilter.UseVisualStyleBackColor = true;
            this.button_addFilter.Click += new System.EventHandler(this.button_addFilter_Click);
            // 
            // checkBox_currentSchema
            // 
            this.checkBox_currentSchema.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_currentSchema.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_currentSchema.AutoSize = true;
            this.checkBox_currentSchema.Checked = true;
            this.checkBox_currentSchema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_currentSchema.Location = new System.Drawing.Point(212, 257);
            this.checkBox_currentSchema.Name = "checkBox_currentSchema";
            this.checkBox_currentSchema.Size = new System.Drawing.Size(93, 23);
            this.checkBox_currentSchema.TabIndex = 45;
            this.checkBox_currentSchema.Text = "Current Schema";
            this.checkBox_currentSchema.UseVisualStyleBackColor = true;
            // 
            // checkBox_LoadMode
            // 
            this.checkBox_LoadMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_LoadMode.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_LoadMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_LoadMode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_LoadMode.Location = new System.Drawing.Point(357, 109);
            this.checkBox_LoadMode.Name = "checkBox_LoadMode";
            this.checkBox_LoadMode.Size = new System.Drawing.Size(299, 17);
            this.checkBox_LoadMode.TabIndex = 46;
            this.checkBox_LoadMode.Text = "L O A D       A L L";
            this.checkBox_LoadMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_LoadMode.UseVisualStyleBackColor = true;
            this.checkBox_LoadMode.CheckedChanged += new System.EventHandler(this.checkBox_LoadMode_CheckedChanged);
            // 
            // button_getSource
            // 
            this.button_getSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_getSource.Enabled = false;
            this.button_getSource.Location = new System.Drawing.Point(662, 228);
            this.button_getSource.Name = "button_getSource";
            this.button_getSource.Size = new System.Drawing.Size(128, 81);
            this.button_getSource.TabIndex = 47;
            this.button_getSource.Text = "Start";
            this.button_getSource.UseVisualStyleBackColor = true;
            this.button_getSource.Click += new System.EventHandler(this.button_getSource_Click);
            // 
            // checkBox_loadAll
            // 
            this.checkBox_loadAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_loadAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_loadAll.AutoSize = true;
            this.checkBox_loadAll.Location = new System.Drawing.Point(212, 228);
            this.checkBox_loadAll.Name = "checkBox_loadAll";
            this.checkBox_loadAll.Size = new System.Drawing.Size(94, 23);
            this.checkBox_loadAll.TabIndex = 49;
            this.checkBox_loadAll.Text = "     All Objects    ";
            this.checkBox_loadAll.UseVisualStyleBackColor = true;
            this.checkBox_loadAll.CheckedChanged += new System.EventHandler(this.checkBox_loadAll_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::DBSource.Properties.Resources.temabit;
            this.pictureBox2.Location = new System.Drawing.Point(654, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(146, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button_GetSource_Stop
            // 
            this.button_GetSource_Stop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_GetSource_Stop.Enabled = false;
            this.button_GetSource_Stop.Location = new System.Drawing.Point(662, 315);
            this.button_GetSource_Stop.Name = "button_GetSource_Stop";
            this.button_GetSource_Stop.Size = new System.Drawing.Size(128, 25);
            this.button_GetSource_Stop.TabIndex = 52;
            this.button_GetSource_Stop.Text = "Stop";
            this.button_GetSource_Stop.UseVisualStyleBackColor = true;
            this.button_GetSource_Stop.Click += new System.EventHandler(this.button_GetSource_Stop_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.button_GetSource_Stop);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.checkBox_loadAll);
            this.Controls.Add(this.button_getSource);
            this.Controls.Add(this.checkBox_LoadMode);
            this.Controls.Add(this.checkBox_currentSchema);
            this.Controls.Add(this.button_addFilter);
            this.Controls.Add(this.button_loadObjects);
            this.Controls.Add(this.label_objects);
            this.Controls.Add(this.checkedListBox_objects);
            this.Controls.Add(this.label_connection);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label_objectTypes);
            this.Controls.Add(this.checkedListBox_objectTypes);
            this.Controls.Add(this.comboBox_Connections);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "DBSource";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.ComboBox comboBox_Connections;
        private System.Windows.Forms.CheckedListBox checkedListBox_objectTypes;
        private System.Windows.Forms.Label label_objectTypes;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label_connection;
        private System.Windows.Forms.CheckedListBox checkedListBox_objects;
        private System.Windows.Forms.Label label_objects;
        private System.Windows.Forms.Button button_loadObjects;
        private System.Windows.Forms.Button button_addFilter;
        private System.Windows.Forms.CheckBox checkBox_currentSchema;
        private System.Windows.Forms.CheckBox checkBox_LoadMode;
        private System.Windows.Forms.Button button_getSource;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExportToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_loadAll;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button_GetSource_Stop;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

