using UMS.UI.Test.BusinessModel.Dto.StudentPortal;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.Repository.Dao.StudentPortal;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Registration
{
    [Binding]
    public class RegistrationStep
    {
        private RegistrationDto _dto;
        private string? _nickName;
        private string? _regestrationNumber;
        private string? _mobileNumber;
        private string? _password;
        private string? _baseUrl;
        private readonly ITestOutputHelper _output;
        private readonly IConfiguration _configuration;
        private readonly RegistrationPage _page;
        private readonly StudentPortalDao _dao;
        public RegistrationStep(RegistrationPage page, ITestOutputHelper output)
        {
            _page = page;
            _output = output;
            _dao = new StudentPortalDao();
            _dto = new RegistrationDto();
            _configuration = AppHelper.GetAppSettings();
        }

        [Given(@"Goto Student Registration Page")]
        public void GivenGotoStudentRegistrationPage()
        {
            //Assert.True(_page.GetRegisterNow().Displayed);
        }

        [When(@"Click on the Register Now")]
        public void WhenClickOnTheRegisterNow()
        {
            _page.GetRegisterNow().Click();
        }

        [Then(@"Show Registration Form Page")]
        public void ThenShowRegistrationFormPage()
        {
            Assert.True(_page.GetNickName().Displayed);
        }

        [When(@"Enter Nick Name in the field")]
        public void WhenEnterNickNameInTheField()
        {
            _nickName = TestHelper.GetUniqueUpString();
            _page.GetNickName().SendKeys(_nickName);
            _dto.NickName = _nickName;
        }

        [When(@"Enter Mobile Number in the field")]
        public void WhenEnterMobileNumberInTheField()
        {
            _mobileNumber = _configuration["Student:MobileNo"];
            _page.GetMobileNumber().SendKeys(_mobileNumber);
            _dto.Mobile = _mobileNumber;
        }

        [When(@"Click on the Next Button")]
        public void WhenClickOnTheNextButton()
        {
            _page.GetRegistrationNextBtn().Click();
        }

        [Then(@"Show OTP Page")]
        public void ThenShowOTPPage()
        {
            Assert.True(_page.GetOtpForm().Displayed);
        }

        [When(@"Enter OTP in the field")]
        public void WhenEnterOTPInTheField()
        {
            _baseUrl = _configuration["Settings:BaseUrl"];
            var url = $"{_baseUrl}/Testing/GetOtpByMobNick?mobileNumber=88{_mobileNumber}&nickName={_nickName}";
            var otp = _page.GetOtpFromUrl(url);
            if (otp.Length >= 4)
                _page.GetOtpForm().SendKeys(otp);
            else
                TestHelper.ShowMessageBox(_output, "OTP not found");
            _dto.BaseUrl = _baseUrl;
        }

        [When(@"Click Resend OTP Button")]
        public void WhenClickResendOTPButton()
        {
            _page.GetOtpCountDown(360);
            _page.GetReSendOtp().Click();
        }

        [When(@"Click on the OTP Next Button")]
        public void WhenClickOnTheOTPNextButton()
        {
            try
            {
                _page.GetOtpNextButton().Click();
            }
            catch (NoSuchElementException)
            {
                TestHelper.ShowMessageBox(_output, $"Frequent Attempt! {_nickName}");
            }

        }

        [Then(@"Show Academic Page")]
        public void ThenShowAcademicPage()
        {
            Assert.True(_page.GetEmail().Displayed);
        }

        [When(@"Select Grade or Level DropDown {string}")]
        public void WhenSelectGradeOrLevelDropDown(string gradeOrLevel)
        {
            if (gradeOrLevel.Length >= 3)
                new SelectElement(_page.GetGradeOrLevel()).SelectByText(gradeOrLevel);
            else
                new SelectElement(_page.GetGradeOrLevel()).SelectByText("Admission");

        }

        [When(@"Select Gender DropDown {string}")]
        public void WhenSelectGenderDropDown(string gender)
        {
            if (gender == "Male" || gender == "Female")
                new SelectElement(_page.GetGender()).SelectByText(gender);
            else
                new SelectElement(_page.GetGender()).SelectByText("Male");

        }

        [When(@"Select Religion DropDown {string}")]
        public void WhenSelectReligionDropDown(string religion)
        {
            if (religion.Length >= 3)
                new SelectElement(_page.GetReligion()).SelectByText(religion);
            else
                new SelectElement(_page.GetReligion()).SelectByText("Islam");
        }

        [When(@"Select District DropDown {string}")]
        public void WhenSelectDistrictDropDown(string district)
        {
            if (district.Length >= 3)
                new SelectElement(_page.GetDistrict()).SelectByText(district);
            else
                new SelectElement(_page.GetDistrict()).SelectByText("Bagerhat");
        }

        [When(@"Enter Email in the field {string}")]
        public void WhenEnterEmailInTheField(string email)
        {
            if (email.Length >= 3)
                _page.GetEmail().SendKeys(email);
            else
                _page.GetEmail().SendKeys($"{_nickName}@auto.com");
        }

        [When(@"Click on the Submit Button")]
        public void WhenClickOnTheSubmitButton()
        {
            _page.GetAcademicSubmit().Click();
        }

        [Then(@"Show Set Your Password Page")]
        public void ThenShowSetYourPasswordPage()
        {
            Assert.True(_page.GetNewPassword().Displayed);
            _regestrationNumber = _page.GetRegestrationNumber().Text;
            TestHelper.ShowMessageBox(_output, _regestrationNumber);
            _dto.RegNumber = _regestrationNumber;
        }

        [When(@"Enter New Password in the field {string}")]
        public void WhenEnterNewPasswordInTheField(string password)
        {
            _password = password;
            if (_password.Length >= 6)
                _page.GetNewPassword().SendKeys(_password);
            else
                _page.GetNewPassword().SendKeys("123456#");
        }

        [When(@"Enter Confirm Password in the field")]
        public void WhenEnterConfirmPasswordInTheField()
        {
            if (string.IsNullOrEmpty(_password) == false)
                _page.GetConfirmPassword().SendKeys(_password);
            else
                _page.GetConfirmPassword().SendKeys("123456#");
        }

        [When(@"Click on the Set Password Submit Button")]
        public void WhenClickOnTheSetPasswordSubmitButton()
        {
            _page.GetSetPasswordSubmit().Click();
        }

        [Then(@"Show Program List Page")]
        public void ThenShowProgramListPage()
        {
            Assert.True(_page.GetShowProfilePic().Displayed);
            _dao.SetRegistrationInfo(_dto, BusinessModel.Enum.QueryType.Insert);
        }



        [When(@"Click on the Forgot Registration Number")]
        public void WhenClickOnTheForgotRegistrationNumber()
        {
            _page.GetForgotRegistrationNumber().Click();
        }

        [Then(@"Show Forgot Registration Number Form Page")]
        public void ThenShowForgotRegistrationNumberFormPage()
        {
            Assert.True(_page.GetNickName().Displayed);
        }

        [When(@"Enter Forgot Registration Nick Name in the field")]
        public void WhenEnterForgotRegistrationNickNameInTheField()
        {
            _nickName = _dao.GetRegistration().NickName;
            if (string.IsNullOrEmpty(_nickName) == false)
            {
                _page.GetNickName().SendKeys(_nickName);
            }
            else
            {
                TestHelper.ShowMessageBox(_output, "First you need to Registration.");
                Assert.Fail("First you need to Registration.");
            }


        }

        [When(@"Enter Forgot Registration Mobile Number in the field")]
        public void WhenEnterForgotRegistrationMobileNumberInTheField()
        {
            _mobileNumber = _dao.GetRegistration().Mobile;
            if (string.IsNullOrEmpty(_mobileNumber) == false)
            {
                _page.GetMobileNumber().SendKeys(_mobileNumber);
            }
            else
            {
                TestHelper.ShowMessageBox(_output, "First you need to Registration.");
                Assert.Fail("First you need to Registration.");
            }
        }

        [When(@"Click on the Forgot Registration Next Button")]
        public void WhenClickOnTheForgotRegistrationNextButton()
        {
            _page.GetForgotRegistrationNextButton().Click();
        }

        [Then(@"Show Forgot Registration OTP Page")]
        public void ThenShowForgotRegistrationOTPPage()
        {
            Assert.True(_page.GetOtpForm().Displayed);
        }

        [When(@"Enter Forgot Registration OTP in the field")]
        public void WhenEnterForgotRegistrationOTPInTheField()
        {
            _baseUrl = _dao.GetRegistration().BaseUrl;
            var url = $"{_baseUrl}/Testing/GetOtpByMobNick?mobileNumber=88{_mobileNumber}&nickName={_nickName}";
            var otp = _page.GetOtpFromUrl(url);
            if (otp.Length >= 4)
                _page.GetOtpForm().SendKeys(otp);
            else
            {
                TestHelper.ShowMessageBox(_output, "OTP not found");
                Assert.Fail("OTP not found");
            }

        }

        [When(@"Click on the Forgot Registration OTP Next Button")]
        public void WhenClickOnTheForgotRegistrationOTPNextButton()
        {
            _page.GetForgotRegistrationNextButton().Click();
        }

        [Then(@"Show Congratulations Page")]
        public void ThenShowCongratulationsPage()
        {
            _regestrationNumber = _page.GetRegestrationNumber().Text;
            TestHelper.ShowMessageBox(_output, _regestrationNumber);
        }

        [Given(@"Goto Student Portal Login Page")]
        public void GivenGotoStudentPortalLoginPage()
        {
            Assert.True(_page.GetStudentLoginPage().Displayed);
        }

        [When(@"Enter Registration Number in the field")]
        public void WhenEnterRegistrationNumberInTheField()
        {
            _regestrationNumber = _dao.GetRegistration().RegNumber;
            if (string.IsNullOrEmpty(_regestrationNumber) == false)
            {
                _page.GetRegistrationNumber().SendKeys(_regestrationNumber);
            }
            else
            {
                TestHelper.ShowMessageBox(_output, "Registration Number Not Found In Database");
                Assert.Fail("Registration Number Not Found In Database");
            }
        }

        [When(@"Click on the Student Login Next button")]
        public void WhenClickOnTheStudentLoginNextButton()
        {
            _page.GetLoginNextBtn().Click();
        }

        [Then(@"Show Forgot Password Text")]
        public void ThenShowForgotPasswordText()
        {
            Assert.True(_page.GetForgotPassword().Displayed);
        }

        [When(@"Click on the Forgot Password Link")]
        public void WhenClickOnTheForgotPasswordLink()
        {
            _page.GetForgotPassword().Click();
        }

        [When(@"Enter Forgot Password Registration Number in the field")]
        public void WhenEnterForgotPasswordRegistrationNumberInTheField()
        {
            _regestrationNumber = _dao.GetRegistration().RegNumber;
            if (string.IsNullOrEmpty(_regestrationNumber) == false)
            {
                _page.GetRegistrationNumber().SendKeys(_regestrationNumber);
            }
            else
            {
                TestHelper.ShowMessageBox(_output, "Registration Number Not Found In Database");
                Assert.Fail("Registration Number Not Found In Database");
            }
        }

        [When(@"Enter Forgot Password Mobile Number in the field")]
        public void WhenEnterForgotPasswordMobileNumberInTheField()
        {
            _mobileNumber = _dao.GetRegistration().Mobile;
            if (string.IsNullOrEmpty(_mobileNumber) == false)
            {
                _page.GetMobileNumber().SendKeys(_mobileNumber);
            }
            else
            {
                TestHelper.ShowMessageBox(_output, "Mobile Number Not Found In Database");
                Assert.Fail("Mobile Number Not Found In Database");
            }
        }

        [When(@"Click on the Forgot Password Next button")]
        public void WhenClickOnTheForgotPasswordNextButton()
        {
            _page.GetForgotRegistrationNextButton().Click();
        }

        [Then(@"Show Forgot Password OTP Page")]
        public void ThenShowForgotPasswordOTPPage()
        {
            Assert.True(_page.GetOtpForm().Displayed);
        }

        [When(@"Enter Forgot Password OTP in the field")]
        public void WhenEnterForgotPasswordOTPInTheField()
        {
            _baseUrl = _dao.GetRegistration().BaseUrl;
            _mobileNumber = _dao.GetRegistration().Mobile;
            _nickName = _dao.GetRegistration().NickName;
            var url = $"{_baseUrl}/Testing/GetOtpByMobNick?mobileNumber=88{_mobileNumber}&nickName={_nickName}";
            var otp = _page.GetOtpFromUrl(url);
            if (otp.Length >= 4)
                _page.GetOtpForm().SendKeys(otp);
            else
            {
                TestHelper.ShowMessageBox(_output, "OTP not found");
                Assert.Fail("OTP not found");
            }
        }

        [When(@"Click on the Forgot Password OTP Next Button")]
        public void WhenClickOnTheForgotPasswordOTPNextButton()
        {
            _page.GetForgotRegistrationNextButton().Click();
        }

        [Then(@"Show Login Button")]
        public void ThenShowLoginButton()
        {
            Assert.True(_page.GetStudentPortalLoginButton().Displayed);
        }


    }
}
