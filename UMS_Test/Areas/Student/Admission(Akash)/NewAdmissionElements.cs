using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    public class NewAdmissionElements
    {
        public By StudentButton = By.LinkText("Student");
        public By AdmissionNav = By.XPath("//body/div[2]/div[1]/div[1]/ul[1]/li[1]/div[1]/h4[1]");
        public By NewAdmissionButton = By.XPath("//a[contains(text(),'New Admission')]");
        public By StudentFindSubmitButton = By.XPath("//body/div[2]/div[2]/div[2]/div[1]/div[2]/div[2]/form[1]/input[2]");
        public By NewStudentButton = By.XPath("//a[contains(text(),'New Student')]");

        //Student Personal Details
        public By NickName = By.XPath("//input[@id='Name']");

        public By MobileNumber = By.XPath("//input[@id='MobNumber']");
        public By Gender = By.Id("Gender");
        public By Religion = By.Id("Religion");
        public By Class = By.Id("StudentClass");
        public By Program = By.Id("Program");
        public By Session = By.Id("Session");
        public By LastInstitute = By.Name("LastInstituteName");
        public By SelectLastInstitute = By.XPath("//*[@id='newAdmissionForm']//a");
        public By StudyVersion = By.Id("VersionOfStudy");
        public By Branch = By.Id("Branch");
        public By Campus = By.Id("Campus");
        public By PhysicalBranch = By.XPath($"//select[@id='AttachedPhysicalBranch']");
        public By? SecondTimerStatus;
        public By? academicGroup;

        //Course
        public By? Course;

        public By? BatchType;
        public By? BatchTime;
        public By NewAdmissionNextBtn = By.Id("newAdmissionNextBtn");

        //Payment
        public By SpecialDiscount = By.Id("spDiscountAmount");

        public By DiscountApprovedBy = By.XPath("//input[@id='DiscountApprovedByAutoComplete']");
        public By ElementToClick = By.XPath("//ul[@class='typeahead dropdown-menu']/li[@class='active' and not(@disabled='disabled')]");
        public By DiscountType = By.Id("RefererList");
        public By DiscountNote = By.Id("referrerenceNote");
        public By netRecieveable = By.Id("netReceivable");
        public By RecieveAmount = By.Id("receivedAmount");
        public By SubmitBtn = By.Id("newAdmissionPaymentSubmitBtn");

        public string courseId = "null";
        public string? recievedAmountFetched;
        public string programId = "null";

    }
}