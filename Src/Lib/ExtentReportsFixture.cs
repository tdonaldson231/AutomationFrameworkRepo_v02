using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using System.IO;
using AventStack.ExtentReports.Reporter.Config;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using RazorEngine;

public class ExtentReportsFixture : IDisposable
{
    private static string dateTime = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
    private readonly string _projectPath;
    public ExtentReports Extent { get; private set; }

    public ExtentReportsFixture()
    {
        string dllDir = Assembly.GetExecutingAssembly().Location;
        _projectPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(dllDir)!, @"..\..\..\"));

        string reportPath = Path.Combine(_projectPath, $"Reports/ExtentReport_{dateTime}.html");
        string configPath = Path.Combine(_projectPath, "Extent-Config.xml");

        Console.WriteLine($"Loading Extent Config from: {configPath}");

        var htmlReporter = new ExtentSparkReporter(reportPath);

        htmlReporter.Config.Theme = Theme.Standard;
        htmlReporter.Config.DocumentTitle = "Test Automation Report";
        htmlReporter.Config.ReportName = "Extent Report - API Tests";
        htmlReporter.Config.Encoding = "UTF8";

        Extent = new ExtentReports();
        Extent.AttachReporter(htmlReporter);
    }

    public void Dispose()
    {
        Extent.Flush();
    }
}
