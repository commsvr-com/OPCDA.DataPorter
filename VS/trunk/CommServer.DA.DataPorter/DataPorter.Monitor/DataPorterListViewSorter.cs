using System;
using System.Windows.Forms;
using System.Collections;
//<summary>
//  Title   : DataPorterListViewSorter
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
      
namespace CAS.DataPorter.Monitor
{
  /// <summary>
  /// Class used for comparing items on the ListView
  /// </summary>
  public class DataPorterListViewSorter: IComparer
  {
    /// <summary>
    /// Is True when sorting is "ascending" and False if "descending"
    /// </summary>
    public bool bAscending = true;

    /// <summary>
    /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
    /// </summary>
    /// <param name="x">The first object to compare.</param>
    /// <param name="y">The second object to compare.</param>
    /// <returns>
    /// Value
    /// Condition
    /// Less than zero
    /// <paramref name="x"/> is less than <paramref name="y"/>.
    /// Zero
    /// <paramref name="x"/> equals <paramref name="y"/>.
    /// Greater than zero
    /// <paramref name="x"/> is greater than <paramref name="y"/>.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">
    /// Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.
    /// -or-
    /// <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other.
    /// </exception>
    public int Compare( object x, object y )
    {
      ListViewItem lvi1 = (ListViewItem)x;
      ListViewItem lvi2 = (ListViewItem)y;
      string lvi1String = lvi1.SubItems[ 0 ].ToString();
      string lvi2String = lvi2.SubItems[ 0 ].ToString();
      if ( bAscending )
        return String.Compare( lvi1String, lvi2String );
      else
        return -String.Compare( lvi1String, lvi2String );
    }
  }
}
