using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace final_task
{
    public class ServicesPage:BasePage
    {
        public string pageURL = "/services";

        public ServicesPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath,Using = "//title")]
        public IWebElement pageTitle;




    }
}
