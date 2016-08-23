
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CAS.CommServer.DA.DataPorter.OPCViewer.UnitTests
{
  [TestClass]
  public class LoadOPCViewerUnitTest
  {
    [TestMethod]
    public void AssemblyLoadTestMethod()
    {
      Type _ProgramType = typeof(Program);
      Assembly _opcViewer = _ProgramType.Assembly;
      Assert.IsNotNull(_opcViewer);
    }
    [TestMethod]
    public void InstallLicenseTestMethod()
    {
#if ! DEBUG
      Assert.Inconclusive("This test method is supported only in the DEBUG");
#endif      
      bool _isCalled = false;
      Program.InstallLicense = x => _isCalled = true;
      Program.DoInstallLicense("");
      Assert.IsFalse(_isCalled);
      Program.DoInstallLicense("installic");
      Assert.IsTrue(_isCalled);
    }
    [TestMethod]
    public void DoInstallLicenseTestMethod()
    {
      bool _isCalled = false;
      Program.MessageBoxShow = (x) => { _isCalled = true; return DialogResult.OK; };
      Program.DoInstallLicense("");
      Assert.IsFalse(_isCalled);
      Program.DoInstallLicense("installic");
      Assert.IsFalse(_isCalled);
    }
    [TestMethod]
    public void DoApplicationRunTestMethod()
    {
#if ! DEBUG
      Assert.Inconclusive("This test method is supported only in the DEBUG");
#endif      
      bool _isCalled = false;
      Program.DoApplicationRun(x => { _isCalled = true; Assert.IsInstanceOfType(x, typeof(Form)); });
      Assert.IsTrue(_isCalled);
    }
  }
}
