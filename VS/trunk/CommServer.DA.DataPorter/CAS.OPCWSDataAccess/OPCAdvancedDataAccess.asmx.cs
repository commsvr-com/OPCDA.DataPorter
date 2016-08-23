//<summary>
//  Title   : service OPCAdvancedDataAccess
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20070730 mzbrzezny - created
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.ComponentModel;
using System.Web.Services;
using CAS.Lib.DeviceSimulator;

namespace OPCWSDataAccess
{
  /// <summary>
  /// Summary description for OPCBufferedDataAccess
  /// </summary>
  [WebService( Namespace = "http://cas.eu/Opc.Da/", Description = "<i>CAS: OPC Advanced Data Access Web Service</i>" )]
  [WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
  [ToolboxItem( false )]
  public class OPCAdvancedDataAccess: OPCDataAccess
  {
    private CAS.Lib.DeviceSimulator.IOPCBufferedDataAccess remotetype;
    /// <summary>
    /// function that returns availiable queues
    /// </summary>
    /// <returns>list of queues</returns>
    [WebMethod( Description = "Get all queues names availiable via this service" )]
    public string[] GetAvailiableQueues()
    {
      return remotetype.GetAvailiableQueues();
    }
    /// <summary>
    /// concect to queue
    /// </summary>
    /// <param name="queueID">queue ID of queue that that we want to connect</param>
    /// <returns>hash (identifier) of the connection</returns>
    [WebMethod]
    public string ConnectToQueue( string queueID )
    {
      return remotetype.ConnectToQueue( queueID );
    }
    /// <summary>
    /// start of the transaction
    /// </summary>
    /// <param name="Hash">identifier of the connection</param>
    /// <returns>array of new values</returns>
    [WebMethod]
    public Opc.Da.ItemValueResult[] StartTransaction( string Hash )
    {
      return remotetype.StartTransaction( Hash );
    }
    /// <summary>
    /// end of transaction
    /// </summary>
    /// <param name="Hash">hash of the connection</param>
    /// <returns>true if everythink is ok</returns>
    [WebMethod]
    public bool EndTransaction( string Hash )
    {
      return remotetype.EndTransaction( Hash );
    }
    public OPCAdvancedDataAccess()
    {
      remotetype = (IOPCBufferedDataAccess)Activator.GetObject
      (
      typeof( IOPCBufferedDataAccess ),
      AppConfigManagement.remote_buffered
      );
    }

  }
}
