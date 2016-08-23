//<summary>
//  Title   : DAtaPorter MainForm
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
      this.m_DadataPorter = new CAS.DataPorter.Main( this.components );
      this.SuspendLayout();
      // 
      // MainForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.ClientSize = new System.Drawing.Size( 179, 12 );
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.Name = "MainForm";
      this.ShowInTaskbar = false;
      this.Text = "DataPorter";
      this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
      this.Load += new System.EventHandler( this.MainForm_Load );
      this.Closing += new System.ComponentModel.CancelEventHandler( this.MainForm_Closing );
      this.ResumeLayout( false );

    }
    #endregion

    private CAS.DataPorter.Main m_DadataPorter;
  }
}