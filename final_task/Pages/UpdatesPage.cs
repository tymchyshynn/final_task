using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace final_task
{
   public class UpdatesPage : BasePage
    {
        public string pageURL = "/updates";

        public UpdatesPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@href ='http://phptravels.com.co/updates/4252/4252.zip']")]
        public IWebElement downloadRtlMenuBug;
      

        
    }
}
