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

using System.ComponentModel;
using System.Configuration.Install;

namespace CAS.DataPorter
{
  /// <summary>
  /// DataPorter service installer
  /// </summary>
  [RunInstaller( true )]
  public partial class DataPorterServicetInstaller: Installer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataPorterServicetInstaller"/> class.
    /// </summary>
    public DataPorterServicetInstaller()
    {
      InitializeComponent();
    }
  }
}
