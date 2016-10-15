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

using CAS.Lib.CodeProtect;
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
      string _commandLine = Environment.CommandLine;
#if DEBUG
      if (_commandLine.ToLower().Contains("debugstop"))
        MessageBox.Show("Attach debug point", "Debug entry point", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
#endif
      if (_commandLine.ToLower().Contains("installic"))
      {
        try
        {
          LibInstaller.InstallLicense(false);
        }
        catch (Exception ex)
        {
          MessageBox.Show("License installation has failed, reason: " + ex.Message);
        }
      }
      MainForm _form = new MainForm();
      try { Application.Run(_form); }
      catch (Exception) { }
    }
  }
}
