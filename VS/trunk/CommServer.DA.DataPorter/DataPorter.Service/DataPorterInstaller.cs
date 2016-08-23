//<summary>
//  Title   : Product installation class
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    MPostol created
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.ComponentModel;
using System.Configuration.Install;

namespace CAS.DataPorter
{
  /// <summary>
  /// Product installation class
  /// </summary>
  [RunInstaller( true )]
  public partial class DataPorterInstaller: Installer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataPorterInstaller"/> class.
    /// </summary>
    public DataPorterInstaller()
    {
      InitializeComponent();
#if DEBUG
      if ( System.Windows.Forms.MessageBox.Show
        (
        "To debug attach to the process. Cancel to abort installation",
        "Main form installer", System.Windows.Forms.MessageBoxButtons.OKCancel
        ) != System.Windows.Forms.DialogResult.OK
        )
        throw new InstallException( "Installation aborted by used" );
#endif
    }
  }
}