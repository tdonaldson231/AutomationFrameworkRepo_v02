using Xunit;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AutomationFrameworkRepo_v02.Src.PageObjects;
using AutomationFramework_v8._0.Src.Lib;
using Xunit.Abstractions;

namespace UserInterface
{
    [Collection("Extent Report Collection")]
    public class PortalTests : Base, IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly IWebDriver _webDriver;
        private readonly ExtentReportsFixture _reportFixture;
        private ExtentTest _test;
        private TestConfigFixture _config;
        private string testMsg;

        public PortalTests(ExtentReportsFixture reportFixture, WebDriverFixture webDriverFixture, TestConfigFixture config, ITestOutputHelper output) : base(config)
        {
            _reportFixture = reportFixture;
            _webDriver = webDriverFixture.WebDriver;
            _config = config;
            _output = output;
            _output.WriteLine($"Test Environment (PortalTests): {testEnvironment}");
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
        [Trait("Category", "Regression")]
        [Trait("Category", "UI")]
        public void PortalVerifyTextOnAboutPage()
        {
            try
            {
                string expectedPageLabel = "We elevate the way the world";
                _test = _reportFixture.Extent.CreateTest("PortalVerifyTextOnAboutPage");

                var homePage = new HomePage(_webDriver, _config);
                var aboutPage = new AboutPage(_webDriver, _config);

                homePage.ClickAboutPageLink();

                Assert.True(aboutPage.ValidatePageHeader(expectedPageLabel));
                testMsg = "PASS: The expected text was found on the About page.";
                _test.Pass(testMsg);
            }
            catch (Exception ex)
            {
                testMsg = "FAIL: The expected status was not detected. " + ex.Message;
                _test.Fail(testMsg);
                throw;
            }
            finally
            {
                _output.WriteLine(testMsg);
            }
        }
    }
}

