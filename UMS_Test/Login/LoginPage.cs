using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Login
{
    public sealed class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public IWebElement GetLoginPage() => _driver.FindElement(LoginElement.LoginPage);

        public IWebElement GetEmailField() => _driver.FindElement(LoginElement.UserName);

        public IWebElement GetPasswordField() => _driver.FindElement(LoginElement.Password);

        public IWebElement GetLoginButton() => _driver.FindElement(LoginElement.LoginBtn);

        public IWebElement GetLoginError() => _driver.FindElement(LoginElement.LoginError);

        public IWebElement GetLoggedPage() => _driver.FindElement(LoginElement.LoggedPage);

        public IWebElement GetLogoutButton() => _driver.FindElement(LoginElement.LogoutButton);

    }
}
