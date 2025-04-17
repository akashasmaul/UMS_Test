using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UMS.UI.Test.ERP.Areas.Student.Image.Copy_Image;
using Xunit;
using Xunit.Abstractions;

namespace UMS.UI.Test.ERP
{
    [Binding]
    public class CopyImageStep
    {
        private readonly ITestOutputHelper _output;
        private readonly CopyImagePage _page;

        public CopyImageStep(ITestOutputHelper output, CopyImagePage page)
        {
            _output = output;
            _page = page;
        }

        [Given("Go to Copy Image Page")]
        public void GivenGoToCopyImagePage()
        {
            _page.StudentMenu().Click();
            _page.ImageNav().Click();
            _page.ImageCopyNav().Click();
        }

        [When("Copy Image Page Loads")]
        public void WhenCopyImagePageLoads()
        {
            Assert.True(_page.ImageCopyPanel().Displayed, "Copy Image panel should be displayed");
            Assert.Contains("Copy Image", _page.ImageCopyPanel().Text);
            Console.WriteLine("Copy Image Page is Loaded");
        }

        [When("Click Increase Row Button {string}")]
        public void WhenClickIncreaseRowButton(int rowNum)
        {
            for (int i = 1; i <= rowNum; i++)
                _page.increaseRowBtn().Click();
        }

        [When("Select Organization Dropdown {string}")]
        public void WhenSelectOrganizationDropdown(string organization)
        {
            SelectDropdownOption(_page.OrganizationDropdown, organization, 1);
        }

        [When("Select Program Dropdown {string}")]
        public void WhenSelectProgramDropdown(string program)
        {
            SelectDropdownOption(_page.ProgramDropdown, program, 1);
        }

        [When("Select Session Dropdown {string}")]
        public void WhenSelectSessionDropdown(string session)
        {
            SelectDropdownOption(_page.SessionDropdown, session, 1);
        }

        [When("Select Target Organization Dropdown {string}")]
        public void WhenSelectTargetOrganizationDropdown(string targetOrganization)
        {
            SetTargetDropdownValues(_page.OrganizationDropdown, targetOrganization);
        }

        [When("Select Target Program Dropdown {string}")]
        public void WhenSelectTargetProgramDropdown(string targetProgram)
        {
            SetTargetDropdownValues(_page.ProgramDropdown, targetProgram);
        }

        [When("Select Target Session Dropdown {string}")]
        public void WhenSelectTargetSessionDropdown(string targetSession)
        {
            SetTargetDropdownValues(_page.SessionDropdown, targetSession);
        }

        [When("Remove All Extra Target Rows Without Values")]
        public void WhenRemoveAllExtraTargetRowsWithoutValues()
        {
            var indexes = GetRowIndexes(true);

            foreach (var index in indexes.OrderByDescending(i => i)) // Delete bottom-up
            {
                var orgValue = GetSelectedText(_page.OrganizationDropdown(index));
                var progValue = GetSelectedText(_page.ProgramDropdown(index));
                var sessValue = GetSelectedText(_page.SessionDropdown(index));

                if (string.IsNullOrWhiteSpace(orgValue) &&
                    string.IsNullOrWhiteSpace(progValue) &&
                    string.IsNullOrWhiteSpace(sessValue))
                {
                    var deleteButton = _page.GetDeleteButtonByRowIndex(index);
                    deleteButton.Click();
                    _output.WriteLine($"\t• Deleted empty row at index {index}");
                }
            }
        }

        [When("Get Status")]
        public void WhenGetStatus()
        {
            var rowIndexes = GetRowIndexes(true);

            foreach (var rowIndex in rowIndexes.OrderBy(i => i))
            {
                var orgValue = GetSelectedText(_page.OrganizationDropdown(rowIndex));
                var progValue = GetSelectedText(_page.ProgramDropdown(rowIndex));
                var sessValue = GetSelectedText(_page.SessionDropdown(rowIndex));
                var hasImage = _page.HasImageInput(rowIndex).GetAttribute("value");
                var missingImage = _page.MissingImageInput(rowIndex).GetAttribute("value");
                var totalStudent = _page.TotalStudentInput(rowIndex).GetAttribute("value");

                _output.WriteLine($"Row {rowIndex}: Organization = {orgValue}, Program = {progValue}, Session = {sessValue}" +
                    $"\n\t\tHasImage = {hasImage}, MissingImage = {missingImage}, TotalStudent = {totalStudent}");
            }
        }

        [When("Click Copy Image Button")]
        public void WhenClickCopyImageButton()
        {
            _page.copyMissingImageBtn().Click();
        }

        [Then("A Validation Message will Appear")]
        public void ThenAValidationMessageWillAppear()
        {
            string message = "";

            try
            {
                message = _page.GetSuccessAlertMessage().Text.Trim();
                message = message.Replace("×", "").Trim();

                _output.WriteLine($"\t • Success Message: {message}");
                message.Should().Contain("Copied Successfully", "Expected success message after copy action");
            }
            catch (NoSuchElementException)
            {
                message = _page.DangerAlertMessage().Text.Trim();
                message = message.Replace("×", "").Trim();

                _output.WriteLine($"\t • Error Message: {message}");
                message.Should().Match(x =>
                    x.Contains("Blank Item Selected") ||
                    x.Contains("No Image to copy") ||
                    x.Contains("Please select at least two Program"),
                    "Expected one of the known validation failure messages");
            }
        }

        private void SelectDropdownOption(Func<int, IWebElement> dropdownFunc, string optionText, int rowIndex)
        {
            var wait = new WebDriverWait(_page.GetDriver(), TimeSpan.FromSeconds(3));
            wait.Until(d => dropdownFunc(rowIndex).Enabled && dropdownFunc(rowIndex).Displayed);

            var select = new SelectElement(dropdownFunc(rowIndex));
            var option = wait.Until(d => select.Options.FirstOrDefault(o => o.Text.Trim().Equals(optionText.Trim(), StringComparison.OrdinalIgnoreCase)));

            if (option != null)
                option.Click();
            else
                throw new NoSuchElementException($"Option '{optionText}' not found in dropdown of row {rowIndex}");
        }

        private void SetTargetDropdownValues(Func<int, IWebElement> dropdownSelector, string csvValues)
        {
            var values = csvValues.Split(',')
                .Select(x => x.Trim()).ToList();

            var dynamicRowIndexes = GetRowIndexes(); // by default excludes row 1

            for (int i = 0; i < dynamicRowIndexes.Count && i < values.Count; i++)
            {
                SelectDropdownOption(dropdownSelector, values[i], dynamicRowIndexes[i]);
            }
        }

        public string GetSelectedText(IWebElement dropdown)
        {
            var select = new SelectElement(dropdown);
            var selectedText = select.SelectedOption?.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(selectedText) || selectedText.Equals("Select", StringComparison.OrdinalIgnoreCase)
                || selectedText.Contains("Select", StringComparison.OrdinalIgnoreCase))
            {
                return "";
            }

            return selectedText;
        }

        public List<int> GetRowIndexes(bool includeDefaultRow = false)
        {
            var allDropdowns = _page.GetDropdowns();

            var rowIndexes = allDropdowns
                .Select(e => int.Parse(e.GetAttribute("id").Split('_')[1]))
                .Where(i => includeDefaultRow || i > 1) // include index 1 only if flag is true
                .Distinct()
                .OrderBy(i => i)
                .ToList();

            return rowIndexes;
        }
    }
}