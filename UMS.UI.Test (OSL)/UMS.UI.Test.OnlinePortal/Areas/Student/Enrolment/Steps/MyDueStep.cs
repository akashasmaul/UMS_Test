using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Pages;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Steps
{
    [Binding]
    public class MyDueStep
    {
        private readonly MyDuePage _page;
        private string? _dueAmount;
        private readonly ITestOutputHelper _output;

        public MyDueStep(MyDuePage page, ITestOutputHelper output)
        {
            _page = page;
            _output = output;
        }

        [Given(@"Navigate Student Due Payment")]
        public void GivenNavigateStudentDuePayment()
        {
            _page.GetDuePaymentMenu().Click();
        }

        [Given(@"Click On Pay Now Button")]
        public void GivenClickOnPayNowButton()
        {
            try
            {
                var payNowButton = _page.GetPayNowButton();

                if (payNowButton.Displayed)
                {
                    payNowButton.Click();
                }
                else
                {
                    TestHelper.ShowMessageBox(_output, "You have no due!");
                    throw new SkipException("Test skipped: You have no due!");
                }
            }
            catch (NoSuchElementException)
            {
                TestHelper.ShowMessageBox(_output, "You have no due!");
                throw new SkipException("Test skipped: You have no due!");
            }
        }

        [Given(@"Extract Due Amount")]
        public void GivenExtractDueAmount()
        {
            _dueAmount = _page.GetDueAmountValue();
            TestHelper.ShowMessageBox(_output, $"Extracted Due Amount: {_dueAmount}");
        }

        [Given(@"Enter Payment Amount")]
        public void GivenEnterPaymentAmount()
        {
            if (!string.IsNullOrEmpty(_dueAmount))
            {
                string cleanedAmount = _dueAmount.Replace(",", "").Trim();

                if (decimal.TryParse(cleanedAmount, out decimal dueAmountValue))
                {
                    int tenPercentAmount = (int)(dueAmountValue * 0.10m);
                    string paymentAmount = tenPercentAmount.ToString();

                    _page.GetPaymentAmount().Clear();
                    _page.GetPaymentAmount().SendKeys(paymentAmount);

                    TestHelper.ShowMessageBox(_output, $"Entered 10% Payment Amount: {paymentAmount}");
                }
                else
                {
                    TestHelper.ShowMessageBox(_output, "Error: Unable to parse Due Amount.");
                }
            }
            else
            {
                TestHelper.ShowMessageBox(_output, "Error: Due Amount is empty.");
            }
        }

        [Given(@"Click On bKash Web Payment")]
        public void GivenClickOnBKashWebPayment()
        {
            _page.GetBkashWebPayment().Click();
        }

        [Given(@"Click On  Agree Terms And Condition")]
        public void GivenClickOnAgreeTermsAndCondition()
        {
            if (!_page.GetIsAgreeTermsAndCondition().Selected)
            {
                _page.GetIsAgreeTermsAndCondition().Click();
            }
        }

        [Given(@"Click On Proceed to Pay Button")]
        public void GivenClickOnProceedToPayButton()
        {
            _page.GetProceedToPayButton().Click();
        }

        [Given(@"Click On Success Button")]
        public void GivenClickOnSuccessButton()
        {
            _page.GetSuccessButton().Click();
        }

        [Then(@"Show Course Success Message")]
        public void ThenShowCourseSuccessMessage()
        {
            var dueSuccessMessageElement = _page.GetSuccessMessage();
            Thread.Sleep(1000);
            Assert.True(dueSuccessMessageElement.Displayed, "Success message is not displayed.");

            var dueSuccessMessageText = dueSuccessMessageElement.Text;
            TestHelper.ShowMessageBox(_output, dueSuccessMessageText);
        }
    }
}
