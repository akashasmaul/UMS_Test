using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Areas.Common
{
    public class AreaCommonPage
    {
        private readonly IWebDriver _driver;
        public AreaCommonPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public IWebDriver GetDriver() => _driver;

        public IWebElement GetOrganization() => _driver.FindElement(AreaCommonElement.Organization);
        public IWebElement GetProgram() => _driver.FindElement(AreaCommonElement.Program);
        public IWebElement GetSession() => _driver.FindElement(AreaCommonElement.Session);
        public IWebElement GetCourse() => _driver.FindElement(AreaCommonElement.Course);
        public IWebElement GetBranch() => _driver.FindElement(AreaCommonElement.Branch);

        public IWebElement GetMultiSelectDropdown(string attributeId) => _driver.FindElement(AreaCommonElement.MultiSelectDropdown(attributeId));
        public IWebElement GetMultiSelectSearchbox(string attributeId) => _driver.FindElement(AreaCommonElement.MultiSelectSearchbox(attributeId));
        public IList<IWebElement> GetMultiCheckboxesByText(string attributeId)
        {
            return _driver.FindElements(AreaCommonElement.MultiCheckboxByText(attributeId));
        }
        public IList<IWebElement> GetMultiCheckboxesByValue(string attributeId)
        {
            return _driver.FindElements(AreaCommonElement.MultiCheckboxByValue(attributeId));
        }

        public IWebElement GetStartDate() => _driver.FindElement(AreaCommonElement.StartDate);
        public IWebElement GetEndDate() => _driver.FindElement(AreaCommonElement.EndDate);
        public IWebElement GetDateFrom(string attributeId) => _driver.FindElement(AreaCommonElement.DateFrom(attributeId));
        public IWebElement GetDateTo(string attributeId) => _driver.FindElement(AreaCommonElement.DateTo(attributeId));

        public IWebElement GetSelectInfoToViewAll() => _driver.FindElement(AreaCommonElement.SelectInfoToViewAll);
        public IWebElement GetDesiredTestPage() => _driver.FindElement(AreaCommonElement.DesiredTestPage);
        public IWebElement GetUpdateGlyphIcon() => _driver.FindElement(AreaCommonElement.UpdateGlyphIcon);
        public IWebElement GetDeleteGlyphIcon() => _driver.FindElement(AreaCommonElement.DeleteGlyphIcon);

        public IWebElement GetModalSuccessButton()
        {
            WaitHelper.WebElementIsVisible(_driver, 05, AreaCommonElement.ModalSuccessButton);
            return _driver.FindElement(AreaCommonElement.ModalSuccessButton);
        }

        public IWebElement GetModalDangerButton()
        {
            WaitHelper.WebElementIsVisible(_driver, 05, AreaCommonElement.ModalDangerButton);
            return _driver.FindElement(AreaCommonElement.ModalDangerButton);
        }

        public IWebElement GetActionSuccessMessage()
        {
            WaitHelper.WebElementIsVisible(_driver, 05, AreaCommonElement.SuccessAlertMessage);
            return _driver.FindElement(AreaCommonElement.SuccessAlertMessage);
        }

        public IWebElement GetActionFailureMessage()
        {
            WaitHelper.WebElementIsVisible(_driver, 05, AreaCommonElement.FailureAlertMessage);
            return _driver.FindElement(AreaCommonElement.FailureAlertMessage);
        }

    }
}
