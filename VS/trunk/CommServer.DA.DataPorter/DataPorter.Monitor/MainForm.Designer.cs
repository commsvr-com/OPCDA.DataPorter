//<summary>
//  Title   : CAS DstaPorter Monitor MainForm (designer)
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

namespace CAS.DataPorter.Monitor
{
  /// <summary>
  /// Main form for DataPorter
  /// </summary>
  public partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region IDisposable
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      try
      {
        this.m_Trayicon.Visible = false;
        if ( disposing )
          if ( components != null )
            components.Dispose();
        base.Dispose( disposing );
      }
      catch ( System.Exception )
      {
        System.Windows.Forms.MessageBox.Show( "Problem with Finalise" );
      }
      System.Windows.Forms.Application.Exit();
    }
    #endregion

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
      this.tabControlInterface = new System.Windows.Forms.TabControl();
      this.tabOPCClient = new System.Windows.Forms.TabPage();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label_cli_overtime = new System.Windows.Forms.Label();
      this.label_overtime = new System.Windows.Forms.Label();
      this.label_cli_connect_disco_time = new System.Windows.Forms.Label();
      this.label29 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.OPCSrvUrl = new System.Windows.Forms.Label();
      this.OPCNumberOfWiteSuccesseslabel = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.OPCNumberOfRegisteredTagsLabe = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.OPCNumberOfReadFailsLabel = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.OPCNumberOfWiteFailsLabel = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.OPCNumberOfReadSuccessesLabel = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.OPCNumberOfRegisteredGroupslabel = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.OPCStateLabel = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.OPCtimeStartLabel = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.OPCtxtServerInfoLabel = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.OPCClientNameLabel = new System.Windows.Forms.Label();
      this.listViewOPCClient = new System.Windows.Forms.ListView();
      this.columnHeaderServers = new System.Windows.Forms.ColumnHeader();
      this.imageListStationIcons = new System.Windows.Forms.ImageList( this.components );
      this.tabPage_groups = new System.Windows.Forms.TabPage();
      this.listView_group = new System.Windows.Forms.ListView();
      this.columnHeaderGroup = new System.Windows.Forms.ColumnHeader();
      this.imageListGroups = new System.Windows.Forms.ImageList( this.components );
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label_gr_minavgmax_readtime = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label_groupdetails = new System.Windows.Forms.Label();
      this.label_gr_writesucc = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label_gr_registeredtags = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label_gr_readnotsucc = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label_gr_writenotsucc = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.label_gr_readsucc = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.label_gr_activetime = new System.Windows.Forms.Label();
      this.label30 = new System.Windows.Forms.Label();
      this.label32 = new System.Windows.Forms.Label();
      this.label_groupname = new System.Windows.Forms.Label();
      this.tabItems = new System.Windows.Forms.TabPage();
      this.listView_items = new System.Windows.Forms.ListView();
      this.columnHeaderItem = new System.Windows.Forms.ColumnHeader();
      this.ImageListItems = new System.Windows.Forms.ImageList( this.components );
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label_item_lasterror = new System.Windows.Forms.Label();
      this.label27 = new System.Windows.Forms.Label();
      this.label_item_minavrmax = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label_item_detail = new System.Windows.Forms.Label();
      this.label_item_wr_succ = new System.Windows.Forms.Label();
      this.label25 = new System.Windows.Forms.Label();
      this.label_item_state = new System.Windows.Forms.Label();
      this.label28 = new System.Windows.Forms.Label();
      this.label_item_read_fail = new System.Windows.Forms.Label();
      this.label33 = new System.Windows.Forms.Label();
      this.label_item_wr_fail = new System.Windows.Forms.Label();
      this.label35 = new System.Windows.Forms.Label();
      this.label_item_read_succ = new System.Windows.Forms.Label();
      this.label37 = new System.Windows.Forms.Label();
      this.label_item_value = new System.Windows.Forms.Label();
      this.label39 = new System.Windows.Forms.Label();
      this.label_item_activtime = new System.Windows.Forms.Label();
      this.label41 = new System.Windows.Forms.Label();
      this.label42 = new System.Windows.Forms.Label();
      this.label_item_name = new System.Windows.Forms.Label();
      this.tabTransactions = new System.Windows.Forms.TabPage();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.label_tr_minavmax = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.label_tr_details = new System.Windows.Forms.Label();
      this.label_tr_deadband = new System.Windows.Forms.Label();
      this.label34 = new System.Windows.Forms.Label();
      this.label_tr_scanrate = new System.Windows.Forms.Label();
      this.label38 = new System.Windows.Forms.Label();
      this.label_tr_updaterate = new System.Windows.Forms.Label();
      this.label45 = new System.Windows.Forms.Label();
      this.label_tr_counter = new System.Windows.Forms.Label();
      this.label51 = new System.Windows.Forms.Label();
      this.label52 = new System.Windows.Forms.Label();
      this.label_tr_name = new System.Windows.Forms.Label();
      this.listView_transactions = new System.Windows.Forms.ListView();
      this.columnHeaderTransactions = new System.Windows.Forms.ColumnHeader();
      this.imageListTransactions = new System.Windows.Forms.ImageList( this.components );
      this.labelTestTimeLab = new System.Windows.Forms.Label();
      this.labelTestTime = new System.Windows.Forms.Label();
      this.m_Trayicon = new System.Windows.Forms.NotifyIcon( this.components );
      this.tray_menu = new System.Windows.Forms.ContextMenu();
      this.toolTip_main = new System.Windows.Forms.ToolTip( this.components );
      this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
      this.menuItem_monitor = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItem_MenuHide = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItem_MenuConfigurator = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItem_MenuReport = new System.Windows.Forms.ToolStripMenuItem();
      this.serviceConfiguratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dCOMConfiguratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItem_helpmain = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItem_help = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.menuItem_about = new System.Windows.Forms.ToolStripMenuItem();
      this.licenseInfomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openLogContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.enterTheUnlockCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.RefreshFormTimer = new System.Windows.Forms.Timer( this.components );
      this.groupBox_connection = new System.Windows.Forms.GroupBox();
      this.groupBox_connectedTo = new System.Windows.Forms.GroupBox();
      this.textBox_conected_to_version = new System.Windows.Forms.TextBox();
      this.textBox_connected_to_name = new System.Windows.Forms.TextBox();
      this.textBox_connected_to_url = new System.Windows.Forms.TextBox();
      this.button_ShutDown = new System.Windows.Forms.Button();
      this.textBox_port = new System.Windows.Forms.TextBox();
      this.textBox_Host = new System.Windows.Forms.TextBox();
      this.label_colon = new System.Windows.Forms.Label();
      this.label_hostport = new System.Windows.Forms.Label();
      this.button_ConnectDisconnect = new System.Windows.Forms.Button();
      this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel_connected_disconnected = new System.Windows.Forms.ToolStripStatusLabel();
      this.serviceControlToolStrip1 = new CAS.Lib.ControlLibrary.ServiceControlToolStrip();
      this.tabControlInterface.SuspendLayout();
      this.tabOPCClient.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabPage_groups.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabItems.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.tabTransactions.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.mainMenuStrip.SuspendLayout();
      this.groupBox_connection.SuspendLayout();
      this.groupBox_connectedTo.SuspendLayout();
      this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControlInterface
      // 
      this.tabControlInterface.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.tabControlInterface.Controls.Add( this.tabOPCClient );
      this.tabControlInterface.Controls.Add( this.tabPage_groups );
      this.tabControlInterface.Controls.Add( this.tabItems );
      this.tabControlInterface.Controls.Add( this.tabTransactions );
      this.tabControlInterface.Location = new System.Drawing.Point( 19, 130 );
      this.tabControlInterface.Multiline = true;
      this.tabControlInterface.Name = "tabControlInterface";
      this.tabControlInterface.SelectedIndex = 0;
      this.tabControlInterface.Size = new System.Drawing.Size( 683, 414 );
      this.tabControlInterface.TabIndex = 0;
      // 
      // tabOPCClient
      // 
      this.tabOPCClient.Controls.Add( this.groupBox3 );
      this.tabOPCClient.Controls.Add( this.listViewOPCClient );
      this.tabOPCClient.Location = new System.Drawing.Point( 4, 22 );
      this.tabOPCClient.Name = "tabOPCClient";
      this.tabOPCClient.Size = new System.Drawing.Size( 675, 388 );
      this.tabOPCClient.TabIndex = 4;
      this.tabOPCClient.Text = "OPC Client";
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.groupBox3.Controls.Add( this.label_cli_overtime );
      this.groupBox3.Controls.Add( this.label_overtime );
      this.groupBox3.Controls.Add( this.label_cli_connect_disco_time );
      this.groupBox3.Controls.Add( this.label29 );
      this.groupBox3.Controls.Add( this.label1 );
      this.groupBox3.Controls.Add( this.OPCSrvUrl );
      this.groupBox3.Controls.Add( this.OPCNumberOfWiteSuccesseslabel );
      this.groupBox3.Controls.Add( this.label3 );
      this.groupBox3.Controls.Add( this.OPCNumberOfRegisteredTagsLabe );
      this.groupBox3.Controls.Add( this.label5 );
      this.groupBox3.Controls.Add( this.OPCNumberOfReadFailsLabel );
      this.groupBox3.Controls.Add( this.label7 );
      this.groupBox3.Controls.Add( this.OPCNumberOfWiteFailsLabel );
      this.groupBox3.Controls.Add( this.label9 );
      this.groupBox3.Controls.Add( this.OPCNumberOfReadSuccessesLabel );
      this.groupBox3.Controls.Add( this.label11 );
      this.groupBox3.Controls.Add( this.OPCNumberOfRegisteredGroupslabel );
      this.groupBox3.Controls.Add( this.label13 );
      this.groupBox3.Controls.Add( this.OPCStateLabel );
      this.groupBox3.Controls.Add( this.label15 );
      this.groupBox3.Controls.Add( this.OPCtimeStartLabel );
      this.groupBox3.Controls.Add( this.label17 );
      this.groupBox3.Controls.Add( this.OPCtxtServerInfoLabel );
      this.groupBox3.Controls.Add( this.label19 );
      this.groupBox3.Controls.Add( this.label20 );
      this.groupBox3.Controls.Add( this.OPCClientNameLabel );
      this.groupBox3.Location = new System.Drawing.Point( 200, 8 );
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size( 459, 374 );
      this.groupBox3.TabIndex = 61;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "OPC statistics";
      // 
      // label_cli_overtime
      // 
      this.label_cli_overtime.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_cli_overtime.BackColor = System.Drawing.SystemColors.Info;
      this.label_cli_overtime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_cli_overtime.Location = new System.Drawing.Point( 128, 223 );
      this.label_cli_overtime.Name = "label_cli_overtime";
      this.label_cli_overtime.Size = new System.Drawing.Size( 323, 16 );
      this.label_cli_overtime.TabIndex = 81;
      this.label_cli_overtime.Text = "----";
      this.label_cli_overtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label_overtime
      // 
      this.label_overtime.Location = new System.Drawing.Point( 8, 215 );
      this.label_overtime.Name = "label_overtime";
      this.label_overtime.Size = new System.Drawing.Size( 112, 32 );
      this.label_overtime.TabIndex = 80;
      this.label_overtime.Text = "Max priority in queue (Min/Avg/Max)";
      this.label_overtime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_cli_connect_disco_time
      // 
      this.label_cli_connect_disco_time.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_cli_connect_disco_time.BackColor = System.Drawing.SystemColors.Info;
      this.label_cli_connect_disco_time.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_cli_connect_disco_time.Location = new System.Drawing.Point( 128, 192 );
      this.label_cli_connect_disco_time.Name = "label_cli_connect_disco_time";
      this.label_cli_connect_disco_time.Size = new System.Drawing.Size( 323, 16 );
      this.label_cli_connect_disco_time.TabIndex = 79;
      this.label_cli_connect_disco_time.Text = "----";
      this.label_cli_connect_disco_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label29
      // 
      this.label29.Location = new System.Drawing.Point( 8, 184 );
      this.label29.Name = "label29";
      this.label29.Size = new System.Drawing.Size( 112, 32 );
      this.label29.TabIndex = 78;
      this.label29.Text = "Connect/Disconnect time[s]";
      this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point( 8, 64 );
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size( 104, 16 );
      this.label1.TabIndex = 76;
      this.label1.Text = "Server url";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCSrvUrl
      // 
      this.OPCSrvUrl.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.OPCSrvUrl.BackColor = System.Drawing.SystemColors.Info;
      this.OPCSrvUrl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCSrvUrl.Location = new System.Drawing.Point( 128, 56 );
      this.OPCSrvUrl.Name = "OPCSrvUrl";
      this.OPCSrvUrl.Size = new System.Drawing.Size( 323, 32 );
      this.OPCSrvUrl.TabIndex = 77;
      this.OPCSrvUrl.Text = "-----";
      this.OPCSrvUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // OPCNumberOfWiteSuccesseslabel
      // 
      this.OPCNumberOfWiteSuccesseslabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCNumberOfWiteSuccesseslabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCNumberOfWiteSuccesseslabel.Location = new System.Drawing.Point( 127, 291 );
      this.OPCNumberOfWiteSuccesseslabel.Name = "OPCNumberOfWiteSuccesseslabel";
      this.OPCNumberOfWiteSuccesseslabel.Size = new System.Drawing.Size( 104, 16 );
      this.OPCNumberOfWiteSuccesseslabel.TabIndex = 75;
      this.OPCNumberOfWiteSuccesseslabel.Text = "----";
      this.OPCNumberOfWiteSuccesseslabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point( 15, 291 );
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size( 104, 16 );
      this.label3.TabIndex = 74;
      this.label3.Text = "Wite successes";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCNumberOfRegisteredTagsLabe
      // 
      this.OPCNumberOfRegisteredTagsLabe.BackColor = System.Drawing.SystemColors.Info;
      this.OPCNumberOfRegisteredTagsLabe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCNumberOfRegisteredTagsLabe.Location = new System.Drawing.Point( 350, 258 );
      this.OPCNumberOfRegisteredTagsLabe.Name = "OPCNumberOfRegisteredTagsLabe";
      this.OPCNumberOfRegisteredTagsLabe.Size = new System.Drawing.Size( 104, 16 );
      this.OPCNumberOfRegisteredTagsLabe.TabIndex = 73;
      this.OPCNumberOfRegisteredTagsLabe.Text = "----";
      this.OPCNumberOfRegisteredTagsLabe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point( 238, 258 );
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size( 104, 16 );
      this.label5.TabIndex = 72;
      this.label5.Text = "Registered tags";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCNumberOfReadFailsLabel
      // 
      this.OPCNumberOfReadFailsLabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCNumberOfReadFailsLabel.ForeColor = System.Drawing.Color.Red;
      this.OPCNumberOfReadFailsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCNumberOfReadFailsLabel.Location = new System.Drawing.Point( 349, 315 );
      this.OPCNumberOfReadFailsLabel.Name = "OPCNumberOfReadFailsLabel";
      this.OPCNumberOfReadFailsLabel.Size = new System.Drawing.Size( 104, 16 );
      this.OPCNumberOfReadFailsLabel.TabIndex = 71;
      this.OPCNumberOfReadFailsLabel.Text = "----";
      this.OPCNumberOfReadFailsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label7
      // 
      this.label7.ForeColor = System.Drawing.Color.Red;
      this.label7.Location = new System.Drawing.Point( 237, 315 );
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size( 104, 16 );
      this.label7.TabIndex = 70;
      this.label7.Text = "Read fails";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCNumberOfWiteFailsLabel
      // 
      this.OPCNumberOfWiteFailsLabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCNumberOfWiteFailsLabel.ForeColor = System.Drawing.Color.Red;
      this.OPCNumberOfWiteFailsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCNumberOfWiteFailsLabel.Location = new System.Drawing.Point( 127, 315 );
      this.OPCNumberOfWiteFailsLabel.Name = "OPCNumberOfWiteFailsLabel";
      this.OPCNumberOfWiteFailsLabel.Size = new System.Drawing.Size( 104, 16 );
      this.OPCNumberOfWiteFailsLabel.TabIndex = 69;
      this.OPCNumberOfWiteFailsLabel.Text = "----";
      this.OPCNumberOfWiteFailsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label9
      // 
      this.label9.ForeColor = System.Drawing.Color.Red;
      this.label9.Location = new System.Drawing.Point( 15, 315 );
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size( 104, 16 );
      this.label9.TabIndex = 68;
      this.label9.Text = "Write fails";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCNumberOfReadSuccessesLabel
      // 
      this.OPCNumberOfReadSuccessesLabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCNumberOfReadSuccessesLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCNumberOfReadSuccessesLabel.Location = new System.Drawing.Point( 349, 291 );
      this.OPCNumberOfReadSuccessesLabel.Name = "OPCNumberOfReadSuccessesLabel";
      this.OPCNumberOfReadSuccessesLabel.Size = new System.Drawing.Size( 104, 16 );
      this.OPCNumberOfReadSuccessesLabel.TabIndex = 67;
      this.OPCNumberOfReadSuccessesLabel.Text = "----";
      this.OPCNumberOfReadSuccessesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label11
      // 
      this.label11.Location = new System.Drawing.Point( 237, 291 );
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size( 104, 16 );
      this.label11.TabIndex = 66;
      this.label11.Text = "Read successes";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCNumberOfRegisteredGroupslabel
      // 
      this.OPCNumberOfRegisteredGroupslabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCNumberOfRegisteredGroupslabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCNumberOfRegisteredGroupslabel.Location = new System.Drawing.Point( 127, 258 );
      this.OPCNumberOfRegisteredGroupslabel.Name = "OPCNumberOfRegisteredGroupslabel";
      this.OPCNumberOfRegisteredGroupslabel.Size = new System.Drawing.Size( 104, 16 );
      this.OPCNumberOfRegisteredGroupslabel.TabIndex = 65;
      this.OPCNumberOfRegisteredGroupslabel.Text = "----";
      this.OPCNumberOfRegisteredGroupslabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point( 15, 258 );
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size( 104, 16 );
      this.label13.TabIndex = 64;
      this.label13.Text = "Registered groups";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCStateLabel
      // 
      this.OPCStateLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.OPCStateLabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCStateLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCStateLabel.Location = new System.Drawing.Point( 128, 160 );
      this.OPCStateLabel.Name = "OPCStateLabel";
      this.OPCStateLabel.Size = new System.Drawing.Size( 323, 16 );
      this.OPCStateLabel.TabIndex = 63;
      this.OPCStateLabel.Text = "----";
      this.OPCStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label15
      // 
      this.label15.Location = new System.Drawing.Point( 8, 160 );
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size( 104, 16 );
      this.label15.TabIndex = 62;
      this.label15.Text = "Server state";
      this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCtimeStartLabel
      // 
      this.OPCtimeStartLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.OPCtimeStartLabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCtimeStartLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCtimeStartLabel.Location = new System.Drawing.Point( 128, 136 );
      this.OPCtimeStartLabel.Name = "OPCtimeStartLabel";
      this.OPCtimeStartLabel.Size = new System.Drawing.Size( 323, 16 );
      this.OPCtimeStartLabel.TabIndex = 61;
      this.OPCtimeStartLabel.Text = "----";
      this.OPCtimeStartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label17
      // 
      this.label17.Location = new System.Drawing.Point( 8, 136 );
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size( 104, 16 );
      this.label17.TabIndex = 60;
      this.label17.Text = "Server time start";
      this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCtxtServerInfoLabel
      // 
      this.OPCtxtServerInfoLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.OPCtxtServerInfoLabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCtxtServerInfoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCtxtServerInfoLabel.Location = new System.Drawing.Point( 128, 96 );
      this.OPCtxtServerInfoLabel.Name = "OPCtxtServerInfoLabel";
      this.OPCtxtServerInfoLabel.Size = new System.Drawing.Size( 323, 32 );
      this.OPCtxtServerInfoLabel.TabIndex = 59;
      this.OPCtxtServerInfoLabel.Text = "----";
      this.OPCtxtServerInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.toolTip_main.SetToolTip( this.OPCtxtServerInfoLabel, "Server vendor information (from GetStatus):" );
      // 
      // label19
      // 
      this.label19.Location = new System.Drawing.Point( 8, 24 );
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size( 104, 16 );
      this.label19.TabIndex = 19;
      this.label19.Text = "Server name";
      this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label20
      // 
      this.label20.Location = new System.Drawing.Point( 8, 104 );
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size( 104, 16 );
      this.label20.TabIndex = 18;
      this.label20.Text = "Server info";
      this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OPCClientNameLabel
      // 
      this.OPCClientNameLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.OPCClientNameLabel.BackColor = System.Drawing.SystemColors.Info;
      this.OPCClientNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.OPCClientNameLabel.Location = new System.Drawing.Point( 128, 16 );
      this.OPCClientNameLabel.Name = "OPCClientNameLabel";
      this.OPCClientNameLabel.Size = new System.Drawing.Size( 323, 32 );
      this.OPCClientNameLabel.TabIndex = 58;
      this.OPCClientNameLabel.Text = "-----";
      this.OPCClientNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // listViewOPCClient
      // 
      this.listViewOPCClient.Alignment = System.Windows.Forms.ListViewAlignment.Left;
      this.listViewOPCClient.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.listViewOPCClient.AutoArrange = false;
      this.listViewOPCClient.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderServers} );
      this.listViewOPCClient.Location = new System.Drawing.Point( 16, 16 );
      this.listViewOPCClient.MultiSelect = false;
      this.listViewOPCClient.Name = "listViewOPCClient";
      this.listViewOPCClient.Size = new System.Drawing.Size( 168, 366 );
      this.listViewOPCClient.SmallImageList = this.imageListStationIcons;
      this.listViewOPCClient.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listViewOPCClient.TabIndex = 0;
      this.listViewOPCClient.UseCompatibleStateImageBehavior = false;
      this.listViewOPCClient.View = System.Windows.Forms.View.Details;
      this.listViewOPCClient.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listView_ColumnClick );
      // 
      // columnHeaderServers
      // 
      this.columnHeaderServers.Text = "Server";
      this.columnHeaderServers.Width = 163;
      // 
      // imageListStationIcons
      // 
      this.imageListStationIcons.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageListStationIcons.ImageStream" ) ) );
      this.imageListStationIcons.TransparentColor = System.Drawing.Color.Transparent;
      this.imageListStationIcons.Images.SetKeyName( 0, "serwer_opc_48_full.ico" );
      this.imageListStationIcons.Images.SetKeyName( 1, "serwer_opc_fail_48_full.ico" );
      this.imageListStationIcons.Images.SetKeyName( 2, "serwer_opc_sb_48_full.ico" );
      this.imageListStationIcons.Images.SetKeyName( 3, "serwer_opc_spec_48_full.ico" );
      // 
      // tabPage_groups
      // 
      this.tabPage_groups.Controls.Add( this.listView_group );
      this.tabPage_groups.Controls.Add( this.groupBox1 );
      this.tabPage_groups.Location = new System.Drawing.Point( 4, 22 );
      this.tabPage_groups.Name = "tabPage_groups";
      this.tabPage_groups.Size = new System.Drawing.Size( 675, 388 );
      this.tabPage_groups.TabIndex = 7;
      this.tabPage_groups.Text = "Groups";
      // 
      // listView_group
      // 
      this.listView_group.Alignment = System.Windows.Forms.ListViewAlignment.Left;
      this.listView_group.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.listView_group.AutoArrange = false;
      this.listView_group.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderGroup} );
      this.listView_group.Location = new System.Drawing.Point( 16, 15 );
      this.listView_group.MultiSelect = false;
      this.listView_group.Name = "listView_group";
      this.listView_group.Size = new System.Drawing.Size( 168, 366 );
      this.listView_group.SmallImageList = this.imageListGroups;
      this.listView_group.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listView_group.TabIndex = 62;
      this.listView_group.UseCompatibleStateImageBehavior = false;
      this.listView_group.View = System.Windows.Forms.View.Details;
      this.listView_group.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listView_ColumnClick );
      // 
      // columnHeaderGroup
      // 
      this.columnHeaderGroup.Text = "Group";
      this.columnHeaderGroup.Width = 163;
      // 
      // imageListGroups
      // 
      this.imageListGroups.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageListGroups.ImageStream" ) ) );
      this.imageListGroups.TransparentColor = System.Drawing.Color.Transparent;
      this.imageListGroups.Images.SetKeyName( 0, "blok_danych_48_full.ico" );
      this.imageListGroups.Images.SetKeyName( 1, "blok_danych_fial_48_full.ico" );
      this.imageListGroups.Images.SetKeyName( 2, "blok_danych_sb_48_full.ico" );
      this.imageListGroups.Images.SetKeyName( 3, "blok_danych_spec_48_full.ico" );
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.groupBox1.Controls.Add( this.label_gr_minavgmax_readtime );
      this.groupBox1.Controls.Add( this.label8 );
      this.groupBox1.Controls.Add( this.label4 );
      this.groupBox1.Controls.Add( this.label_groupdetails );
      this.groupBox1.Controls.Add( this.label_gr_writesucc );
      this.groupBox1.Controls.Add( this.label10 );
      this.groupBox1.Controls.Add( this.label_gr_registeredtags );
      this.groupBox1.Controls.Add( this.label14 );
      this.groupBox1.Controls.Add( this.label_gr_readnotsucc );
      this.groupBox1.Controls.Add( this.label18 );
      this.groupBox1.Controls.Add( this.label_gr_writenotsucc );
      this.groupBox1.Controls.Add( this.label22 );
      this.groupBox1.Controls.Add( this.label_gr_readsucc );
      this.groupBox1.Controls.Add( this.label24 );
      this.groupBox1.Controls.Add( this.label_gr_activetime );
      this.groupBox1.Controls.Add( this.label30 );
      this.groupBox1.Controls.Add( this.label32 );
      this.groupBox1.Controls.Add( this.label_groupname );
      this.groupBox1.Location = new System.Drawing.Point( 200, 7 );
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size( 459, 374 );
      this.groupBox1.TabIndex = 63;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Group statistics";
      // 
      // label_gr_minavgmax_readtime
      // 
      this.label_gr_minavgmax_readtime.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_gr_minavgmax_readtime.BackColor = System.Drawing.SystemColors.Info;
      this.label_gr_minavgmax_readtime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_gr_minavgmax_readtime.Location = new System.Drawing.Point( 120, 146 );
      this.label_gr_minavgmax_readtime.Name = "label_gr_minavgmax_readtime";
      this.label_gr_minavgmax_readtime.Size = new System.Drawing.Size( 331, 16 );
      this.label_gr_minavgmax_readtime.TabIndex = 82;
      this.label_gr_minavgmax_readtime.Text = "----";
      this.label_gr_minavgmax_readtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point( 8, 138 );
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size( 104, 32 );
      this.label8.TabIndex = 81;
      this.label8.Text = "Min/Avg/Max gr. read time [ms]";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point( 8, 72 );
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size( 104, 16 );
      this.label4.TabIndex = 76;
      this.label4.Text = "Group details";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_groupdetails
      // 
      this.label_groupdetails.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_groupdetails.BackColor = System.Drawing.SystemColors.Info;
      this.label_groupdetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_groupdetails.Location = new System.Drawing.Point( 120, 56 );
      this.label_groupdetails.Name = "label_groupdetails";
      this.label_groupdetails.Size = new System.Drawing.Size( 331, 48 );
      this.label_groupdetails.TabIndex = 77;
      this.label_groupdetails.Text = "-----";
      this.label_groupdetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label_gr_writesucc
      // 
      this.label_gr_writesucc.BackColor = System.Drawing.SystemColors.Info;
      this.label_gr_writesucc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_gr_writesucc.Location = new System.Drawing.Point( 120, 207 );
      this.label_gr_writesucc.Name = "label_gr_writesucc";
      this.label_gr_writesucc.Size = new System.Drawing.Size( 104, 16 );
      this.label_gr_writesucc.TabIndex = 75;
      this.label_gr_writesucc.Text = "----";
      this.label_gr_writesucc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point( 8, 209 );
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size( 104, 16 );
      this.label10.TabIndex = 74;
      this.label10.Text = "Wite successes";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_gr_registeredtags
      // 
      this.label_gr_registeredtags.BackColor = System.Drawing.SystemColors.Info;
      this.label_gr_registeredtags.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_gr_registeredtags.Location = new System.Drawing.Point( 120, 183 );
      this.label_gr_registeredtags.Name = "label_gr_registeredtags";
      this.label_gr_registeredtags.Size = new System.Drawing.Size( 104, 16 );
      this.label_gr_registeredtags.TabIndex = 73;
      this.label_gr_registeredtags.Text = "----";
      this.label_gr_registeredtags.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point( 8, 185 );
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size( 104, 16 );
      this.label14.TabIndex = 72;
      this.label14.Text = "Registered tags";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_gr_readnotsucc
      // 
      this.label_gr_readnotsucc.BackColor = System.Drawing.SystemColors.Info;
      this.label_gr_readnotsucc.ForeColor = System.Drawing.Color.Red;
      this.label_gr_readnotsucc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_gr_readnotsucc.Location = new System.Drawing.Point( 342, 233 );
      this.label_gr_readnotsucc.Name = "label_gr_readnotsucc";
      this.label_gr_readnotsucc.Size = new System.Drawing.Size( 104, 16 );
      this.label_gr_readnotsucc.TabIndex = 71;
      this.label_gr_readnotsucc.Text = "----";
      this.label_gr_readnotsucc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label18
      // 
      this.label18.ForeColor = System.Drawing.Color.Red;
      this.label18.Location = new System.Drawing.Point( 230, 231 );
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size( 104, 16 );
      this.label18.TabIndex = 70;
      this.label18.Text = "Read fails";
      this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_gr_writenotsucc
      // 
      this.label_gr_writenotsucc.BackColor = System.Drawing.SystemColors.Info;
      this.label_gr_writenotsucc.ForeColor = System.Drawing.Color.Red;
      this.label_gr_writenotsucc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_gr_writenotsucc.Location = new System.Drawing.Point( 120, 231 );
      this.label_gr_writenotsucc.Name = "label_gr_writenotsucc";
      this.label_gr_writenotsucc.Size = new System.Drawing.Size( 104, 16 );
      this.label_gr_writenotsucc.TabIndex = 69;
      this.label_gr_writenotsucc.Text = "----";
      this.label_gr_writenotsucc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label22
      // 
      this.label22.ForeColor = System.Drawing.Color.Red;
      this.label22.Location = new System.Drawing.Point( 8, 233 );
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size( 104, 16 );
      this.label22.TabIndex = 68;
      this.label22.Text = "Write fails";
      this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_gr_readsucc
      // 
      this.label_gr_readsucc.BackColor = System.Drawing.SystemColors.Info;
      this.label_gr_readsucc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_gr_readsucc.Location = new System.Drawing.Point( 342, 209 );
      this.label_gr_readsucc.Name = "label_gr_readsucc";
      this.label_gr_readsucc.Size = new System.Drawing.Size( 104, 16 );
      this.label_gr_readsucc.TabIndex = 80;
      this.label_gr_readsucc.Text = "----";
      this.label_gr_readsucc.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label24
      // 
      this.label24.Location = new System.Drawing.Point( 230, 207 );
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size( 104, 16 );
      this.label24.TabIndex = 66;
      this.label24.Text = "Read successes";
      this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_gr_activetime
      // 
      this.label_gr_activetime.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_gr_activetime.BackColor = System.Drawing.SystemColors.Info;
      this.label_gr_activetime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_gr_activetime.Location = new System.Drawing.Point( 120, 112 );
      this.label_gr_activetime.Name = "label_gr_activetime";
      this.label_gr_activetime.Size = new System.Drawing.Size( 331, 16 );
      this.label_gr_activetime.TabIndex = 61;
      this.label_gr_activetime.Text = "----";
      this.label_gr_activetime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label30
      // 
      this.label30.Location = new System.Drawing.Point( 8, 112 );
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size( 104, 16 );
      this.label30.TabIndex = 60;
      this.label30.Text = "Group active time";
      this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label32
      // 
      this.label32.Location = new System.Drawing.Point( 8, 24 );
      this.label32.Name = "label32";
      this.label32.Size = new System.Drawing.Size( 104, 16 );
      this.label32.TabIndex = 19;
      this.label32.Text = "Group name";
      this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_groupname
      // 
      this.label_groupname.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_groupname.BackColor = System.Drawing.SystemColors.Info;
      this.label_groupname.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_groupname.Location = new System.Drawing.Point( 120, 16 );
      this.label_groupname.Name = "label_groupname";
      this.label_groupname.Size = new System.Drawing.Size( 331, 32 );
      this.label_groupname.TabIndex = 58;
      this.label_groupname.Text = "-----";
      this.label_groupname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tabItems
      // 
      this.tabItems.Controls.Add( this.listView_items );
      this.tabItems.Controls.Add( this.groupBox2 );
      this.tabItems.Location = new System.Drawing.Point( 4, 22 );
      this.tabItems.Name = "tabItems";
      this.tabItems.Size = new System.Drawing.Size( 675, 388 );
      this.tabItems.TabIndex = 5;
      this.tabItems.Text = "Items";
      // 
      // listView_items
      // 
      this.listView_items.Alignment = System.Windows.Forms.ListViewAlignment.Left;
      this.listView_items.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.listView_items.AutoArrange = false;
      this.listView_items.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderItem} );
      this.listView_items.FullRowSelect = true;
      this.listView_items.Location = new System.Drawing.Point( 8, 8 );
      this.listView_items.MultiSelect = false;
      this.listView_items.Name = "listView_items";
      this.listView_items.ShowGroups = false;
      this.listView_items.Size = new System.Drawing.Size( 192, 366 );
      this.listView_items.SmallImageList = this.ImageListItems;
      this.listView_items.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listView_items.TabIndex = 65;
      this.listView_items.UseCompatibleStateImageBehavior = false;
      this.listView_items.View = System.Windows.Forms.View.Details;
      this.listView_items.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listView_ColumnClick );
      // 
      // columnHeaderItem
      // 
      this.columnHeaderItem.Text = "Item";
      this.columnHeaderItem.Width = 171;
      // 
      // ImageListItems
      // 
      this.ImageListItems.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ImageListItems.ImageStream" ) ) );
      this.ImageListItems.TransparentColor = System.Drawing.Color.Transparent;
      this.ImageListItems.Images.SetKeyName( 0, "tag_element_48_full.ico" );
      this.ImageListItems.Images.SetKeyName( 1, "tag_element_fail_48_full.ico" );
      this.ImageListItems.Images.SetKeyName( 2, "tag_element_sb_48_full.ico" );
      this.ImageListItems.Images.SetKeyName( 3, "tag_element_spec_48_full.ico" );
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.groupBox2.Controls.Add( this.label_item_lasterror );
      this.groupBox2.Controls.Add( this.label27 );
      this.groupBox2.Controls.Add( this.label_item_minavrmax );
      this.groupBox2.Controls.Add( this.label12 );
      this.groupBox2.Controls.Add( this.label16 );
      this.groupBox2.Controls.Add( this.label_item_detail );
      this.groupBox2.Controls.Add( this.label_item_wr_succ );
      this.groupBox2.Controls.Add( this.label25 );
      this.groupBox2.Controls.Add( this.label_item_state );
      this.groupBox2.Controls.Add( this.label28 );
      this.groupBox2.Controls.Add( this.label_item_read_fail );
      this.groupBox2.Controls.Add( this.label33 );
      this.groupBox2.Controls.Add( this.label_item_wr_fail );
      this.groupBox2.Controls.Add( this.label35 );
      this.groupBox2.Controls.Add( this.label_item_read_succ );
      this.groupBox2.Controls.Add( this.label37 );
      this.groupBox2.Controls.Add( this.label_item_value );
      this.groupBox2.Controls.Add( this.label39 );
      this.groupBox2.Controls.Add( this.label_item_activtime );
      this.groupBox2.Controls.Add( this.label41 );
      this.groupBox2.Controls.Add( this.label42 );
      this.groupBox2.Controls.Add( this.label_item_name );
      this.groupBox2.Location = new System.Drawing.Point( 208, 8 );
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size( 459, 374 );
      this.groupBox2.TabIndex = 64;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Item statistics";
      // 
      // label_item_lasterror
      // 
      this.label_item_lasterror.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_lasterror.ForeColor = System.Drawing.Color.Red;
      this.label_item_lasterror.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_lasterror.Location = new System.Drawing.Point( 144, 328 );
      this.label_item_lasterror.Name = "label_item_lasterror";
      this.label_item_lasterror.Size = new System.Drawing.Size( 216, 40 );
      this.label_item_lasterror.TabIndex = 81;
      this.label_item_lasterror.Text = "----";
      this.label_item_lasterror.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label27
      // 
      this.label27.ForeColor = System.Drawing.Color.Red;
      this.label27.Location = new System.Drawing.Point( 32, 328 );
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size( 104, 16 );
      this.label27.TabIndex = 80;
      this.label27.Text = "Last Error";
      this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_minavrmax
      // 
      this.label_item_minavrmax.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_item_minavrmax.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_minavrmax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_minavrmax.Location = new System.Drawing.Point( 120, 144 );
      this.label_item_minavrmax.Name = "label_item_minavrmax";
      this.label_item_minavrmax.Size = new System.Drawing.Size( 331, 16 );
      this.label_item_minavrmax.TabIndex = 79;
      this.label_item_minavrmax.Text = "----";
      this.label_item_minavrmax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point( 8, 136 );
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size( 104, 40 );
      this.label12.TabIndex = 78;
      this.label12.Text = "Min/Avr/Max item scan rate";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label16
      // 
      this.label16.Location = new System.Drawing.Point( 8, 72 );
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size( 104, 16 );
      this.label16.TabIndex = 76;
      this.label16.Text = "Item details";
      this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_detail
      // 
      this.label_item_detail.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_item_detail.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_detail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_detail.Location = new System.Drawing.Point( 120, 72 );
      this.label_item_detail.Name = "label_item_detail";
      this.label_item_detail.Size = new System.Drawing.Size( 331, 32 );
      this.label_item_detail.TabIndex = 77;
      this.label_item_detail.Text = "-----";
      this.label_item_detail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label_item_wr_succ
      // 
      this.label_item_wr_succ.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_wr_succ.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_wr_succ.Location = new System.Drawing.Point( 144, 232 );
      this.label_item_wr_succ.Name = "label_item_wr_succ";
      this.label_item_wr_succ.Size = new System.Drawing.Size( 104, 16 );
      this.label_item_wr_succ.TabIndex = 75;
      this.label_item_wr_succ.Text = "----";
      this.label_item_wr_succ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label25
      // 
      this.label25.Location = new System.Drawing.Point( 32, 232 );
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size( 104, 16 );
      this.label25.TabIndex = 74;
      this.label25.Text = "Wite successes";
      this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_state
      // 
      this.label_item_state.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_state.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_state.Location = new System.Drawing.Point( 144, 208 );
      this.label_item_state.Name = "label_item_state";
      this.label_item_state.Size = new System.Drawing.Size( 224, 16 );
      this.label_item_state.TabIndex = 73;
      this.label_item_state.Text = "----";
      this.label_item_state.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label28
      // 
      this.label28.Location = new System.Drawing.Point( 32, 208 );
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size( 104, 16 );
      this.label28.TabIndex = 72;
      this.label28.Text = "Item state";
      this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_read_fail
      // 
      this.label_item_read_fail.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_read_fail.ForeColor = System.Drawing.Color.Red;
      this.label_item_read_fail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_read_fail.Location = new System.Drawing.Point( 144, 304 );
      this.label_item_read_fail.Name = "label_item_read_fail";
      this.label_item_read_fail.Size = new System.Drawing.Size( 104, 16 );
      this.label_item_read_fail.TabIndex = 71;
      this.label_item_read_fail.Text = "----";
      this.label_item_read_fail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label33
      // 
      this.label33.ForeColor = System.Drawing.Color.Red;
      this.label33.Location = new System.Drawing.Point( 32, 304 );
      this.label33.Name = "label33";
      this.label33.Size = new System.Drawing.Size( 104, 16 );
      this.label33.TabIndex = 70;
      this.label33.Text = "Read fails";
      this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_wr_fail
      // 
      this.label_item_wr_fail.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_wr_fail.ForeColor = System.Drawing.Color.Red;
      this.label_item_wr_fail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_wr_fail.Location = new System.Drawing.Point( 144, 256 );
      this.label_item_wr_fail.Name = "label_item_wr_fail";
      this.label_item_wr_fail.Size = new System.Drawing.Size( 104, 16 );
      this.label_item_wr_fail.TabIndex = 69;
      this.label_item_wr_fail.Text = "----";
      this.label_item_wr_fail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label35
      // 
      this.label35.ForeColor = System.Drawing.Color.Red;
      this.label35.Location = new System.Drawing.Point( 32, 256 );
      this.label35.Name = "label35";
      this.label35.Size = new System.Drawing.Size( 104, 16 );
      this.label35.TabIndex = 68;
      this.label35.Text = "Write fails";
      this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_read_succ
      // 
      this.label_item_read_succ.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_read_succ.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_read_succ.Location = new System.Drawing.Point( 144, 280 );
      this.label_item_read_succ.Name = "label_item_read_succ";
      this.label_item_read_succ.Size = new System.Drawing.Size( 104, 16 );
      this.label_item_read_succ.TabIndex = 67;
      this.label_item_read_succ.Text = "----";
      this.label_item_read_succ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label37
      // 
      this.label37.Location = new System.Drawing.Point( 32, 280 );
      this.label37.Name = "label37";
      this.label37.Size = new System.Drawing.Size( 104, 16 );
      this.label37.TabIndex = 66;
      this.label37.Text = "Read successes";
      this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_value
      // 
      this.label_item_value.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_value.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_value.Location = new System.Drawing.Point( 144, 184 );
      this.label_item_value.Name = "label_item_value";
      this.label_item_value.Size = new System.Drawing.Size( 224, 16 );
      this.label_item_value.TabIndex = 65;
      this.label_item_value.Text = "----";
      this.label_item_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label39
      // 
      this.label39.Location = new System.Drawing.Point( 8, 184 );
      this.label39.Name = "label39";
      this.label39.Size = new System.Drawing.Size( 128, 16 );
      this.label39.TabIndex = 64;
      this.label39.Text = "Item value";
      this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_activtime
      // 
      this.label_item_activtime.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_item_activtime.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_activtime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_activtime.Location = new System.Drawing.Point( 120, 112 );
      this.label_item_activtime.Name = "label_item_activtime";
      this.label_item_activtime.Size = new System.Drawing.Size( 331, 16 );
      this.label_item_activtime.TabIndex = 61;
      this.label_item_activtime.Text = "----";
      this.label_item_activtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label41
      // 
      this.label41.Location = new System.Drawing.Point( 8, 112 );
      this.label41.Name = "label41";
      this.label41.Size = new System.Drawing.Size( 104, 16 );
      this.label41.TabIndex = 60;
      this.label41.Text = "Item active time";
      this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label42
      // 
      this.label42.Location = new System.Drawing.Point( 24, 40 );
      this.label42.Name = "label42";
      this.label42.Size = new System.Drawing.Size( 88, 16 );
      this.label42.TabIndex = 19;
      this.label42.Text = "Item/Tag name";
      this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_item_name
      // 
      this.label_item_name.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_item_name.BackColor = System.Drawing.SystemColors.Info;
      this.label_item_name.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_item_name.Location = new System.Drawing.Point( 120, 32 );
      this.label_item_name.Name = "label_item_name";
      this.label_item_name.Size = new System.Drawing.Size( 331, 32 );
      this.label_item_name.TabIndex = 58;
      this.label_item_name.Text = "-----";
      this.label_item_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tabTransactions
      // 
      this.tabTransactions.Controls.Add( this.groupBox4 );
      this.tabTransactions.Controls.Add( this.listView_transactions );
      this.tabTransactions.Location = new System.Drawing.Point( 4, 22 );
      this.tabTransactions.Name = "tabTransactions";
      this.tabTransactions.Size = new System.Drawing.Size( 675, 388 );
      this.tabTransactions.TabIndex = 6;
      this.tabTransactions.Text = "Transaction";
      // 
      // groupBox4
      // 
      this.groupBox4.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.groupBox4.Controls.Add( this.label_tr_minavmax );
      this.groupBox4.Controls.Add( this.label21 );
      this.groupBox4.Controls.Add( this.label23 );
      this.groupBox4.Controls.Add( this.label_tr_details );
      this.groupBox4.Controls.Add( this.label_tr_deadband );
      this.groupBox4.Controls.Add( this.label34 );
      this.groupBox4.Controls.Add( this.label_tr_scanrate );
      this.groupBox4.Controls.Add( this.label38 );
      this.groupBox4.Controls.Add( this.label_tr_updaterate );
      this.groupBox4.Controls.Add( this.label45 );
      this.groupBox4.Controls.Add( this.label_tr_counter );
      this.groupBox4.Controls.Add( this.label51 );
      this.groupBox4.Controls.Add( this.label52 );
      this.groupBox4.Controls.Add( this.label_tr_name );
      this.groupBox4.Location = new System.Drawing.Point( 208, 8 );
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size( 459, 374 );
      this.groupBox4.TabIndex = 67;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Transaction statistics";
      // 
      // label_tr_minavmax
      // 
      this.label_tr_minavmax.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_tr_minavmax.BackColor = System.Drawing.SystemColors.Info;
      this.label_tr_minavmax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_tr_minavmax.Location = new System.Drawing.Point( 143, 190 );
      this.label_tr_minavmax.Name = "label_tr_minavmax";
      this.label_tr_minavmax.Size = new System.Drawing.Size( 305, 16 );
      this.label_tr_minavmax.TabIndex = 79;
      this.label_tr_minavmax.Text = "----";
      this.label_tr_minavmax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label21
      // 
      this.label21.Location = new System.Drawing.Point( 11, 173 );
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size( 124, 44 );
      this.label21.TabIndex = 78;
      this.label21.Text = "Min/Avr/Max transaction execution rate [ms]";
      this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label23
      // 
      this.label23.Location = new System.Drawing.Point( 31, 72 );
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size( 104, 16 );
      this.label23.TabIndex = 76;
      this.label23.Text = "Transaction details";
      this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_tr_details
      // 
      this.label_tr_details.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_tr_details.BackColor = System.Drawing.SystemColors.Info;
      this.label_tr_details.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_tr_details.Location = new System.Drawing.Point( 143, 56 );
      this.label_tr_details.Name = "label_tr_details";
      this.label_tr_details.Size = new System.Drawing.Size( 305, 48 );
      this.label_tr_details.TabIndex = 77;
      this.label_tr_details.Text = "-----";
      this.label_tr_details.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label_tr_deadband
      // 
      this.label_tr_deadband.BackColor = System.Drawing.SystemColors.Info;
      this.label_tr_deadband.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_tr_deadband.Location = new System.Drawing.Point( 144, 257 );
      this.label_tr_deadband.Name = "label_tr_deadband";
      this.label_tr_deadband.Size = new System.Drawing.Size( 104, 16 );
      this.label_tr_deadband.TabIndex = 75;
      this.label_tr_deadband.Text = "----";
      this.label_tr_deadband.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label34
      // 
      this.label34.Location = new System.Drawing.Point( 16, 257 );
      this.label34.Name = "label34";
      this.label34.Size = new System.Drawing.Size( 120, 16 );
      this.label34.TabIndex = 74;
      this.label34.Text = "Deadband [%]";
      this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_tr_scanrate
      // 
      this.label_tr_scanrate.BackColor = System.Drawing.SystemColors.Info;
      this.label_tr_scanrate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_tr_scanrate.Location = new System.Drawing.Point( 144, 225 );
      this.label_tr_scanrate.Name = "label_tr_scanrate";
      this.label_tr_scanrate.Size = new System.Drawing.Size( 104, 16 );
      this.label_tr_scanrate.TabIndex = 73;
      this.label_tr_scanrate.Text = "----";
      this.label_tr_scanrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label38
      // 
      this.label38.Location = new System.Drawing.Point( 8, 217 );
      this.label38.Name = "label38";
      this.label38.Size = new System.Drawing.Size( 128, 32 );
      this.label38.TabIndex = 72;
      this.label38.Text = "Transaction Scanning Rate [ms]";
      this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_tr_updaterate
      // 
      this.label_tr_updaterate.BackColor = System.Drawing.SystemColors.Info;
      this.label_tr_updaterate.ForeColor = System.Drawing.Color.Black;
      this.label_tr_updaterate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_tr_updaterate.Location = new System.Drawing.Point( 144, 281 );
      this.label_tr_updaterate.Name = "label_tr_updaterate";
      this.label_tr_updaterate.Size = new System.Drawing.Size( 104, 16 );
      this.label_tr_updaterate.TabIndex = 69;
      this.label_tr_updaterate.Text = "----";
      this.label_tr_updaterate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label45
      // 
      this.label45.ForeColor = System.Drawing.Color.Black;
      this.label45.Location = new System.Drawing.Point( 8, 281 );
      this.label45.Name = "label45";
      this.label45.Size = new System.Drawing.Size( 128, 16 );
      this.label45.TabIndex = 68;
      this.label45.Text = "Min Update Rate [ms]";
      this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_tr_counter
      // 
      this.label_tr_counter.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_tr_counter.BackColor = System.Drawing.SystemColors.Info;
      this.label_tr_counter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_tr_counter.Location = new System.Drawing.Point( 141, 134 );
      this.label_tr_counter.Name = "label_tr_counter";
      this.label_tr_counter.Size = new System.Drawing.Size( 305, 16 );
      this.label_tr_counter.TabIndex = 61;
      this.label_tr_counter.Text = "----";
      this.label_tr_counter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label51
      // 
      this.label51.Location = new System.Drawing.Point( 31, 112 );
      this.label51.Name = "label51";
      this.label51.Size = new System.Drawing.Size( 104, 61 );
      this.label51.TabIndex = 60;
      this.label51.Text = "Transaction counter\r\nexecuted/tested\r\n(executed to tested coeficient)\r\n";
      this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label52
      // 
      this.label52.Location = new System.Drawing.Point( 34, 21 );
      this.label52.Name = "label52";
      this.label52.Size = new System.Drawing.Size( 101, 24 );
      this.label52.TabIndex = 19;
      this.label52.Text = "Transaction name";
      this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label_tr_name
      // 
      this.label_tr_name.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.label_tr_name.BackColor = System.Drawing.SystemColors.Info;
      this.label_tr_name.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label_tr_name.Location = new System.Drawing.Point( 143, 16 );
      this.label_tr_name.Name = "label_tr_name";
      this.label_tr_name.Size = new System.Drawing.Size( 305, 32 );
      this.label_tr_name.TabIndex = 58;
      this.label_tr_name.Text = "-----";
      this.label_tr_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // listView_transactions
      // 
      this.listView_transactions.Alignment = System.Windows.Forms.ListViewAlignment.Left;
      this.listView_transactions.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.listView_transactions.AutoArrange = false;
      this.listView_transactions.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTransactions} );
      this.listView_transactions.FullRowSelect = true;
      this.listView_transactions.Location = new System.Drawing.Point( 8, 8 );
      this.listView_transactions.MultiSelect = false;
      this.listView_transactions.Name = "listView_transactions";
      this.listView_transactions.Size = new System.Drawing.Size( 192, 366 );
      this.listView_transactions.SmallImageList = this.imageListTransactions;
      this.listView_transactions.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listView_transactions.TabIndex = 66;
      this.listView_transactions.UseCompatibleStateImageBehavior = false;
      this.listView_transactions.View = System.Windows.Forms.View.Details;
      this.listView_transactions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listView_ColumnClick );
      // 
      // columnHeaderTransactions
      // 
      this.columnHeaderTransactions.Text = "Transaction";
      this.columnHeaderTransactions.Width = 188;
      // 
      // imageListTransactions
      // 
      this.imageListTransactions.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageListTransactions.ImageStream" ) ) );
      this.imageListTransactions.TransparentColor = System.Drawing.Color.Transparent;
      this.imageListTransactions.Images.SetKeyName( 0, "transformacja_48_full.ico" );
      this.imageListTransactions.Images.SetKeyName( 1, "transformacja_fail_48_full.ico" );
      this.imageListTransactions.Images.SetKeyName( 2, "transformacja_sb_48_full.ico" );
      this.imageListTransactions.Images.SetKeyName( 3, "transformacja_spec_48_full.ico" );
      // 
      // labelTestTimeLab
      // 
      this.labelTestTimeLab.Location = new System.Drawing.Point( 0, 5 );
      this.labelTestTimeLab.Name = "labelTestTimeLab";
      this.labelTestTimeLab.Size = new System.Drawing.Size( 88, 16 );
      this.labelTestTimeLab.TabIndex = 78;
      this.labelTestTimeLab.Text = "Run time:";
      this.labelTestTimeLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // labelTestTime
      // 
      this.labelTestTime.BackColor = System.Drawing.SystemColors.Info;
      this.labelTestTime.ForeColor = System.Drawing.SystemColors.ControlText;
      this.labelTestTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.labelTestTime.Location = new System.Drawing.Point( 94, 5 );
      this.labelTestTime.Name = "labelTestTime";
      this.labelTestTime.Size = new System.Drawing.Size( 72, 16 );
      this.labelTestTime.TabIndex = 77;
      this.labelTestTime.Text = "0";
      this.labelTestTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // m_Trayicon
      // 
      this.m_Trayicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.m_Trayicon.BalloonTipText = "Popup DataPorter";
      this.m_Trayicon.BalloonTipTitle = "DataPorter";
      this.m_Trayicon.ContextMenu = this.tray_menu;
      this.m_Trayicon.Icon = ( (System.Drawing.Icon)( resources.GetObject( "m_Trayicon.Icon" ) ) );
      this.m_Trayicon.Text = "DataPorter";
      this.m_Trayicon.Visible = true;
      this.m_Trayicon.DoubleClick += new System.EventHandler( this.Show_click );
      // 
      // mainMenuStrip
      // 
      this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.mainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.mainMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_monitor,
            this.toolsToolStripMenuItem,
            this.menuItem_helpmain} );
      this.mainMenuStrip.Location = new System.Drawing.Point( 0, 0 );
      this.mainMenuStrip.Name = "mainMenuStrip";
      this.mainMenuStrip.Size = new System.Drawing.Size( 715, 24 );
      this.mainMenuStrip.TabIndex = 80;
      // 
      // menuItem_monitor
      // 
      this.menuItem_monitor.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_MenuHide,
            this.toolStripSeparator1,
            this.menuItem_exit} );
      this.menuItem_monitor.Name = "menuItem_monitor";
      this.menuItem_monitor.Size = new System.Drawing.Size( 62, 20 );
      this.menuItem_monitor.Text = "Monitor";
      // 
      // menuItem_MenuHide
      // 
      this.menuItem_MenuHide.Image = ( (System.Drawing.Image)( resources.GetObject( "menuItem_MenuHide.Image" ) ) );
      this.menuItem_MenuHide.Name = "menuItem_MenuHide";
      this.menuItem_MenuHide.Size = new System.Drawing.Size( 99, 22 );
      this.menuItem_MenuHide.Text = "Hide";
      this.menuItem_MenuHide.Click += new System.EventHandler( this.menuItem_MenuHide_Click );
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size( 96, 6 );
      // 
      // menuItem_exit
      // 
      this.menuItem_exit.Image = ( (System.Drawing.Image)( resources.GetObject( "menuItem_exit.Image" ) ) );
      this.menuItem_exit.Name = "menuItem_exit";
      this.menuItem_exit.Size = new System.Drawing.Size( 99, 22 );
      this.menuItem_exit.Text = "Exit";
      this.menuItem_exit.Click += new System.EventHandler( this.Exit_Click );
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_MenuConfigurator,
            this.menuItem_MenuReport,
            this.serviceConfiguratorToolStripMenuItem,
            this.dCOMConfiguratorToolStripMenuItem,
            this.toolStripSeparator2,
            this.optionsToolStripMenuItem} );
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size( 48, 20 );
      this.toolsToolStripMenuItem.Text = "Tools";
      // 
      // menuItem_MenuConfigurator
      // 
      this.menuItem_MenuConfigurator.Image = ( (System.Drawing.Image)( resources.GetObject( "menuItem_MenuConfigurator.Image" ) ) );
      this.menuItem_MenuConfigurator.Name = "menuItem_MenuConfigurator";
      this.menuItem_MenuConfigurator.Size = new System.Drawing.Size( 180, 22 );
      this.menuItem_MenuConfigurator.Text = "Configurator";
      this.menuItem_MenuConfigurator.Click += new System.EventHandler( this.MenuConfigurator_Click );
      // 
      // menuItem_MenuReport
      // 
      this.menuItem_MenuReport.Name = "menuItem_MenuReport";
      this.menuItem_MenuReport.Size = new System.Drawing.Size( 180, 22 );
      this.menuItem_MenuReport.Text = "Report";
      this.menuItem_MenuReport.Click += new System.EventHandler( this.RaportGenerator_Click );
      // 
      // serviceConfiguratorToolStripMenuItem
      // 
      this.serviceConfiguratorToolStripMenuItem.Name = "serviceConfiguratorToolStripMenuItem";
      this.serviceConfiguratorToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
      this.serviceConfiguratorToolStripMenuItem.Text = "Service configurator";
      this.serviceConfiguratorToolStripMenuItem.Click += new System.EventHandler( this.serviceConfiguratorToolStripMenuItem_Click );
      // 
      // dCOMConfiguratorToolStripMenuItem
      // 
      this.dCOMConfiguratorToolStripMenuItem.Name = "dCOMConfiguratorToolStripMenuItem";
      this.dCOMConfiguratorToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
      this.dCOMConfiguratorToolStripMenuItem.Text = "DCOM configurator";
      this.dCOMConfiguratorToolStripMenuItem.Click += new System.EventHandler( this.dCOMConfiguratorToolStripMenuItem_Click );
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size( 177, 6 );
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "optionsToolStripMenuItem.Image" ) ) );
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
      this.optionsToolStripMenuItem.Text = "Options ...";
      this.optionsToolStripMenuItem.Click += new System.EventHandler( this.optionsToolStripMenuItem_Click );
      // 
      // menuItem_helpmain
      // 
      this.menuItem_helpmain.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_help,
            this.toolStripSeparator3,
            this.menuItem_about,
            this.licenseInfomToolStripMenuItem,
            this.openLogContainingFolderToolStripMenuItem,
            this.enterTheUnlockCodeToolStripMenuItem} );
      this.menuItem_helpmain.Name = "menuItem_helpmain";
      this.menuItem_helpmain.Size = new System.Drawing.Size( 44, 20 );
      this.menuItem_helpmain.Text = "Help";
      // 
      // menuItem_help
      // 
      this.menuItem_help.Image = ( (System.Drawing.Image)( resources.GetObject( "menuItem_help.Image" ) ) );
      this.menuItem_help.Name = "menuItem_help";
      this.menuItem_help.Size = new System.Drawing.Size( 226, 22 );
      this.menuItem_help.Text = "Help";
      this.menuItem_help.Click += new System.EventHandler( this.Help_Click );
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size( 223, 6 );
      // 
      // menuItem_about
      // 
      this.menuItem_about.Image = ( (System.Drawing.Image)( resources.GetObject( "menuItem_about.Image" ) ) );
      this.menuItem_about.Name = "menuItem_about";
      this.menuItem_about.Size = new System.Drawing.Size( 226, 22 );
      this.menuItem_about.Text = "About";
      this.menuItem_about.Click += new System.EventHandler( this.About_Click );
      // 
      // licenseInfomToolStripMenuItem
      // 
      this.licenseInfomToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "licenseInfomToolStripMenuItem.Image" ) ) );
      this.licenseInfomToolStripMenuItem.Name = "licenseInfomToolStripMenuItem";
      this.licenseInfomToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
      this.licenseInfomToolStripMenuItem.Text = "License infomation";
      this.licenseInfomToolStripMenuItem.Click += new System.EventHandler( this.licenseInfomToolStripMenuItem_Click );
      // 
      // openLogContainingFolderToolStripMenuItem
      // 
      this.openLogContainingFolderToolStripMenuItem.Image = global::CAS.DataPorter.Monitor.Properties.Resources.Folder_Open;
      this.openLogContainingFolderToolStripMenuItem.Name = "openLogContainingFolderToolStripMenuItem";
      this.openLogContainingFolderToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
      this.openLogContainingFolderToolStripMenuItem.Text = "Open log containing folder";
      this.openLogContainingFolderToolStripMenuItem.Click += new System.EventHandler( this.openLogContainingFolderToolStripMenuItem_Click );
      // 
      // enterTheUnlockCodeToolStripMenuItem
      // 
      this.enterTheUnlockCodeToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "enterTheUnlockCodeToolStripMenuItem.Image" ) ) );
      this.enterTheUnlockCodeToolStripMenuItem.Name = "enterTheUnlockCodeToolStripMenuItem";
      this.enterTheUnlockCodeToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K ) ) );
      this.enterTheUnlockCodeToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
      this.enterTheUnlockCodeToolStripMenuItem.Text = "Enter the unlock code";
      this.enterTheUnlockCodeToolStripMenuItem.Click += new System.EventHandler( this.enterTheUnlockCodeToolStripMenuItem_Click );
      // 
      // RefreshFormTimer
      // 
      this.RefreshFormTimer.Interval = 500;
      this.RefreshFormTimer.Tick += new System.EventHandler( this.RefreshFormTimer_Tick );
      // 
      // groupBox_connection
      // 
      this.groupBox_connection.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.groupBox_connection.Controls.Add( this.groupBox_connectedTo );
      this.groupBox_connection.Controls.Add( this.textBox_port );
      this.groupBox_connection.Controls.Add( this.textBox_Host );
      this.groupBox_connection.Controls.Add( this.label_colon );
      this.groupBox_connection.Controls.Add( this.label_hostport );
      this.groupBox_connection.Controls.Add( this.button_ConnectDisconnect );
      this.groupBox_connection.Location = new System.Drawing.Point( 303, 5 );
      this.groupBox_connection.Name = "groupBox_connection";
      this.groupBox_connection.Size = new System.Drawing.Size( 398, 119 );
      this.groupBox_connection.TabIndex = 79;
      this.groupBox_connection.TabStop = false;
      this.groupBox_connection.Text = "Connection";
      // 
      // groupBox_connectedTo
      // 
      this.groupBox_connectedTo.Controls.Add( this.textBox_conected_to_version );
      this.groupBox_connectedTo.Controls.Add( this.textBox_connected_to_name );
      this.groupBox_connectedTo.Controls.Add( this.textBox_connected_to_url );
      this.groupBox_connectedTo.Controls.Add( this.button_ShutDown );
      this.groupBox_connectedTo.Location = new System.Drawing.Point( 9, 39 );
      this.groupBox_connectedTo.Name = "groupBox_connectedTo";
      this.groupBox_connectedTo.Size = new System.Drawing.Size( 381, 74 );
      this.groupBox_connectedTo.TabIndex = 3;
      this.groupBox_connectedTo.TabStop = false;
      this.groupBox_connectedTo.Text = "Connected to:";
      // 
      // textBox_conected_to_version
      // 
      this.textBox_conected_to_version.BackColor = System.Drawing.SystemColors.Info;
      this.textBox_conected_to_version.Location = new System.Drawing.Point( 193, 48 );
      this.textBox_conected_to_version.Name = "textBox_conected_to_version";
      this.textBox_conected_to_version.ReadOnly = true;
      this.textBox_conected_to_version.Size = new System.Drawing.Size( 181, 20 );
      this.textBox_conected_to_version.TabIndex = 3;
      // 
      // textBox_connected_to_name
      // 
      this.textBox_connected_to_name.BackColor = System.Drawing.SystemColors.Info;
      this.textBox_connected_to_name.Location = new System.Drawing.Point( 6, 48 );
      this.textBox_connected_to_name.Name = "textBox_connected_to_name";
      this.textBox_connected_to_name.ReadOnly = true;
      this.textBox_connected_to_name.Size = new System.Drawing.Size( 181, 20 );
      this.textBox_connected_to_name.TabIndex = 3;
      // 
      // textBox_connected_to_url
      // 
      this.textBox_connected_to_url.BackColor = System.Drawing.SystemColors.Info;
      this.textBox_connected_to_url.Location = new System.Drawing.Point( 6, 19 );
      this.textBox_connected_to_url.Name = "textBox_connected_to_url";
      this.textBox_connected_to_url.ReadOnly = true;
      this.textBox_connected_to_url.Size = new System.Drawing.Size( 274, 20 );
      this.textBox_connected_to_url.TabIndex = 3;
      // 
      // button_ShutDown
      // 
      this.button_ShutDown.Location = new System.Drawing.Point( 286, 17 );
      this.button_ShutDown.Name = "button_ShutDown";
      this.button_ShutDown.Size = new System.Drawing.Size( 88, 23 );
      this.button_ShutDown.TabIndex = 0;
      this.button_ShutDown.Text = "Shutdown req.";
      this.button_ShutDown.UseVisualStyleBackColor = true;
      this.button_ShutDown.Click += new System.EventHandler( this.button_ShutDown_Click );
      // 
      // textBox_port
      // 
      this.textBox_port.Location = new System.Drawing.Point( 179, 15 );
      this.textBox_port.MaxLength = 5;
      this.textBox_port.Name = "textBox_port";
      this.textBox_port.Size = new System.Drawing.Size( 63, 20 );
      this.textBox_port.TabIndex = 2;
      // 
      // textBox_Host
      // 
      this.textBox_Host.Location = new System.Drawing.Point( 63, 15 );
      this.textBox_Host.Name = "textBox_Host";
      this.textBox_Host.Size = new System.Drawing.Size( 100, 20 );
      this.textBox_Host.TabIndex = 2;
      // 
      // label_colon
      // 
      this.label_colon.AutoSize = true;
      this.label_colon.Location = new System.Drawing.Point( 166, 19 );
      this.label_colon.Name = "label_colon";
      this.label_colon.Size = new System.Drawing.Size( 10, 13 );
      this.label_colon.TabIndex = 1;
      this.label_colon.Text = ":";
      // 
      // label_hostport
      // 
      this.label_hostport.AutoSize = true;
      this.label_hostport.Location = new System.Drawing.Point( 6, 19 );
      this.label_hostport.Name = "label_hostport";
      this.label_hostport.Size = new System.Drawing.Size( 51, 13 );
      this.label_hostport.TabIndex = 1;
      this.label_hostport.Text = "Host:Port";
      // 
      // button_ConnectDisconnect
      // 
      this.button_ConnectDisconnect.Location = new System.Drawing.Point( 295, 15 );
      this.button_ConnectDisconnect.Name = "button_ConnectDisconnect";
      this.button_ConnectDisconnect.Size = new System.Drawing.Size( 88, 23 );
      this.button_ConnectDisconnect.TabIndex = 0;
      this.button_ConnectDisconnect.Text = "Connect";
      this.button_ConnectDisconnect.UseVisualStyleBackColor = true;
      this.button_ConnectDisconnect.Click += new System.EventHandler( this.button_ConnectDisconnect_Click );
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.BottomToolStripPanel
      // 
      this.toolStripContainer1.BottomToolStripPanel.Controls.Add( this.statusStrip1 );
      // 
      // toolStripContainer1.ContentPanel
      // 
      this.toolStripContainer1.ContentPanel.Controls.Add( this.labelTestTime );
      this.toolStripContainer1.ContentPanel.Controls.Add( this.labelTestTimeLab );
      this.toolStripContainer1.ContentPanel.Controls.Add( this.tabControlInterface );
      this.toolStripContainer1.ContentPanel.Controls.Add( this.groupBox_connection );
      this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size( 715, 575 );
      this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer1.Location = new System.Drawing.Point( 0, 0 );
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.Size = new System.Drawing.Size( 715, 646 );
      this.toolStripContainer1.TabIndex = 81;
      this.toolStripContainer1.Text = "toolStripContainer1";
      // 
      // toolStripContainer1.TopToolStripPanel
      // 
      this.toolStripContainer1.TopToolStripPanel.Controls.Add( this.mainMenuStrip );
      this.toolStripContainer1.TopToolStripPanel.Controls.Add( this.serviceControlToolStrip1 );
      // 
      // statusStrip1
      // 
      this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_connected_disconnected} );
      this.statusStrip1.Location = new System.Drawing.Point( 0, 0 );
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size( 715, 22 );
      this.statusStrip1.TabIndex = 80;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel_connected_disconnected
      // 
      this.toolStripStatusLabel_connected_disconnected.Name = "toolStripStatusLabel_connected_disconnected";
      this.toolStripStatusLabel_connected_disconnected.Size = new System.Drawing.Size( 175, 17 );
      this.toolStripStatusLabel_connected_disconnected.Text = "Connected/disconnected status";
      // 
      // serviceControlToolStrip1
      // 
      this.serviceControlToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.serviceControlToolStrip1.Location = new System.Drawing.Point( 3, 24 );
      this.serviceControlToolStrip1.Name = "serviceControlToolStrip1";
      this.serviceControlToolStrip1.ServiceName = "DataPorter";
      this.serviceControlToolStrip1.ServiceResponseTimeout = System.TimeSpan.Parse( "00:00:10" );
      this.serviceControlToolStrip1.Size = new System.Drawing.Size( 307, 25 );
      this.serviceControlToolStrip1.TabIndex = 81;
      this.serviceControlToolStrip1.Text = "DataPorter local service controller";
      // 
      // MainForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.ClientSize = new System.Drawing.Size( 715, 646 );
      this.Controls.Add( this.toolStripContainer1 );
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.Name = "MainForm";
      this.Text = "DataPorter Monitor";
      this.Load += new System.EventHandler( this.MainForm_Load );
      this.VisibleChanged += new System.EventHandler( this.MainForm_VisibleChanged );
      this.Closing += new System.ComponentModel.CancelEventHandler( this.MainForm_Closing );
      this.tabControlInterface.ResumeLayout( false );
      this.tabOPCClient.ResumeLayout( false );
      this.groupBox3.ResumeLayout( false );
      this.tabPage_groups.ResumeLayout( false );
      this.groupBox1.ResumeLayout( false );
      this.tabItems.ResumeLayout( false );
      this.groupBox2.ResumeLayout( false );
      this.tabTransactions.ResumeLayout( false );
      this.groupBox4.ResumeLayout( false );
      this.mainMenuStrip.ResumeLayout( false );
      this.mainMenuStrip.PerformLayout();
      this.groupBox_connection.ResumeLayout( false );
      this.groupBox_connection.PerformLayout();
      this.groupBox_connectedTo.ResumeLayout( false );
      this.groupBox_connectedTo.PerformLayout();
      this.toolStripContainer1.BottomToolStripPanel.ResumeLayout( false );
      this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
      this.toolStripContainer1.ContentPanel.ResumeLayout( false );
      this.toolStripContainer1.TopToolStripPanel.ResumeLayout( false );
      this.toolStripContainer1.TopToolStripPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout( false );
      this.toolStripContainer1.PerformLayout();
      this.statusStrip1.ResumeLayout( false );
      this.statusStrip1.PerformLayout();
      this.ResumeLayout( false );

    }
    #endregion


    private System.Windows.Forms.TabControl tabControlInterface;
    private System.Windows.Forms.Label labelTestTimeLab;
    private System.Windows.Forms.Label labelTestTime;
    private System.Windows.Forms.ImageList imageListStationIcons;
    private System.Windows.Forms.TabPage tabOPCClient;
    private System.Windows.Forms.ListView listViewOPCClient;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label OPCClientNameLabel;
    private System.Windows.Forms.Label OPCtxtServerInfoLabel;
    private System.Windows.Forms.Label OPCtimeStartLabel;
    private System.Windows.Forms.Label OPCNumberOfRegisteredGroupslabel;
    private System.Windows.Forms.Label OPCStateLabel;
    private System.Windows.Forms.Label OPCNumberOfRegisteredTagsLabe;
    private System.Windows.Forms.Label OPCNumberOfWiteSuccesseslabel;
    private System.Windows.Forms.Label OPCNumberOfWiteFailsLabel;
    private System.Windows.Forms.Label OPCNumberOfReadSuccessesLabel;
    private System.Windows.Forms.TabPage tabItems;
    private System.Windows.Forms.TabPage tabTransactions;
    private System.Windows.Forms.NotifyIcon m_Trayicon;
    private System.Windows.Forms.ContextMenu tray_menu;
    private System.Windows.Forms.ToolTip toolTip_main;
    private System.Windows.Forms.Label OPCNumberOfReadFailsLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label OPCSrvUrl;
    private System.Windows.Forms.TabPage tabPage_groups;
    private System.Windows.Forms.ListView listView_group;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label_groupdetails;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label_groupname;
    private System.Windows.Forms.Label label_gr_writesucc;
    private System.Windows.Forms.Label label_gr_readnotsucc;
    private System.Windows.Forms.Label label_gr_writenotsucc;
    private System.Windows.Forms.Label label_gr_readsucc;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label33;
    private System.Windows.Forms.Label label35;
    private System.Windows.Forms.Label label37;
    private System.Windows.Forms.Label label39;
    private System.Windows.Forms.Label label41;
    private System.Windows.Forms.Label label42;
    private System.Windows.Forms.MenuStrip mainMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuItem_monitor;
    private System.Windows.Forms.ToolStripMenuItem menuItem_MenuHide;
    private System.Windows.Forms.ToolStripMenuItem menuItem_MenuReport;
    private System.Windows.Forms.ToolStripMenuItem menuItem_MenuConfigurator;
    private System.Windows.Forms.Label label_item_minavrmax;
    private System.Windows.Forms.Label label_item_detail;
    private System.Windows.Forms.Label label_item_wr_succ;
    private System.Windows.Forms.Label label_item_state;
    private System.Windows.Forms.Label label_item_read_fail;
    private System.Windows.Forms.Label label_item_wr_fail;
    private System.Windows.Forms.Label label_item_read_succ;
    private System.Windows.Forms.Label label_item_value;
    private System.Windows.Forms.Label label_item_activtime;
    private System.Windows.Forms.Label label_item_name;
    private System.Windows.Forms.ListView listView_items;
    private System.Windows.Forms.ListView listView_transactions;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label label_tr_minavmax;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label label_tr_details;
    private System.Windows.Forms.Label label_tr_deadband;
    private System.Windows.Forms.Label label34;
    private System.Windows.Forms.Label label_tr_scanrate;
    private System.Windows.Forms.Label label38;
    private System.Windows.Forms.Label label_tr_updaterate;
    private System.Windows.Forms.Label label45;
    private System.Windows.Forms.Label label_tr_counter;
    private System.Windows.Forms.Label label51;
    private System.Windows.Forms.Label label52;
    private System.Windows.Forms.Label label_tr_name;
    private System.Windows.Forms.Label label_gr_activetime;
    private System.Windows.Forms.Label label_item_lasterror;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.Label label_gr_registeredtags;
    private System.Windows.Forms.Label label29;
    private System.Windows.Forms.Label label_cli_connect_disco_time;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label_gr_minavgmax_readtime;
    private System.Windows.Forms.ImageList ImageListItems;
    private System.Windows.Forms.ImageList imageListTransactions;
    private System.Windows.Forms.ToolStripMenuItem menuItem_exit;
    private System.Windows.Forms.ToolStripMenuItem menuItem_helpmain;
    private System.Windows.Forms.ToolStripMenuItem menuItem_help;
    private System.Windows.Forms.ToolStripMenuItem menuItem_about;
    private System.Windows.Forms.Timer RefreshFormTimer;
    private System.Windows.Forms.Label label_cli_overtime;
    private System.Windows.Forms.Label label_overtime;
    private System.Windows.Forms.GroupBox groupBox_connection;
    private System.Windows.Forms.Label label_hostport;
    private System.Windows.Forms.Button button_ConnectDisconnect;
    private System.Windows.Forms.TextBox textBox_port;
    private System.Windows.Forms.TextBox textBox_Host;
    private System.Windows.Forms.Label label_colon;
    private System.Windows.Forms.GroupBox groupBox_connectedTo;
    private System.Windows.Forms.TextBox textBox_conected_to_version;
    private System.Windows.Forms.TextBox textBox_connected_to_name;
    private System.Windows.Forms.TextBox textBox_connected_to_url;
    private System.Windows.Forms.Button button_ShutDown;
    private System.Windows.Forms.ImageList imageListGroups;
    private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem serviceConfiguratorToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_connected_disconnected;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private CAS.Lib.ControlLibrary.ServiceControlToolStrip serviceControlToolStrip1;
    private System.Windows.Forms.ColumnHeader columnHeaderItem;
    private System.Windows.Forms.ColumnHeader columnHeaderTransactions;
    private System.Windows.Forms.ColumnHeader columnHeaderServers;
    private System.Windows.Forms.ColumnHeader columnHeaderGroup;
    private System.Windows.Forms.ToolStripMenuItem dCOMConfiguratorToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem licenseInfomToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openLogContainingFolderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enterTheUnlockCodeToolStripMenuItem;
  }
}