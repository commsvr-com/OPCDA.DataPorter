rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$
if "%1%"=="" goto ERROR

svn mkdir svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1  -m "created new tag  %1 (release folder)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/PR26-DataPorter svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1/PR26-DataPorter -m "created new DataPorter tag %1 (project PR26-DataPorter)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/IN12-SampleHTTPSoapOPCClient svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1/IN12-SampleHTTPSoapOPCClient -m "created new DataPorter tag %1 (project IN12-SampleHTTPSoapOPCClient)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/PR24-Biblioteka svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1/PR24-Biblioteka -m "created new DataPorter tag %1 (project PR24-Biblioteka)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/CommonBinaries svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1/CommonBinaries -m "created new DataPorter tag %1 (project CommonBinaries)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/ImageLibrary svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1/ImageLibrary -m "created new DataPorter tag %1 (project ImageLibrary)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/PR30-OPCViever svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1/PR30-OPCViever -m "created new DataPorter tag %1 (project PR30-OPCViever)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/PR39-CommonResources svn://svnserver.hq.cas.com.pl/VS/tags/DataPorter/%1/PR39-CommonResources -m "created new DataPorter tag %1 (project PR39-CommonResources)"

goto EXIT
:ERROR
echo Parametr must be set
:EXIT
