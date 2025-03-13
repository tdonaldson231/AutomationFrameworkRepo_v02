using AutomationFramework_v8._0.Src.Lib;
using AutomationFrameworkRepo_v02.Src.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFrameworkRepo_v02.Src.PageObjects
{
    class HomePage : Base
    {
        private readonly IWebDriver webDriver;
        private readonly WebDriverWait wait;

        public HomePage(IWebDriver webDriver, TestConfigFixture config) : base(config)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
        }

        //private By AboutPageLinkLocator => By.XPath("//a[text()='About']");
        private By AboutPageLinkLocator => By.XPath(LocatorReader.GetLocator("HomePage", "AboutPageLink"));

        public void ClickAboutPageLink()
        {
            try
            {
                IWebElement aboutPageLink = wait.Until(ExpectedConditions.ElementToBeClickable(AboutPageLinkLocator));
                aboutPageLink.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
