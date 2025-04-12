using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Login
{
    public class LoginPageElements
    {
        public By EmailField = By.XPath("//input[@id='UserName']");
        public By PasswordField = By.XPath(" //input[@id='Password']");
        public By LoginButton = By.XPath("//button[@id='Submit']");
    }
}
