using System;
using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.button_connect = new DevExpress.XtraEditors.SimpleButton();
            this.label_objectTypes = new DevExpress.XtraEditors.LabelControl();
            this.label_connection = new DevExpress.XtraEditors.LabelControl();
            this.label_objects = new DevExpress.XtraEditors.LabelControl();
            this.button_loadObjects = new DevExpress.XtraEditors.SimpleButton();
            this.button_addFilter = new DevExpress.XtraEditors.SimpleButton();
            this.button_getSource = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button_GetSource_Stop = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.buttonGIT = new DevExpress.XtraEditors.SimpleButton();
            this.button_addDateFilter = new DevExpress.XtraEditors.SimpleButton();
            this.button_currentSchema = new DevExpress.XtraEditors.SimpleButton();
            this.checkedListBox_objects = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.dbObjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new DBSource.DataSet();
            this.checkedListBox_objectTypes = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.dbObjectTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_loadAll = new DevExpress.XtraEditors.SimpleButton();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem_Connection = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem_DevStyle = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_page = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Wiki = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbCh1_SelectAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbCh1_Clear = new DevExpress.XtraBars.BarButtonItem();
            this.bbCh2_SelectAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbCh2_Clear = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.comboBox_Connections = new DevExpress.XtraEditors.ComboBoxEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox_objects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbObjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox_objectTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbObjectTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox_Connections.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Image = global::DBSource.Properties.Resources.icons8_link_32;
            this.button_connect.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_connect.Location = new System.Drawing.Point(221, 46);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(37, 37);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "\r\n";
            this.button_connect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label_objectTypes
            // 
            this.label_objectTypes.Location = new System.Drawing.Point(12, 109);
            this.label_objectTypes.Name = "label_objectTypes";
            this.label_objectTypes.Size = new System.Drawing.Size(68, 13);
            this.label_objectTypes.TabIndex = 35;
            this.label_objectTypes.Text = "Object Types:";
            // 
            // label_connection
            // 
            this.label_connection.Location = new System.Drawing.Point(9, 46);
            this.label_connection.Name = "label_connection";
            this.label_connection.Size = new System.Drawing.Size(58, 13);
            this.label_connection.TabIndex = 39;
            this.label_connection.Text = "Connection:";
            // 
            // label_objects
            // 
            this.label_objects.Location = new System.Drawing.Point(323, 109);
            this.label_objects.Name = "label_objects";
            this.label_objects.Size = new System.Drawing.Size(41, 13);
            this.label_objects.TabIndex = 42;
            this.label_objects.Text = "Objects:";
            // 
            // button_loadObjects
            // 
            this.button_loadObjects.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_loadObjects.Enabled = false;
            this.button_loadObjects.Image = ((System.Drawing.Image)(resources.GetObject("button_loadObjects.Image")));
            this.button_loadObjects.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_loadObjects.Location = new System.Drawing.Point(254, 324);
            this.button_loadObjects.Name = "button_loadObjects";
            this.button_loadObjects.Size = new System.Drawing.Size(66, 30);
            this.button_loadObjects.TabIndex = 43;
            this.button_loadObjects.Click += new System.EventHandler(this.button_loadObjects_Click);
            // 
            // button_addFilter
            // 
            this.button_addFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_addFilter.Appearance.BackColor = System.Drawing.Color.LightGreen;
            this.button_addFilter.Appearance.Options.UseBackColor = true;
            this.button_addFilter.Image = ((System.Drawing.Image)(resources.GetObject("button_addFilter.Image")));
            this.button_addFilter.Location = new System.Drawing.Point(290, 288);
            this.button_addFilter.Name = "button_addFilter";
            this.button_addFilter.Size = new System.Drawing.Size(30, 30);
            this.button_addFilter.TabIndex = 44;
            this.button_addFilter.Click += new System.EventHandler(this.button_addFilter_Click);
            // 
            // button_getSource
            // 
            this.button_getSource.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_getSource.Appearance.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_getSource.Appearance.Options.UseFont = true;
            this.button_getSource.Enabled = false;
            this.button_getSource.Image = ((System.Drawing.Image)(resources.GetObject("button_getSource.Image")));
            this.button_getSource.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_getSource.Location = new System.Drawing.Point(722, 255);
            this.button_getSource.Name = "button_getSource";
            this.button_getSource.Size = new System.Drawing.Size(66, 28);
            this.button_getSource.TabIndex = 47;
            this.button_getSource.Click += new System.EventHandler(this.button_getSource_Click);
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
            this.button_GetSource_Stop.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_GetSource_Stop.Enabled = false;
            this.button_GetSource_Stop.Image = ((System.Drawing.Image)(resources.GetObject("button_GetSource_Stop.Image")));
            this.button_GetSource_Stop.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_GetSource_Stop.Location = new System.Drawing.Point(722, 289);
            this.button_GetSource_Stop.Name = "button_GetSource_Stop";
            this.button_GetSource_Stop.Size = new System.Drawing.Size(66, 28);
            this.button_GetSource_Stop.TabIndex = 52;
            this.button_GetSource_Stop.Click += new System.EventHandler(this.button_GetSource_Stop_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // buttonGIT
            // 
            this.buttonGIT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonGIT.Location = new System.Drawing.Point(722, 490);
            this.buttonGIT.Name = "buttonGIT";
            this.buttonGIT.Size = new System.Drawing.Size(66, 23);
            this.buttonGIT.TabIndex = 53;
            this.buttonGIT.Text = "GIT Commit";
            this.buttonGIT.Visible = false;
            this.buttonGIT.Click += new System.EventHandler(this.buttonGIT_Click);
            // 
            // button_addDateFilter
            // 
            this.button_addDateFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_addDateFilter.Appearance.BackColor = System.Drawing.Color.LightGreen;
            this.button_addDateFilter.Appearance.Options.UseBackColor = true;
            this.button_addDateFilter.Image = ((System.Drawing.Image)(resources.GetObject("button_addDateFilter.Image")));
            this.button_addDateFilter.Location = new System.Drawing.Point(254, 288);
            this.button_addDateFilter.Name = "button_addDateFilter";
            this.button_addDateFilter.Size = new System.Drawing.Size(30, 30);
            this.button_addDateFilter.TabIndex = 54;
            this.button_addDateFilter.Click += new System.EventHandler(this.button_addDateFilter_Click);
            // 
            // button_currentSchema
            // 
            this.button_currentSchema.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_currentSchema.Appearance.BackColor = System.Drawing.Color.LightGreen;
            this.button_currentSchema.Appearance.Options.UseBackColor = true;
            this.button_currentSchema.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.button_currentSchema.Image = ((System.Drawing.Image)(resources.GetObject("button_currentSchema.Image")));
            this.button_currentSchema.Location = new System.Drawing.Point(290, 252);
            this.button_currentSchema.Name = "button_currentSchema";
            this.button_currentSchema.Size = new System.Drawing.Size(30, 30);
            this.button_currentSchema.TabIndex = 55;
            this.button_currentSchema.Click += new System.EventHandler(this.button_currentSchema_Click);
            // 
            // checkedListBox_objects
            // 
            this.checkedListBox_objects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox_objects.CheckOnClick = true;
            this.checkedListBox_objects.DataSource = this.dbObjectsBindingSource;
            this.checkedListBox_objects.DisplayMember = "NAME";
            this.checkedListBox_objects.Location = new System.Drawing.Point(326, 125);
            this.checkedListBox_objects.Name = "checkedListBox_objects";
            this.checkedListBox_objects.Size = new System.Drawing.Size(390, 388);
            this.checkedListBox_objects.TabIndex = 56;
            this.checkedListBox_objects.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_objects_MouseDown);
            // 
            // dbObjectsBindingSource
            // 
            this.dbObjectsBindingSource.DataMember = "DbObjects";
            this.dbObjectsBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkedListBox_objectTypes
            // 
            this.checkedListBox_objectTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox_objectTypes.CheckOnClick = true;
            this.checkedListBox_objectTypes.DataSource = this.dbObjectTypesBindingSource;
            this.checkedListBox_objectTypes.DisplayMember = "NAME";
            this.checkedListBox_objectTypes.Location = new System.Drawing.Point(15, 125);
            this.checkedListBox_objectTypes.Name = "checkedListBox_objectTypes";
            this.checkedListBox_objectTypes.Size = new System.Drawing.Size(233, 388);
            this.checkedListBox_objectTypes.TabIndex = 57;
            this.checkedListBox_objectTypes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_objectTypes_MouseDown);
            // 
            // dbObjectTypesBindingSource
            // 
            this.dbObjectTypesBindingSource.DataMember = "DbObjectTypes";
            this.dbObjectTypesBindingSource.DataSource = this.dataSet;
            // 
            // button_loadAll
            // 
            this.button_loadAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_loadAll.Appearance.BackColor = System.Drawing.Color.LightGreen;
            this.button_loadAll.Appearance.Options.UseBackColor = true;
            this.button_loadAll.Image = global::DBSource.Properties.Resources.icons8_check_all_30;
            this.button_loadAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_loadAll.Location = new System.Drawing.Point(254, 252);
            this.button_loadAll.Name = "button_loadAll";
            this.button_loadAll.Size = new System.Drawing.Size(30, 30);
            this.button_loadAll.TabIndex = 59;
            this.button_loadAll.Click += new System.EventHandler(this.button_loadAll_Click);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem_Connection,
            this.barButtonItem_Add,
            this.barButtonItem_Edit,
            this.barButtonItem_Delete,
            this.barSubItem1,
            this.barSubItem_DevStyle,
            this.barSubItem2,
            this.barButtonItem_page,
            this.barButtonItem_Wiki,
            this.barButtonItem1,
            this.bbCh1_SelectAll,
            this.bbCh1_Clear,
            this.bbCh2_SelectAll,
            this.bbCh2_Clear,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 17;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_Connection),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem_Connection
            // 
            this.barSubItem_Connection.Caption = "Connection";
            this.barSubItem_Connection.Id = 1;
            this.barSubItem_Connection.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Edit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Delete)});
            this.barSubItem_Connection.Name = "barSubItem_Connection";
            // 
            // barButtonItem_Add
            // 
            this.barButtonItem_Add.Caption = "Add";
            this.barButtonItem_Add.Id = 2;
            this.barButtonItem_Add.Name = "barButtonItem_Add";
            this.barButtonItem_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Add_ItemClick);
            // 
            // barButtonItem_Edit
            // 
            this.barButtonItem_Edit.Caption = "Edit";
            this.barButtonItem_Edit.Id = 3;
            this.barButtonItem_Edit.Name = "barButtonItem_Edit";
            this.barButtonItem_Edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Edit_ItemClick);
            // 
            // barButtonItem_Delete
            // 
            this.barButtonItem_Delete.Caption = "Delete";
            this.barButtonItem_Delete.Id = 4;
            this.barButtonItem_Delete.Name = "barButtonItem_Delete";
            this.barButtonItem_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Delete_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Settings";
            this.barSubItem1.Id = 5;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_DevStyle)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem_DevStyle
            // 
            this.barSubItem_DevStyle.Caption = "Style";
            this.barSubItem_DevStyle.Id = 6;
            this.barSubItem_DevStyle.Name = "barSubItem_DevStyle";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "About";
            this.barSubItem2.Id = 7;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_page),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Wiki)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem_page
            // 
            this.barButtonItem_page.Caption = "Project Page";
            this.barButtonItem_page.Id = 8;
            this.barButtonItem_page.Name = "barButtonItem_page";
            this.barButtonItem_page.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_page_ItemClick);
            // 
            // barButtonItem_Wiki
            // 
            this.barButtonItem_Wiki.Caption = "Manual";
            this.barButtonItem_Wiki.Id = 9;
            this.barButtonItem_Wiki.Name = "barButtonItem_Wiki";
            this.barButtonItem_Wiki.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Wiki_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(800, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 527);
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 505);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 505);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bbCh1_SelectAll
            // 
            this.bbCh1_SelectAll.Caption = "Select all";
            this.bbCh1_SelectAll.Id = 11;
            this.bbCh1_SelectAll.Name = "bbCh1_SelectAll";
            this.bbCh1_SelectAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCh1_SelectAll_ItemClick);
            // 
            // bbCh1_Clear
            // 
            this.bbCh1_Clear.Caption = "Clear";
            this.bbCh1_Clear.Id = 12;
            this.bbCh1_Clear.Name = "bbCh1_Clear";
            this.bbCh1_Clear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCh1_Clear_ItemClick);
            // 
            // bbCh2_SelectAll
            // 
            this.bbCh2_SelectAll.Caption = "Select all";
            this.bbCh2_SelectAll.Id = 13;
            this.bbCh2_SelectAll.Name = "bbCh2_SelectAll";
            this.bbCh2_SelectAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCh2_SelectAll_ItemClick);
            // 
            // bbCh2_Clear
            // 
            this.bbCh2_Clear.Caption = "Clear";
            this.bbCh2_Clear.Id = 14;
            this.bbCh2_Clear.Name = "bbCh2_Clear";
            this.bbCh2_Clear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCh2_Clear_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Select all";
            this.barButtonItem2.Id = 15;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCh2_SelectAll_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Clear";
            this.barButtonItem3.Id = 16;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCh2_Clear_ItemClick);
            // 
            // comboBox_Connections
            // 
            this.comboBox_Connections.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_Connections.Location = new System.Drawing.Point(9, 65);
            this.comboBox_Connections.MenuManager = this.barManager1;
            this.comboBox_Connections.Name = "comboBox_Connections";
            this.comboBox_Connections.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox_Connections.Size = new System.Drawing.Size(194, 20);
            this.comboBox_Connections.TabIndex = 69;
            this.comboBox_Connections.SelectedIndexChanged += new System.EventHandler(this.comboBox_Connections_SelectedIndexChanged);
            this.comboBox_Connections.Leave += new System.EventHandler(this.comboBox_Connections_Leave);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCh1_SelectAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCh1_Clear)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.popupMenu2.Manager = this.barManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.comboBox_Connections);
            this.Controls.Add(this.button_loadAll);
            this.Controls.Add(this.checkedListBox_objectTypes);
            this.Controls.Add(this.checkedListBox_objects);
            this.Controls.Add(this.button_currentSchema);
            this.Controls.Add(this.button_addDateFilter);
            this.Controls.Add(this.buttonGIT);
            this.Controls.Add(this.button_GetSource_Stop);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_getSource);
            this.Controls.Add(this.button_addFilter);
            this.Controls.Add(this.button_loadObjects);
            this.Controls.Add(this.label_objects);
            this.Controls.Add(this.label_connection);
            this.Controls.Add(this.label_objectTypes);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 588);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBSource";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox_objects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbObjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox_objectTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbObjectTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox_Connections.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton button_connect;
        private DevExpress.XtraEditors.LabelControl label_objectTypes;
        private DevExpress.XtraEditors.LabelControl label_connection;
        private DevExpress.XtraEditors.LabelControl label_objects;
        private DevExpress.XtraEditors.SimpleButton button_loadObjects;
        private DevExpress.XtraEditors.SimpleButton button_addFilter;
        private DevExpress.XtraEditors.SimpleButton button_getSource;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton button_GetSource_Stop;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private DevExpress.XtraEditors.SimpleButton buttonGIT;
        private DevExpress.XtraEditors.SimpleButton button_addDateFilter;
        private DevExpress.XtraEditors.SimpleButton button_currentSchema;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBox_objects;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBox_objectTypes;
        private System.Windows.Forms.BindingSource dbObjectsBindingSource;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource dbObjectTypesBindingSource;
        private DevExpress.XtraEditors.SimpleButton button_loadAll;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem_Connection;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Edit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Delete;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem_DevStyle;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_page;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Wiki;
        private DevExpress.XtraEditors.ComboBoxEdit comboBox_Connections;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem bbCh1_SelectAll;
        private DevExpress.XtraBars.BarButtonItem bbCh1_Clear;
        private DevExpress.XtraBars.BarButtonItem bbCh2_SelectAll;
        private DevExpress.XtraBars.BarButtonItem bbCh2_Clear;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}

