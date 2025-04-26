using UMS.UI.Test.BusinessModel;
using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Login
{
    [Binding]
    public class StudentLoginStep
    {
        private readonly StudentLoginPage _page;
        private readonly IConfiguration _configuration;
        public StudentLoginStep(StudentLoginPage page)
        {
            _page = page;
            _configuration = AppHelper.GetAppSettings();
        }


        [Given(@"Goto Student Login Page")]
        public void GivenGotoStudentLoginPage()
        {
            Assert.True(_page.GetStudentLoginPage().Displayed);
        }

        [When(@"Enter Registration No\. in the field")]
        public void WhenEnterRegistrationNo_InTheField()
        {
            var username = UserCredential.GetStudentInfo().Username ?? _configuration["Student:Username"];
            _page.GetRegistrationNoField().SendKeys(username);
        }

        [When(@"Click on the Next button")]
        public void WhenClickOnTheNextButton()
        {
            _page.GetStudentLoginNextButton().Click();
        }

        [When(@"Enter Password in the field")]
        public void WhenEnterPasswordInTheField()
        {
            var password = UserCredential.GetStudentInfo().Password ?? _configuration["Student:Password"];
            _page.GetStudentPasswordField().SendKeys(password);
        }

        [When(@"Click on Student Login button")]
        public void WhenClickOnStudentLoginButton()
        {
            _page.GetStudentPortalLoginButton().Click();
        }

        [Then(@"Is Student Login Success")]
        public void ThenIsStudentLoginSuccess()
        {
            Assert.True(_page.GetStudentPortalLoggedPage().Displayed);
        }

        [Given(@"The student is already logged in")]
        public void GivenTheStudentIsAlreadyLoggedIn()
        {
            if (_page.IsVisibleLoggedPage() == false)
            {
                WhenEnterRegistrationNo_InTheField();
                WhenClickOnTheNextButton();
                WhenEnterPasswordInTheField();
                WhenClickOnStudentLoginButton();
            }
        }

        [When(@"The student click the logout button")]
        public void WhenTheStudentClickTheLogoutButton()
        {
            if (_page.IsVisibleDiscussionGroupButton())
                _page.GetDiscussionGroupPopupButton().Click();

            _page.GetStudentPortalLoggedPage().Click();
            Thread.Sleep(2000);
        }

        [Then(@"Assert that student is goto login page")]
        public void ThenAssertThatStudentIsGoToLoginPage()
        {
            _page.GetLogoutButton().Click();
        }

    }
}
