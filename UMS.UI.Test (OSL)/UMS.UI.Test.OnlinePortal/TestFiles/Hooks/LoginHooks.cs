using UMS.UI.Test.BusinessModel;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Student.Login;
using UMS.UI.Test.OnlinePortal.Areas.Teacher.Pages;

namespace UMS.UI.Test.OnlinePortal.TestFiles.Hooks
{
    public class LoginHooks
    {
        private readonly IConfiguration _configuration;
        private readonly StudentLoginPage studentLoginPage;
        private readonly TeacherLoginPage teacherLoginPage;
        public LoginHooks(IWebDriver driver, ScenarioInfo scenarioInfo)
        {
            _configuration = AppHelper.GetAppSettings();
            studentLoginPage = new StudentLoginPage(driver);
            teacherLoginPage = new TeacherLoginPage(driver);

            if (!new[] { "Login", "Logout" }.Any(scenarioInfo.Title.Contains))
            {
                if (scenarioInfo.Title.Contains("Teacher") == true)
                {
                    GetTeacherAuthentication(teacherLoginPage);
                }
                else
                {
                    GetStudentAuthentication(studentLoginPage);
                }
            }
        }

        private void GetStudentAuthentication(StudentLoginPage login)
        {
            var (Username, Password, _) = UserCredential.GetStudentInfo();
            var username = /*Username ??*/ _configuration["Student:Username"];
            var password = /*Password ??*/ _configuration["Student:Password"];

            login.GetStudentLoginPage();
            login.GetRegistrationNoField().SendKeys(username);
            login.GetStudentLoginNextButton().Click();
            login.GetStudentPasswordField().SendKeys(password);
            login.GetStudentPortalLoginButton().Click();
            //if (login.IsVisibleDiscussionGroupButton())
            //    login.GetDiscussionGroupPopupButton().Click();
        }

        private void GetTeacherAuthentication(TeacherLoginPage login)
        {
            var (Username, Password, _) = UserCredential.GetTeacherInfo();
            var username = Username ?? _configuration["Teacher:Username"];
            var password = Password ?? _configuration["Teacher:Password"];

            login.GetTeacherLoginPage();
            login.GetTeacherPIN().SendKeys(username);
            login.GetTeacherPassword().SendKeys(password);
            login.GetTeacherLoginButton().Click();
        }
    }
}
