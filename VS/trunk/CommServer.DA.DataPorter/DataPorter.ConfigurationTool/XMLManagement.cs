//<summary>
//  Title   : Writing the configuration
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    mzbrzezny 20070904 - added indent formating
//    mzbrzezby 2004 created
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http://www.cas.eu
//</summary>
using System;
using System.Data;

namespace NetworkConfig
{
  /// <summary>
  /// Summary description for XMLManagement.
  /// </summary>
  public class XMLManagement
  {
    //Create a file name to write to.
    System.IO.FileStream myFileStream;

//    public bool XMLFileExist
//    {
//      get
//      {
//        return System.IO.File.Exists(filename);
//      }
//    }
    /// <summary>
    /// Reads the XML file.
    /// </summary>
    /// <param name="myData">My data.</param>
    /// <param name="filename">The filename.</param>
    public void readXMLFile(DataSet myData, string filename)
    {
      //Create the FileStream to read from.
      myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Open);
      System.Xml.XmlTextReader myXmlReader;
      //Create an XmlTextWriter with the fileStream.
      myXmlReader  = new System.Xml.XmlTextReader(myFileStream);
      try
      {
        myData.ReadXml( myXmlReader );
      }
      catch ( Exception ex )
      {
        throw ex;
      }
      finally
      {
        myXmlReader.Close();
      }
    }
    /// <summary>
    /// Writes the XML file.
    /// </summary>
    /// <param name="myData">My data.</param>
    /// <param name="filename">The filename.</param>
    public void writeXMLFile(DataSet myData, string filename)
    {
      myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
      System.Xml.XmlTextWriter myXmlWriter;
      //Create an XmlTextWriter with the fileStream.
      myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
      myXmlWriter.Formatting = System.Xml.Formatting.Indented;
      myData.WriteXml(myXmlWriter);   
      myXmlWriter.Close();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="XMLManagement"/> class.
    /// </summary>
    public XMLManagement()
    {
      //Create the FileStream to write with.
    }
  }
}
