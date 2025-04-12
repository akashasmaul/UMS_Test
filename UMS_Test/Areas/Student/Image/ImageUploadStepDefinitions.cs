using FluentAssertions;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Security.AccessControl;
using Xunit;
using Xunit.Abstractions;

namespace UMS.UI.Test.ERP.Areas.Student.Image
{
    [Binding]
    public class ImageUploadStepDefinitions
    {
        private int totalImageFound = 0;
        private int toBeUploadCount = 0;
        private int toBeSuccessCount = 0;
        private int toBeFailCount = 0;

        private readonly ImageUploadPage _page;
        private readonly ITestOutputHelper _output;

        private ImageUploadStepDefinitions(ImageUploadPage page, ITestOutputHelper output)
        {
            _page = page;
            _output = output;
        }

        [Given("Go to the Upload Image Page")]
        public void GivenGoToTheUploadImagePage()
        {
            _page.StudentMenu().Click();
            _page.ImageNav().Click();
            _page.UploadImageNav().Click();
        }

        [When("Based on Image Type {string}, Browse {string} and Select Images")]
        public void WhenBasedOnImageTypeBrowseAndSelectImages(string imageType, string path)
        {
            try
            {
                if (string.Equals(imageType?.Trim(), "Single", StringComparison.OrdinalIgnoreCase))
                {
                    string absolutePath = GetAbsolutePath(path);
                    ValidateAndUploadImage(absolutePath);
                }
                else if (string.Equals(imageType?.Trim(), "Batch", StringComparison.OrdinalIgnoreCase))
                {
                    string absolutePath = GetAbsolutePath(path);
                    string[] files = Directory.GetFiles(absolutePath);
                    totalImageFound = files.Length;
                    _output.WriteLine($"\n\tTotal images found in folder: {totalImageFound} \n");

                    foreach (string file in files)
                    {
                        toBeUploadCount++;
                        ValidateAndUploadImage(file);
                    }
                    _output.WriteLine($"\n\tTotal valid images to be uploaded: {toBeUploadCount} \n");
                }
            }
            catch (Exception ex)
            {
                _output.WriteLine($"Error in image upload process: {ex.Message}");
                throw; // Re-throw to maintain behavior
            }
        }

        [When("Check Allow Over Write Checkbox as {string}")]
        public void WhenCheckAllowOverWriteCheckboxAs(string overWrite)
        {
            bool shouldCheck = overWrite.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                               overWrite.Trim().Equals("1");

            _page.SetOverwrite(shouldCheck);

            _output.WriteLine(shouldCheck
                ? (_page.IsOverwriteChecked()
                    ? "Allow Overwrite checkbox was already checked."
                    : "Allow Overwrite checkbox is now checked.")
                : "Allow Overwrite checkbox is not checked based on input.");
        }

        [When("Click the Upload Button")]
        public void WhenClickTheUploadButton()
        {
            _page.UploadBtn().Click();
        }

        [Then("Image Upload Should be Succeed")]
        public void ThenImageUploadShouldBeSucceed()
        {
            // 1. Show expected counts
            var checkTotalExpectedCount = toBeSuccessCount + toBeFailCount;
            _output.WriteLine($"\n🧮 Expected (Based on Test Data) Upload Summary:");
            _output.WriteLine($"\t✅ Expected Success Count: {toBeSuccessCount}");
            _output.WriteLine($"\t❌ Expected Fail Count: {toBeFailCount}");
            _output.WriteLine($"\t🟰 Expected Total Image to be Processed: {checkTotalExpectedCount}");
            // 2. Wait for all messages to load
            _page.WaitForMessagesToLoad();

            // 3. Count success/fail uploads
            _output.WriteLine("");
            var (systemSuccessCount, systemFailCount, systemTotalCount) = CountUploadResults();

            // 4. Show system results
            _output.WriteLine($"\n🧾 System Upload Result (After Upload):");
            _output.WriteLine($"\t✅ Success Messages Count: {systemSuccessCount}");
            _output.WriteLine($"\t❌ Fail Messages Count: {systemFailCount}");
            _output.WriteLine($"\t🟰 Total Processed: {systemTotalCount}");



            // 5. Get and show UI counters

            int uiSuccessCount = _page.GetSucceedCount();
            int uiFailCount = _page.GetFailCount();
            int uiDuplicateCount = _page.GetDuplicateCount();
            int uiTotalCount = _page.GetTotalCount();

            _output.WriteLine($"\n📊 System UI Counters After Upload:");
            _output.WriteLine($"\t✅ UI Success Count: {uiSuccessCount}");
            _output.WriteLine($"\t❌ UI Fail Count: {uiFailCount}");
            _output.WriteLine($"\t♻️ UI Duplicate Count: {uiDuplicateCount}");
            _output.WriteLine($"\t📁 UI Total Count: {uiTotalCount}\n");
            var checkTotalUiCount = uiSuccessCount + uiFailCount + uiDuplicateCount;

            // 6. Validate result
            using (new AssertionScope()) // Ensures all assertions run using Package FluentAssertions
            {
                // Test Data (Expected) vs Actual System Processing
                checkTotalExpectedCount.Should().Be(systemTotalCount,
                    $"Test data expected {checkTotalExpectedCount} , but system processed total {systemTotalCount}");

                // System Processing vs UI Display
                systemTotalCount.Should().Be(checkTotalUiCount,
                    $"System processed {systemTotalCount} successes but UI shows {checkTotalUiCount}");

                // System Processing Success vs UI Display Success
                systemSuccessCount.Should().Be(uiSuccessCount,
                    $"System processed {systemSuccessCount} successes but UI shows {uiSuccessCount}");

                // System Processing Fail vs UI Display Fail
                systemFailCount.Should().Be(uiFailCount,
                    $"System recorded {systemFailCount} failures but UI shows {uiFailCount}");

                // Ui Expected Total vs Ui Actual Total
                uiTotalCount.Should().Be(checkTotalUiCount,
                    $"Ui Expected {checkTotalUiCount} in-total but UI shows {uiTotalCount} in-total");
            }
        }

        private string GetAbsolutePath(string inputPath)
        {
            if (string.IsNullOrWhiteSpace(inputPath))
            {
                throw new ArgumentException("Path cannot be null or empty");
            }

            // Handle both forward and backward slashes
            string normalizedPath = inputPath.Replace('/', '\\').Trim();

            // Check if path is already absolute
            if (Path.IsPathRooted(normalizedPath))
            {
                // Verify the absolute path exists (file or directory)
                if (File.Exists(normalizedPath) || Directory.Exists(normalizedPath))
                {
                    return normalizedPath;
                }
                throw new FileNotFoundException($"The path '{normalizedPath}' does not exist");
            }

            // Handle relative paths
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.GetFullPath(Path.Combine(baseDirectory, normalizedPath));

                // Verify the resolved path exists
                if (File.Exists(fullPath) || Directory.Exists(fullPath))
                {
                    return fullPath;
                }
                throw new FileNotFoundException($"The resolved path '{fullPath}' does not exist");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to resolve path '{inputPath}': {ex.Message}", ex);
            }
        }

        private bool ValidateAndUploadImage(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            string extension = fileInfo.Extension.ToLower();
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

            // ✅ Check if file exists
            if (!fileInfo.Exists)
            {
                _output.WriteLine($"Error: File '{filePath}' not found.");
                return false;
            }

            // ✅ Check file extension
            else if (extension != ".jpg" && extension != ".jpeg")
            {
                _output.WriteLine($"\tError: Invalid file extension '{extension}' for file '{filePath}'. Only .jpg and .jpeg are allowed.");
                _page.browsenSelect().SendKeys(filePath);  //System Selects Invalid Extension but does not upload.
                toBeUploadCount--;
                toBeFailCount++;
            }

            // ✅ Check file size (max 100KB)
            else if (fileInfo.Length > 100 * 1024)
            {
                _output.WriteLine($"\tError: File '{filePath}' exceeds the maximum allowed size of 100KB.");
                _page.browsenSelect().SendKeys(filePath);  // System Selects but does not upload.
                toBeUploadCount--;
                toBeFailCount++;
            }

            // ✅ Check filename: Must be 7 or 11 digits ONLY (no letters/symbols)
            else if (fileNameWithoutExt.Length != 7 && fileNameWithoutExt.Length != 11)
            {
                _output.WriteLine($"\tError: Invalid file name length '{fileNameWithoutExt.Length}' for '{filePath}'. Allowed lengths: 7 (Registration Number) or 11 (Roll Number).");
                _page.browsenSelect().SendKeys(filePath);  // System selects but does not upload
                toBeUploadCount--;
                toBeFailCount++;
            }
            // ✅ Check filename: Must be 7 or 11 digits ONLY (no letters/symbols)
            else if (!fileNameWithoutExt.All(char.IsDigit))
            {
                _output.WriteLine($"\tError: Invalid file name '{fileNameWithoutExt}'. Only Digits are Allowed.");
                _page.browsenSelect().SendKeys(filePath);  // System selects but does not upload
                toBeUploadCount--;
                toBeFailCount++;
            }
            else
            {
                _page.browsenSelect().SendKeys(filePath);
                toBeSuccessCount++;
                Console.WriteLine($"\tImage '{filePath}' selected successfully.");
                return true;
            }
            return true;
        }

        private (int Success, int Fail, int Total) CountUploadResults()
        {
            int systemSuccess = 0;
            int systemFail = 0;
            int systemTotal = 0;

            foreach (var item in _page.GetUploadListItems())
            {
                try
                {
                    var fileName = item.FindElement(By.CssSelector("p.para")).Text.Split('\n')[0].Trim();
                    var message = item.FindElement(By.CssSelector(".message"));
                    var messageText = message.Text.Trim();
                    var color = message.GetCssValue("color");

                    if (messageText.Equals("Success", StringComparison.OrdinalIgnoreCase) &&
                        color == "rgba(0, 204, 0, 1)")
                    {
                        systemSuccess++;
                    }
                    else if (color == "rgba(255, 0, 0, 1)")
                    {
                        systemFail++;
                        _output.WriteLine($"• Failed to upload: '{fileName}' - {messageText}");
                    }
                    else
                    {
                        systemFail++;
                        _output.WriteLine($"Unknown: '{fileName}' - {messageText} ({color})");
                    }
                }
                catch
                {
                    systemFail++;
                    _output.WriteLine($"Error checking: {item.GetAttribute("class")}");
                }
            }
            systemTotal= systemSuccess + systemFail;
            return (systemSuccess, systemFail, systemTotal);
        }
    }
}