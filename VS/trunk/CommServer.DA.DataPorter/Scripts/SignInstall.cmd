echo off
echo Remeber to configure net20sdk environmental variable
echo e.g.: using command "set net20sdk=C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin"
"%net20sdk%\signtool.exe" sign /n "CAS" /a "..\Deliverables\release\setup.exe" 
"%net20sdk%\signtool.exe" sign /n "CAS" /a "..\Deliverables\release\DataPorterSetup.msi" 
rem "%net20sdk%\signtool.exe" sign /n "CAS" /a "..\Deliverables\release\DataPorterSetup_2_00_02.exe"