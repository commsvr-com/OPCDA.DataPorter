//  Title   : Reads application configuration file
//  Author  : Maciej Zbrzezny
//  System  : Microsoft Visual C# .NET
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    mzbrzezny, 20071121: removal of license keys
//    24-03-2005: created
//
//  Copyright (C)2003, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu

namespace CAS.DataPorter
{
  /// <summary>
  /// Allows to read application setting and define default values
  /// </summary>
  internal class AppConfigManagement: CAS.Lib.RTLib.Management.AppConfigManagement
  {
    /// <summary>
    /// TCP port for the HTTP Soap Server
    /// </summary>
    public static readonly int HTTPSoapPort = 0;
    /// <summary>
    /// TCP port for the TCP Binary Server
    /// </summary>
    public static readonly int TCPBinaryPort = 0;
    static AppConfigManagement()
    {
      HTTPSoapPort = global::CAS.Lib.RTLib.Management.ApplicationConfiguration.GetAppSetting( "HTTPSoapPort", HTTPSoapPort );
      TCPBinaryPort = global::CAS.Lib.RTLib.Management.ApplicationConfiguration.GetAppSetting( "TCPBinaryPort", TCPBinaryPort );
    }
  }
}
