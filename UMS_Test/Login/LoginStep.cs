using Microsoft.Extensions.Configuration;
using UMS.UI.Test.BusinessModel.Helper;
using Xunit;

namespace UMS.UI.Test.ERP.Login
{
    [Binding]
    public sealed class LoginStep
    {
        private readonly LoginPage _page;
        private readonly IConfiguration _configuration;
        public LoginStep(LoginPage page)
        {
            _page = page;
            _configuration = AppHelper.GetAppSettings();
        }


        [Given(@"Goto Login Page")]
        public void GivenGotoLoginPage()
        {
            //_loginPage.GotoBaseUrl();
            Assert.True(_page.GetLoginPage().Displayed);
        }

        [When(@"Click on the email field")]
        public void WhenClickOnTheEmailField()
        {
            _page.GetEmailField().Click();
        }

        [When(@"Enter email in the field")]
        public void GivenEnterEmailInTheField()
        {
            _page.GetEmailField().SendKeys(_configuration["Admin:Username"]);
        }

        [When(@"Click on the password field")]
        public void WhenClickOnThePasswordField()
        {
            _page.GetPasswordField().Click();
        }

        [When(@"Enter password in the field")]
        public void GivenEntUasswordInTheField()
        {
            _page.GetPasswordField().SendKeys(_configuration["Admin:Password"]);
        }

        [When(@"Click on the submit button")]
        public void WhenClickOnTheSubmitButton()
        {
            _page.GetLoginButton().Click();
        }

        [Then(@"Is Success Login")]
        public void ThenIsSuccessLogin()
        {
            Assert.True(_page.GetLoggedPage().Displayed);
        }

        [Given(@"The user is already logged in")]
        public void GivenTheUserIsAlreadyLoggedIn()
        {
            if (!_page.GetLoggedPage().Displayed)
            {
                GivenGotoLoginPage();
                GivenEnterEmailInTheField();
                GivenEntUasswordInTheField();
                _page.GetLoginButton().Click();
            }
        }

        [When(@"The user clicks the logout button")]
        public void WhenTheUserClicksTheLogoutButton()
        {
            _page.GetLogoutButton().Click();
        }

        [Then(@"Assert that user is redirected to login page")]
        public void ThenAssertThatUserIsRedirectedToLoginPage()
        {
            Thread.Sleep(1000);
            Assert.True(_page.GetLoginPage().Displayed);
        }

    }
}
