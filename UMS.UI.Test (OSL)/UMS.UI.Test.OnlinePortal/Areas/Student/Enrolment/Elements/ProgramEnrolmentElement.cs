namespace UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Elements
{
    public static class ProgramEnrolmentElement
    {
        public static By StudentClassType => By.XPath("//select[@id='studentClassId']");

        public static By EnrollNowButtonById(string programId, string sessionId)
        {
            return By.XPath($"//*[@href='/Enrolment/ProgramEnrolment?programId={programId}&sessionId={sessionId}']");
        }

        public static By EnrollNowButtonByText(string program, string session)
        {
            return By.XPath($"//*[text()='{program} {session}']/ancestor::div[@class='uu-routine-item']//*[contains(@href,'/ProgramEnrolment')]");
        }

        public static By EnrollPrograms => By.XPath("//*[contains(@href,'/Enrolment/ProgramEnrolment')]");
        public static By CourseList => By.XPath("//*[contains(@class,'course-name-check')]");
        public static By CourseFee => By.XPath("//amount[@id='calculatedPaymentInfo']//strong");
        public static By InstituteName => By.XPath("//input[@id='InstituteName']");
        public static By InstituteSelect => By.XPath("//a[@role='option']");
        public static By StudyVersion => By.XPath("//select[@id='VersionOfStudy']");
        public static By Branch => By.XPath("//select[@id='BranchId']");
        public static By AttachedPhysicalBranch => By.XPath("//select[@id='AttachedPhysicalBranchId']");
        public static By MbbsDbsStatus => By.XPath("//input[@id='MbbsDbsStatus']");
        public static By AcademicGroup => By.XPath("//*[@id='AcademicGroup']");
        public static By BatchType(string courseId) => By.XPath($"//select[@id='Course-{courseId}-BatchDays']");
        public static By BatchTime(string courseId) => By.XPath($"//select[@id='Course-{courseId}-BatchTime']");
        public static By BatchName(string courseId) => By.XPath($"//select[@id='Course-{courseId}-Batch']");
        public static By PayableAmount => By.XPath("//input[@id='PayableAmount']");
        public static By PaymentAmount => By.XPath("//input[@id='StudentPaymentAmount']");
        public static By PaymentMethod => By.XPath("//input[@id='SslCommerzPaymentMethod']");
        public static By TermsAndCondition => By.XPath("//*[@id='IsAgreeTermsAndCondition']");
        public static By SuccessButton => By.XPath("//input[@type='submit'][@value='Success']");
        public static By Congratulations => By.XPath("//div[@class='uu-login-form-wrapper']");

        public static By SubmitButton => By.XPath("//button[@id='btnSubmit']");
        public static By DashboardButton => By.XPath("//*[@href='/Dashboard']");

    }
}
