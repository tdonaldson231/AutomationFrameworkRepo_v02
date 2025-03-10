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
        
        /// <name>
        ///   Test Case: PortalVerifyTextOnAboutPage
        /// </name>
        /// <summary>
        ///   Verify the user is directed to the About Page by verifying the expected text
        ///   Page is returned after clicking on the link from the Home Page.
        /// </summary>
        /// <testid>
        ///     MRN-488: <link to test case id here>
        /// </testid>
        /// <bug>     
        /// </bug>
        /// <note>
        /// </note>
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

