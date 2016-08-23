//<summary>
//  Title   : ImportItemSettings
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    mzbrzezny - 2007-11-21:
//    created
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http://www.cas.eu
//</summary>

using System;
using BaseStation;
using System.ComponentModel;
using CAS.Windows.Forms;

namespace CAS.DataPorter.Configurator.HMI.Import
{
  /// <summary>
  /// Summary description for ImportItemSettings.
  /// </summary>
  internal class ImportItemSettings : ImportFunctionRootClass
  {
    #region ImportTagsInfo
    internal class ImportTagsInfo : CAS.Lib.ControlLibrary.ImportFileControll.ImportInfo
    {
      #region private
      long? m_ServerID = 0;
      bool m_addnew = false;
      bool m_creategroup = false;
      int m_SamplingRate = 1000;
      int m_TransactionRate = 1000;
      long? m_GroupID = null;
      #endregion
      public override string ImportName
      {
        get { return "Import item settings"; }
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
          return "Tags settings in CSV file (*.CSV)|*.CSV";
        }
      }
      /// <summary>
      /// deafult extension for the dialog which is used for selecting a file
      /// </summary>
      public override string DefaultExt
      {
        get
        {
          return ".CSV";
        }
      }
      /// <summary>
      /// text that is used to show the information about this importing function
      /// </summary>
      public override string InformationText
      {
        get
        {
          return "This function immport settings for items from file - each line in file must be: ItemName;Type;Conversion;Async;Maxage0;Endline";
        }
      }
      [
      BrowsableAttribute(true),
      CategoryAttribute("Settings - new group"),
      DescriptionAttribute("ID of the Server - required only when new group is created")
      ]
      public long? ServerID
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
      BrowsableAttribute(true),
      CategoryAttribute("Settings"),
      DescriptionAttribute("If false tags are updated. I true tags are created")
      ]
      public bool AddNew
      {
        get
        {
          return m_addnew;
        }
        set
        {
          m_addnew = value;
        }
      }
      [
      BrowsableAttribute(true),
      CategoryAttribute("Settings - new group"),
      DescriptionAttribute("If true new group will be created instead of updating existing group")
      ]
      public bool CreateGroup
      {
        get
        {
          return m_creategroup;
        }
        set
        {
          m_creategroup = value;
        }
      }
      [
      BrowsableAttribute(true),
      CategoryAttribute("Settings"),
      DescriptionAttribute("ID of the Group - if not null - import will update existing group")
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
      BrowsableAttribute(true),
      CategoryAttribute("Settings - new group"),
      DescriptionAttribute("Sampling Rate [ms]")
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
      BrowsableAttribute(true),
      CategoryAttribute("Settings - new group"),
      DescriptionAttribute("Transaction Rate [ms]")
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
    }
    #endregion
    #region private
    private OPCCliConfiguration m_database;
    private ImportTagsInfo m_ImportTagsInfo;
    private long getMaxItemID()
    {
      long ret = 0;
      foreach (OPCCliConfiguration.ItemsRow itrow in m_database.Items)
      {
        if (itrow.ID >= ret)
          ret = itrow.ID + 1;
      }
      return ret;
    }
    #endregion
    #region ImportFunctionRootClass
    protected override void DoTheImport()
    {
      int changes_number = 0;
      #region IMPORT
      //robimy jakies importowanie:
      long group_add = 0;
      long server_add = 0;
      if (this.m_ImportTagsInfo.AddNew && this.m_ImportTagsInfo.CreateGroup && m_ImportTagsInfo.ServerID.HasValue)
      {
        OPCCliConfiguration.SubscriptionsRow newgroup = this.m_database.Subscriptions.NewSubscriptionsRow();
        newgroup.UpdateRate = m_ImportTagsInfo.SamplingRate;
        newgroup.Name = "NewGroup";
        newgroup.ID_server = (long)m_ImportTagsInfo.ServerID;
        this.m_database.Subscriptions.AddSubscriptionsRow(newgroup);
        this.m_ImportTagsInfo.GroupID = newgroup.ID;
      }
      if (this.m_ImportTagsInfo.AddNew && this.m_ImportTagsInfo.GroupID.HasValue)
      {
        group_add = (long)this.m_ImportTagsInfo.GroupID;
        //szukamy serwera
        foreach (OPCCliConfiguration.SubscriptionsRow srow in this.m_database.Subscriptions)
        {
          if (srow.ID == group_add)
          {
            server_add = srow.ID_server;
            break;
          }
        }
      }
      CSVManagement file = CSVManagement.ReadFile(m_ImportTagsInfo.Filename);
      while (file.ToString().Length > 0)
      {
        string read;
        string name = file.GetAndMove2NextElement();
        int type;
        read = file.GetAndMove2NextElement();
        if (read.Length > 0)
        {
          type = System.Convert.ToByte(read);
        }
        else
        {
          type = -1;
        }
        string conversion = file.GetAndMove2NextElement();
        bool async;
        read = file.GetAndMove2NextElement();
        if (read.Length > 0)
        {
          async = System.Convert.ToBoolean(System.Convert.ToInt16(read));
        }
        else
        {
          async = false;
        }
        int maxage = -1;
        read = file.GetAndMove2NextElement();
        if (read.Length > 0)
        {
          maxage = System.Convert.ToInt32(read);
        }
        System.Console.WriteLine("tag do zminay: " + name);
        if (this.m_ImportTagsInfo.AddNew && this.m_ImportTagsInfo.GroupID.HasValue)
        {
          throw new Exception("Importing tools are not support new schema yet");

          //OPCCliConfiguration.ItemsRow itrow = m_database.Items.NewItemsRow();
          //itrow.Name = name;
          //itrow.ID = getMaxItemID();
          //itrow.ID_Subscription = group_add;
          ////if ( type >= 0 )
          ////  itrow.RequestedType = (byte)type;
          //if ( maxage >= 0 )
          //  itrow.MaxAge = maxage;
          //else
          //  itrow.SetMaxAgeNull();//=new DBNull();
          ////TODO:fix import tool
          ////itrow.Async = async;
          ////if ( conversion != "" )
          ////  itrow.Conversion = conversion;
          //m_database.Items.AddItemsRow( itrow );
          //changes_number++;

        }
        else
        {
          //szukamy teraz odpowiedniego taga w liscie
          foreach (OPCCliConfiguration.ItemsRow itrow in m_database.Items)
          {
            if (itrow.Name.Equals(name))
            {
              throw new Exception("Importing tools are not support new schema yet");
              ////if ( type >= 0 )
              ////  itrow.RequestedType = (byte)type;
              //if ( maxage >= 0 )
              //  itrow.MaxAge = maxage;
              //else
              //  itrow.SetMaxAgeNull();//=new DBNull();

              ////TODO:fix import tool
              ////itrow.Async = async;
              ////if ( conversion != "" )
              ////  itrow.Conversion = conversion;
              //itrow.AcceptChanges();
              ////System.Console.WriteLine("zmieniono: "+itrow.Name.ToString()+" numer" +zmieniono.ToString());
              //changes_number++;
            }
          }
        }
        //czytamy jeszce slowo endline:
        file.GetAndMove2NextElement();

      }
      AppendToLog("changed: " + changes_number.ToString() + "of: " + m_database.Items.Count.ToString());
      #endregion IMPORT    
    }
    #endregion

    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportItemSettings"/> class.
    /// </summary>
    /// <param name="database">The database.</param>
    /// <param name="parrent_form">The parrent_form.</param>
    public ImportItemSettings(OPCCliConfiguration database, System.Windows.Forms.Form parrent_form)
      : base(parrent_form)
    {
      m_database = database;
      m_ImportTagsInfo = new ImportTagsInfo();
      SetImportInfo(m_ImportTagsInfo);
    }
    #endregion

  }
}
