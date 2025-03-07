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

        [Fact]
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
                _test.Fail("FAIL: " + ex.Message);
                throw;
            }
        }

        [Fact]
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
                _test.Fail("FAIL: " + ex.Message);
                throw;
            }
        }
    }
}

