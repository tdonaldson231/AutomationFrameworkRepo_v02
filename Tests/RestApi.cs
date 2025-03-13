using Xunit;
using RestSharp;
using AutomationFramework_v8._0.Src.Lib;
using AventStack.ExtentReports;
using Xunit.Abstractions;
using System;

namespace RestApi
{
    [Collection("Extent Report Collection")]
    public class RestApi : Base
    {
        private readonly ITestOutputHelper _output;
        private readonly ExtentReportsFixture _reportFixture;
        private ExtentTest _test;
        private string testMsg;

        public RestApi(ExtentReportsFixture reportFixture, TestConfigFixture config, ITestOutputHelper output) : base(config)
        {
            _reportFixture = reportFixture;
            _output = output;
            _output.WriteLine($"Test Environment (RestApi): {testEnvironment}");
        }     

        /// <name>
        ///   Test Case: RestApiGetDataBackendService
        /// </name>
        /// <summary>
        ///   Verify backend service responds with an status code 200/OK 
        ///    when performing a Get.
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
        public void RestApiGetDataBackendService()
        {
            try
            {
                string apiUrl = Base.restApiUrl;
                var client = new RestClient(apiUrl);
                _test = _reportFixture.Extent.CreateTest("RestApiGetDataBackendService");

                RestResponse response = client.Get(new RestRequest());
                System.Net.HttpStatusCode statusCode = response.StatusCode;

                Assert.Equal("OK", statusCode.ToString());
                testMsg = "PASS: The expected status was detected from the backend service.";
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

        [Fact]
        [Trait("Category", "API")]
        public void RestApiGetDataBackendServiceFailure()
        {
            try
            {
                string apiUrl = Base.restApiUrl;
                var client = new RestClient(apiUrl);
                _test = _reportFixture.Extent.CreateTest("RestApiGetDataBackendService");

                RestResponse response = client.Get(new RestRequest());
                System.Net.HttpStatusCode statusCode = response.StatusCode;

                Assert.Equal("OkieDokie", statusCode.ToString());
                testMsg = "PASS: The expected status was detected from the backend service.";
                _test.Pass(testMsg);
            }
            catch (Exception ex)
            {
                testMsg = "FAIL: The expected status was not detected: " + ex.Message;
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

