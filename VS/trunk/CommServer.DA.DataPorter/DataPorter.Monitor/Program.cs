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
using System.Windows.Forms;

namespace CAS.DataPorter.Monitor
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
#if DEBUG
      if ( m_cmmdLine.ToLower().Contains( "debugstop" ) )
        MessageBox.Show( "Atach debug point", "Debug entry point", MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
#endif
      if ( m_cmmdLine.ToLower().Contains( "installic" ) )
      {
        try
        {
          CAS.Lib.CodeProtect.LibInstaller.InstalLicense();
        }
        catch ( Exception ex )
        {
          MessageBox.Show( "License instalation has failed, reason: " + ex.Message );
        }
      }
      MainForm myform = new MainForm();
      try { Application.Run( myform ); }
      catch ( Exception ) { }
    }
  }
}
