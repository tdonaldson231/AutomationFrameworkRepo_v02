using Xunit;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AutomationFrameworkRepo_v02.Src.PageObjects;

namespace UserInterface
{
    [Collection("Extent Report Collection")]
    public class PortalTests : IClassFixture<WebDriverFixture>
    {
        private readonly IWebDriver _webDriver;
        private readonly ExtentReportsFixture _reportFixture;
        private ExtentTest _test;

        public PortalTests(ExtentReportsFixture reportFixture, WebDriverFixture webDriverFixture)
        {
            _reportFixture = reportFixture;
            _webDriver = webDriverFixture.WebDriver;
        }
        
        [Fact]
        public void PortalVerifyTextOnAboutPage()
        {
            try
            {
                string expectedPageLabel = "We elevate the way the world";
                _test = _reportFixture.Extent.CreateTest("PortalVerifyTextOnAboutPage");

                var homePage = new HomePage(_webDriver);
                var aboutPage = new AboutPage(_webDriver);

                homePage.ClickAboutPageLink();

                Assert.True(aboutPage.ValidatePageHeader(expectedPageLabel));
                _test.Pass("PASS: The expected text was found on the About page.");
            }
            catch (Exception ex)
            {
                _test.Fail("FAIL: " + ex.Message);
                throw;
            }
        }
    }
}

