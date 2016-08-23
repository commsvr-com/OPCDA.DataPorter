//<summary>
//  Title   : Monitor Interface (this class is used as interface to monitor)
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
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using CAS.DataPorter.Lib.BaseStation.Management;
using CAS.DataPorter.Monitor.Interface;
using CAS.DataPorter.Properties;
using CAS.Lib.OPCClient.Da.Management;
using CAS.Lib.RTLib.Management;

namespace CAS.DataPorter
{
  class MonitorInterface: MonitorInterfaceAbstract
  {
    private static string ProductName = "DataPorter";
    private static string ProductVersion = "1";
    private static bool started = false;
    private static SortedList<uint, string> namesList;
    private static SortedList<uint, ConnectionState.States> connectionStatesList;
    private static SortedList<uint, string> groupNamesList;
    private static SortedList<uint, ConnectionState.States> groupsConnectionStateList;
    private static SortedList<long, string> tagNamesList;
    private static SortedList<long, ConnectionState.States> tagConnectionStateList;
    private static SortedList<long, string> transactionNamesList;
    private static SortedList<long, ConnectionState.States> transactionConnectionStateList;
    private static void CreateLists()
    {
      #region opcClient
      if ( namesList == null )
        namesList = new SortedList<uint, string>();
      else
        namesList.Clear();

      if ( connectionStatesList == null )
        connectionStatesList = new SortedList<uint, ConnectionState.States>();
      else
        connectionStatesList.Clear();
      foreach ( var kvp in OPCClientStatistics.ServersList )
      {
        namesList.Add( kvp.Key, kvp.Value.StatisticsInternal.ToString() );
        connectionStatesList.Add( kvp.Key, kvp.Value.CurrState );
      }
      #endregion
      #region group
      if ( groupNamesList == null )
        groupNamesList = new SortedList<uint, string>();
      else
        groupNamesList.Clear();

      if ( groupsConnectionStateList == null )
        groupsConnectionStateList = new SortedList<uint, ConnectionState.States>();
      else
        groupsConnectionStateList.Clear();
      foreach ( var kvp in OPCGroup.GroupList )
      {
        groupNamesList.Add( kvp.Key, kvp.Value.StatisticsInternal.Name );
        groupsConnectionStateList.Add( kvp.Key, kvp.Value.CurrState );
      }
      #endregion group
      #region tag
      if ( tagNamesList == null )
        tagNamesList = new SortedList<long, string>();
      else
        tagNamesList.Clear();

      if ( tagConnectionStateList == null )
        tagConnectionStateList = new SortedList<long, ConnectionState.States>();
      else
        tagConnectionStateList.Clear();
      foreach ( var kvp in OPCTag.AllTags )
      {
        tagNamesList.Add( kvp.Key, kvp.Value.StatisticsInternal.Name );
        tagConnectionStateList.Add( kvp.Key, kvp.Value.CurrState );
      }
      #endregion tag
      #region transaction
      if ( transactionNamesList == null )
        transactionNamesList = new SortedList<long, string>();
      else
        transactionNamesList.Clear();

      if ( transactionConnectionStateList == null )
        transactionConnectionStateList = new SortedList<long, ConnectionState.States>();
      else
        transactionConnectionStateList.Clear();
      foreach ( var kvp in TransactionStatistics.TransactionList )
      {
        transactionNamesList.Add( kvp.Key, kvp.Value.StatisticsInternal.Name );
        transactionConnectionStateList.Add( kvp.Key, kvp.Value.CurrState );
      }
      #endregion transaction
    }
    /// <summary>
    /// Gets the name of the configuration file.
    /// </summary>
    /// <returns>configuration file name</returns>
    public override string GetConfigurationFileName()
    {
      FileInfo fi = new FileInfo( AppConfigManagement.filename );
      if ( fi.Exists )
        return fi.FullName;
      return string.Empty;
    }
    public override string GetProductName()
    {
      return ProductName;
    }
    public override string GetProductVersion()
    {
      return ProductVersion;
    }
    public override string GetReport()
    {
      ReportGenerator rep = new ReportGenerator( "CAS-DataPorter_state" );
      return rep.GetReportString();
    }
    public override TimeSpan GetRunTime()
    {
      return Main.RunTime;
    }
    public override void ShutdownRequest()
    {
      Main.MainComponent.Close();
    }

    #region OPC Client
    private static void UpdateOPCClientStatisticsConnectionStatesList()
    {
      foreach ( var kvp in OPCClientStatistics.ServersList )
      {
        connectionStatesList[ kvp.Key ] = kvp.Value.CurrState;
      }
    }
    public override SortedList<uint, string> GetOPCClientStatisticsNamesList()
    {
      return namesList;
    }
    public override SortedList<uint, ConnectionState.States> GetOPCClientStatisticsConnectionStatesList()
    {
      UpdateOPCClientStatisticsConnectionStatesList();
      return connectionStatesList;
    }
    public override OPCClientStatistics.OPCClientStatisticsInternal GetOPCClientStatistics( uint Identifier )
    {
      OPCClientStatistics stats = OPCClientStatistics.ServersList[ Identifier ];
      stats.UpdateInternals();
      return stats.StatisticsInternal;
    }
    #endregion OPC Client
    #region OPC Group
    private static void UpdateGroupStatisticConnectionStatesList()
    {
      foreach ( var kvp in OPCGroup.GroupList )
      {
        groupsConnectionStateList[ kvp.Key ] = kvp.Value.CurrState;
      }
    }
    public override SortedList<uint, string> GetGroupStatisticNamesList()
    {
      return groupNamesList;
    }
    public override SortedList<uint, ConnectionState.States> GetGroupStatisticConnectionStatesList()
    {
      UpdateGroupStatisticConnectionStatesList();
      return groupsConnectionStateList;
    }
    public override OPCGroup.OPCGroupStatisticsInternal GetGroupStatistics( uint Identifier )
    {
      OPCGroup stats = OPCGroup.GroupList[ Identifier ];
      stats.UpdateInternals();
      return stats.StatisticsInternal;
    }
    #endregion OPC Group
    #region OPC Tag
    private static void UpdateTagStatisticConnectionStatesList()
    {
      foreach ( var kvp in OPCTag.AllTags )
      {
        tagConnectionStateList[ kvp.Key ] = kvp.Value.CurrState;
      }
    }
    public override SortedList<long, string> GetTagStatisticNamesList()
    {
      return tagNamesList;
    }
    public override SortedList<long, ConnectionState.States> GetTagStatisticConnectionStatesList()
    {
      UpdateTagStatisticConnectionStatesList();
      return tagConnectionStateList;
    }
    public override OPCTag.OPCTagStatisticsInternal GetTagStatistics( long Identifier )
    {
      OPCTag stats = OPCTag.AllTags[ Identifier ];
      stats.UpdateInternals();
      return stats.StatisticsInternal;
    }
    #endregion OPC Tag
    #region OPC Transaction
    private static void UpdateTransactionStatisticConnectionStatesList()
    {
      foreach ( var kvp in TransactionStatistics.TransactionList )
      {
        transactionConnectionStateList[ kvp.Key ] = kvp.Value.CurrState;
      }
    }
    public override SortedList<long, string> GetTransactionStatisticNamesList()
    {
      return transactionNamesList;
    }
    public override SortedList<long, ConnectionState.States> GetTransactionStatisticConnectionStatesList()
    {
      UpdateTransactionStatisticConnectionStatesList();
      return transactionConnectionStateList;
    }
    public override TransactionStatistics.TransactionStatisticsInternal GetTransactionStatistics( long Identifier )
    {
      TransactionStatistics stats = TransactionStatistics.TransactionList[ Identifier ];
      stats.UpdateInternals();
      return stats.StatisticsInternal;
    }
    #endregion OPC Transaction
    /// <summary>
    /// Starts the server with specified product name and version.
    /// </summary>
    /// <param name="cProductName">Name of the c product.</param>
    /// <param name="cProductVersion">The c product version.</param>
    public static void Start( string cProductName, string cProductVersion )
    {
      if ( !started )
      {
        ProductName = cProductName;
        ProductVersion = cProductVersion;
        CreateLists();

        #region channel initialisation
        started = true;
        TcpServerChannel channel;
        //        SoapServerFormatterSinkProvider ftProvider = new SoapServerFormatterSinkProvider();
        //        ftProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
        //        ftProvider.Next=new  System.Runtime.Remoting.MetadataServices.SdlChannelSinkProvider();
        BinaryServerFormatterSinkProvider ftProvider = new BinaryServerFormatterSinkProvider();
        ftProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
        channel = new TcpServerChannel( null, Settings.Default.MonitorInterfacePort, ftProvider );
        //rejestracja kanału
        ChannelServices.RegisterChannel( channel, false );
        //rejestracja MonitorInterface
        WellKnownServiceTypeEntry remObj = new WellKnownServiceTypeEntry
          (
          typeof( MonitorInterface ),
          Settings.Default.MonitorInterfaceEntryName,
          WellKnownObjectMode.Singleton
          );
        RemotingConfiguration.RegisterWellKnownServiceType( remObj );
        #endregion channel initialisation
      }
    }
  }
}
