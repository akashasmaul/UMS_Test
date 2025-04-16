using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Xunit.Abstractions;

namespace UMS.UI.Test.ERP.Areas.Student.Image.ImageDownload
{
    [Binding]
    public class ImageDownloadStep
    {
        private readonly ITestOutputHelper _output;
        private readonly ImageDownloadPage _page;

        public ImageDownloadStep(ITestOutputHelper output, ImageDownloadPage page)
        {
            _output = output;
            _page = page;
        }

        [Given("Go to Image Download Page")]
        public void GivenGoToImageDownloadPage()
        {
            _page.StudentMenu().Click();
            _page.ImageNav().Click();
            _page.ImageDownloadNav().Click();
        }

        [When("Missing Image Download Page Loads")]
        public void WhenMissingImageDownloadPageLoads()
        {
            Assert.True(_page.ImageDownloadPanel().Displayed, "Download Image panel should be displayed");
            Assert.Contains("Image Download", _page.ImageDownloadPanel().Text);
            Console.WriteLine("Image Download Page is Loaded");
        }

        [When("Select {string} Organization")]
        public void WhenSelectOrganization(string organization)
        {
            SelectDropdownOption(() => _page.Organization(), organization);
        }

        [When("Select {string} Program")]
        public void WhenSelectProgram(string program)
        {
            SelectDropdownOption(() => _page.Program(), program);
        }

        [When("Select {string} Session")]
        public void WhenSelectSession(string session)
        {
            SelectDropdownOption(() => _page.Session(), session);
        }

        [When("Select {string} Course")]
        public void WhenSelectCourse(string course)
        {
            SelectMultiOptions(_page.CourseId(), course);
        }

        [When("Select {string} Gender")]
        public void WhenSelectGender(string gender)
        {
            SelectMultiOptions(_page.GenderId(), gender);
        }

        [When("Select {string} Version")]
        public void WhenSelectVersion(string version)
        {
            SelectMultiOptions(_page.VersionofStudy(), version);
        }

        [When("Select {string} Branch")]
        public void WhenSelectBranch(string branch)
        {
            SelectMultiOptions(_page.BranchId(), branch);
        }

        [When("Select {string} Campus")]
        public void WhenSelectCampus(string campus)
        {
            SelectMultiOptions(_page.CampusId(), campus);
        }

        [When("Select {string} BatchType")]
        public void WhenSelectBatchType(string batchType)
        {
            SelectMultiOptions(_page.batchDays(), batchType);
        }

        [When("Select {string} BatchTime")]
        public void WhenSelectBatchTime(string batchTime)
        {
            SelectMultiOptions(_page.batchTime(), batchTime);
        }

        [When("Select {string} Batch")]
        public void WhenSelectBatch(string batch)
        {
            SelectMultiOptions(_page.batchName(), batch);
        }

        [When("Click Count Button and Get Counts")]
        public void WhenClickCountButtonAndGetCounts()
        {
            _page.ClickCountButton().Click();
            Thread.Sleep(1500);

            string displayCount = _page.GetCountResult().GetAttribute("value");
            _output.WriteLine($"Count Result: {displayCount}");

            Assert.False(string.IsNullOrWhiteSpace(displayCount), "Count result should not be empty.");
            Assert.False(displayCount.Trim() == "...", "Count result should not be '...'.");
        }

        [When("Click Image Download Button {string}")]
        public void WhenClickImageDownloadButton(string status)
        {
            if (status.ToLower().Trim() != "yes")
            {
                _output.WriteLine("⏭️ Download step skipped based on input status.");
                return;
            }
            var downloadBtn = _page.DownlaodImageBtn();
            if (downloadBtn.Displayed && downloadBtn.Enabled)
            {
                downloadBtn.Click();
                _output.WriteLine("✅ Download button clicked.");
            }
            _output.WriteLine("📁 Expecting Zip file to be downloaded.");
            Thread.Sleep(5000);
        }

        private void SelectDropdownOption(Func<IWebElement> dropdownLocator, string optionText)
        {
            var wait = new WebDriverWait(_page.GetDriver(), TimeSpan.FromSeconds(3));
            wait.Until(d => dropdownLocator().Enabled && dropdownLocator().Displayed);

            var select = new SelectElement(dropdownLocator());
            var option = wait.Until(d => select.Options.FirstOrDefault(o =>
                o.Text.Trim().Equals(optionText.Trim(), StringComparison.OrdinalIgnoreCase)));
            option.Click();
        }

        private void SelectMultiOptions(string dropdownId, string optionList)
        {
            if (string.IsNullOrWhiteSpace(optionList))
                return;

            _page.GetDropdownToggle(dropdownId).Click();

            foreach (var item in optionList.Split(','))
            {
                var trimmed = item.Trim();
                if (string.IsNullOrWhiteSpace(trimmed))
                    continue;

                string labelText = trimmed.Equals("All", StringComparison.OrdinalIgnoreCase) ||
                   trimmed.Equals("Select All", StringComparison.OrdinalIgnoreCase) ||
                   trimmed.Equals("All Batch", StringComparison.OrdinalIgnoreCase)
                   ? "select all" // already in lowercase
                   : trimmed.ToLowerInvariant(); // force lowercase

                var labelElement = _page.GetOption(dropdownId, labelText); // Updated element method

                if (labelElement != null && !labelElement.Selected)
                {
                    labelElement.Click();
                }
            }

            if (_page.GetDropdownToggle(dropdownId).Displayed)
                _page.GetDropdownToggle(dropdownId).Click();
        }
    }
}