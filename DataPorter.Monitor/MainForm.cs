// <summary>
//  Title   : DataPorter Client OPC Mainform
//  Author  : MZbrzezny
//  System  : Microsoft Visual C# .NET
//  History :
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//    20081222: mzbrzezny: 
//    changes that allows to install new license even if the previous one has expired.
//    20080901: mzbrzezny: 
//    - main window is a bit resized
//    - DataPorter starts hidden
//    - run time is in HH:MM:SS format
//    20080704: mzbrzezny: the new configurator is OPCViewer and it must be opened from different location.
//    20080704: mzbrzezny: after changes to Transaction and Operation engine, 
//              some of the text outputs are not longer necessary and they are removed.
//    Mzbrzezny - 11-03-05
//      created (base file mianform from PR04XX_SWX_AKOM)
//      added toll tips and tray icon and menu
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: 42' 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
// </summary>

using CAS.DataPorter.Lib.BaseStation.Management;
using CAS.DataPorter.Monitor.Interface;
using CAS.DataPorter.Monitor.Properties;
using CAS.Lib.CodeProtect;
using CAS.Lib.ControlLibrary;
using CAS.Lib.OPCClient.Da.Management;
using CAS.Lib.RTLib.Processes;
using CAS.Windows.Forms.CodeProtectControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace CAS.DataPorter.Monitor
{
  /// <summary>
  /// Main form for DataPorter
  /// </summary>
  public partial class MainForm : Form
  {

    #region private
    #region VAR
    private MonitorInterfaceAbstract remoterserver = null;
    #endregion

    /// <summary>
    /// Shows the about dialog.
    /// </summary>
    private void ShowAboutDialog()
    {
      Assembly cMyAss = Assembly.GetEntryAssembly();
      using (AboutForm cAboutForm = new AboutForm(null, String.Empty, cMyAss))
      {
        cAboutForm.ShowDialog();
      }
    }

    #region refresh procedures
    private void RefreshMainForm()
    {
      if (remoterserver != null)
      {
        this.labelTestTime.Text = remoterserver.GetRunTime().ToString();
        this.button_ConnectDisconnect.Text = Resources.tx_DataPorter_MainForm_buttonDisconnect;
        this.toolStripStatusLabel_connected_disconnected.Text = Resources.tx_DataPorter_MainForm_status_connected;
      }
      else
      {
        this.labelTestTime.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.textBox_connected_to_name.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.textBox_conected_to_version.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.textBox_connected_to_url.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.button_ShutDown.Enabled = false;
        this.button_ConnectDisconnect.Text = Resources.tx_DataPorter_MainForm_buttonConnect;
        this.toolStripStatusLabel_connected_disconnected.Text = Resources.tx_DataPorter_MainForm_status_disconnect;
      }
    }
    /// <summary>
    /// Refresh OPC Client Page
    /// </summary>
    private void RefreshOPCPage()
    {
      OPCClientStatistics.OPCClientStatisticsInternal curr = null;
      if (remoterserver != null)
      {
        var ConnectionStatesList = remoterserver.GetOPCClientStatisticsConnectionStatesList();
        foreach (ListViewItem lvi in listViewOPCClient.Items)
        {
          lvi.ImageIndex = (int)ConnectionStatesList[(uint)lvi.Tag];
        }
        if ((listViewOPCClient.SelectedItems.Count > 0) && (listViewOPCClient.SelectedItems[0] != null))
        {
          curr = remoterserver.GetOPCClientStatistics((uint)listViewOPCClient.SelectedItems[0].Tag);
        }
      }
      else
      {
        listViewOPCClient.Items.Clear();
      }
      if (curr != null)
      {
        OPCClientNameLabel.Text = curr.myClientName;
        toolTip_main.SetToolTip(this.OPCClientNameLabel, "Name assigned by client:\r\n" + curr.myClientName);
        OPCNumberOfReadFailsLabel.Text = curr.NumberOfReadFails.ToString();
        OPCNumberOfReadSuccessesLabel.Text = curr.NumberOfReadSuccesses.ToString();
        OPCNumberOfRegisteredGroupslabel.Text = curr.NumberOfRegisteredGroups.ToString();
        OPCNumberOfRegisteredTagsLabe.Text = curr.NumberOfRegisteredTags.ToString();
        OPCNumberOfWiteFailsLabel.Text = curr.NumberOfWiteFails.ToString();
        OPCNumberOfWiteSuccesseslabel.Text = curr.NumberOfWiteSuccesses.ToString();
        label_cli_overtime.Text = curr.StatPriority;
        OPCStateLabel.Text = curr.state;
        OPCtimeStartLabel.Text = curr.timeStart;
        OPCtxtServerInfoLabel.Text = curr.TxtServerInfo;
        toolTip_main.SetToolTip(this.OPCtxtServerInfoLabel, "Server vendor information (from GetStatus):\r\n" + curr.TxtServerInfo);
        OPCSrvUrl.Text = curr.myURL;
        toolTip_main.SetToolTip(this.OPCSrvUrl, "Server url:\r\n" + curr.myURL);
        label_cli_connect_disco_time.Text = curr.Connect_NotConnect_TimeInSec;
        listViewOPCClient.Refresh();
      }
      else
      {
        OPCClientNameLabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCNumberOfReadFailsLabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCNumberOfReadSuccessesLabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCNumberOfRegisteredGroupslabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCNumberOfRegisteredTagsLabe.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCNumberOfWiteFailsLabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCNumberOfWiteSuccesseslabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_cli_overtime.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCStateLabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCtimeStartLabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCtxtServerInfoLabel.Text = Resources.tx_DataPorter_MainForm_noconnection;
        OPCSrvUrl.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_cli_connect_disco_time.Text = Resources.tx_DataPorter_MainForm_noconnection;
        toolTip_main.SetToolTip(this.OPCClientNameLabel, "");
        toolTip_main.SetToolTip(this.OPCtxtServerInfoLabel, "");
        toolTip_main.SetToolTip(this.OPCSrvUrl, "");
      }
    }
    /// <summary>
    /// Refresh Group page
    /// </summary>
    private void RefreshGroupPage()
    {
      OPCGroup.OPCGroupStatisticsInternal curr = null;
      if (remoterserver != null)
      {
        var ConnectionStatesList = remoterserver.GetGroupStatisticConnectionStatesList();
        foreach (ListViewItem lvi in listView_group.Items)
        {
          lvi.ImageIndex = (int)ConnectionStatesList[(uint)lvi.Tag];
        }

        if ((listView_group.SelectedItems.Count > 0) && (listView_group.SelectedItems[0] != null))
        {
          curr = remoterserver.GetGroupStatistics((uint)listView_group.SelectedItems[0].Tag);
        }
      }
      else
      {
        listView_group.Items.Clear();
      }
      if (curr != null)
      {
        label_groupname.Text = curr.Name;
        label_groupdetails.Text = curr.ToString();
        label_gr_minavgmax_readtime.Text = curr.ReadCycleStatistics;
        label_gr_writenotsucc.Text = curr.NumberOfWiteFails.ToString();
        label_gr_writesucc.Text = curr.NumberOfWiteSuccesses.ToString();
        label_gr_readnotsucc.Text = curr.NumberOfReadFails.ToString();
        label_gr_readsucc.Text = curr.NumberOfReadSuccesses.ToString();
        label_gr_registeredtags.Text = curr.NumberOfTags.ToString();
        label_gr_activetime.Text = curr.ActiveTime.ToString();
        listView_group.Refresh();
      }
      else
      {
        label_groupname.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_groupdetails.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_gr_minavgmax_readtime.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_gr_writenotsucc.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_gr_writesucc.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_gr_readnotsucc.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_gr_readsucc.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_gr_registeredtags.Text = Resources.tx_DataPorter_MainForm_noconnection;
        label_gr_activetime.Text = Resources.tx_DataPorter_MainForm_noconnection;
      }
    }
    /// <summary>
    /// Refreshing Item Page
    /// </summary>
    private void RefreshItemPage()
    {
      OPCTag.OPCTagStatisticsInternal curr = null;
      if (remoterserver != null)
      {
        var ConnectionStatesList = remoterserver.GetTagStatisticConnectionStatesList();
        foreach (ListViewItem lvi in listView_items.Items)
        {
          lvi.ImageIndex = (int)ConnectionStatesList[(long)lvi.Tag];
        }
        if ((listView_items.SelectedItems.Count > 0) && (listView_items.SelectedItems[0] != null))
        {
          curr = remoterserver.GetTagStatistics((long)listView_items.SelectedItems[0].Tag);
        }
      }
      else
      {
        listView_items.Items.Clear();
      }
      if (curr != null)
      {
        this.label_item_name.Text = curr.Name;
        this.label_item_detail.Text = curr.ToString();
        this.label_item_value.Text = curr.StringValue;
        this.label_item_state.Text = curr.Value.Quality.ToString();
        this.label_item_minavrmax.Text = curr.MinAvrMaxRateStat;
        this.label_item_activtime.Text = curr.ActiveTime.ToString();
        this.label_item_wr_succ.Text = curr.NumberOfWiteSuccesses.ToString();
        this.label_item_read_fail.Text = curr.NumberOfReadFails.ToString();
        this.label_item_read_succ.Text = curr.NumberOfReadSuccesses.ToString();
        this.label_item_wr_fail.Text = curr.NumberOfWiteFails.ToString();
        this.label_item_lasterror.Text = curr.LastErrorMessage;
        this.listView_items.Refresh();
      }
      else
      {
        this.label_item_name.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_detail.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_value.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_state.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_minavrmax.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_activtime.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_wr_succ.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_read_fail.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_read_succ.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_wr_fail.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_item_lasterror.Text = Resources.tx_DataPorter_MainForm_noconnection;
      }
    }
    /// <summary>
    /// Refreshing Item Page
    /// </summary>
    private void RefreshTransactionPage()
    {
      TransactionStatistics.TransactionStatisticsInternal curr = null;
      if (remoterserver != null)
      {

        var ConnectionStatesList = remoterserver.GetTransactionStatisticConnectionStatesList();
        foreach (ListViewItem lvi in listView_transactions.Items)
        {
          lvi.ImageIndex = (int)ConnectionStatesList[(long)lvi.Tag];
        }
        if ((listView_transactions.SelectedItems.Count > 0) && (listView_transactions.SelectedItems[0] != null))
        {
          curr = remoterserver.GetTransactionStatistics((long)listView_transactions.SelectedItems[0].Tag);
        }
      }
      else
      {
        listView_transactions.Items.Clear();
      }
      if (curr != null)
      {
        this.label_tr_name.Text = curr.Name;
        this.label_tr_details.Text = curr.ToString();
        this.label_tr_counter.Text = curr.SuccessfullExecutionCountToTotalExecutionTriesAndCoefiecientAsString;
        this.label_tr_minavmax.Text = curr.MinAvrMaxTransationRateStatistics;
        this.label_tr_scanrate.Text = curr.TransationUpdateRate.ToString();
        this.label_tr_deadband.Text = curr.Deadband.ToString();
        bool hasValue = curr.MinUpdateRate.HasValue;
        this.label_tr_updaterate.Text = hasValue ? curr.MinUpdateRate.Value.ToString() : Properties.Resources.tx_DataPorter_MainForm_noconnection;
        listView_transactions.Refresh();
      }
      else
      {
        this.label_tr_name.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_tr_details.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_tr_counter.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_tr_minavmax.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_tr_scanrate.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_tr_deadband.Text = Resources.tx_DataPorter_MainForm_noconnection;
        this.label_tr_updaterate.Text = Resources.tx_DataPorter_MainForm_noconnection;
      }
    }
    #endregion  refresh procedures
    private void RefreshFormTimer_Tick(object sender, EventArgs e)
    {
      try
      {
        RefreshMainForm();
        if (tabControlInterface.SelectedTab.Name == this.tabOPCClient.Name)
          RefreshOPCPage();
        if (tabControlInterface.SelectedTab.Name == this.tabPage_groups.Name)
          RefreshGroupPage();
        if (tabControlInterface.SelectedTab.Name == this.tabItems.Name)
          RefreshItemPage();
        if (tabControlInterface.SelectedTab.Name == this.tabTransactions.Name)
          RefreshTransactionPage();
      }
      catch
      {
        remoterserver = null;
        MessageBox.Show(Resources.tx_DataPorter_MainForm_warning_disconnected + this.textBox_connected_to_url.Text);
      }
      if (CAS.Lib.RTLib.Processes.Manager.NumOfErrors > 0)
      {
        new CAS.Lib.RTLib.Processes.EventLogMonitor
          (
          "DataPorter finished with Assert error", System.Diagnostics.EventLogEntryType.Error, 0, 0
          ).WriteEntry();
      }
    }
    private void MainForm_VisibleChanged(object sender, EventArgs e)
    {
      RefreshFormTimer.Enabled = this.Visible;
    }
    #region Pages Initiation
    private void InitOPCPage()
    {
      listViewOPCClient.Items.Clear();
      foreach (var kvp_srvint in remoterserver.GetOPCClientStatisticsNamesList())
      {
        ListViewItem listItem = new ListViewItem(kvp_srvint.Value);
        listItem.Tag = kvp_srvint.Key;
        listViewOPCClient.Items.Add(listItem);
        listItem.ImageIndex = 0;
        listItem.Selected = true;
      }
      listViewOPCClient.Refresh();
    }
    private void InitGroupPage()
    {
      listView_group.Items.Clear();
      foreach (var kvp_group in remoterserver.GetGroupStatisticNamesList())
      {
        ListViewItem listItem = new ListViewItem(kvp_group.Value);
        listItem.Tag = kvp_group.Key;
        listView_group.Items.Add(listItem);
        listItem.ImageIndex = 0;
        listItem.Selected = true;
      }
      listView_group.Refresh();
    }
    private void InitTagPage()
    {
      listView_items.Items.Clear();
      foreach (var kvp_tag in remoterserver.GetTagStatisticNamesList())
      {

        ListViewItem listItem = new ListViewItem(kvp_tag.Value);
        listItem.Tag = kvp_tag.Key;
        listView_items.Items.Add(listItem);
        listItem.ImageIndex = 0;
        listItem.Selected = true;
      }
      listView_items.Refresh();
    }
    private void InitTransactionPage()
    {
      listView_transactions.Items.Clear();
      foreach (var kvp_tag in remoterserver.GetTransactionStatisticNamesList())
      {
        ListViewItem listItem = new ListViewItem(kvp_tag.Value);
        listItem.Tag = kvp_tag.Key;
        listView_transactions.Items.Add(listItem);
        listItem.ImageIndex = 0;
        listItem.Selected = true;
      }
      listView_transactions.Refresh();
    }
    #endregion  Pages Initiation
    private void InitializeAdditionalComponent()
    {
      if (Settings.Default.HideOnStartup)
      {
        this.WindowState = FormWindowState.Minimized;
      }
      //tray menu
      this.tray_menu = new ContextMenu();
      this.tray_menu.MenuItems.Add(0,
        new System.Windows.Forms.MenuItem("Exit", new System.EventHandler(Exit_click)));
      this.tray_menu.MenuItems.Add(1,
        new System.Windows.Forms.MenuItem("Show", new System.EventHandler(Show_click)));
      this.tray_menu.MenuItems.Add(2,
        new System.Windows.Forms.MenuItem("Hide", new System.EventHandler(Hide_click)));
      this.m_Trayicon.ContextMenu = this.tray_menu;
      //resize handler
      this.Resize += new EventHandler(MainForm_Resize);

      this.textBox_Host.Text = Properties.Settings.Default.MonitorInterfaceHost;
      this.textBox_port.Text = Properties.Settings.Default.MonitorInterfacePort.ToString();

      TcpClientChannel channel = new TcpClientChannel();
      ChannelServices.RegisterChannel(channel, false);

    }
    private void ConnectToRemoteServerAndInitialiseDiagnosticPages()
    {
      string label_connected_to_Text = "tcp://" + this.textBox_Host.Text + ":" +
         this.textBox_port.Text + "/" + Settings.Default.MonitorInterfaceEntryName;
      try
      {
        this.remoterserver = (MonitorInterfaceAbstract)Activator.GetObject
          (typeof(MonitorInterfaceAbstract), label_connected_to_Text);
      }
      catch
      {
        remoterserver = null;
      }
      if (remoterserver != null)
      {
        this.textBox_connected_to_url.Text = label_connected_to_Text;
        //pages initialisation
        try
        {
          this.textBox_connected_to_name.Text = remoterserver.GetProductName();
          this.textBox_conected_to_version.Text = remoterserver.GetProductVersion();
          this.button_ShutDown.Enabled = true;
          InitOPCPage();
          InitGroupPage();
          InitTagPage();
          InitTransactionPage();
          RefreshFormTimer.Enabled = true;
        }
        catch
        {
          remoterserver = null;
          MessageBox.Show(Resources.tx_DataPorter_MainForm_unabletoconnect + this.textBox_connected_to_url.Text);
        }
      }
    }
    #endregion
    #region constructor
    internal MainForm()
    {
      try
      {
        InitializeComponent();
        InitializeAdditionalComponent();
        if (Settings.Default.ConnectToDataPorterServiceOnStartup)
          ConnectToRemoteServerAndInitialiseDiagnosticPages();
        RefreshFormTimer.Enabled = true;
        string msg = "Starting the application. Product name: {0}, product version: {1}";
        new EventLogMonitor(String.Format(msg, Application.ProductName, Application.ProductVersion), EventLogEntryType.Information, 0, 1829).WriteEntry();
      }
      catch (LicenseException ex)
      {
        ShowAboutDialogInSTAThread();
        MessageBox.Show(String.Format(Resources.tx_DataPorter_MainForm_LicenceExceptionOnInitialisation, ex.Message));
        this.DialogResult = DialogResult.Abort;
        this.Close();
      }
      catch (Exception ex)
      {
        string msg = "Cannot start the application. Product name: {0}, product version: {1} becauce of the exception {2}: {3}";
        msg = String.Format(msg, Application.ProductName, Application.ProductVersion, ex.GetType().FullName, ex.Message);
        MessageBox.Show(msg, "Application initialization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        new EventLogMonitor(msg, EventLogEntryType.Error, 0, 1822).WriteEntry();
        this.DialogResult = DialogResult.Abort;
        this.Close();
      }
    }
    #endregion
    #region Event handlers
    #region hide / restore form
    private void MainForm_Resize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
        this.Hide();
    }
    private void Exit_click(Object sender, System.EventArgs e)
    {
      Close();
    }
    private void Hide_click(Object sender, System.EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }
    private void Hide_Form(Object sender, System.EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
      {
        Hide();
      }
    }
    private void Show_click(Object sender, System.EventArgs e)
    {
      Show();
      this.WindowState = FormWindowState.Normal;
    }
    #endregion
    private void button_ConnectDisconnect_Click(object sender, EventArgs e)
    {
      if (remoterserver != null)
      {
        //disconnecting:
        this.remoterserver = null;
        this.button_ConnectDisconnect.Text = Resources.tx_DataPorter_MainForm_buttonConnect;
      }
      else
      {
        this.button_ConnectDisconnect.Text = Resources.tx_DataPorter_MainForm_buttonDisconnect;
        this.ConnectToRemoteServerAndInitialiseDiagnosticPages();
      }
    }
    private void button_ShutDown_Click(object sender, EventArgs e)
    {
      remoterserver.ShutdownRequest();
    }
    private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (this.DialogResult == DialogResult.Abort)
      {
        new EventLogMonitor("Program initialization aborted", EventLogEntryType.Warning, 0, 1880).WriteEntry();
        e.Cancel = false;
        return;
      }
      string message = "Are you sure to close the application";
      string caption = this.Text;
      MessageBoxButtons buttons = MessageBoxButtons.YesNo;
      DialogResult result;
      // Displays the MessageBox.
      result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
      e.Cancel = result != DialogResult.Yes;
    }
    private void MainForm_Load(object sender, System.EventArgs e)
    {
      if (Settings.Default.DispalySplashScreenOnStartup)
      {
        RunMethodAsynchronously runasync = new RunMethodAsynchronously(delegate (object[] param)
       {
         SplashScreen SplashScreenObj = new SplashScreen();
         SplashScreenObj.Show();
         SplashScreenObj.Refresh();
         int time = 1000;
         if (param != null)
           time = (int)param[0];
         System.Threading.Thread.Sleep(time);
         SplashScreenObj.Close();
       });
        runasync.RunAsync(new object[] { 5000 });
      }
      if (Settings.Default.HideOnStartup)
      {
        this.Hide();
      }
    }
    private void menuItem_MenuHide_Click(object sender, System.EventArgs e)
    {
      this.Hide();
    }
    private void RaportGenerator_Click(object sender, System.EventArgs e)
    {
      if (remoterserver != null)
      {
        RunMethodAsynchronously runasync = new RunMethodAsynchronously(delegate (object[] o)
       {
         CAS.Lib.RTLib.Utils.ReportGenerator.DisplayReport(remoterserver.GetReport());
       });
        runasync.RunAsync();
      }
      else
      {
        MessageBox.Show(Resources.tx_DataPorter_MainForm_connecttodoreport);
      }
    }
    private void Exit_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }
    private void Help_Click(object sender, System.EventArgs e)
    {
      RunMethodAsynchronously runasync = new RunMethodAsynchronously(delegate (object[] o)
     {
       try
       {
         Process.Start(Resources.OnlineDocumentation_url);
       }
       catch (Exception)
       {
         MessageBox.Show("Online Documentation", "Cannot start Online Documentation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
       };
     }
      );
      runasync.RunAsync();
    }
    private void About_Click(object sender, System.EventArgs e)
    {
      ShowAboutDialogInSTAThread();
    }

    private void ShowAboutDialogInSTAThread()
    {
      //About box contains web browser controll that must be run in STA!!
      System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(ShowAboutDialog));
      th.SetApartmentState(System.Threading.ApartmentState.STA);
      th.Start();
    }
    private void MenuConfigurator_Click(object sender, EventArgs e)
    {
      RunMethodAsynchronously runasync = new RunMethodAsynchronously(delegate (object[] o)
     {
       string configurationApplication = Path.Combine(Application.StartupPath, "CAS.OPCViewer.exe");
       string arguments = "";
       if (remoterserver != null)
         arguments = remoterserver.GetConfigurationFileName();
       if (!string.IsNullOrEmpty(arguments))
         arguments = string.Format("\"{0}\"", arguments);
       try
       {
         System.Diagnostics.Process.Start(configurationApplication, arguments);
       }
       catch (Exception ex)
       {
         MessageBox.Show(configurationApplication, "Cannot start the configuration application: \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
       };
     }
      );
      runasync.RunAsync();
    }
    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PropertyGrid myGrid = new PropertyGrid();
      myGrid.SelectedObject = Properties.Settings.Default;
      myGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      using (OKCancelForm myConfigurationForm = new OKCancelForm(Resources.ConfigurationFormName))
      {
        UserControl myControl = new UserControl();
        myControl.Controls.Add(myGrid);
        myConfigurationForm.SetUserControl = myControl;
        myConfigurationForm.CanBeAccepted(true);
        if (myConfigurationForm.ShowDialog(this) == DialogResult.OK)
        {
          Properties.Settings.Default.Save();
          MessageBox.Show(Resources.ConfigurationForm_MessageAfterChange);
        }
      }
    }
    private void serviceConfiguratorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //services.msc
      RunMethodAsynchronously runasync = new RunMethodAsynchronously(delegate (object[] o)
     {
       try
       {
         System.Diagnostics.Process.Start("services.msc");
       }
       catch (Exception ex)
       {
         MessageBox.Show("services.msc", "Cannot start the service configuration console:" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
       };
     }
      );
      runasync.RunAsync();
    }
    private void dCOMConfiguratorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //dcomcnfg
      RunMethodAsynchronously runasync = new RunMethodAsynchronously(delegate (object[] o)
     {
       try
       {
         System.Diagnostics.Process.Start("dcomcnfg");
       }
       catch (Exception ex)
       {
         MessageBox.Show("dcomcnfg", "Cannot start the DCOM configuration console:" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
       };
     }
      );
      runasync.RunAsync();
    }
    void listView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
      DataPorterListViewSorter columnSorter = new DataPorterListViewSorter();
      ListView lv = (ListView)sender;
      if (lv.Sorting == SortOrder.Ascending)
      {
        columnSorter.bAscending = true;
        lv.Sorting = SortOrder.Descending;
      }
      else
      {
        columnSorter.bAscending = false;
        lv.Sorting = SortOrder.Ascending;
      }
      lv.ListViewItemSorter = (System.Collections.IComparer)columnSorter;
    }


    #endregion Mainmenu

    private void licenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string usr = "";
      Assembly cMyAss = Assembly.GetEntryAssembly();
      using (LicenseForm cAboutForm = new LicenseForm(null, usr, cMyAss))
      {
        using (Licenses cLicDial = new Licenses())
        {
          cAboutForm.SetAdditionalControl = cLicDial;
          cAboutForm.LicenceRequestMessageProvider = new LicenseForm.LicenceRequestMessageProviderDelegate(delegate () { return cLicDial.GetLicenseMessageRequest(); });
          cAboutForm.ShowDialog();
        }
      }
    }
    private void openLogContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string path = Path.Combine(InstallContextNames.ApplicationDataPath, "log");
      try
      {
        using (Process process = Process.Start(@path)) { }
      }
      catch (Win32Exception)
      {
        MessageBox.Show($"No Log folder exists under this link: {path}. You can create this folder yourself.", "No Log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (Exception _ex)
      {
        MessageBox.Show($"An error ({_ex}) during opening a log folder occurs and the log folder cannot be open", "Problem with log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    private void enterTheUnlockCodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (UnlockKeyDialog dialog = new UnlockKeyDialog())
      {
        dialog.ShowDialog();
      }
    }

  }//MainForm
}
