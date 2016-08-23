//<summary>
//  Title   : Data Porter Splash Screen
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    mzbrzezny: 2004: created
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http://www.cas.eu
//</summary>

using System;
using System.Reflection;
using System.Windows.Forms;

namespace CAS.DataPorter.Monitor
{
  /// <summary>
  /// Summary description for SplashScreen.
  /// </summary>
  public class SplashScreen: System.Windows.Forms.Form
  {
    private Label label1;
    private GroupBox groupBox1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    /// <summary>
    /// Initializes a new instance of the <see cref="SplashScreen"/> class.
    /// </summary>
    public SplashScreen()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if ( disposing )
      {
        if ( components != null )
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.PictureBox n_PictureBox;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SplashScreen ) );
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      n_PictureBox = new System.Windows.Forms.PictureBox();
      ( (System.ComponentModel.ISupportInitialize)( n_PictureBox ) ).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // n_PictureBox
      // 
      n_PictureBox.Dock = System.Windows.Forms.DockStyle.Top;
      n_PictureBox.Image = ( (System.Drawing.Image)( resources.GetObject( "n_PictureBox.Image" ) ) );
      n_PictureBox.Location = new System.Drawing.Point( 3, 16 );
      n_PictureBox.Name = "n_PictureBox";
      n_PictureBox.Size = new System.Drawing.Size( 442, 70 );
      n_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      n_PictureBox.TabIndex = 0;
      n_PictureBox.TabStop = false;
      n_PictureBox.UseWaitCursor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 238 ) ) );
      this.label1.Location = new System.Drawing.Point( 12, 121 );
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size( 46, 18 );
      this.label1.TabIndex = 1;
      this.label1.Text = "label1";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label1.UseWaitCursor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add( n_PictureBox );
      this.groupBox1.Controls.Add( this.label1 );
      this.groupBox1.Location = new System.Drawing.Point( 0, 0 );
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size( 448, 146 );
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.UseWaitCursor = true;
      // 
      // SplashScreen
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.ClientSize = new System.Drawing.Size( 448, 148 );
      this.Controls.Add( this.groupBox1 );
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.Name = "SplashScreen";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Splash screen";
      this.UseWaitCursor = true;
      this.Load += new System.EventHandler( this.SplashScreen_Load );
      ( (System.ComponentModel.ISupportInitialize)( n_PictureBox ) ).EndInit();
      this.groupBox1.ResumeLayout( false );
      this.groupBox1.PerformLayout();
      this.ResumeLayout( false );

    }
    #endregion

    private void SplashScreen_Load( object sender, EventArgs e )
    {
      this.label1.Text = Assembly.GetExecutingAssembly().GetName().Name +
        " ver:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
  }
}
