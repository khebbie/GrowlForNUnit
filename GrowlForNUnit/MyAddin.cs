using System;
using NUnit.Core;
using NUnit.Core.Extensibility;

namespace GrowlForNUnit
{
    [NUnitAddin(Type = ExtensionType.Core,
        Name = "Growl for NUnit Add In",
        Description = "Sends build notifications to growl")]
    public class GrowlAddin : IAddin, EventListener
    {
        private readonly Notifier _notifier;

        public GrowlAddin()
        {
            _notifier = new Notifier();
            _notifier.RegisterGrowl();
        }

        #region EventListener Members

        public void RunStarted(string name, int testCount)
        {
        }

        public void RunFinished(TestResult result)
        {
        }

        public void RunFinished(Exception exception)
        {
        }

        public void TestStarted(TestName testName)
        {
        }

        public void TestFinished(TestResult result)
        {
        }

        public void SuiteStarted(TestName testName)
        {
        }

        public void SuiteFinished(TestResult result)
        {
            //_notifier.Notify("Suite finished", result.Message, true);
        }

        public void UnhandledException(Exception exception)
        {
        }

        public void TestOutput(TestOutput testOutput)
        {
        }

        #endregion

        #region IAddin Members

        public bool Install(IExtensionHost host)
        {
            IExtensionPoint testCaseBuilders = host.GetExtensionPoint("EventListeners");

            if (testCaseBuilders == null)
                return false;
            testCaseBuilders.Install(this); //this implments both interfaces
            return true;
        }

        #endregion
    }
}