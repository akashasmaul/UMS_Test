using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Areas.Teacher.TeacherActivity.OpeningBalance

{
    public class OpeningBalancePage
    {
        private readonly IWebDriver _driver;
        private readonly OpeningBalanceElements _elements;

        public OpeningBalancePage(IWebDriver driver)
        {
            _driver = driver;
            _elements = new OpeningBalanceElements();
        }

        public IWebDriver GetDriver() => _driver;

        public IWebElement TeacherMenu() => _driver.FindElement(_elements.TeacherMenu);

        public IWebElement TeacherActivityGroup() => _driver.FindElement(_elements.TeacherActivityGroup);

        public IWebElement OpeningBalanceMenu() => _driver.FindElement(_elements.OpeningBalanceMenu);

        public IWebElement PanelTitle()
        {
            WaitHelper.WebElementIsVisible(_driver, 3, _elements.PanelTitle);
            return _driver.FindElement(_elements.PanelTitle);
        }

        public IWebElement SelectOrganization() => _driver.FindElement(_elements.SelectOrganization);

        public IWebElement TPinList() => _driver.FindElement(_elements.TPinList);

        public IWebElement ViewBtn() => _driver.FindElement(_elements.ViewBtn);

        public IWebElement OpeningDate() => _driver.FindElement(_elements.OpeningDate);
        public IWebElement TotalTeacherCountNumber() => _driver.FindElement(_elements.TotalTeacherCountNumber);
        public IWebElement TotalClassInput(string teacherId) => _driver.FindElement(_elements.TotalClassInputByTeacherId(teacherId));
        public IWebElement SaveBtn() => _driver.FindElement(_elements.SaveBtn);

    }
}