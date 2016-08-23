echo off
rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$


rem DEL [/P] [/F] [/S] [/Q] [/A[[:]attributes]] names
rem   names         Specifies a list of one or more files or directories.
rem                 Wildcards may be used to delete multiple files. If a
rem                 directory is specified, all files within the directory
rem                 will be deleted.
rem 
rem   /P            Prompts for confirmation before deleting each file.
rem   /F            Force deleting of read-only files.
rem   /S            Delete specified files from all subdirectories.
rem   /Q            Quiet mode, do not ask if ok to delete on global wildcard
rem   /A            Selects files to delete based on attributes
rem   attributes    R  Read-only files            S  System files
rem                 H  Hidden files               A  Files ready for archiving
rem                 -  Prefix meaning not
REM RMDIR [/S] [/Q] [drive:]path
REM RD [/S] [/Q] [drive:]path

REM     /S      Removes all directories and files in the specified directory
REM             in addition to the directory itself.  Used to remove a directory
REM             tree.

REM     /Q      Quiet mode, do not ask if ok to remove a directory tree with /S
rem all cleanup should be performed in the following directories:
rem EX01-OPCFoundation_NETApi
rem IN12XX-SampleHTTPSoapOPCClient
rem PR24-Biblioteka
rem PR26-DataPorter
echo "$URL$

cd ..\..\
RD /S /Q .\bin 
RD /S /Q .\PR26-DataPorter\bin 
RD /S /Q .\PR26-DataPorter\TestResults 
RD /S /Q .\PR26-DataPorter\Deliverables 
RD /S /Q .\PR26-DataPorter\DataPorterUnitTests\bin 
RD /S /Q .\PR26-DataPorter\DataPorterUnitTests\obj 
RD /S /Q .\PR26-DataPorter\DataPorterConfig\bin 
RD /S /Q .\PR26-DataPorter\DataPorterConfig\obj 
RD /S /Q .\PR26-DataPorter\DataPorter\bin 
RD /S /Q .\PR26-DataPorter\DataPorter\obj 
RD /S /Q .\PR26-DataPorter\DataPorter.Monitor\bin 
RD /S /Q .\PR26-DataPorter\DataPorter.Monitor\obj 
RD /S /Q .\PR26-DataPorter\DataPorter.Monitor.Interface\bin 
RD /S /Q .\PR26-DataPorter\DataPorter.Monitor.Interface\obj 
RD /S /Q .\PR26-DataPorter\Scripts\bin 
RD /S /Q .\PR26-DataPorter\Scripts\obj 
RD /S /Q .\PR26-DataPorter\CAS.OPCWSDataAccess\bin
RD /S /Q .\PR26-DataPorter\CAS.OPCWSDataAccess\obj
RD /S /Q .\PR26-DataPorter\CAS.OPCWSDataAccessSetup\Debug
RD /S /Q .\PR26-DataPorter\CAS.OPCWSDataAccessSetup\Release
RD /S /Q .\PR26-DataPorter\CAS.OPCWSDataAccessSetup\Deliverables
RD /S /Q .\PR26-DataPorter\CAS.OPCWSDataAccessSetup\obj


rem deleting project user files
del /F /S /Q /A:H .\PR26-DataPorter\*.suo
del /F /S /Q  .\PR26-DataPorter\*.cache
rem deleting objects
del /F /S /Q  .\PR26-DataPorter\*.obj
rem deleting intellisence
del /F /S /Q  .\PR26-DataPorter\*.ncb
rem deleting debuger informations
del /F /S /Q  .\PR26-DataPorter\*.pdb
rem deleting user settings 
del /F /S /Q  .\PR26-DataPorter\*.user
rem deleting test settings 
del /F /S /Q  .\PR26-DataPorter\*.vsmdi
rem deletind desktop.ini
del /F /S /Q /A:H .\PR26-DataPorter\*.ini

if /I "%1" NEQ "local" (
echo cleanup
echo $URL$
cd .\PR24-Biblioteka\Scripts
call clean.cmd local
cd ..\..
rem echo $URL$
rem cd .\EX01-OPCFoundation_NETApi\Scripts
rem call clean.cmd local
rem cd ..\..
echo $URL$
cd .\IN12-SampleHTTPSoapOPCClient\Scripts\
call clean.cmd local
cd ..\..
)
rem returning to base directory
cd .\PR26-DataPorter\Scripts
echo on
