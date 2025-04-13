using OpenQA.Selenium;
using Reqnroll.BoDi;
using System.ComponentModel;
using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Login
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly JsonHelper _jsonHelper;
        private readonly LoginPageElements _loginElement;

        public LoginPage(IWebDriver driver, JsonHelper jsonHelper)
        {
            _driver = driver;
            _jsonHelper = jsonHelper;
            _loginElement = new LoginPageElements();
        }

        public void GoToBaseUrl() =>
        _driver.Navigate().GoToUrl(_jsonHelper.BaseURL);

        public void PerformLogin()
        {
            EmailField.SendKeys(_jsonHelper.UserName);
            PasswordField.SendKeys(_jsonHelper.Password);
            LoginButton.Click();
        }

        public IWebElement EmailField => _driver.FindElement(_loginElement.EmailField);
        public IWebElement PasswordField => _driver.FindElement(_loginElement.PasswordField);
        public IWebElement LoginButton => _driver.FindElement(_loginElement.LoginButton);
    }
}