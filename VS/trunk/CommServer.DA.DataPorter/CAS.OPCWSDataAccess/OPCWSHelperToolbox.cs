//<summary>
//  Title   : OPC WebServices Helper Toolbox
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

namespace OPCWSDataAccess
{
  public class OPCWSHelperToolbox
  {
    static internal Opc.Da.ItemProperty PropertyXMLSerializerFilter( Opc.Da.ItemProperty prop )
    {
      Opc.Da.ItemProperty retprop = (Opc.Da.ItemProperty)prop.Clone();
      if ( prop.Value != null )
      {
        string valuetype = prop.Value.GetType().FullName;
        if ( valuetype == "System.RuntimeType" || valuetype == "System.Type" )
        {
          retprop.Value = ( (System.Type)prop.Value ).FullName;
        }
      }
      return retprop;
    }
    static internal Opc.Da.ItemPropertyCollection PropertiesXMLSerializerFilter( Opc.Da.ItemPropertyCollection inputproplist )
    {
      Opc.Da.ItemPropertyCollection returnproplist = new Opc.Da.ItemPropertyCollection();
      foreach ( Opc.Da.ItemProperty prop in inputproplist )
      {

        returnproplist.Add( PropertyXMLSerializerFilter( prop ) );
      }
      return returnproplist;
    }
    static internal Opc.Da.ItemPropertyCollection[] PropertiesCollectionXMLSerializerFilter( Opc.Da.ItemPropertyCollection[] inputproplist )
    {
      Opc.Da.ItemPropertyCollection[] returnproplist = new Opc.Da.ItemPropertyCollection[ inputproplist.Length ];
      int idx = 0;
      foreach ( Opc.Da.ItemPropertyCollection prop in inputproplist )
      {
        returnproplist[ idx++ ] = PropertiesXMLSerializerFilter( prop );
      }
      return returnproplist;

    }
  }
}