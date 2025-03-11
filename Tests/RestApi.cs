using Xunit;
using RestSharp;
using AutomationFramework_v8._0.Src.Lib;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace RestApi
{
    [Collection("Extent Report Collection")]
    public class RestApi
    {
        private readonly ExtentReportsFixture _reportFixture;
        private ExtentTest _test;

        public RestApi(ExtentReportsFixture reportFixture)
        {
            _reportFixture = reportFixture;
        }

        /// <name>
        ///   Test Case: RestApiPostDataBackendService
        /// </name>
        /// <summary>
        ///   Verify backend service responds with an status code 200/OK 
        //?    when performing a Get.
        /// </summary>
        /// <testid>
        ///     MRN-303: <link to test case id here>
        /// </testid>
        /// <bug>
        ///     JIRA-5004: An Error is displayed when attempting API Get
        /// </bug>
        /// <note>
        ///     Note: Throws an Assert if the returned status codes does not equal OK
        /// </note>
        [Fact]
        [Trait("Category", "Regression")]
        [Trait("Category", "API")]
        public void RestApiPostDataBackendService()
        {
            try
            {
                string apiUrl = Base.restApiUrl;
                var client = new RestClient(apiUrl);
                _test = _reportFixture.Extent.CreateTest("RestApiPostDataBackendService");

                RestResponse response = client.Get(new RestRequest());
                System.Net.HttpStatusCode statusCode = response.StatusCode;

                Assert.Equal("OK", statusCode.ToString());
                _test.Pass("PASS: The expected status was detected from the backend service.");
            }
            catch (Exception ex)
            {
                _test.Fail("FAIL: The expected status was detected. " + ex.Message);
                throw;
            }
        }

        [Fact]
        [Trait("Category", "API")]
        public void RestApiPostDataBackendServiceFailure()
        {
            try
            {
                string apiUrl = Base.restApiUrl;
                var client = new RestClient(apiUrl);
                _test = _reportFixture.Extent.CreateTest("RestApiPostDataBackendService");

                RestResponse response = client.Get(new RestRequest());
                System.Net.HttpStatusCode statusCode = response.StatusCode;

                Assert.Equal("OkieDokie", statusCode.ToString());
                _test.Pass("PASS: The expected status was detected from the backend service.");
            }
            catch (Exception ex)
            {
                _test.Fail("FAIL: The expected status was detected: " + ex.Message);
                throw;
            }
        }
    }
}

