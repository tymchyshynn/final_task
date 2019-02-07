using System;
using System.IO;
using NUnit.Framework;


namespace final_task
{
    [SetUpFixture]
    public class ScreanshotDirectory
    {

        //Path to screanshots
        public static string destinationPath = AppDomain.CurrentDomain.BaseDirectory;
        public string screenshotPath = Path.Combine(destinationPath, "Screanshots", DateTime.Now.ToString("dd-MM-yy HH-mm-ss"));

       
        [OneTimeSetUp]
        public void CreateScreanshotDirectory()
        {


            if (!Directory.Exists(screenshotPath))
            {
                Directory.CreateDirectory(screenshotPath);
            }

        }

        

    }           
           
}
