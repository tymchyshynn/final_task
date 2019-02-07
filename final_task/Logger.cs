using System;
using System.IO;
using NUnit.Framework;
using Serilog;

namespace final_task
{
    [SetUpFixture]
    class Logger
    {
       //Path to logs
       private string testsResultFolder = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestResults", DateTime.Now.ToString("dd-MM-yy HH-mm-ss"));
  
        [OneTimeSetUp]
        public void CreateLogger()
        {

           

            //Create date and time folder for test results
            if (!Directory.Exists(testsResultFolder))
            {
                Directory.CreateDirectory(testsResultFolder);
            }

            //Create and set up logger
            Log.Information("Create and set up logger");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithProcessId()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                .WriteTo.File($@"{testsResultFolder}\logs.txt", Serilog.Events.LogEventLevel.Information, outputTemplate: "[{Timestamp:yyyy/MM/dd HH:mm:ss}][{ProcessId}][{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File($@"{testsResultFolder}\detailedLogs.txt", outputTemplate: "[{Timestamp:yyyy/MM/dd HH:mm:ss}][{ProcessId}][{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information("Create folder for test results");

        }

        [OneTimeTearDown]
        public void FlushLogger()
        {
            //Log.Information("Call OneTimeTearDown Method");
            Log.CloseAndFlush();
        }

    }
}
