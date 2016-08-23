//<summary>
//  Title   : DataPorter Service
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

using System;
using System.ServiceProcess;

namespace CAS.DataPorter
{
  /// <summary>
  /// DataPorter Service
  /// </summary>
  partial class DataPorterService: ServiceBase
  {

    public DataPorterService()
    {
      InitializeComponent();
    }
    #region service support
    protected override void OnStart( string[] args )
    {
      if ( m_DataPorter == null )
        m_DataPorter = new Main();
      m_DataPorter.Tracer.TraceInformation( 23, this.GetType().Name, "Service is starting" );
      m_DataPorter.Start();
      m_DataPorter.ShutdownRequest += m_DataPorter_ShutdownRequest;
    }
    protected override void OnStop()
    {
      StopDataPorter();
    }
    #endregion service support
    #region private
    private void m_DataPorter_ShutdownRequest( object sender, EventArgs e )
    {
      StopDataPorter();
      Stop();
    }
    private void StopDataPorter()
    {
      if ( m_DataPorter != null )
      {
        m_DataPorter.Stop();
        m_DataPorter.ShutdownRequest -= m_DataPorter_ShutdownRequest;
      }
      m_DataPorter = null;
    }
    #endregion private
  }
}
