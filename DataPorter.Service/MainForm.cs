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
//              some of the text outputs are not longer neccessary and they are removed.
//    Mzbrzezny - 11-03-05
//      created (base file mianform from PR04XX_SWX_AKOM)
//      added tolltips and tray icon and menu
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: 42' 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
// </summary>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using CAS.Lib.RTLib.Processes;

namespace CAS.DataPorter
{
  /// <summary>
  /// Main form for DataPorter
  /// </summary>
  public partial class MainForm: System.Windows.Forms.Form
  {
    #region constructor
    internal MainForm()
    {
      InitializeComponent();
      m_DadataPorter.Start();
      m_DadataPorter.ShutdownRequest += new EventHandler( Application_ShutdownRequest );
    }
    #endregion
    #region Event handlers
    private void MainForm_Closing( object sender, System.ComponentModel.CancelEventArgs e )
    {
      if ( this.DialogResult == DialogResult.Abort )
      {
        new EventLogMonitor( "Program initialization aborted", EventLogEntryType.Warning, 0, 1880 ).WriteEntry();
        e.Cancel = false;
        return;
      }
      string message = "Are you sure to close the application";
      string caption = this.Text;
      MessageBoxButtons buttons = MessageBoxButtons.YesNo;
      DialogResult result;
      // Displays the MessageBox.
      result = MessageBox.Show( this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );
      e.Cancel = result != DialogResult.Yes;
    }
    private void MainForm_Load( object sender, System.EventArgs e )
    {
      this.Hide();
    }
    private delegate void InvokeDelegate();
    void Application_ShutdownRequest( object sender, EventArgs e )
    {
      if ( InvokeRequired )
      {
        BeginInvoke( new InvokeDelegate( Close ) );
      }
      else
        this.Close();
    }
    #endregion Mainmenu
  }//MainForm
}
