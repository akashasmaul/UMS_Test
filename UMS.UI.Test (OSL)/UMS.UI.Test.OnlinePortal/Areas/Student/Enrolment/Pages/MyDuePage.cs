using UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Elements;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Pages
{
    public class MyDuePage
    {
        private readonly IWebDriver _driver;
        public MyDuePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver GetDriver() { return _driver; }

        public IWebElement GetDuePaymentMenu() => _driver.FindElement(MyDueElement.DuePaymentMenu);
        public IWebElement GetPayNowButton() => _driver.FindElement(MyDueElement.PayNowButton);
        public IWebElement GetDueAmount() => _driver.FindElement(MyDueElement.DueAmount);
        public string GetDueAmountValue() => GetDueAmount().GetAttribute("value");
        public IWebElement GetPaymentAmount() => _driver.FindElement(MyDueElement.PaymentAmount);
        public IWebElement GetBkashWebPayment() => _driver.FindElement(MyDueElement.BkashWebPayment);
        public IWebElement GetIsAgreeTermsAndCondition() => _driver.FindElement(MyDueElement.IsAgreeTermsAndCondition);
        public IWebElement GetProceedToPayButton() => _driver.FindElement(MyDueElement.ProceedToPayButon);
        public IWebElement GetSuccessButton() => _driver.FindElement(MyDueElement.SuccessButton);
        public IWebElement GetSuccessMessage() => _driver.FindElement(MyDueElement.SuccessMessage);
    }
}
