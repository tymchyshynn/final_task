using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Serilog;

namespace final_task.Tests
{
    class UserSubsribeTest:BaseTest
    {
        User user = new User().FillIn();
        
        [Test]
        [Description("Subscribe user to news")]
        public void SubsribeUserToNews()
        {
            BasePage page = new BasePage(driver);
            page.SubscribeUser(user.Email);
            Thread.Sleep(2000);
            Assert.That(page.succsessMessage.Displayed);

        }
    }
}
