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

        public UMSLoginStep(LoginPage loginPage)
        {
            _loginPage = loginPage;
            
        }

        [Given("Go to the URL")]
        public void GivenGoToTheURL()
        {
            _loginPage.GoToBaseUrl(); 
        }

        [Given("Give Credentials and Hit LoginBtn")]
        public void GivenGiveCredentialsAndHitLoginBtn()
        {
            _loginPage.PerformLogin();
        }

        [Then("Is Success Login")]
        public void ThenIsSuccessLogin()
        {
            Console.WriteLine("Login Successfull");
        }
    }
}