using AutomationFramework_v8._0.Src.Lib;
using OpenQA.Selenium;

public class WebDriverFixture : IDisposable
{
    public IWebDriver WebDriver { get; private set; }

    public WebDriverFixture()
    {
        WebDriver = Base.getSeleniumDriver();
    }

    public void Dispose()
    {
        WebDriver.Quit();
    }
}