namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    public static class NewAdmissionElement
    {
        private static int Day { get; } = DateTime.Today.AddDays(2).Day;

        public static By AdmissionMenuGroup => By.XPath("//*[@href='#collapse_51']");
        //public static By AdmissionMenuGroup => By.XPath("//a[normalize-space()='Admission']");
        public static By NewAdmissionMenu => By.XPath("//*[@href='/Student/Admission/NewAdmission']");
        public static By OldAdmissionButton => By.XPath("//*[@action='/Student/Admission/ProgramSummary']");
        public static By NewAdmissionButton => By.XPath("//*[@href='/Student/Admission/NewStudentAdmission']");

        public static By NewAdmissionPage => By.XPath("//*[@id='newAdmissionForm']");
        public static By RegOrRollField => By.XPath("//*[@id='stdRollOrStdProRoll']");
        public static By OldAdmissionPage => By.XPath("//*[@class='panel panel-default']//*[@class='panel-body']");
        public static By AdmissionStatus => By.XPath("//*[@id='main-body-content']//td[normalize-space()='Visited']");
        public static By StudentNickname => By.XPath("//*[@id='Name']");
        public static By StudentMobileNo => By.XPath("//*[@id='MobNumber']");
        public static By StudentGender => By.XPath("//*[@id='Gender']");
        public static By StudentReligion => By.XPath("//*[@id='Religion']");
        public static By StudentClassType => By.XPath("//*[@id='StudentClass']");
        public static By StudentProgram => By.XPath("//*[@id='Program']");
        public static By StudentSession => By.XPath("//*[@id='Session']");
        public static By SearchInstitute => By.XPath("//*[@id='LastInstituteName']");
        public static By SelectInstitute => By.XPath("//*[@id='newAdmissionForm']//a");
        public static By StudyVersion => By.XPath("//*[@id='VersionOfStudy']");

        public static By BranchName => By.XPath("//*[@id='Branch']"); //select[@id='Branch']
        public static By CampusName => By.XPath("//*[@id='Campus']");
        public static By AttachedPhysicalBranch => By.XPath("//*[@id='AttachedPhysicalBranch']");
        //public static By IsAdmission2ndTimer => By.XPath("//*[@id='IsSecondTimer_No']");
        //public static By SelectAcademicGroup => By.XPath("//*[@id='academicGroup_Science']");
        //public static By CourseDetails => By.XPath("//*[@id='courseDetailsCheckList']");
        public static By CourseList => By.XPath("//*[contains(@class,'course-name-check')]");

        //td[normalize-space()='Engineering Pre-Admission Course'];
        public static By SelectComplementaryCourse => By.XPath("(//table[@class='table'])[1]//input");
        public static By ComplementaryCourseModal => By.XPath("//div[@class='modal-content']");
        public static By ConfirmComplementaryBtn => By.XPath("//button[normalize-space()='Confirm']");
        public static By CouseCheckList => By.XPath("//div[@id='CouseCheckList']");
        public static By CompulsoryCourses => By.XPath("//*[@data-isofficecompulsary='True']");

        public static By NewAdmissionNextBtn => By.XPath("//*[@id='newAdmissionNextBtn']");
        public static By TotalCourseFee => By.XPath("//*[@id='totalCourseFee']");
        public static By OfferedDiscount => By.XPath("//*[@id='offeredDiscount']");
        public static By PreStdDiscount => By.XPath("//*[@id='previousStudentDiscountAmount']");
        public static By SpecialDiscount => By.XPath("//input[@id='spDiscountAmount']");
        public static By SpDiscountApprovedBy => By.XPath("//input[@id='DiscountApprovedByAutoComplete']");
        public static By SpDiscountApprover => By.XPath("//*[@id='paymentContainer']//a[@role='option']");
        public static By SpecialDiscountType => By.XPath("//select[@id='RefererList']");
        public static By SpDiscountReferredBy => By.XPath("//*[@id='ReferrerNameAutoComplete']");
        public static By SpDiscountReferrer => By.XPath("//*[contains(@class,'referrerTextField')]//a");
        public static By SpecialDicountNote => By.XPath("//textarea[@id='referrerenceNote']");
        public static By NetReceivableAmount => By.XPath("//*[@id='netReceivable']");
        public static By ReceivedAmount => By.XPath("//*[@id='receivedAmount']");
        public static By AvailableDueAmount => By.XPath("//*[@id='dueAmount']");

        public static By NextReceivedDate => By.XPath("//*[@id='nextRecDate']");
        public static By SelectReceiveDate => By.XPath($"//td[normalize-space()='{Day}']");
        public static By PaymentDetails => By.XPath("//div[@id='paymentContainer']");
        public static By NewAdmissionSubmitBtn => By.XPath("//*[@id='newAdmissionPaymentSubmitBtn']");
        public static By OldAdmissionSubmitBtn => By.XPath("//input[@id='admissionPaymentSubmitBtn']");
        public static By AdmissionMoneyReceiptPage => By.XPath("//*[@id='viewport']");
        public static By AdmissionMoneyReceiptPDF => By.XPath("//*[@id='viewport']//canvas");

        public static By SecondTimer(string value) => By.XPath($"//*[@id='IsSecondTimer_{value}']");
        public static By AcademicGroup(string value) => By.XPath($"//*[@id='academicGroup_{value}']");
        public static By ComplementaryCourse(string value) => By.XPath($"//*[normalize-space()='{value}']");
        //*[@id='{courseId}']//input
        public static By CourseSubjects(string value) => By.XPath($"//p//*[@data-course-id='{value}']");
        public static By CourseBatchType(string value) => By.XPath($"//*[contains(@class,'batch-day-course-{value}')]");
        public static By CourseBatchTime(string value) => By.XPath($"//*[contains(@class,'batch-time-course-{value}')]");
        public static By CourseBatchName(string value) => By.XPath($"//*[contains(@class,'batch-course-{value}')]");

    }
}
