//<summary>
//  Title   : DataPorter component
//  System  : Microsoft Visual C# .NET
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CAS.DataPorter.Configurator;
using CAS.Lib.CodeProtect.Controls;
using CAS.Lib.CodeProtect.LicenseDsc;
using CAS.Lib.CodeProtect.Properties;
using CAS.Lib.ControlLibrary;
using CAS.Lib.DeviceSimulator;
using CAS.Lib.RTLib.Processes;
using Configuration = CAS.DataPorter.AppConfigManagement;
using CAS.Lib.CodeProtect;
using CAS.DataPorter.RemoteAccess;
using System.Threading;

namespace CAS.DataPorter
{
  /// <summary>
  /// DataPorter component
  /// </summary>
  [LicenseProvider(typeof(CodeProtectLP))]
  [GuidAttribute("FB08CA65-AE23-4322-83CA-010D229306AA")]
  public partial class Main : Component
  {
    #region private
    private bool isStarted = false;
    private static CAS.Lib.RTLib.Processes.Stopwatch m_RunTime = new CAS.Lib.RTLib.Processes.Stopwatch();
    private string src = typeof(Main).ToString();
    private uint? m_RunTimeConstrain = 180;
    private uint? m_VolumeConstrain = 10;
    private CAS.Lib.RTLib.Processes.TraceEvent m_tracer = new CAS.Lib.RTLib.Processes.TraceEvent("CAS.Lib.DataPorter");
    private static string cProductName;
    private static string cProductVersion;
    private static HTTPSoapServer myHTTPSoapServer;
    private static TCPBinaryServer myTCPBinaryServer;

    static Main()
    {
      MainComponent = null;
      ulong times1 = m_RunTime.Start;
      cProductName = Assembly.GetExecutingAssembly().GetName().Name;
      cProductVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      OPCDataQueue.DisconnectAllServers();
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }
    private void InitializationClient()
    {
      Device m_device;
      BaseStation.ItemDescriber.XMLManagement xml_desc = new BaseStation.ItemDescriber.XMLManagement();
      Main.m_ds_dsc = new BaseStation.ItemDescriber.ItemDecriberDataSet();
      xml_desc.readXMLFile(Main.m_ds_dsc, CAS.DataPorter.Properties.Settings.Default.ItemDscConfigurationFile);
      //Device initialization:
      m_device = new CAS.Lib.DeviceSimulator.Device();
      HTTPSoapServer.SetDevice(m_device);
      //initialization from xml file
      //servers/groups/tags initialization
      using (ConfigurationManagement cm = new ConfigurationManagement())
      {
        cm.ReadConfiguration(AppConfigManagement.filename);
        foreach (OPCCliConfiguration.ServersRow srvdsc in cm.Configuartion.Servers)
          //server initialization
          OPCDataQueue.CrateServer(srvdsc, ref m_VolumeConstrain);
        foreach (OPCCliConfiguration.TransactionsRow transdsc in cm.Configuartion.Transactions)
          OPCDataQueue.CreateTransaction(transdsc);
      }
      OPCDataQueue.SwitchOnScanning();
      MonitorInterface.Start(cProductName, cProductVersion);
    }
    private void GuardTimer_Tick(object sender, EventArgs e)
    {
      if (this.RunTimeConstrain.HasValue &&
        RunTime.Seconds > this.RunTimeConstrain.Value)
      {
        new EventLogMonitor("This is demo version - real time server has stopped", EventLogEntryType.Warning, 0, 1888).WriteEntry();
        this.Close();
      }
      if (Manager.NumOfErrors > 0)
        new EventLogMonitor("DataPorter finished with Assert error", System.Diagnostics.EventLogEntryType.Error, 0, 0).WriteEntry();
    }
    private void InitializeAdditionalComponent()
    {
      if (Configuration.HTTPSoapPort > 0)
      {
        myHTTPSoapServer = new HTTPSoapServer(Configuration.HTTPSoapPort);
        myHTTPSoapServer.Start();
      }
      if (Configuration.TCPBinaryPort > 0)
      {
        myTCPBinaryServer = new TCPBinaryServer(Configuration.TCPBinaryPort);
        myTCPBinaryServer.Start();
      }
    }
    private void ShowAboutDialog()
    {
      string usr = this.UserOrganization + "[" + this.UserEmail + "]";
      Assembly cMyAss = Assembly.GetEntryAssembly();
      using (AboutForm cAboutForm = new AboutForm(null, usr, cMyAss))
      {
        using (Licences cLicDial = new Licences())
        {
          cAboutForm.ShowDialog();
        }
      }
    }
    private void ShowAboutDialogInSTAThread()
    {
      //About box contains web browser control that must be run in STA!!
      Thread th = new Thread(new ThreadStart(ShowAboutDialog));
      th.SetApartmentState(ApartmentState.STA);
      th.Start();
    }
    private void ValidateLicense(ref uint? runTimeConstrain, ref uint? volumeConstrain)
    {
      License lic = null;
      bool m_DemoVer = true;
      if (!LicenseManager.IsValid(this.GetType(), this, out lic))
        Tracer.TraceWarning(157, src, string.Format(Resources.Tx_LicNoFileErr + Resources.Tx_LicCap));
      else
      {
        using (lic)
        {
          LicenseFile m_license = lic as LicenseFile;
          MaintenanceControlComponent mcc = new MaintenanceControlComponent();
          if (mcc.Warning != null)
            Tracer.TraceInformation(159, this.GetType().Name, "The following warning(s) appeared during loading of the license: " + mcc.Warning);
          UserOrganization = m_license.User.Organization;
          UserEmail = m_license.User.Email;
          Debug.Assert(m_license != null);
          if (!String.IsNullOrEmpty(m_license.FailureReason))
            Tracer.TraceWarning(167, src, string.Format(m_license.FailureReason + Resources.Tx_LicCap));
          else
          {
            m_DemoVer = false;
            if (m_license.RunTimeConstrain > 0)
              runTimeConstrain = 60 * 60 * (uint)m_license.RunTimeConstrain;
            else
              runTimeConstrain = null;
            if (m_license.VolumeConstrain > 0)
              volumeConstrain = (uint)m_license.VolumeConstrain;
            else
              volumeConstrain = null;
          }
        }
      }
      if (m_DemoVer)
        Tracer.TraceWarning(183, src, string.Format(Resources.Tx_LicDemoModeInfo + Resources.Tx_LicCap));
    }
    #endregion

    #region internal
    internal event EventHandler ShutdownRequest;
    internal void Close()
    {
      if (ShutdownRequest != null)
        ShutdownRequest(this, EventArgs.Empty);
    }
    internal static BaseStation.ItemDescriber.ItemDecriberDataSet m_ds_dsc;
    internal static Main MainComponent { get; private set; }
    internal void SystemExceptionHandler(System.Exception e, short line, string source)
    {
      string msg = string.Format("Exception in {0} with error: {1}", source,
        CAS.Lib.RTLib.Processes.TraceEvent.GetMessageWithExceptionNameFromExceptionIncludingInnerException(e));
      m_tracer.TraceWarning(line, source, msg);
    }
    internal CAS.Lib.RTLib.Processes.TraceEvent Tracer { get { return m_tracer; } }
    internal uint? RunTimeConstrain { get { return m_RunTimeConstrain; } }
    internal string UserOrganization { get; private set; }
    internal string UserEmail { get; private set; }
    /// <summary>
    /// properties that gives access to time in seconds that the program runs
    /// </summary>
    internal static TimeSpan RunTime
    {
      get
      {
        return new TimeSpan(0, 0, Convert.ToInt32(CAS.Lib.RTLib.Processes.Stopwatch.ConvertTo_s(m_RunTime.Read)));
      }
    }
    #endregion

    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    public Main()
    {
      InitializeComponent();
      MainComponent = this;// this must be set before initialization of other elements, this is due to fact that that some elements can use tracer from this component
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="DataPorter"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public Main(IContainer container)
      : this()
    {
      container.Add(this);
    }
    /// <summary>
    /// Starts the DataPorter
    /// </summary>
    public void Start()
    {
      if (!isStarted)
      {
        try
        {
          //System.Diagnostics.Debug.Assert( MainComponent == null );
          if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
          {
            ValidateLicense(ref m_RunTimeConstrain, ref m_VolumeConstrain);
            InitializationClient();
          }
          AssemblyName nm = Assembly.GetExecutingAssembly().GetName();
          string msg = "Product {0} Rel {1} started.";
          Tracer.TraceInformation(247, src, string.Format(msg, nm.FullName, nm.Version));
          if (m_RunTimeConstrain.HasValue)
            Tracer.TraceInformation
              (250, src, string.Format("Runtime of the product is constrained up to {0} minutes.", m_RunTimeConstrain.Value / 60));
          const string vmsg = "The license allows you to add {0} more tags.";
          Tracer.TraceInformation
            (253, src, string.Format(vmsg, m_VolumeConstrain.GetValueOrDefault(uint.MaxValue)));
          msg = "Starting the application. Product name: {0}, product version: {1}";
          new EventLogMonitor(String.Format(msg, Application.ProductName, Application.ProductVersion), EventLogEntryType.Information, 0, 1829).WriteEntry();
          InitializeAdditionalComponent();
        }
        catch (LicenseException ex)
        {
          Tracer.TraceWarning(262, src, String.Format(Properties.Resources.tx_DataPorter_MainForm_LicenceExceptionOnInitialisation, ex.Message));
          this.Close();
        }
        catch (Exception ex)
        {
          string msg = "Cannot start the application. Product name: {0}, product version: {1} because of the exception {2}: {3}";
          msg = String.Format(msg, Application.ProductName, Application.ProductVersion, ex.GetType().FullName, ex.Message);
          Tracer.TraceError(269, src, msg);
          new EventLogMonitor(msg, EventLogEntryType.Error, 0, 1822).WriteEntry();
          this.Close();
        }
      }
    }
    /// <summary>
    /// Stops  the DataPorter.
    /// </summary>
    public void Stop()
    {
      if (isStarted)
      {
        string msg = "Closing the application. Product name: {0}, product version: {1}";
        new EventLogMonitor(String.Format(msg, Application.ProductName, Application.ProductVersion), EventLogEntryType.Information, 0, 1829).WriteEntry();
        isStarted = false;
        OPCDataQueue.DisconnectAllServers();
      }
    }
    #endregion

  }
}
