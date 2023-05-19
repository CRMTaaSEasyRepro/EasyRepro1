using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace Microsoft.Dynamics365.UIAutomation.Sample
{
    [TestClass]
    public class ExtentReportManager
    {
        protected static ExtentReports extent;
        protected static ExtentTest test;

        [AssemblyInitialize]
        public static void SetupReport(TestContext context)
        {
            string currentDicrectory = Directory.GetCurrentDirectory();
            string reportPath = Path.Combine(currentDicrectory, "Report.html");

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.ReportName = "Test Execution Report";
            htmlReporter.Config.Theme = Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        public void CreateTest(string testName, string testDescription)
        {
            test = extent.CreateTest(testName, testDescription);
        }

        public void LogTestStep(Status status, string stepDescription)
        {
            test.Log(status, stepDescription);
        }

        [AssemblyCleanup]
        public static void FlushReport()
        {
            extent.Flush();
        }
        
    }
}
