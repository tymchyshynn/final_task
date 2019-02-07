using System;
using System.IO;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Serilog;

namespace final_task.Tests
{
    class ServicesPageTitleTest:BaseTest
    {

        [Test]
        [Description("Services page title text")]
        public void VerifyPageTitle()
        {
            ServicesPage srvPage = new ServicesPage(driver);

            Log.Information("Open Services page");
            srvPage.Open(srvPage.pageURL);

            Log.Information("Verify page title");
            Assert.That(srvPage.pageTitle.Text.Length > 1000);
        }
    }
}
