//_______________________________________________________________
//  Title   : HTTPSoapServer
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.DataPorter.Lib.BaseStation.RemoteAccess;
using CAS.Lib.DeviceSimulator;
using CAS.Lib.RTLib.Processes;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace CAS.DataPorter.RemoteAccess
{
  /// <summary>
  ///Base Station Remote Access HTTP Soap HTTPSoapServer.
  /// </summary>
  public class HTTPSoapServer : IRemoteAccessServer
  {
    #region private
    private HttpServerChannel m_Channel = null;
    #endregion

    /// <summary>
    /// Constructor for the HTTP on Soap Formatter server
    /// </summary>
    /// <param name="portNumber">TCP port number that this server is listening on</param>
    public HTTPSoapServer(int portNumber)
    {
      try
      {
        IDictionary formatterProps = new Hashtable();
        formatterProps["includeVersions"] = false;
        formatterProps["strictBinding"] = false;

        SoapServerFormatterSinkProvider ftProvider = new SoapServerFormatterSinkProvider(formatterProps, null);
        //SoapServerFormatterSinkProvider ftProvider = new SoapServerFormatterSinkProvider();
        ftProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

        ftProvider.Next = new System.Runtime.Remoting.MetadataServices.SdlChannelSinkProvider();
        m_Channel = new HttpServerChannel(null, portNumber, ftProvider);
        EventLogMonitor.WriteToEventLogInfo("HTTPServerChannel, port:" + portNumber.ToString() + "..created", (int)Error.DataPorter_Servers);
      }
      catch (Exception ex)
      {
        EventLogMonitor.WriteToEventLogError("HTTPServerChannel not started, exception:" + ex.Message, (int)Error.DataPorter_Servers);
      }
    }
    /// <summary>
    /// Sets the device.
    /// </summary>
    /// <param name="device">The device.</param>
    public static void SetDevice(IDevice device)
    {
      OPCDataAccess.SetDevice(device);
    }
    #region IRemoteAccessServer Members
    /// <summary>
    /// Starts the server.
    /// </summary>
    public void Start()
    {
      if (m_Channel == null) // channel is null when there was exception caught in the constructor
        return;
      ChannelServices.RegisterChannel(m_Channel, false);
      WellKnownServiceTypeEntry remObj = new WellKnownServiceTypeEntry
        (
          typeof(OPCDataAccess),
          "OPCDataAccess",
          WellKnownObjectMode.Singleton
        );
      RemotingConfiguration.RegisterWellKnownServiceType(remObj);
#if !COMMSERVER
      //register OPCBufferedDataAccess
      WellKnownServiceTypeEntry remObj3 = new WellKnownServiceTypeEntry
        (
        typeof(OPCAdvancedDataAccess),
        "OPCAdvancedDataAccess",
        WellKnownObjectMode.Singleton
        );
      RemotingConfiguration.RegisterWellKnownServiceType(remObj3);
#endif
      EventLogMonitor.WriteToEventLogInfo("HTTPServerChannel" + "..started", (int)Error.DataPorter_Servers);
    }
    /// <summary>
    /// Stops the server.
    /// </summary>
    public void Stop()
    {
      if (m_Channel != null) // channel is null when there was exception caught in the constructor
        ChannelServices.UnregisterChannel(m_Channel);
    }
    #endregion
  }
}
