using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Teacher.Pages;

namespace UMS.UI.Test.OnlinePortal.Areas.Teacher.Login
{
    [Binding]
    public class TeacherLoginStep
    {
        private readonly TeacherLoginPage _page;
        private readonly IConfiguration configuration;
        public TeacherLoginStep(TeacherLoginPage page)
        {
            _page = page;
            configuration = AppHelper.GetAppSettings();
        }


        [Given(@"Goto Teacher Login Page")]
        public void GivenGotoTeacherLoginPage()
        {
            Assert.True(_page.GetTeacherLoginPage().Displayed);
        }

        [When(@"Enter TPIN in The Field")]
        public void WhenEnterTPINInTheField()
        {
            _page.GetTeacherPIN().SendKeys(configuration["Teacher:Username"]);
        }

        [When(@"Enter Teacher Password")]
        public void WhenEnterTeacherPassword()
        {
            _page.GetTeacherPassword().SendKeys(configuration["Teacher:Password"]);
        }

        [When(@"Click on Teacher Login Button")]
        public void WhenClickOnTeacherLoginButton()
        {
            _page.GetTeacherLoginButton().Click();
        }

        [Then(@"Is Teacher Login Success")]
        public void ThenIsTeacherLoginSuccess()
        {
            Assert.True(_page.GetTeacherLoggedPage().Displayed);
        }

        [Given(@"The Teacher is already logged in")]
        public void GivenTheTeacherIsAlreadyLoggedIn()
        {
            if (!_page.IsVisibleLoggedPage())
            {
                WhenEnterTPINInTheField();
                WhenEnterTeacherPassword();
                WhenClickOnTeacherLoginButton();
                ThenIsTeacherLoginSuccess();
            }
        }

        [When(@"Teacher click the logout button")]
        public void WhenTeacherClickTheLogoutButton()
        {
            _page.GetTeacherLoggedPage().Click();
            _page.GetTeacherLogoutButton().Click();
        }

        [Then(@"Assert that Teacher goto login page")]
        public void ThenAssertThatTeacherGotoLoginPage()
        {
            Assert.True(_page.GetTeacherLoginPage().Displayed);
        }

    }
}
