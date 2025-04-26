using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.TestFiles.Support
{
    public class ExtentReport
    {
        //protected static ExtentTest _step = null!;
        protected static ExtentTest _feature = null!;
        protected static ExtentTest _scenario = null!;
        protected static ExtentReports _reports = null!;

        protected static void DeployExtentReport()
        {
            var reportPath = AppHelper.GetFilePath("TestFiles\\Reports", "ExtentReport.html");

            //var reporter = new ExtentHtmlReporter(reportPath);
            var reporter = new ExtentSparkReporter(reportPath);

            reporter.Config.ReportName = "Automation Status Report";
            reporter.Config.DocumentTitle = "Automation Test Report";
            reporter.Config.Theme = Theme.Standard;
            //reporter.Start();

            _reports = new ExtentReports();
            _reports.AttachReporter(reporter);
            _reports.AddSystemInfo("Website", AppHelper.GetAppSettings()["Settings:BaseUrl"]);
            _reports.AddSystemInfo("Browser", "Chrome");
            _reports.AddSystemInfo("OS", "Windows");
        }

        protected static void DisposeExtentReport()
        {
            _reports.Flush();
        }

        protected static string Photographer(IWebDriver driver, ScenarioContext scenarioContext)
        {
            var imageName = $"{scenarioContext.ScenarioInfo.Title}-{DateTime.Now:ffff}.png";
            var filePath = AppHelper.GetImageSavePath(imageName);
            AppHelper.CaptureFullPageScreenshot(driver, filePath);
            return imageName;
        }

    }
}
