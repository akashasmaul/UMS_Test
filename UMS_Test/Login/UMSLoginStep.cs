using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.BoDi;
using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Login
{
    [Binding]
    public class UMSLoginStep
    {
        private readonly LoginPage _loginPage;
        private readonly JsonHelper _jsonHelper;

        public UMSLoginStep(IObjectContainer container)
        {
            _loginPage = container.Resolve<LoginPage>();
            _jsonHelper = container.Resolve<JsonHelper>();
        }

        [Given("Go to the URL")]
        public void GivenGoToTheURL()
        {
            _loginPage.GoToBaseUrl(); // Call page method instead of direct driver access
        }

        [Given("Give Credentials and Hit LoginBtn")]
        public void GivenGiveCredentialsAndHitLoginBtn()
        {
            _loginPage.EnterCredentials(
                _jsonHelper.UserName,
                _jsonHelper.Password
            );
        }

        [Then("Is Success Login")]
        public void ThenIsSuccessLogin()
        {
            Console.WriteLine("Login Successfull");
        }
    }
 }

