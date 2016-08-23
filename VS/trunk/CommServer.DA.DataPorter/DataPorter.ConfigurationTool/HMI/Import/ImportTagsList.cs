//<summary>
//  Title   : ImportTagsList
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    mzbrzezny - 2007-08-03:
//    created
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http://www.cas.eu
//</summary>

using CAS.Windows.Forms;
using System;
using System.ComponentModel;

namespace CAS.DataPorter.Configurator.HMI.Import
{
  /// <summary>
  /// Summary description for ImportTagsForSimulation.
  /// </summary>
  internal class ImportTagsList: ImportFunctionRootClass
  {
    #region ImportTagsInfo
    internal class ImportTagsInfo: CAS.Lib.ControlLibrary.ImportFileControll.ImportInfo
    {
      #region private
      long m_ServerID = 0;
      int m_SamplingRate = 1000;
      int m_TransactionRate = 1000;
      int m_MaxAge = 1000;
      long? m_GroupID = null;
      bool m_cleargroup = true;
      #endregion
      public override string ImportName
      {
        get { return "Import Tags List"; }
      }
      public override string InitialDirectory
      {
        get
        {
          return AppDomain.CurrentDomain.BaseDirectory;
        }
      }
      /// <summary>
      /// deafult browse filter for the dialog which is used for selecting a file
      /// </summary>
      public override string BrowseFilter
      {
        get
        {
          return "Tags list in TXT file (*.TXT)|*.TXT";
        }
      }
      /// <summary>
      /// deafult extension for the dialog which is used for selecting a file
      /// </summary>
      public override string DefaultExt
      {
        get
        {
          return ".TXT";
        }
      }
      /// <summary>
      /// text that is used to show the information about this importing function
      /// </summary>
      public override string InformationText
      {
        get
        {
          return "This function immport tags from file - each line in file is one tag name";
        }
      }
      [
      BrowsableAttribute( true ),
      CategoryAttribute( "Settings" ),
      DescriptionAttribute( "ID of the Server" )
      ]
      public long ServerID
      {
        get
        {
          return m_ServerID;
        }
        set
        {
          m_ServerID = value;
        }
      }
      [
      BrowsableAttribute( true ),
      CategoryAttribute( "Settings" ),
      DescriptionAttribute( "ID of the Group - if not null - import will update existing group" )
      ]
      public long? GroupID
      {
        get
        {
          return m_GroupID;
        }
        set
        {
          m_GroupID = value;
        }
      }
      [
      BrowsableAttribute( true ),
      CategoryAttribute( "Settings" ),
      DescriptionAttribute( @"Clear Subscription?? (remove items first??) - if not true and we are updating subscription 
                            - import will remove contenst of the group" )
      ]
      public bool ClearGroup
      {
        get
        {
          return m_cleargroup;
        }
        set
        {
          m_cleargroup = value;
        }
      }


      [
      BrowsableAttribute( true ),
      CategoryAttribute( "Settings" ),
      DescriptionAttribute( "Sampling Rate [ms]" )
      ]
      public int SamplingRate
      {
        get
        {
          return m_SamplingRate;
        }
        set
        {
          m_SamplingRate = value;
        }
      }
      [
      BrowsableAttribute( true ),
      CategoryAttribute( "Settings" ),
      DescriptionAttribute( "Transaction Rate [ms]" )
      ]
      public int TransactionRate
      {
        get
        {
          return m_TransactionRate;
        }
        set
        {
          m_TransactionRate = value;
        }
      }
      [
      BrowsableAttribute( true ),
      CategoryAttribute( "Settings" ),
      DescriptionAttribute( "Max Age [ms]" )
      ]
      public int MaxAge
      {
        get
        {
          return m_MaxAge;
        }
        set
        {
          m_MaxAge = value;
        }
      }

    }
    #endregion
    #region private
    private OPCCliConfiguration m_database;
    private ImportTagsInfo m_ImportTagsInfo;
    #endregion
    #region ImportFunctionRootClass
    protected override void DoTheImport()
    {
      int changes_number = 0;
      #region IMPORT
      //robimy jakies importowanie:
      //dodajemy grupe:
      OPCCliConfiguration.SubscriptionsRow grow = null;
      try
      {
        if ( m_ImportTagsInfo.GroupID != null )
        {
          foreach ( OPCCliConfiguration.SubscriptionsRow tempgr in m_database.Subscriptions )
            if ( m_ImportTagsInfo.GroupID == tempgr.ID )
            {
              grow = tempgr;
              break;
            }
        }
        if (grow==null)
        {
          grow = m_database.Subscriptions.NewSubscriptionsRow();
          grow.ID_server = m_ImportTagsInfo.ServerID;
          grow.UpdateRate = m_ImportTagsInfo.SamplingRate;
          grow.Name = "ImportedGroup" + m_ImportTagsInfo.ServerID.ToString();
          m_database.Subscriptions.AddSubscriptionsRow( grow );
        }
        if ( m_ImportTagsInfo.ClearGroup )
        {
          foreach ( OPCCliConfiguration.ItemsRow itrow in grow.GetItemsRows() )
          {
            m_database.Items.RemoveItemsRow( itrow );
          }
        }
        
      }
      catch
      {
        AppendToLog( "Problem with adding for server: " + m_ImportTagsInfo.ServerID.ToString() );
        return;
      }
      //teraz otworzymy plik i dodamy wszystkie tagi:
      System.IO.StreamReader plik = new System.IO.StreamReader( m_ImportTagsInfo.Filename, System.Text.Encoding.Default );
      string plikzawartosc = plik.ReadToEnd();
      plik.Close();
      string Tagname = "-- unknowname --";
      while ( plikzawartosc.Length > 0 )
      {
        try
        {
          int pos = plikzawartosc.IndexOf( "\r\n" );
          if ( pos >= 0 )
          {
            Tagname = plikzawartosc.Substring( 0, pos );
            plikzawartosc = plikzawartosc.Remove( 0, pos + 2 );
          }
          else
          {
            if ( plikzawartosc.Length > 0 )
            {
              Tagname = plikzawartosc;
              plikzawartosc = "";
            }
          }
          Tagname = Tagname.Trim();
          if ( Tagname.Length > 0 ) //only if the line is not empty
          {
            //dodajemy taga:
            OPCCliConfiguration.ItemsRow itemrow = m_database.Items.NewItemsRow();
            itemrow.Name = Tagname;
            itemrow.ID_Subscription = grow.ID;
            itemrow.MaxAge = m_ImportTagsInfo.MaxAge;
            m_database.Items.AddItemsRow( itemrow );
            changes_number++;
          }
        }
        catch (
Exception
#if DEBUG
 ex
#endif
 )
        {
          AppendToLog( "problem with tag:" + Tagname + " :"
#if DEBUG
 + ex.Message.ToString()
#endif
 );
        }
      }
      #endregion IMPORT
      AppendToLog( "Number of changed tags: " + changes_number.ToString() );
    }

    #endregion
    #region creator
    public ImportTagsList( OPCCliConfiguration database, System.Windows.Forms.Form parrent_form )
      : base( parrent_form )
    {
      m_database = database;
      m_ImportTagsInfo = new ImportTagsInfo();
      SetImportInfo( m_ImportTagsInfo );
    }
    #endregion
  }
}
