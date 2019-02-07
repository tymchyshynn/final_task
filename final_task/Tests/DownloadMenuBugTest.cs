using System;
using System.IO;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Serilog;

namespace final_task.Tests
{
    class DownloadMenuBugTest: BaseTest
    {
        [Test]
        [Description("Download menu bug")]
        public void DownloadMenuBug()
        {
            UpdatesPage updPage = new UpdatesPage(driver);

            Log.Information("Open Updates page");
            updPage.Open(updPage.pageURL);

            Log.Information("Downloal zip file");
            updPage.downloadRtlMenuBug.Click();
            
          Assert.That(Directory.GetFiles(downloadDirectoryPath), Is.Not.Empty);


        }
    }
}
