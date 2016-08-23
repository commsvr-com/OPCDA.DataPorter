//<summary>
//  Title   : service OPCDataAccess
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20081229: mzbrzezny: spelling fixes - Intem is changed to Item
//    20081217: mzbrzezny: set value functionality is added
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
using System.Xml.Serialization;
using CAS.Lib.DeviceSimulator;

namespace OPCWSDataAccess
{
  /// <summary>
  /// Summary description for OPCDataAccess
  /// </summary>
  [WebService( Namespace = "http://cas.eu/Opc.Da/", Name = "OPCDataAccess", Description = "Data Acces to OPC via Web Services" )]
  [WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
  [ToolboxItem( false )]
  public class OPCDataAccess: System.Web.Services.WebService
  {
    private CAS.Lib.DeviceSimulator.IOPCDataAccess remotetype_DA;
    [WebMethod( Description = "Get all item names availiable via this service" )]
    public string[] GetAvailiableItems()
    {
      return ( (IOPCDataAccess)remotetype_DA ).GetAvailiableItems();
    }
    [WebMethod( Description = "List all OPC properties" )]
    public Opc.Da.PropertyID[] GetOPCProperties()
    {
      return ( (IOPCDataAccess)remotetype_DA ).GetOPCProperties();
    }
    [WebMethod( Description = "Get properties values for one selected item and property list" )]
    public Opc.Da.ItemPropertyCollection GetAvailableProperties_OneItem_Proplist( string itemID, Opc.Da.PropertyID[] propertyIDs )
    {
      return OPCWSHelperToolbox.PropertiesXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( itemID, propertyIDs ) );
    }
    [WebMethod]
    public Opc.Da.ItemPropertyCollection GetAvailableProperties_OneItem_Proplist_returnValues( string itemID, Opc.Da.PropertyID[] propertyIDs, bool returnValues )
    {
      return OPCWSHelperToolbox.PropertiesXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( itemID, propertyIDs, returnValues ) );
    }
    [WebMethod]
    [XmlInclude( typeof( System.Type ) ), XmlInclude( typeof( Opc.ResultID ) ), XmlInclude( typeof( Opc.Da.PropertyID ) )]
    public Opc.Da.ItemPropertyCollection GetAvailableProperties_OneItem( string itemID )
    {
      return OPCWSHelperToolbox.PropertiesXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( itemID ) );
    }
    [WebMethod]
    [XmlInclude( typeof( System.Type ) ), XmlInclude( typeof( Opc.ResultID ) ), XmlInclude( typeof( Opc.Da.PropertyID ) )]
    public Opc.Da.ItemProperty GetProperty_OneItem( string itemID, int idx )
    {
      return OPCWSHelperToolbox.PropertyXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( itemID )[ idx ] );
    }
    [WebMethod]
    public Opc.Da.ItemPropertyCollection GetAvailableProperties_OneItem_returnValues( string itemID, bool returnValues )
    {
      return OPCWSHelperToolbox.PropertiesXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( itemID, returnValues ) );
    }
    [WebMethod]
    public Opc.Da.ItemPropertyCollection[] GetAvailableProperties_MultiItem_PropList( string[] itemID, Opc.Da.PropertyID[] propertyIDs )
    {
      return OPCWSHelperToolbox.PropertiesCollectionXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( itemID, propertyIDs ) );
    }
    [WebMethod]
    public Opc.Da.ItemPropertyCollection[] GetAvailableProperties_MultiItem_Proplist_returnValues( string[] itemID, Opc.Da.PropertyID[] propertyIDs, bool returnValues )
    {
      return OPCWSHelperToolbox.PropertiesCollectionXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( itemID, propertyIDs, returnValues ) );
    }
    [WebMethod]
    public Opc.Da.ItemPropertyCollection[] GetAvailableProperties_Proplist( Opc.Da.PropertyID[] propertyIDs )
    {
      return OPCWSHelperToolbox.PropertiesCollectionXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( propertyIDs ) );
    }
    [WebMethod]
    public Opc.Da.ItemPropertyCollection[] GetAvailableProperties_Proplist_returnValues( Opc.Da.PropertyID[] propertyIDs, bool returnValues )
    {
      return OPCWSHelperToolbox.PropertiesCollectionXMLSerializerFilter( ( (IOPCDataAccess)remotetype_DA ).GetAvailableProperties( propertyIDs, returnValues ) );
    }
    /// <summary>
    /// get version of interface
    /// </summary>
    /// <returns>version of interface</returns>
    [WebMethod]
    public string GetVersion()
    {
      return ( (IOPCDataAccess)remotetype_DA ).GetVersion() + "| WS version = $Id$";
    }
    #region tests
    //[WebMethod]
    //public Opc.ResultID getresultid()
    //{
    //  return Opc.Results.E_ACCESS_DENIED;
    //}
    //[WebMethod]
    //public Opc.Da.PropertyID getpropid()
    //{
    //  return Opc.Da.Property.TIMESTAMP;
    //}
    //[WebMethod]
    //public Opc.OPCXmlQualifiedName getqualifiedname()
    //{
    //  return new Opc.OPCXmlQualifiedName( "nazwa", "namespace" );
    //}
    #endregion
    #region realtime DA
    [WebMethod]
    [XmlInclude( typeof( Opc.Da.ItemValueResult ) ), XmlInclude( typeof( System.Type ) ), XmlInclude( typeof( System.Reflection.MemberInfo ) )]
    public Opc.Da.ItemValueResult GetValue_OneItem( string ItemName )
    {
      return ( (IOPCDataAccess)remotetype_DA ).GetValue( ItemName );
    }
    [WebMethod( Description = "Set the value of item as String" )]
    public bool SetValueAsString_OneItem( string ItemName, System.String Value )
    {
      return ( (IOPCDataAccess)remotetype_DA ).SetValue( ItemName, Value );
    }
    [WebMethod( Description = "Set the value of item as Double" )]
    public bool SetValueAsDouble_OneItem( string ItemName, System.Double Value )
    {
      return ( (IOPCDataAccess)remotetype_DA ).SetValue( ItemName, Value );
    }
    [WebMethod( Description = "Set the value of item as Integer 32" )]
    public bool SetValueAsInt32_OneItem( string ItemName, System.Int32 Value )
    {
      return ( (IOPCDataAccess)remotetype_DA ).SetValue( ItemName, Value );
    }
    [WebMethod]
    public Opc.Da.ItemValueResult[] GetValue_MultiItem( string[] ItemName )
    {
      return ( (IOPCDataAccess)remotetype_DA ).GetValue( ItemName );
    }
    #endregion

    public OPCDataAccess()
    {

      remotetype_DA = (IOPCDataAccess)Activator.GetObject
        (
        typeof( IOPCDataAccess ),
        AppConfigManagement.remote_da
        );
    }
  }
}
