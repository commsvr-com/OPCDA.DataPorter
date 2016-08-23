//<summary>
//  Title   : Main DataPorter Component
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
  partial class Main
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.OPCClientDa = new CAS.Lib.OPCClient.Da.Main(this.components);
      this.timer_Guard = new System.Windows.Forms.Timer(this.components);
      // 
      // timer_Guard
      // 
      this.timer_Guard.Enabled = true;
      this.timer_Guard.Interval = 1000;
      this.timer_Guard.Tick += new System.EventHandler(this.GuardTimer_Tick);

    }

    #endregion

    private CAS.Lib.OPCClient.Da.Main OPCClientDa;
    private System.Windows.Forms.Timer timer_Guard;
  }
}
