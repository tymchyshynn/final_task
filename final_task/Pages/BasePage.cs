using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Serilog;

namespace final_task
{
    public class BasePage: DriverProvider
    {
       
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Open(string pageURL)
        {
            Log.Information("Open base url");
            driver.Navigate().GoToUrl(driver.Url +  pageURL);
        }

        public void DismisAllert()
        {
            Log.Information("Dismis Allert");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("onesignal-popover-cancel-button"))).Click();
     
        }

        public void CloseModalPopup()
        {
            Log.Information("Close modal popup");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-dojo-attach-point = 'modalClose']"))).Click();
                     
        }

        
        [FindsBy(How = How.Id, Using = "address")]
        private IWebElement emailField;

        [FindsBy(How = How.XPath, Using = "//input[@type ='submit']")]
        public IWebElement subscribeButton;

        public void SubscribeUser(string emailAddress)
        {
            Log.Information("Subscibe user to news");
            emailField.SendKeys(emailAddress);
           subscribeButton.Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'strong text-success']")]
        public IWebElement succsessMessage;


    }
}
