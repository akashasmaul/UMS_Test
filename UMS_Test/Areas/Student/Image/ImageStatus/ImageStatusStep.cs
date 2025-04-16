using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            SelectMultiOptions(_page.CourseId(), courses);
        }

        [When("Select Gender {string}")]
        public void WhenSelectGender(string gender)
        {
            SelectMultiOptions(_page.GenderId(), gender);
        }

        [When("Select Version {string}")]
        public void WhenSelectVersion(string version)
        {
            SelectMultiOptions(_page.VersionofStudy(), version);
        }

        [When("Select Branch {string}")]
        public void WhenSelectBranch(string branch)
        {
            SelectMultiOptions(_page.BranchId(), branch);
        }

        [When("Select Campus {string}")]
        public void WhenSelectCampus(string campus)
        {
            SelectMultiOptions(_page.CampusId(), campus);
        }

        [When("Select BatchType {string}")]
        public void WhenSelectBatchType(string batchType)
        {
            SelectMultiOptions(_page.batchDays(), batchType);
        }

        [When("Select BatchTime {string}")]
        public void WhenSelectBatchTime(string batchTime)
        {
            SelectMultiOptions(_page.batchTime(), batchTime);
        }

        [When("Select Batch {string}")]
        public void WhenSelectBatch(string batch)
        {
            SelectMultiOptions(_page.batchName(), batch);
        }

        [When("Click Count Button and Get Count")]
        public void WhenClickCountButtonAndGetCount()
        {
            _page.ClickCountButton().Click();
            Thread.Sleep(1500);

            string displayCount = _page.GetCountResult().GetAttribute("value");
            _output.WriteLine($"Count Result: {displayCount}");

            Assert.False(string.IsNullOrWhiteSpace(displayCount), "Count result should not be empty.");
            Assert.False(displayCount.Trim() == "...", "Count result should not be '...'.");
        }

        [When("Select Information {string}")]
        public void WhenSelectInformation(string information)
        {
            SelectInformationFields(information);
        }

        [When("Remove Information {string}")]
        public void WhenRemoveInformation(string infoString)
        {
            RemoveInformationFields(infoString);
        }

        [When("Enter Reg No.\\/Roll No. {string}")]
        public void WhenEnterRegNo_RollNo_(string regOrRoll)
        {
            if (string.IsNullOrWhiteSpace(regOrRoll))
            {
                _output.WriteLine("⏭️ Skipped Reg/Roll input as it's empty.");
                return;
            }
            if (!regOrRoll.All(char.IsDigit))
                throw new ArgumentException("❌ Reg No./Roll No. must be numeric.");

            _page.RegOrRollInput().Clear();
            _page.RegOrRollInput().SendKeys(regOrRoll);
            _output.WriteLine($"✅ Reg No./Roll No. entered: {regOrRoll}");
        }

        [When("Enter Nickname {string}")]
        public void WhenEnterNickname(string nickName)
        {
            if (string.IsNullOrWhiteSpace(nickName))
            {
                _output.WriteLine("⏭️ Skipped Nickname input as it's empty.");
                return;
            }

            _page.NickNameInput().Clear();
            _page.NickNameInput().SendKeys(nickName);
            _output.WriteLine($"✅ Nickname entered: {nickName}");
        }

        [When("Enter Mobile Number {string}")]
        public void WhenEnterMobileNumber(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                _output.WriteLine("⏭️ Skipped Mobile Number input as it's empty.");
                return;
            }

            if (!mobileNumber.All(char.IsDigit))
                throw new ArgumentException("❌ Mobile number must be numeric.");
            if (!(mobileNumber.Length == 11 || mobileNumber.Length == 13))
                throw new ArgumentException($"❌ Mobile number must be exactly 11 or 13 digits. Got: {mobileNumber.Length}");
            if (mobileNumber.Length == 13 && !mobileNumber.StartsWith("880"))
                throw new ArgumentException("❌ 13-digit number must start with '880'.");

            _page.MobileNumberInput().Clear();
            _page.MobileNumberInput().SendKeys(mobileNumber);
            _output.WriteLine($"✅ Mobile Number entered: {mobileNumber}");
        }

        [When("Click View Button")]
        public void WhenClickViewButton()
        {
            _page.ViewBtn().Click();
            Thread.Sleep(100);
        }

        [Then("DataTable Should Appear")]
        public void ThenDataTableShouldAppear()
        {
            var dataTable = _page.dataTable();
            if (dataTable.Displayed)
            {
                _output.WriteLine("✅ DataTable is visible and rendered correctly.");
            }
            Assert.True(dataTable.Displayed, $"DataTable is not displayed. Tag: {dataTable.TagName}, Text: {dataTable.Text}, Enabled: {dataTable.Enabled}");
        }

        [Then("Export the DataTable {string}")]
        public void ThenExportTheDataTable(string status)
        {
            if (status.ToLower().Trim() != "yes")
            {
                _output.WriteLine("⏭️ Export step skipped based on input status.");
                return;
            }
            // Step 1: Click Expand
            var expandIcon = _page.ExpandIcon();
            if (expandIcon.Displayed && expandIcon.Enabled)
            {
                expandIcon.Click();
                Console.WriteLine("Expand icon clicked successfully.");
            }
            // Step 2: Click Export Button
            var exportBtn = _page.ExportButton();
            if (exportBtn.Displayed && exportBtn.Enabled)
            {
                exportBtn.Click();
                _output.WriteLine("✅ Export button clicked.");
            }
            _output.WriteLine("📁 Expecting Excel file to be downloaded.");
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

        private void SelectInformationFields(string infoString)
        {
            var infoList = infoString.Split(',')
                                     .Select(x => x.Trim().ToLower())
                                     .ToList();

            var selectElement = new SelectElement(_page.NonSelectedList());

            var allAvailableOptions = selectElement.Options
                                                   .Select(o => new
                                                   {
                                                       Text = o.Text.Trim(),
                                                       LowerText = o.Text.Trim().ToLower()
                                                   })
                                                   .ToList();

            if (infoList.Contains("all") || infoList.Contains("select all"))
            {
                _page.MoveAllButton().Click();
                _output.WriteLine("\t• Selected All Information'");
                return;
            }

            List<string> found = new();
            List<string> notFound = new();

            var matchedOptions = new List<string>();

            foreach (var info in infoList)
            {
                var match = allAvailableOptions.FirstOrDefault(o =>
                    o.LowerText.Contains(info)); // partial + case-insensitive

                if (match != null)
                {
                    selectElement.SelectByText(match.Text); // select actual visible text
                    found.Add(match.Text);
                    matchedOptions.Add(match.Text);
                }
                else
                {
                    notFound.Add(info);
                }
            }

            _output.WriteLine("\t✔️ Found Items: " + string.Join(", ", found));
            if (notFound.Any())
                _output.WriteLine("\t❌ Not Found Items: " + string.Join(", ", notFound));

            _page.MoveSelectedButton().Click();
            _output.WriteLine("• Selected: " + string.Join(", ", matchedOptions));
        }

        private void RemoveInformationFields(string infoString)
        {
            var infoList = infoString.Split(',')
                                      .Select(x => x.Trim().ToLower())
                                      .ToList();

            if (infoList.Contains("all") || infoList.Contains("remove all"))
            {
                _page.RemoveAllButton().Click();
                return;
            }

            var selectElement = new SelectElement(_page.SelectedList());
            foreach (var info in infoList)
            {
                var match = selectElement.Options.FirstOrDefault(o => o.Text.Trim().ToLower() == info);
                if (match != null)
                {
                    selectElement.SelectByText(match.Text);
                }
                else
                {
                    _output.WriteLine($"Option '{info}' not found in the selected list.");
                    continue;
                }
            }

            _page.RemoveSelectedButton().Click();
        }
    }
}