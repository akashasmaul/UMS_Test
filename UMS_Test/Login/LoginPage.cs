using OpenQA.Selenium;
using Reqnroll.BoDi;
using System.ComponentModel;
using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Login
{

    public class LoginPage : LoginPageElements
    {
        private readonly IWebDriver _driver;
        private readonly JsonHelper _jsonHelper;

        public LoginPage(IObjectContainer container)
        {
            _driver = container.Resolve<IWebDriver>();
            _jsonHelper = container.Resolve<JsonHelper>();
        }
        public void GoToBaseUrl() =>
        _driver.Navigate().GoToUrl(_jsonHelper.BaseURL);

        public void EnterCredentials(string username, string password)
        {
            _driver.FindElement(EmailField).SendKeys(username);
            _driver.FindElement(PasswordField).SendKeys(password);
            _driver.FindElement(LoginButton).Click();
        }  
    }
}