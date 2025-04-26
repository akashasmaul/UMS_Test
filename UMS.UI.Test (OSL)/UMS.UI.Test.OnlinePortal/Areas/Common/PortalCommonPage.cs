using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.OnlinePortal.Areas.Common
{
    public class PortalCommonPage
    {
        private readonly IWebDriver _driver;
        public PortalCommonPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public IWebDriver GetDriver() => _driver;

        public IWebElement GetActionSuccessMessage()
        {
            WaitHelper.WebElementIsVisible(_driver, 05, PortalCommonElement.SuccessAlertMessage);
            return _driver.FindElement(PortalCommonElement.SuccessAlertMessage);
        }

        public IWebElement GetActionFailureMessage()
        {
            WaitHelper.WebElementIsVisible(_driver, 05, PortalCommonElement.FailureAlertMessage);
            return _driver.FindElement(PortalCommonElement.FailureAlertMessage);
        }

    }
}
