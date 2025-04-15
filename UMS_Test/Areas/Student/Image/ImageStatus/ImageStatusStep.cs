using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.CommonModels;
using System;
using System.IO;
using System.Xml.Linq;
using Xunit;
using Xunit.Abstractions;

namespace UMS.UI.Test.ERP.Areas.Student.Image.ImageStatus
{
    [Binding]
    public class ImageStatusStep
    {
        private readonly ITestOutputHelper _output;
        private readonly ImageStatusPage _page;

        public ImageStatusStep(ITestOutputHelper output, ImageStatusPage page)
        {
            _output = output;
            _page = page;
        }

        [Given("Go to Image Status Page")]
        public void GivenGoToImageStatusPage()
        {
            _page.StudentMenu().Click();
            _page.ImageNav().Click();
            _page.ImageStatusNav().Click();
        }

        [When("Missing Image Page Loads")]
        public void WhenMissingImagePagePopsUp()
        {
            Assert.True(_page.missingImagePanel().Displayed, "Missing Image panel should be displayed");
            Assert.Equal("Colapse", _page.missingImagePanel().GetAttribute("title"));
            Console.WriteLine("Image Status Page is Loaded");
        }

        [When("Select Organization {string}")]
        public void WhenSelectOrganization(string organization)
        {
            SelectDropdownOption(() => _page.Organization(), organization);
        }

        [When("Select Program {string}")]
        public void WhenSelectProgram(string program)
        {
            SelectDropdownOption(() => _page.Program(), program);
        }

        [When("Select Session {string}")]
        public void WhenSelectSession(string session)
        {
            SelectDropdownOption(() => _page.Session(), session);
        }

        [When("Select Image Status {string}")]
        public void WhenSelectImageStatus(string imageStatus)
        {
            SelectDropdownOption(() => _page.ImgStatus(), imageStatus);
        }

        [When("Select Courses {string}")]
        public void WhenSelectCourses(string courses)
        {
            SelectMultiOptions("CourseId", courses);
        }

        [When("Select Gender {string}")]
        public void WhenSelectGender(string gender)
        {
            SelectMultiOptions("GenderId", gender);
        }

        [When("Select Version {string}")]
        public void WhenSelectVersion(string version)
        {
            SelectMultiOptions("VersionofStudy", version);
        }

        [When("Select Branch {string}")]
        public void WhenSelectBranch(string branch)
        {
            SelectMultiOptions("BranchId", branch);
        }

        [When("Select Campus {string}")]
        public void WhenSelectCampus(string campus)
        {
            SelectMultiOptions("CampusId", campus);
        }

        [When("Select BatchType {string}")]
        public void WhenSelectBatchType(string batchType)
        {
            SelectMultiOptions("batchDays", batchType);
        }

        [When("Select BatchTime {string}")]
        public void WhenSelectBatchTime(string batchTime)
        {
            SelectMultiOptions("batchTime", batchTime);
        }

        [When("Select Batch {string}")]
        public void WhenSelectBatch(string batch)
        {
            SelectMultiOptions("batchName", batch);
        }

        [When("Click Count Button and Get Count")]
        public void WhenClickCountButtonAndGetCount()
        {
            _page.ClickCountButton().Click();
            Thread.Sleep(1000);

            string displayCount = _page.GetCountResult().GetAttribute("value");
            _output.WriteLine($"Count Result: {displayCount}");

            Assert.False(string.IsNullOrWhiteSpace(displayCount), "Count result should not be empty.");
            Assert.False(displayCount.Trim() == "...", "Count result should not be '...'.");
        }


        [When("Select Information {string}")]
        public void WhenSelectInformation(string information)
        {
            Console.WriteLine("Wait");
        }

        [When("Enter Reg No.\\/Roll No. {string}")]
        public void WhenEnterRegNo_RollNo_(string regOrRoll)
        {
            Console.WriteLine("Wait");
        }

        [When("Enter Nickname {string}")]
        public void WhenEnterNickname(string nickName)
        {
            Console.WriteLine("Wait");
        }

        [When("Enter Mobile Number {string}")]
        public void WhenEnterMobileNumber(string mobileNumber)
        {
            Console.WriteLine("Wait");
        }

        [Then("DataTable Should Appear")]
        public void ThenDataTableShouldAppear()
        {
            Console.WriteLine("Wait");
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