//<summary>
//  Title   : Abstract class definition of the Monitor interface
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

using System;
using System.Collections.Generic;
using CAS.DataPorter.Lib.BaseStation.Management;
using CAS.Lib.RTLib.Management;
using CAS.Lib.OPCClient.Da.Management;

namespace CAS.DataPorter.Monitor.Interface
{
  /// <summary>
  /// Abstract class definition of the DataPorter Monitor interface
  /// </summary>
  public abstract class MonitorInterfaceAbstract: MarshalByRefObject
  {
    /// <summary>
    /// Gets the run time in seconds.
    /// </summary>
    /// <returns>run time in seconds</returns>
    public abstract TimeSpan GetRunTime();
    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    /// <returns>product name</returns>
    public abstract string GetProductName();
    /// <summary>
    /// Gets the product version.
    /// </summary>
    /// <returns>product version</returns>
    public abstract string GetProductVersion();
    /// <summary>
    /// Gets the report.
    /// </summary>
    /// <returns>html report</returns>
    public abstract string GetReport();
    /// <summary>
    /// Gets the name of the configuration file.
    /// </summary>
    /// <returns>configuration file name</returns>
    public abstract string GetConfigurationFileName();
    /// <summary>
    /// Shutdown request.
    /// </summary>
    public abstract void ShutdownRequest();
    #region OPC Clients
    /// <summary>
    /// Gets the names list of the OPC client  
    /// </summary>
    /// <returns>list of names</returns>
    public abstract SortedList<uint, string> GetOPCClientStatisticsNamesList();
    /// <summary>
    /// Gets the OPC client statistics connection states list.
    /// </summary>
    /// <returns>list of current states</returns>
    public abstract SortedList<uint, ConnectionState.States> GetOPCClientStatisticsConnectionStatesList();
    /// <summary>
    /// Gets the OPC client statistics.
    /// </summary>
    /// <param name="Identifier">The identifier.</param>
    /// <returns>the statistics</returns>
    public abstract OPCClientStatistics.OPCClientStatisticsInternal GetOPCClientStatistics( uint Identifier );
    #endregion OPC Clients
    #region OPC Groups
    /// <summary>
    /// Gets the group statistic names list.
    /// </summary>
    /// <returns>list of group names</returns>
    public abstract SortedList<uint, string> GetGroupStatisticNamesList();
    /// <summary>
    /// Gets the group statistic connection states list.
    /// </summary>
    /// <returns>list of current states</returns>
    public abstract SortedList<uint, ConnectionState.States> GetGroupStatisticConnectionStatesList();
    /// <summary>
    /// Gets the group statistics.
    /// </summary>
    /// <param name="Identifier">The identifier.</param>
    /// <returns>the group statistics</returns>
    public abstract OPCGroup.OPCGroupStatisticsInternal GetGroupStatistics( uint Identifier );
    #endregion OPC Groups
    #region OPC Items
    /// <summary>
    /// Gets the tag statistic names list.
    /// </summary>
    /// <returns>the list of names</returns>
    public abstract SortedList<long, string> GetTagStatisticNamesList();
    /// <summary>
    /// Gets the tag statistic connection states list.
    /// </summary>
    /// <returns>the lsit of current states</returns>
    public abstract SortedList<long, ConnectionState.States> GetTagStatisticConnectionStatesList();
    /// <summary>
    /// Gets the tag statistics.
    /// </summary>
    /// <param name="Identifier">The identifier.</param>
    /// <returns>the statistics for tag</returns>
    public abstract OPCTag.OPCTagStatisticsInternal GetTagStatistics( long Identifier );
    #endregion OPC Items
    #region OPC Transaction
    /// <summary>
    /// Gets the transaction statistic names list.
    /// </summary>
    /// <returns>the list fo transaction names</returns>
    public abstract SortedList<long, string> GetTransactionStatisticNamesList();
    /// <summary>
    /// Gets the transaction statistic connection states list.
    /// </summary>
    /// <returns>The list of current states</returns>
    public abstract SortedList<long, ConnectionState.States> GetTransactionStatisticConnectionStatesList();
    /// <summary>
    /// Gets the transaction statistics.
    /// </summary>
    /// <param name="Identifier">The identifier.</param>
    /// <returns>the transaction statistics</returns>
    public abstract TransactionStatistics.TransactionStatisticsInternal GetTransactionStatistics( long Identifier );
    #endregion OPC Transaction

  }
}
