using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Areas.Common
{
    [Binding]
    public class AreaCommonStep
    {
        private IWebElement? _webElement;
        private SelectElement? _selectElement;

        private readonly IWebDriver? _driver;
        private readonly AreaCommonPage _page;
        public AreaCommonStep(AreaCommonPage page)
        {
            _page = page;
            _driver = _page!.GetDriver();
        }


        public IList<string> MultiSelectDropdown(string excelValue, IWebElement webElement)
        {
            var excelValues = excelValue.Split(',', StringSplitOptions.TrimEntries).Where(x => x != "").ToList();
            if (excelValues.Any())
            {
                foreach (var selectItem in excelValues)
                {
                    var selectElement = new SelectElement(webElement);

                    if (TestHelper.IsNumber(selectItem))
                        selectElement.SelectByValue(selectItem);
                    else
                        selectElement.SelectByText(selectItem);
                }
            }
            return excelValues;
        }

        public IList<string> MultiSelectDropdownCheckbox(string excelValue, string attributeId)
        {
            var excelValues = TestHelper.GetStringsBySplitOptions(excelValue);
            if (excelValues.Any())
            {
                var dropdownWebElement = _page.GetMultiSelectDropdown(attributeId);
                dropdownWebElement.Click();

                foreach (var value in excelValues)
                {
                    var searchBoxWebElement = _page.GetMultiSelectSearchbox(attributeId);
                    if (TestHelper.IsNumber(value) == false)
                    {
                        searchBoxWebElement.SendKeys(value);
                        _page.GetMultiCheckboxesByText(attributeId)
                            .FirstOrDefault(x => x.Text.Trim() == value)?.Click();
                        searchBoxWebElement.Clear();
                    }
                    else
                    {
                        _page.GetMultiCheckboxesByValue(attributeId)
                            .FirstOrDefault(x => x.GetAttribute("value") == value)?.Click();
                    }
                    //var checkboxWebElement = _page.GetMultiSelectTextCheckboxes(programId)
                    //    .FirstOrDefault(x => x.Text.Trim() == value || x.GetAttribute("value") == value);

                    //checkboxWebElement?.Click();
                    //searchBoxWebElement.Clear();
                }

                dropdownWebElement.Click();
            }
            return excelValues;
        }

        public void DateExecute(string date, IWebElement webElement)
        {
            var js = (IJavaScriptExecutor)_driver!;
            date = string.IsNullOrEmpty(date) == false ? date : DateTime.Now.ToString("yyyy-MM-dd");
            js.ExecuteScript($"arguments[0].value = '{date}';", webElement);
        }


        [When(@"Select Organization ""([^""]*)""")]
        public void WhenSelectOrganization(string organization)
        {
            _webElement = _page.GetOrganization();
            MultiSelectDropdown(organization, _webElement);
        }

        [When(@"Multi Select Organization ""([^""]*)"" With AttributeId ""([^""]*)""")]
        public void WhenMultiSelectOrganizationWithAttributeId(string organization, string organizationId)
        {
            MultiSelectDropdownCheckbox(organization, organizationId);
        }

        [When(@"Select Program ""([^""]*)""")]
        public void WhenSelectProgram(string program)
        {
            _webElement = _page.GetProgram();
            MultiSelectDropdown(program, _webElement);
        }

        [When(@"Multi Select Program ""([^""]*)"" With AttributeId ""([^""]*)""")]
        public void WhenMultiSelectProgramWithAttributeId(string program, string programId)
        {
            MultiSelectDropdownCheckbox(program, programId);
        }

        [When(@"Select Session ""([^""]*)""")]
        public void WhenSelectSession(string session)
        {
            _webElement = _page.GetSession();
            var sessions = session.Split(',', StringSplitOptions.TrimEntries).Where(x => x != "").ToList();
            if (sessions.Any())
            {
                foreach (var selectItem in sessions)
                {
                    _selectElement = new SelectElement(_webElement);
                    _selectElement.SelectByText(selectItem);
                }
            }
        }

        [When(@"Multi Select Session ""([^""]*)"" With AttributeId ""([^""]*)""")]
        public void WhenMultiSelectSessionWithAttributeId(string session, string sessionId)
        {
            var sessions = TestHelper.GetStringsBySplitOptions(session);
            if (sessions.Any())
            {
                var dropdownWebElement = _page.GetMultiSelectDropdown(sessionId);
                dropdownWebElement.Click();

                foreach (var value in sessions)
                {
                    var searchBoxWebElement = _page.GetMultiSelectSearchbox(sessionId);
                    searchBoxWebElement.SendKeys(value);

                    _page.GetMultiCheckboxesByText(sessionId)
                        .FirstOrDefault(x => x.Text.Trim() == value)?.Click();

                    searchBoxWebElement.Clear();
                }

                dropdownWebElement.Click();
            }
        }

        [When(@"Select Course ""([^""]*)""")]
        public void WhenSelectCourse(string course)
        {
            _webElement = _page.GetCourse();
            MultiSelectDropdown(course, _webElement);
        }

        [When(@"Multi Select Course ""([^""]*)"" With AttributeId ""([^""]*)""")]
        public void WhenMultiSelectCourseWithAttributeId(string course, string courseId)
        {
            MultiSelectDropdownCheckbox(course, courseId);
        }

        [When(@"Select Branch ""([^""]*)""")]
        public void WhenSelectBranch(string branch)
        {
            _webElement = _page.GetBranch();
            MultiSelectDropdown(branch, _webElement);
        }

        [When(@"Multi Select Branch ""([^""]*)"" With AttributeId ""([^""]*)""")]
        public void WhenMultiSelectBranchWithAttributeId(string branch, string branchId)
        {
            MultiSelectDropdownCheckbox(branch, branchId);
        }

        [When(@"Select Start Date From ""([^""]*)""")]
        public void WhenSelectStartDateFrom(string startDate)
        {
            _webElement = _page.GetStartDate();
            DateExecute(startDate, _webElement);
            //var js = (IJavaScriptExecutor)_driver!;
            //startDate = string.IsNullOrEmpty(startDate) == false ? startDate : DateTime.Now.ToString("yyyy-MM-dd");
            //js.ExecuteScript($"arguments[0].value = '{startDate}';", _webElement);
        }

        [When(@"Select End Date To ""([^""]*)""")]
        public void WhenSelectEndDateTo(string endDate)
        {
            _webElement = _page.GetEndDate();
            DateExecute(endDate, _webElement);
            //var js = (IJavaScriptExecutor)_driver!;
            //endDate = string.IsNullOrEmpty(endDate) == false ? endDate : DateTime.Now.ToString("yyyy-MM-dd");
            //js.ExecuteScript($"arguments[0].value = '{endDate}';", _webElement);
        }

        [When(@"Select Start Date From ""([^""]*)""  With AttributeId ""([^""]*)""")]
        public void WhenSelectStartDateFromWithAttributeId(string startDate, string attributeId)
        {
            _webElement = _page.GetDateFrom(attributeId);
            DateExecute(startDate, _webElement);
        }

        [When(@"Select End Date To ""([^""]*)"" With AttributeId ""([^""]*)""")]
        public void WhenSelectEndDateToWithAttributeId(string endDate, string attributeId)
        {
            _webElement = _page.GetDateTo(attributeId);
            DateExecute(endDate, _webElement);
        }

        [When(@"Select Information To View All")]
        public void WhenSelectInformationToViewAll() => _page.GetSelectInfoToViewAll().Click();

        [When(@"Click On Update Glyph Icon")]
        public void WhenClickOnUpdateGlyphIcon() => _page.GetUpdateGlyphIcon().Click();

        [When(@"Click On Delete Glyph Icon")]
        public void WhenClickOnDeleteGlyphIcon() => _page.GetDeleteGlyphIcon().Click();

        [When(@"Click On Modal Success Button")]
        public void WhenClickOnModalSuccessButton() => _page.GetModalSuccessButton().Click();

        [When(@"Click On Modal Danger Button")]
        public void WhenClickOnModalDangerButton() => _page.GetModalDangerButton().Click();

        [Then(@"Is Show Desired Test Page")]
        public void ThenIsShowDesiredTestPage() => Assert.True(_page.GetDesiredTestPage().Displayed);

        [Then(@"Is Show Action Success Message")]
        public void ThenIsShowActionSuccessMessage() => Assert.True(_page.GetActionSuccessMessage().Displayed);

        [Then(@"Is Show Action Failure Message")]
        public void ThenIsShowActionFailureMessage() => Assert.True(_page.GetActionFailureMessage().Displayed);

    }
}
