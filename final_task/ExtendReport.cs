using System;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using Serilog;


namespace final_task
{
    public  class ExtentReport: DriverProvider
    {
        public  ExtentReports report;
        public  ExtentTest test;

        [OneTimeSetUp]
        public void CreateExtentReport()
        {
            var destinationPath = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                //Create report 
                Log.Information("Create report");
                report = new ExtentReports();

                //Path to report
                string reportsPath = Path.Combine(destinationPath, "Reports", DateTime.Now.ToString("dd-MM-yy HH-mm-ss"));

                if (!Directory.Exists(reportsPath))
                    {
                        Directory.CreateDirectory(reportsPath);
                    }

                //Set up report 
                var htmlReporter = new ExtentHtmlReporter(reportsPath  + "\\Automation_Report" + ".html");
                report.AddSystemInfo("Environment", "phptravels");
                report.AddSystemInfo("User Name", "Vasyl Tymchyshyn");
                report.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        [OneTimeTearDown]
        public void FlushExtentReport()
        {
            Log.Information("Flush report");
            report.Flush();    
        }

    }
}