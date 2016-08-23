//<summary>
//  Title   : RemoteAccess.TCP.Binary
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    mzbrzezny - 20071121: fixed problem when Exception occour in the constructor
//    mzbrzezny - 2007:
//    created
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using CAS.Lib.RTLib.Processes;

namespace CAS.DataPorter.RemoteAccess
{
  /// <summary>
  /// Summary description for TCPBinaryServer. (Base Station Remote Access TCP Binary Server)
  /// </summary>
  public class TCPBinaryServer: CAS.Lib.DeviceSimulator.IRemoteAccessServer
  {
    #region private
    private TcpServerChannel channel = null;
    #endregion
    #region constructor
    /// <summary>
    /// Constructor for the TCP on Binnary Formater server
    /// </summary>
    /// <param name="portnumber">TCP port number that this server is listening on</param>
    public TCPBinaryServer( int portnumber )
    {
      try
      {
        IDictionary formatterProps = new Hashtable();
        formatterProps[ "includeVersions" ] = false;
        formatterProps[ "strictBinding" ] = false;

        BinaryServerFormatterSinkProvider ftProvider = new BinaryServerFormatterSinkProvider( formatterProps, null );
        ftProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

        //ftProvider.Next = new System.Runtime.Remoting.MetadataServices.SdlChannelSinkProvider();
        channel = new TcpServerChannel( "TcpServerChannel", portnumber );
        EventLogMonitor.WriteToEventLogInfo( "TcpServerChannel, port:" + portnumber.ToString() + "..created", (int)Error.DataPorter_Servers );
        //channelT = new TcpServerChannel("TcpServerChannel", portnumber, ftProvider);
      }
      catch ( Exception ex )
      {
        EventLogMonitor.WriteToEventLogError( "TcpServerChannel not started, exception:" + ex.Message, (int)Error.DataPorter_Servers );
      }

    }
    #endregion
    #region public
    /// <summary>
    /// Sets the device.
    /// </summary>
    /// <param name="device">The device.</param>
    public static void SetDevice( CAS.Lib.DeviceSimulator.IDevice device )
    {
      //ustawienie device:
      CAS.DataPorter.Lib.BaseStation.RemoteAccess.OPCDataAccess.SetDevice( device );
    }
    #endregion
    #region IRemoteAccessServer Members
    /// <summary>
    /// Starts the server.
    /// </summary>
    public void Start()
    {
      if ( channel != null )// channel is null when there was exception(catched) in the constructor
      {
        //rejestracja kana³u
        ChannelServices.RegisterChannel( channel, false );
        //rejestracja OPCRealtimeDataAccess
        WellKnownServiceTypeEntry remObj = new WellKnownServiceTypeEntry
          (
          typeof( CAS.DataPorter.Lib.BaseStation.RemoteAccess.OPCDataAccess ),
          "OPCDataAccess",
          WellKnownObjectMode.Singleton
          );
        RemotingConfiguration.RegisterWellKnownServiceType( remObj );
#if !COMMSERVER
        //rejestracja OPCBufferedDataAccess
        WellKnownServiceTypeEntry remObj2 = new WellKnownServiceTypeEntry
          (
          typeof( CAS.DataPorter.Lib.BaseStation.RemoteAccess.OPCAdvancedDataAccess ),
          "OPCAdvancedDataAccess",
          WellKnownObjectMode.Singleton
          );
        RemotingConfiguration.RegisterWellKnownServiceType( remObj2 );
#endif
        EventLogMonitor.WriteToEventLogInfo( "TcpServerChannel" + "..started", (int)Error.DataPorter_Servers );
      }
    }
    /// <summary>
    /// Stops the server.
    /// </summary>
    public void Stop()
    {
      if ( channel != null )// channel is null when there was exception(catched) in the constructor
      {
        ChannelServices.UnregisterChannel( channel );
      }
    }
    #endregion
  }
}
