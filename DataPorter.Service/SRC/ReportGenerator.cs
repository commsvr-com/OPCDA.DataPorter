// <summary>
//  Title   : DataPorter (Client OPC) ReportGenerator
//  Author  : MZbrzezny
//  System  : Microsoft Visual C# .NET
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  History :
//    Mzbrzezny - 25-03-05
//      created 
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: 42' 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
// </summary>

using System.IO;
using System.Text;
using CAS.DataPorter.Lib.BaseStation.Management;
using CAS.Lib.OPCClient.Da.Management;
using CAS.Lib.RTLib.Management;

namespace CAS.DataPorter
{
  /// <summary>
  /// Class that generate html report about OPC Client Transporter state
  /// </summary>
  public class ReportGenerator: CAS.Lib.RTLib.Utils.ReportGenerator
  {
    /// <summary>
    /// Gets the string that represents the report.
    /// </summary>
    /// <returns>the report</returns>
    /// <remarks>not yet implemented.</remarks>
    public override string GetReportString()
    {
      StringBuilder sb = new StringBuilder();
      //wpisujemy nag³owek
      sb.AppendLine( this.getHeader() );
      //najpierw robimy nag³owek
      sb.AppendLine( @"<tr><td width='782'><h1>CAS - DataPorter " + "</h1></td><tr>" );
      sb.AppendLine( @"<tr><td  bgcolor='#021376' width='782' height='1'></td></tr>" );
      sb.AppendLine( @"<tr><td width='782'>" );
      //
      //Miejsce na wlasciwe dane
      sb.AppendLine( @"<table border='0' align='center' width='700' class='t1'>" );
      sb.AppendLine( @"<tr><td class='k1'>Report time </td><td>" + System.DateTime.Now.ToString() + "</td></tr>" );
      sb.AppendLine( @"<tr><td class='k1'>Run Time [s] </td><td>" + Main.RunTime.ToString() + "</td></tr>" );
      sb.AppendLine( @"<tr><td class='k1'>Program Name </td><td>" + System.Windows.Forms.Application.ProductName + "</td></tr>" );
      sb.AppendLine( @"<tr><td class='k1'>Release </td><td>" + System.Windows.Forms.Application.ProductVersion + "</td></tr>" );
      sb.AppendLine( @"</table>" );
      sb.AppendLine( @"<Table border='0' width='100'>
	          <TBody>
	          <TR>
	          <TD class='kk'><t>.......................................................................................</TD>
            </TR></TBODY></Table>
             " );
      //
      // pierwszy obiekt - by wziac naglowek tabeli
      IHtmlOutput firstobj;
      //clienci opc:
      if ( OPCClientStatistics.ServersList.Count > 0 )
      {
        sb.AppendLine( @"<h2>OPC Clients</h2><table border='1'>" );
        firstobj = OPCClientStatistics.ServersList.Values[0];
        sb.AppendLine( firstobj.GetHtmlTableRowDescription() );
        foreach ( var kvp in OPCClientStatistics.ServersList )
        {
          IHtmlOutput obj = kvp.Value as IHtmlOutput;
          if ( obj != null )
            sb.AppendLine( obj.ToHtmlTableRow() );
        }
        sb.AppendLine( @"</table>" );
      }
      //grupy opc:
      if ( OPCGroup.GroupList.Count > 0 )
      {
        sb.AppendLine( @"<h2>OPC Groups</h2><table border='1'>" );
        firstobj = (IHtmlOutput)OPCGroup.GroupList.Values[ 0 ];
        sb.AppendLine( firstobj.GetHtmlTableRowDescription() );
        foreach ( var kvp in OPCGroup.GroupList )
        {
          IHtmlOutput obj = kvp.Value as IHtmlOutput;
          if ( obj != null )
            sb.AppendLine( obj.ToHtmlTableRow() );
        }
        sb.AppendLine( @"</table>" );
      }
      //items opc:
      if ( OPCTag.AllTags.Count > 0 )
      {
        sb.AppendLine( @"<h2>OPC Items</h2><table border='1'>" );
        firstobj = (IHtmlOutput)OPCTag.AllTags.Values[ 0 ];
        sb.AppendLine( firstobj.GetHtmlTableRowDescription() );
        foreach ( var kvp in OPCTag.AllTags )
        {
          IHtmlOutput obj = kvp.Value as IHtmlOutput;
          if ( obj != null )
            sb.AppendLine( obj.ToHtmlTableRow() );
        }
        sb.AppendLine( @"</table>" );
      }
      if ( TransactionStatistics.TransactionList.Count > 0 )
      {
        //transaction opc:
        sb.AppendLine( @"<h2>Transaction</h2><table border='1'>" );
        firstobj = (IHtmlOutput)
          TransactionStatistics.TransactionList.Values[ 0 ];
        sb.AppendLine( firstobj.GetHtmlTableRowDescription() );
        foreach ( var kvp in TransactionStatistics.TransactionList )
        {
          IHtmlOutput obj = kvp.Value as IHtmlOutput;
          if ( obj != null )
            sb.AppendLine( obj.ToHtmlTableRow() );
        }
        sb.AppendLine( @"</table>" );
      }
      //
      //stopka:
      sb.AppendLine( this.getFooter() );
      return sb.ToString();
    }
    /// <summary>
    /// generatin a report
    /// </summary>
    protected override void doReport()
    {
      //otwieramy
      using ( StreamWriter sw = File.CreateText( DestFilename ) )
      {
        sw.WriteLine( this.GetReportString() );
      }
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ReportGenerator"/> class.
    /// </summary>
    /// <param name="title">The title of the repoert.</param>
    public ReportGenerator( string title )
      : base( title )
    {
    }
  }
}
