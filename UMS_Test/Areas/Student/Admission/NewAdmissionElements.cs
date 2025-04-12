using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    public class NewAdmissionElements
    {
        public By xStudentButton = By.LinkText("Student");
        public By xAdmissionNav = By.XPath("//body/div[2]/div[1]/div[1]/ul[1]/li[1]/div[1]/h4[1]");
        public By xNewAdmissionButton = By.XPath("//a[contains(text(),'New Admission')]");
        public By xStudentFindSubmitButton = By.XPath("//body/div[2]/div[2]/div[2]/div[1]/div[2]/div[2]/form[1]/input[2]");
        public By xNewStudentButton = By.XPath("//a[contains(text(),'New Student')]");

        //Student Personal Details
        public By xNickName = By.XPath("//input[@id='Name']");

        public By xMobileNumber = By.XPath("//input[@id='MobNumber']");
        public By xGender = By.Id("Gender");
        public By xReligion = By.Id("Religion");
        public By xClass = By.Id("StudentClass");
        public By xProgram = By.Id("Program");
        public By xSession = By.Id("Session");
        public By xLastInstitute = By.Name("LastInstituteName");
        public By xSelectLastInstitute = By.XPath("//*[@id='newAdmissionForm']//a");
        public By xStudyVersion = By.Id("VersionOfStudy");
        public By xBranch = By.Id("Branch");
        public By xCampus = By.Id("Campus");
        public By xPhysicalBranch = By.XPath($"//select[@id='AttachedPhysicalBranch']");
        public By? xSecondTimerStatus;
        public By? xacademicGroup;

        //Course
        public By? xCourse;

        public By? xBatchType;
        public By? xBatchTime;
        public By xNewAdmissionNextBtn = By.Id("newAdmissionNextBtn");

        //Payment
        public By xSpecialDiscount = By.Id("spDiscountAmount");

        public By xDiscountApprovedBy = By.XPath("//input[@id='DiscountApprovedByAutoComplete']");
        public By xElementToClick = By.XPath("//ul[@class='typeahead dropdown-menu']/li[@class='active' and not(@disabled='disabled')]");
        public By xDiscountType = By.Id("RefererList");
        public By xDiscountNote = By.Id("referrerenceNote");
        public By xnetRecieveable = By.Id("netReceivable");
        public By xRecieveAmount = By.Id("receivedAmount");
        public By xSubmitBtn = By.Id("newAdmissionPaymentSubmitBtn");

        public string courseId = "null";
        public string? recievedAmountFetched;
        public string programId = "null";

    }
}