using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using SkiaSharp;

namespace UMS.UI.Test.BusinessModel.Helper
{
    public static class AppHelper
    {
        private const string baseFolder = "";

        private static Screenshot GetScreenshot(IWebDriver driver)
        {
            var screenshotDriver = driver as ITakesScreenshot;
            return screenshotDriver!.GetScreenshot();
        }

        public static IConfiguration GetAppSettings()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return configuration;
        }

        public static string GetFolderPath(string folderName)
        {
            var appPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../"));
            return Path.Combine(appPath, folderName);
        }

        public static string GetFilePath(string folderName, string fileName)
        {
            var folderPath = GetFolderPath(folderName);
            return Path.Combine(folderPath, fileName);
        }

        public static string GetImageSavePath(string imageName)
        {
            var filePath = GetFolderPath("TestFiles\\Reports");
            return Path.Combine(filePath, imageName);
        }

        //public static void CaptureFullPageScreenshot(IWebDriver driver, string filePath)
        //{
        //    var jsExecutor = driver as IJavaScriptExecutor;
        //    var totalHeight = (long)jsExecutor!.ExecuteScript("return document.body.scrollHeight");

        //    int viewHeight = driver.Manage().Window.Size.Height;

        //    // Create a Bitmap to stitch the screenshots together
        //    var stitchedImage = new Bitmap(driver.Manage().Window.Size.Width, (int)totalHeight);

        //    // Loop through and capture screenshots while scrolling
        //    for (int i = 0; i < totalHeight; i += viewHeight - 98)
        //    {
        //        // Scroll the page
        //        jsExecutor.ExecuteScript($"window.scrollTo(0, {i})");

        //        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        //        Screenshot screenshot = GetScreenshot(driver);

        //        // Convert screenshot to Image
        //        using var memoryStream = new MemoryStream(screenshot.AsByteArray);
        //        var screenshotImage = Image.FromStream(memoryStream);

        //        // Captured screenshots stitched
        //        using var graphics = Graphics.FromImage(stitchedImage);
        //        graphics.DrawImage(screenshotImage, new Point(0, i));
        //    }
        //    stitchedImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        //}

        public static void CaptureFullPageScreenshot(IWebDriver driver, string filePath)
        {
            var jsExecutor = (IJavaScriptExecutor)driver;
            var totalHeight = Convert.ToInt32(jsExecutor.ExecuteScript("return document.body.scrollHeight"));
            int viewHeight = driver.Manage().Window.Size.Height;
            int viewWidth = driver.Manage().Window.Size.Width;

            using SKBitmap stitchedBitmap = new SKBitmap(viewWidth, totalHeight);
            using SKCanvas canvas = new SKCanvas(stitchedBitmap);

            int yOffset = 0;

            for (int i = 0; i < totalHeight; i += viewHeight - 98)
            {
                jsExecutor.ExecuteScript($"window.scrollTo(0, {i})");
                System.Threading.Thread.Sleep(500); // Allow time for scrolling

                Screenshot screenshot = driver.TakeScreenshot();
                using SKBitmap screenshotBitmap = SKBitmap.Decode(screenshot.AsByteArray);

                canvas.DrawBitmap(screenshotBitmap, new SKPoint(0, yOffset));
                yOffset += viewHeight - 98;
            }

            using SKImage image = SKImage.FromBitmap(stitchedBitmap);
            using SKData data = image.Encode(SKEncodedImageFormat.Png, 100);
            File.WriteAllBytes(filePath, data.ToArray());
        }

        public static string DownloadMoneyReceiptPath(IWebDriver driver, ScenarioInfo scenarioInfo)
        {
            var fileName = $"{scenarioInfo.Title} {DateTime.Now:HHmmss}.pdf";

            var jScript = $"var pdfData = $('#moneyReceiptData').val();" +
                            $"var link = document.createElement('a');" +
                            $"link.href = 'data:application/pdf;base64,' + pdfData;" +
                            $"link.download = '{fileName}';" +
                            $"link.style.display = 'none';" + // Hide the link
                            $"document.body.appendChild(link);" +
                            $"link.click();" +
                            $"document.body.removeChild(link);";

            var downloadPath = GetFolderPath("TestFiles\\Reports");
            var filePath = Path.Combine(downloadPath, fileName);
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(5));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

            try
            {
                jsExecutor.ExecuteScript(jScript);
                wait.Until(f => File.Exists(filePath));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return filePath;
        }

        public static string[] ConvertPdfToText(string pdfPath)
        {
            string extractedText = string.Empty;
            using var document = new PdfDocument(new PdfReader(pdfPath));

            for (int pageNum = 1; pageNum <= document.GetNumberOfPages(); pageNum++)
            {
                var strategy = new LocationTextExtractionStrategy();
                var viewPage = document.GetPage(pageNum);
                var pageText = PdfTextExtractor.GetTextFromPage(viewPage, strategy);
                extractedText += pageText;
            }

            string[] lines = extractedText.Split
                (
                    new[] { "\n", " : " }, StringSplitOptions.RemoveEmptyEntries
                );
            return lines.Where(s => !string.IsNullOrEmpty(s)).Skip(7).ToArray();
        }

    }
}
