using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Login
{
    public class StudentLoginPage
    {
        private readonly IWebDriver _driver;
        public StudentLoginPage(IWebDriver driver) => _driver = driver;


        public IWebElement GetStudentLoginPage() => _driver.FindElement(StudentLoginElement.LoginPage);

        public IWebElement GetRegistrationNoField() => _driver.FindElement(StudentLoginElement.Registration);

        public IWebElement GetStudentLoginNextButton() => _driver.FindElement(StudentLoginElement.LoginNextBtn);

        public IWebElement GetStudentPasswordField() => _driver.FindElement(StudentLoginElement.Password);

        public IWebElement GetStudentPortalLoginButton() => _driver.FindElement(StudentLoginElement.LoginBtn);

        public IWebElement GetStudentPortalLoggedPage() => _driver.FindElement(StudentLoginElement.LoggedPage);

        public IWebElement GetDiscussionGroupPopupButton() => _driver.FindElement(StudentLoginElement.FbGroupPopup);

        public IWebElement GetLogoutButton() => _driver.FindElement(StudentLoginElement.LogoutButton);

        public bool IsVisibleLoggedPage() => WaitHelper.IsExistsWebElement(_driver, 02, StudentLoginElement.LoggedPage);

        public bool IsVisibleDiscussionGroupButton() => WaitHelper.IsExistsWebElement(_driver, 02, StudentLoginElement.FbGroupPopup);

    }
}
