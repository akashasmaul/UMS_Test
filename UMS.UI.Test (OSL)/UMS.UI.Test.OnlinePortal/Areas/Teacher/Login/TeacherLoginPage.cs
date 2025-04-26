using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Teacher.Elements;

namespace UMS.UI.Test.OnlinePortal.Areas.Teacher.Pages
{
    public class TeacherLoginPage
    {
        private readonly IWebDriver _driver;
        public TeacherLoginPage(IWebDriver driver) => _driver = driver;


        public IWebDriver GetDriver() => _driver;

        public IWebElement GetTeacherLoginPage() => _driver.FindElement(TeacherLoginElement.LoginPage);

        public IWebElement GetTeacherPIN() => _driver.FindElement(TeacherLoginElement.TeacherPIN);

        public IWebElement GetTeacherPassword() => _driver.FindElement(TeacherLoginElement.Password);

        public IWebElement GetTeacherLoginButton() => _driver.FindElement(TeacherLoginElement.LoginBtn);

        public IWebElement GetTeacherLoggedPage() => _driver.FindElement(TeacherLoginElement.LoggedPage);

        public IWebElement GetTeacherLogoutButton() => _driver.FindElement(TeacherLoginElement.LogoutButton);

        public bool IsVisibleLoggedPage() => WaitHelper.IsVisibleWebElement(_driver, 02, TeacherLoginElement.LoggedPage);

    }
}
