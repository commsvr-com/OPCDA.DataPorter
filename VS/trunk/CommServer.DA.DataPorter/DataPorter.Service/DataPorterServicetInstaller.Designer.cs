//<summary>
//  Title   : DataPorter service installer
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

namespace CAS.DataPorter
{
  partial class DataPorterServicetInstaller
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.serviceProcessInstaller_DataPorter = new System.ServiceProcess.ServiceProcessInstaller();
      this.serviceInstaller_DataPorter = new System.ServiceProcess.ServiceInstaller();
      // 
      // serviceProcessInstaller_DataPorter
      // 
      this.serviceProcessInstaller_DataPorter.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
      this.serviceProcessInstaller_DataPorter.Password = null;
      this.serviceProcessInstaller_DataPorter.Username = null;
      // 
      // serviceInstaller_DataPorter
      // 
      this.serviceInstaller_DataPorter.Description = "DataPorter is an independent package of the CommServer software family. It is des" +
    "igned to integrate industrial applications - as an engine to port data between m" +
    "ost popular standards.";
      this.serviceInstaller_DataPorter.ServiceName = "DataPorter";
      // 
      // DataPorterServicetInstaller
      // 
      this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller_DataPorter,
            this.serviceInstaller_DataPorter});

    }

    #endregion

    private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller_DataPorter;
    private System.ServiceProcess.ServiceInstaller serviceInstaller_DataPorter;
  }
}