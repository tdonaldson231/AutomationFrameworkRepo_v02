using AutomationFramework_v8._0.Src.Lib;
using AutomationFrameworkRepo_v02.Src.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFrameworkRepo_v02.Src.PageObjects
{
    class AboutPage : Base
    {
        private readonly IWebDriver webDriver;
        private readonly WebDriverWait wait;
        private static int webDriverTimeout = 15;

        // Use WebDriverWait in combination with expected conditions to wait for an element to appear, 
        // become clickable, or change state before interacting with it. 
        public AboutPage(IWebDriver webDriver, TestConfigFixture config) : base(config)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(webDriverTimeout));
        }

        //private By PageHeaderLabelLocator => By.XPath("//span[contains(text(), 'We elevate the way the world')]");
        private By PageHeaderLabelLocator => By.XPath(LocatorReader.GetLocator("AboutPage", "PageHeaderLabel"));

        public bool ValidatePageHeader(string expectedHeader)
        {
            try
            {
                IWebElement pageHeaderLabel = wait.Until(ExpectedConditions.ElementIsVisible(PageHeaderLabelLocator));

                Assert.True(pageHeaderLabel.Text.Contains(expectedHeader),
                    "The Web Page does not contain the specified label");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
            return true;
        }
    }
}
