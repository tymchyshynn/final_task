using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.IO;

namespace final_task
{
    //[SetUpFixture]
    public class DriverProvider
    {
        public string downloadDirectoryPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Downloads", DateTime.Now.ToString("dd-MM-yy HH-mm-ss"));

        public IWebDriver driver = null;

        [OneTimeSetUp]
        public void CreateDriverWithOptions()
        {
            try
            {
                //Driver options
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments
                (
                    //"--start-fullscreen",
                    //"--headless",
                    "--start-maximized",
                    "--disable-infobars"
                );

                //Change the default download directory
                Directory.CreateDirectory(downloadDirectoryPath);
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectoryPath);

                //Create driver
                Log.Information("Creating driver with option");
                driver = new ChromeDriver(chromeOptions);
                driver.Url = "https://phptravels.com";

                
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [OneTimeTearDown]
        public void QuitDriver()
        {
            Log.Information("Quit driver");
            driver.Quit();
        }


    }
}
