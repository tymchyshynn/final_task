using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using Serilog;

namespace final_task
{

    public class BaseTest : ExtentReport
    {
        ScreanshotDirectory dir = new ScreanshotDirectory();


        [SetUp]
        public void BeforeTest()
        {
            BasePage page = new BasePage(driver);
            try
           {
                Log.Information("Getting the name of current running test to extent report");
                Log.Information("Start test");
                test = report.CreateTest(TestContext.CurrentContext.Test.Name);
                page.DismisAllert();
                page.CloseModalPopup();
            }
           catch (Exception e)
           { 
                throw (e);
           }
        }
      

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    logstatus = Status.Fail;
                    Log.Information("Test failed");
                    Log.Debug(TestContext.CurrentContext.Result.Message);
                    Log.Debug(TestContext.CurrentContext.Result.StackTrace);
                    Log.Information("Take a screenshot");
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    var testName = TestContext.CurrentContext.Test.MethodName;
                    var finalScreenshotPath = Path.Combine(dir.screenshotPath, testName.ToString() + ".jpeg");
                    screenshot.SaveAsFile(finalScreenshotPath);
                    test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                    test.Log(logstatus, "Snapshot below: " + test.AddScreenCaptureFromPath(finalScreenshotPath));
                    break;

                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    logstatus = Status.Skip;
                    Log.Information("Test skiped");
                    test.Log(logstatus, "Test ended with " + logstatus);
                    break;

                default:
                    logstatus = Status.Pass;
                    Log.Information("Test passed");
                    test.Log(logstatus, "Test ended with " + logstatus);             
                    break;
            }

        }

    }
}
