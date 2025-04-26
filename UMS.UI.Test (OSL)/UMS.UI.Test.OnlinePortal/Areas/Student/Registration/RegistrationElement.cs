namespace UMS.UI.Test.OnlinePortal.Areas.Student.Registration
{
    public static class RegistrationElement
    {
        public static By RegisterNow => By.XPath("//a[@class='uu-forgot-number text-action']");
        public static By ForgotRegistrationNumber => By.XPath("//a[@href='/Account/ForgotRegistrationNumber']");
        public static By ForgotPassword => By.XPath("//a[@href='/Account/ForgotPassword']");
        public static By NickName => By.XPath("//input[@id='nickName']");
        public static By MobileNumber => By.XPath("//input[@id='mobileNumber']");
        public static By RegistrationNextBtn => By.XPath("//button[@id='nextOperation']");
        public static By OtpForm => By.XPath("//input[@id='otp']");
        public static By ReSendOtp => By.XPath("//a[@id='ReSendOtp']");
        public static By OtpNextButton => By.XPath("//button[@id='nextOperation']");
        public static By GradeOrLevel => By.XPath("//select[@id='studentClassId']");
        public static By Gender => By.XPath("//select[@id='gender']");
        public static By Religion => By.XPath("//select[@id='religion']");
        public static By District => By.XPath("//select[@id='districtId']");
        public static By Email => By.XPath("//input[@id='email']");
        public static By AcademicSubmit => By.XPath("//button[@id='nextOperation']");
        public static By RegestrationName => By.XPath("//h3[contains(text(), 'Dear')]/strong");
        public static By RegestrationNumber => By.XPath("//span[@class='reg-number']");
        public static By NewPassword => By.XPath("//input[@id='newPassword' or @id='NewPassword']");
        public static By ConfirmPassword => By.XPath("//input[@id='confirmPassword' or @id='ConfirmPassword']");
        public static By SetPasswordSubmit => By.XPath("//button[@id='nextOperation']");
        public static By ShowProfilePic => By.XPath("//img[@class='uu-profile-pic']");


        public static By LoginPage => By.XPath("//div[@class='uu-main']");
        public static By LoginBtn => By.XPath("//button[normalize-space()='Login']");
        public static By RegistrationNumber => By.XPath("//input[@id='registrationNumber' or @id='RegistrationNumber']");
        public static By ForgotRegistrationNextButton => By.XPath("//button[@id='next']");
        public static By LoginNextBtn => By.XPath("//button[@id='btnSubmit']");
        public static By OtpCountDown => By.XPath("//span[@id='OtpCountDown']");

    }
}
