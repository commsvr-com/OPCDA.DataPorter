//  Title   : Reads application configuration file
//  Author  : Maciej Zbrzezny
//  System  : Microsoft Visual C# .NET
//  History :
//    24-03-2005: created
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2003, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http:\\www.cas.com.pl
namespace OPCWSDataAccess
{
  using System;
  using System.Configuration;
	/// <summary>
	/// Summary description for AppConfigManagement.
	/// </summary>
	internal class AppConfigManagement
	{
    private static readonly System.Collections.Specialized.NameValueCollection ConfigValues;
    private static string GetAppSetting(string key, string val_alternative)
    {
      return ConfigValues[ key ];
    }
    public static readonly string remote_da = "";
    public static readonly string remote_realitime = "";
    public static readonly string remote_buffered = "";
    static AppConfigManagement()
		{
      ConfigValues = ConfigurationManager.AppSettings;

      remote_da = GetAppSetting( "remote_da", remote_da );
      remote_realitime = GetAppSetting( "remote_realitime", remote_realitime );
      remote_buffered = GetAppSetting( "remote_buffered", remote_buffered );
    }
	}
}
