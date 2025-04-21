using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Login
{
    public static class LoginElement
    {

        public static By LoginPage => By.XPath("//div[@class='panel-title text-center']");
        public static By UserName => By.XPath("//input[@id='UserName']");
        public static By Password => By.XPath("//input[@id='Password']");
        public static By LoginBtn => By.XPath("//button[@id='Submit']");
        public static By LoginError => By.XPath("//div[@class='alert alert-danger']");
        public static By LoggedPage => By.XPath("//form[@id='logoutForm']");
        public static By LogoutButton => By.XPath("//*[@class='glyphicon glyphicon-off']");

    }
}
