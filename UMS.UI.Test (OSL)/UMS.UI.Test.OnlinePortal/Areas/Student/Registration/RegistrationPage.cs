using System.Text.Json;
using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Registration
{
    public class RegistrationPage
    {
        private readonly IWebDriver _driver;
        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver GetDriver() => _driver;
        public IWebElement GetRegisterNow() => _driver.FindElement(RegistrationElement.RegisterNow);
        public IWebElement GetForgotRegistrationNumber() => _driver.FindElement(RegistrationElement.ForgotRegistrationNumber);
        public IWebElement GetForgotPassword() => _driver.FindElement(RegistrationElement.ForgotPassword);
        public IWebElement GetNickName() => _driver.FindElement(RegistrationElement.NickName);
        public IWebElement GetMobileNumber() => _driver.FindElement(RegistrationElement.MobileNumber);
        public IWebElement GetRegistrationNextBtn() => _driver.FindElement(RegistrationElement.RegistrationNextBtn);
        public IWebElement GetOtpForm() => _driver.FindElement(RegistrationElement.OtpForm);
        public IWebElement GetReSendOtp() => _driver.FindElement(RegistrationElement.ReSendOtp);
        public IWebElement GetOtpNextButton() => _driver.FindElement(RegistrationElement.OtpNextButton);
        public IWebElement GetGradeOrLevel() => _driver.FindElement(RegistrationElement.GradeOrLevel);
        public IWebElement GetGender() => _driver.FindElement(RegistrationElement.Gender);
        public IWebElement GetReligion() => _driver.FindElement(RegistrationElement.Religion);
        public IWebElement GetDistrict() => _driver.FindElement(RegistrationElement.District);
        public IWebElement GetEmail() => _driver.FindElement(RegistrationElement.Email);
        public IWebElement GetAcademicSubmit() => _driver.FindElement(RegistrationElement.AcademicSubmit);
        public IWebElement GetRegestrationName() => _driver.FindElement(RegistrationElement.RegestrationName);
        public IWebElement GetRegestrationNumber() => _driver.FindElement(RegistrationElement.RegestrationNumber);
        public IWebElement GetNewPassword() => _driver.FindElement(RegistrationElement.NewPassword);
        public IWebElement GetConfirmPassword() => _driver.FindElement(RegistrationElement.ConfirmPassword);
        public IWebElement GetSetPasswordSubmit() => _driver.FindElement(RegistrationElement.SetPasswordSubmit);
        public IWebElement GetShowProfilePic() => _driver.FindElement(RegistrationElement.ShowProfilePic);
        public IWebElement GetRegistrationNumber() => _driver.FindElement(RegistrationElement.RegistrationNumber);
        public IWebElement GetForgotRegistrationNextButton() => _driver.FindElement(RegistrationElement.ForgotRegistrationNextButton);
        public IWebElement GetStudentLoginPage() => _driver.FindElement(RegistrationElement.LoginPage);
        public IWebElement GetStudentPortalLoginButton() => _driver.FindElement(RegistrationElement.LoginBtn);
        public IWebElement GetLoginNextBtn() => _driver.FindElement(RegistrationElement.LoginNextBtn);
        public void GetOtpCountDown(int second)
        {
            WaitHelper.WebElementIsInvisible(_driver, second, RegistrationElement.OtpCountDown);
        }

        public string GetOtpFromUrl(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result; // Synchronous Call

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result; // Synchronous Read
                using JsonDocument doc = JsonDocument.Parse(jsonResponse);
                return doc.RootElement.GetProperty("otp").GetString() ?? "OTP Not Found";
            }

            return "Failed to fetch OTP";
        }
    }
}
