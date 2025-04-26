namespace UMS.UI.Test.OnlinePortal.Areas.Teacher.Elements
{
    public static class TeacherLoginElement
    {

        public static By LoginPage => By.XPath("//div[@class='uu-main']");
        public static By TeacherPIN => By.XPath("//input[@id='Username']");
        public static By Password => By.XPath("//input[@id='Password']");
        public static By LoginBtn => By.XPath("//button[normalize-space()='Login']");
        public static By LoginError => By.XPath("");
        public static By LoggedPage => By.XPath("//img[@class='uu-profile-pic']");
        public static By LogoutButton => By.XPath("//a[@class='uu-logout']");

    }
}
