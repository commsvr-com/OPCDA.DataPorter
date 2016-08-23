// <summary>
//  Title   : Configuration management utilities
//  Author  : Mariusz Postol
//  System  : Microsoft Visual C# .NET
//  History :
//    <Author> MZbrzezny <date>:09032005
//    <description> dostosowano do konfiguracji clienta OPC
//
//  Copyright (C)2003, CAS LODZ POLAND.
//  TEL: 42' 686 25 47
//  mailto: techsupp@cas.com.pl
//  http: www.cas.com.pl
// </summary>

using System.Data;
using System.IO;

namespace CAS.DataPorter
{
  /// <summary>
  /// Opens and reads OPC server configuration from XML file.
  /// </summary>
  public class XMLManagement
  {
    #region PRIVATE
    private string filename = AppConfigManagement.filename;
    #endregion
    #region PUBLIC
    /// <summary>
    /// Reads the XML file.
    /// </summary>
    /// <param name="myData">My data.</param>
    public void readXMLFile( DataSet myData )
    {
      System.Xml.XmlTextReader myXmlReader;
      using ( FileStream myFileStream = new System.IO.FileStream( filename, System.IO.FileMode.Open ) )
      {
        //Create an XmlTextReader with the fileStream.
        myXmlReader = new System.Xml.XmlTextReader( myFileStream );
      }
      myData.ReadXml( myXmlReader );
      myXmlReader.Close();
    }
    /// <summary>
    /// Writes the XML file.
    /// </summary>
    /// <param name="myData">My data.</param>
    public void writeXMLFile( DataSet myData )
    {
      System.Xml.XmlTextWriter myXmlWriter;
      using ( FileStream myFileStream = new System.IO.FileStream( filename, System.IO.FileMode.Create ) )
      {
        //Create an XmlTextWriter with the fileStream.
        myXmlWriter = new System.Xml.XmlTextWriter( myFileStream, System.Text.Encoding.Unicode );
      }
      myData.WriteXml( myXmlWriter );
      myXmlWriter.Close();
    }
    #endregion
  }
}
