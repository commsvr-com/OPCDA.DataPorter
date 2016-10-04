//  Title   : DataPorter handling class
//  Author  : Maciej Zbrzezny, Mariusz Postol
//  System  : Microsoft Visual C# .NET
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//   20081006: mzbrzezny: HandlerWaitTimeList is inside CAS.Lib.RTLib.Processes not in Processes Namespace
//   20080630: mzbrzezny: Transaction.IWriteValue.SetValue is changed to check whether tag has server handle (in previously there was check whether the tag is active)
//   20071001- mzbrzezny: time parameters are now passed as int numbers, adaptation for new HandlerWaitTimeList
//    MZbrzezny - 2006-02-16
//    added implementation of Transaction.IWriteValue.SetValue(Opc.Da.ItemValue it, object val) for OPCClientTag
//    MZbrzezny - 2005-11-21
//    dodano operacje w transakcjach
//    MZbrzezny - 09-03-05
//      Utworzono na podstawie pliku DataQueue
//
//  Copyright (C)2005, CAS LODZ POLAND.
//  TEL: 48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu

using CAS.DataPorter.Configurator;
using CAS.DataPorter.Lib.Transactions;
using CAS.DataPorter.Lib.Transactions.Operations;
using CAS.DataPorter.Properties;
using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClient.Da.Management;
using CAS.Lib.RTLib.Processes;
using CAS.Lib.RTLib.Utils.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using OPCClientTag = CAS.Lib.OPCClient.Da.OPC_Interface.OPC_Interface_Tag;
using OpcDa = global::Opc.Da;

namespace CAS.DataPorter
{
  /// <summary>
  /// OPC tags data queue handling class.
  /// </summary>
  internal sealed class OPCDataQueue: HandlerWaitTimeList<OPCDataQueue.OPCClientTransaction>
  {
    #region PRIVATE
    private static OPCDataQueue m_DataQueue = new OPCDataQueue();
    private TraceEvent Tracer { get { return Main.MainComponent.Tracer; } }
    /// <summary>
    /// Queue handler description
    /// </summary>
    internal class OPCClientTransaction: HandlerWaitTimeList<OPCDataQueue.OPCClientTransaction>.TODescriptor
    {
      #region private
      private static string SwitchOnSourceName = typeof( OPCClientTransaction ).Name + "SwitchOn()";
      private static ArrayList m_AllTransactions = new ArrayList();
      private Transaction m_Transaction;
      private bool m_StopIfBadQuality;
      private string m_BadQualityValue = null;
      private TraceEvent Tracer { get { return Main.MainComponent.Tracer; } }
      private void RiseWriteIsReadyEvent()
      {
        if ( WriteIsReady != null )
          WriteIsReady( this, EventArgs.Empty );
      }
      //TODO wywaliæ po uzgodnieniu z MZ
      //private void AddOperationRowToTree(
      //    ref SortedTree<Operation> tree,
      //    OPCCliConfiguration.OperationsRow row,
      //    int childOutputNumber,
      //    Operation parentOperationRowWrapper,
      //    int parentInputNumber,
      //    ref bool canBeAdded
      //    )
      //{
      //  try
      //  {
      //    Operation operrowOperation = OperationFactory.GetOperation( row, m_StopIfBadQuality, m_BadQualityValue );
      //    tree.AddNode( parentOperationRowWrapper, parentInputNumber, operrowOperation, childOutputNumber );
      //    // dla tej wybranej operacji musimy wybrac wszystkie podoperacje 
      //    foreach ( OPCCliConfiguration.OperationLinksRow operlinkrow in row.GetOperationLinksRowsByFK_OPERATION_OperationLinks() )
      //    {
      //      AddOperationRowToTree(
      //        ref tree,
      //        operlinkrow.OPERATIONRowByFK_OPERATION_OperationLinksChild,
      //        operlinkrow.ChildOutput_number,
      //        operrowOperation,
      //        operlinkrow.Input_number,
      //        ref canBeAdded );
      //    }
      //  }
      //  catch ( Exception ex )
      //  {
      //    string src = "CAS.Lib.DataPorter.OPCDataQueue.OPCClientTransaction.AddOperationRowToTree";
      //    Main.MainComponent.SystemExceptionHandler
      //      ( ex, 102, src + " Problem with operation initialisation : " + m_Transaction.STATISTICS.Name );
      //    canBeAdded = false;
      //  }
      //}
      #endregion
      #region public
      internal void RunTransactionChainProcess()
      {
        if ( m_Transaction == null )
          return;
        m_Transaction.Go();
        RiseWriteIsReadyEvent();
      }
      /// <summary>
      /// Occurs when write operation can be executed.
      /// </summary>
      internal event EventHandler WriteIsReady;
      /// <summary>
      /// Switches on this transaction.
      /// </summary>
      internal void SwitchOn()
      {
        if ( this.m_Transaction == null || this.m_Transaction.Statistics == null )
          Tracer.TraceWarning( 119, SwitchOnSourceName, Resources.tx_OPCDataQueue_CannotSwitchOn + ":" +
            Resources.tx_OPCDataQueue_CannotSwitchOn_empty );
        try
        {
          m_Transaction.SwitchOn();
          this.ResetCounter();
        }
        catch ( Exception ex )
        {
          Tracer.TraceInformation( 124, SwitchOnSourceName, Resources.tx_OPCDataQueue_CannotSwitchOn + ":"
            + this.m_Transaction.Statistics.Name
            + "Reason: " + ex.Message );
        }
      }
      /// <summary>
      /// Switches on all transactions.
      /// </summary>
      internal static void SwitchOnAll()
      {
        foreach ( OPCClientTransaction item in m_AllTransactions )
        {
          item.SwitchOn();
        }
      }
      #endregion
      #region constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="OPCClientTransaction"/> class.
      /// </summary>
      /// <param name="configuration">The configuration.</param>
      /// <param name="ParentDataQueue">The parent data queue.</param>
      internal OPCClientTransaction( OPCCliConfiguration.TransactionsRow configuration, OPCDataQueue ParentDataQueue )
        : base( ParentDataQueue, new TimeSpan( 0, 0, 0, 0, configuration.TransactionRate == 0 ? 1 : configuration.TransactionRate ) )
      {
        bool canBeAdded = true;
        if ( !configuration.IsBadQualityValueNull() )
          m_BadQualityValue = configuration.BadQualityValue;
        m_StopIfBadQuality = configuration.StopIfBadQuality;
        OPCCliConfiguration.OperationsRow[] operations = configuration.GetOperationsRows();
        // stworzymy tablice operacji do wykonania;
        SortedList<long, Operation> operationList = new SortedList<long, Operation>( configuration.GetOperationsRows().Length );
        SortedList<long, OPCCliConfiguration.OperationsRow> operationRowList =
          new SortedList<long, OPCCliConfiguration.OperationsRow>( configuration.GetOperationsRows().Length );
        SortedTree<Operation> myOperationTree = new SortedTree<Operation>();
        try
        {
          //najpierw dodajemy wszystkie operacje
          foreach ( OPCCliConfiguration.OperationsRow row in configuration.GetOperationsRows() )
          {
            try
            {
              Operation operrowOperation = OperationFactory.GetOperation( row, m_StopIfBadQuality, m_BadQualityValue );
              operationRowList.Add( (long)operrowOperation.Statistics.Identifier, row );
              operationList.Add( (long)operrowOperation.Statistics.Identifier, operrowOperation );
              myOperationTree.AddNode( operrowOperation ); //najpiewr dodajemy wszystykie jako rooty
            }
            catch ( Exception ex )
            {
              Exception newExcetion = new Exception( String.Format( Resources.tx_OPCDataQueue_Operation_CannotBeAdded, row.Name ), ex );
              throw newExcetion;
            }
          }
          //teraz dodajemy wszystkie linki:
          foreach ( Operation node in myOperationTree )
            foreach ( OPCCliConfiguration.OperationLinksRow OpLinksRow in operationRowList[ node.Statistics.Identifier ].GetOperationLinksRowsByFK_OPERATION_OperationLinks() )
            {
              myOperationTree.ConnectTheNodeToOtherNode( operationList[ OpLinksRow.ID_Operation ], OpLinksRow.Input_number,
                operationList[ OpLinksRow.IDChild_Operation ], OpLinksRow.ChildOutput_number );
            }
        }
        catch ( Exception ex )
        {
          Main.MainComponent.SystemExceptionHandler( ex, 158, this.ToString() );
          canBeAdded = false;
        }
        if ( canBeAdded )
        {
          m_Transaction = new Transaction( configuration, myOperationTree );
          m_AllTransactions.Add( this );
        }
        else
        {
          Main.MainComponent.Tracer.TraceWarning( 194, this.GetType().ToString(),
            String.Format( Resources.tx_OPCDataQueue_Transaction_CannotBeAdded, configuration.Name ) );
        }
      }
      #endregion
    }
    /// <summary>
    /// Class that represent a OPC subscription / group from configuration
    /// </summary>
    internal class OPCClientGroup
    {
      #region private
      private OPC_Interface.OPCGroup m_OPCGroup;
      private static List<OPCClientGroup> m_AllGroups = new List<OPCClientGroup>();
      private OPC_Interface.OPC_Interface_Tag[] Tags
        ( OPCCliConfiguration.ItemsRow[] items, OPC_Interface server, OPC_Interface.OPCGroup oPCGroup )
      {
        OPCClientTag[] tags = new OPCClientTag[ items.Length ];
        int idx = 0;
        #region foreach ( OPCCliConfiguration.ItemsRow row in items )
        foreach ( OPCCliConfiguration.ItemsRow row in items )
        {
          OpcDa.Item item = row.Item;
          double measurement_low = double.NaN;
          double measurement_hi = double.NaN;
          double engineer_low = double.NaN;
          double engineer_hi = double.NaN;
          OPCCliConfiguration.ConversionsRow[] conversions = row.GetConversionsRows();
          if ( conversions.Length > 0 )
          {
            if ( conversions.Length != 1 )
              throw new Exception( "Too many ConversionsRows for item " + row.Name );
            //musimy konwersje uruchomic
            measurement_low = conversions[ 0 ].MeasuredValue1;
            measurement_hi = conversions[ 0 ].MeasuredValue2;
            engineer_low = conversions[ 0 ].EngineeringValue1;
            engineer_hi = conversions[ 0 ].EngineeringValue2;
          }
          //odczytanie odpowiednich property z pliku opisów
          global::Opc.Da.ItemPropertyCollection properties =
              BaseStation.ItemDescriber.ItemDescriber2OpcDA.GetItemPropertiesCollection( row.Name, Main.m_ds_dsc );
          if ( properties.Count == 0 )
          {
            //nalezy sprawdzic jeszcze - czy moze nie ma nazewnictwa path/ tagname:
            properties = BaseStation.ItemDescriber.ItemDescriber2OpcDA.GetItemPropertiesCollection
              ( server.Name + "/" + oPCGroup.Name + "/" + row.Name, Main.m_ds_dsc );
          }
          OPCTag tagStatistics =
            new OPCTag( (uint)row.ID, row.Item, measurement_low, measurement_hi, engineer_low, engineer_hi );
          string path = server.Name + "/" + oPCGroup.Name + "/";
          OPCClientTag tag = new OPCClientTag
              ( tagStatistics, oPCGroup, null, OpcDa.qualityBits.badNotConnected, properties, path, row.Item );
          tag.ClientHandle = idx;
          tags[ idx++ ] = tag;
        }
        #endregion foreach ( OPCCliConfiguration.ItemsRow row in items )
        return tags;
      }
      #endregion private
      #region public
      /// <summary>
      /// Commits write operation - all changed tags are sent to the server.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
      internal void WriteOperation( object sender, EventArgs e )
      {
        m_OPCGroup.CommitWrite();
      }
      /// <summary>
      /// Initializes a new instance of the <see cref="OPCClientGroup"/> class.
      /// </summary>
      /// <param name="group">The group description from XML configuration file<see cref="OPCCliConfiguration.SubscriptionsRow"/>.</param>
      /// <param name="items">The table of items <see cref="OPCCliConfiguration.ItemsRow"/>.</param>
      /// <param name="server">Server that this group should belong to</param>
      /// <param name="parent">The parent.</param>
      /// <param name="volumeConstrain">The volume constrain.</param>
      internal OPCClientGroup
        (
        OPCCliConfiguration.SubscriptionsRow group,
        OPCCliConfiguration.ItemsRow[] items,
        OPC_Interface server,
        OPCDataQueue parent,
        ref uint? volumeConstrain
        )
      {
        if ( volumeConstrain.HasValue )
          if ( volumeConstrain.Value < items.Length )
            throw new LicenseException( typeof( Main ), Main.MainComponent, CAS.Lib.CodeProtect.Properties.Resources.Tx_LicVolumeConstrainErr );
          else
            volumeConstrain = volumeConstrain.Value - Convert.ToUInt32( items.Length );
        OpcDa.SubscriptionState state = group.CreateSubscriptionState;
        m_OPCGroup = server.CreateOPCGroup( (uint)group.ID, (uint)group.ID_server, group.Asynchronous, state );
        m_OPCGroup.Tags = Tags( items, server, m_OPCGroup );
        m_AllGroups.Add( this );
      }
      /// <summary>
      /// Gets all groups.
      /// </summary>
      /// <value>All groups <see cref="OPCClientGroup"/>.</value>
      static internal List<OPCClientGroup> AllGroups { get { return m_AllGroups; } }
      #endregion PUBLIC
    } // OPCClientGroup
    protected override void Handler( OPCClientTransaction operation )
    {
      operation.RunTransactionChainProcess();
    }
    private OPCDataQueue() : base( true, "OPCDataQueue" ) { }
    #endregion PRIVATE
    #region PUBLIC STATIC
    /// <summary>
    /// Creates new instance of an OPC client and
    /// </summary>
    /// <param name="server">The server.</param>
    /// <param name="volumeConstrain">The  volume constrain.</param>
    internal static void CrateServer( OPCCliConfiguration.ServersRow server, ref uint? volumeConstrain )
    {
      OPC_Interface m_Server = new OPC_Interface( server.PreferedSpecification, server.URL, server.Name );
      foreach ( OPCCliConfiguration.SubscriptionsRow group in server.GetSubscriptionsRows() )
        new OPCDataQueue.OPCClientGroup( group, group.GetItemsRows(), m_Server, m_DataQueue, ref volumeConstrain );
    }
    /// <summary>
    /// Creates the transaction.
    /// </summary>
    /// <param name="transactionDescription">The transaction description.</param>
    internal static void CreateTransaction( OPCCliConfiguration.TransactionsRow transactionDescription )
    {
      OPCClientTransaction transaction = new OPCClientTransaction( transactionDescription, m_DataQueue );
      foreach ( OPCClientGroup gr in OPCClientGroup.AllGroups )
        transaction.WriteIsReady += gr.WriteOperation;
    }
    /// <summary>
    /// Switch on Scanning of thr all goups and complet initiaition
    /// </summary>
    internal static void SwitchOnScanning()
    {
      OPC_Interface.SwitchOnAllServers();
      OPCClientTransaction.SwitchOnAll();
    }
    /// <summary>
    /// finalize all server interfaces
    /// </summary>
    internal static void DisconnectAllServers()
    {
      OPC_Interface.DisconnectAllServers();
    }
    #endregion PUBLIC STATIC

  } //class OPCDataQueue
} //namespace BaseStation