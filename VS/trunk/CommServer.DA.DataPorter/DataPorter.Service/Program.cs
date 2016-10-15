//<summary>
//  Title   : Program class for DataPorter
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

using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace CAS.DataPorter
{
  class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [MTAThread]
    static void Main()
    {
      string m_cmmdLine = Environment.CommandLine;
      if ( m_cmmdLine.ToLower().Contains( "installic" ) )
      {
        try
        {
          CAS.Lib.CodeProtect.LibInstaller.InstallLicense( true );
        }
        catch ( Exception ex )
        {
          MessageBox.Show( "License installation has failed, reason: " + ex.Message );
        }
      }
      if ( m_cmmdLine.ToLower().Contains( "no service" ) )
      {
#if DEBUG
        if ( m_cmmdLine.ToLower().Contains( "debugstop" ) )
          MessageBox.Show( "Attach debug point", "Debug entry point", MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
#endif
        MainForm myform = new MainForm();
        try { Application.Run( myform ); }
        catch ( Exception ) { }
      }
      else
      {
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[] 
			    { 
				    new DataPorterService() 
			    };
        ServiceBase.Run( ServicesToRun );
      }
    }
  }
}
