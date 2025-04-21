using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using UMS.UI.Test.BusinessModel;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.ERP.Login;

namespace UMS.UI.Test.ERP.TestFiles.Hooks
{
    public class LoginHooks
    {
        private readonly LoginPage _loginPage;
        private readonly IConfiguration _configuration;
        public LoginHooks(IWebDriver driver, ScenarioInfo scenarioInfo)
        {
            _loginPage = new LoginPage(driver);
            _configuration = AppHelper.GetAppSettings();
            if (scenarioInfo.Title.Contains("Login") == false)
            {
                GetAuthentication(_loginPage);
            }
        }

        private void GetAuthentication(LoginPage login)
        {
            var (Username, Password, _) = UserCredential.GetAdminInfo();
            login.GetLoginPage();
            login.GetEmailField().SendKeys(Username ?? _configuration["Admin:Username"]);
            login.GetPasswordField().SendKeys(Password ?? _configuration["Admin:Password"]);
            login.GetLoginButton().Click();
        }
    }
}
