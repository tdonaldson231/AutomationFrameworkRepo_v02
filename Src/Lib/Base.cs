using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace AutomationFramework_v8._0.Src.Lib
{
    public class Base
    {

        private static IWebDriver? webDriver;
        private static string portalUrl = "https://ultimateqa.com/automation";
        private static int webDriverTimeout = 5000;
        public static string restApiUrl = "https://reqres.in/api/users/2";
        public static string mySqlConnection = "Server=localhost;Port=3306;Database=testdb;User ID=testuser;Password=testpassword;";

        public static IWebDriver getSeleniumDriver()
        {
            if (webDriver == null)
            {
                try
                {
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(webDriverTimeout);
                    webDriver.Manage().Window.Maximize();
                    webDriver.Navigate().GoToUrl(Base.portalUrl);
                }
                catch (WebDriverException wdEx)
                {
                    Console.WriteLine("WebDriver Exception: {0}", wdEx.Message);
                    Console.WriteLine(wdEx.StackTrace);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return webDriver!;
        }
    }
}
