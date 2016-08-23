//_______________________________________________________________
//  Title   : Program - starting point for the application.
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.OPCViewer;
using System;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace CAS.CommServer.DA.DataPorter.OPCViewer
{
  /// <summary>
  /// Class Program.
  /// </summary>
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
      string _commandLine = Environment.CommandLine;
      if (_commandLine.ToLower().Contains("debugstop"))
        MessageBox.Show("Attach debug point");
      DoInstallLicense(_commandLine);
#endif
      try
      {
        SecurityPermission permission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
        if (!SecurityManager.IsGranted(permission))
        {
          string msg = "";
          msg += "This application requires permission to access unmanaged code ";
          msg += "in order to connect to COM-DA servers directly.\r\n\r\n";
          msg += "Connections to XML-DA servers will not be affected.";
          MessageBox.Show(msg, "CAS OPCViewer Data Access Client");
        }
        DoApplicationRun(Application.Run);
      }
      catch (Exception e)
      {
        MessageBox.Show("An unexpected exception occurred. Application exiting.\r\n\r\n" + e.Message,
          "OPCViewer - Data Access Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    [System.Diagnostics.Conditional("DEBUG")]
    internal static void DoInstallLicense(string m_commandLine)
    {
      if (!m_commandLine.ToLower().Contains(m_InstallLicenseString))
        return;
      try
      {
        InstallLicense(false);
      }
      catch (Exception ex)
      {
        MessageBoxShow("License installation has failed, reason: " + ex.Message);
      }
    }
    internal static void DoApplicationRun(Action<Form> applicationRun)
    {
      MainFormV2008 _mainForm = new MainFormV2008();
      applicationRun(_mainForm);
    }
    internal static Action<bool> InstallLicense { get { return m_InstallLicense; } set { m_InstallLicense = value; } }
    internal static Func<string, DialogResult> MessageBoxShow { get { return m_MessageBoxShow; } set { m_MessageBoxShow = value; } }

    private static Action<bool> m_InstallLicense = Lib.CodeProtect.LibInstaller.InstalLicense;
    private static Func<string, DialogResult> m_MessageBoxShow = MessageBox.Show;
    private readonly static string m_InstallLicenseString = "installic";

  }
}
