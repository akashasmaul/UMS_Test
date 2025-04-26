namespace UMS.UI.Test.OnlinePortal.Areas.Student.Login
{
    public static class StudentLoginElement
    {

        public static By LoginPage => By.XPath("//div[@class='uu-main']");
        public static By Registration => By.XPath("//input[@id='RegistrationNumber']");
        public static By Password => By.XPath("//input[@id='Password']");
        public static By LoginNextBtn => By.XPath("//button[@id='btnSubmit']");
        public static By LoginBtn => By.XPath("//button[normalize-space()='Login']");
        public static By LoggedPage => By.XPath("//img[@class='uu-profile-pic']");
        public static By FbGroupPopup => By.XPath("//img[@class='cursor-pointer']");
        public static By LogoutButton => By.XPath("//a[@class='uu-logout']");

    }
}
