using OpenQA.Selenium;
using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    [Binding]
    public class NewStudnetAdmissionStep
    {
        private readonly NewAdmissionPage _page;
        private readonly IWebDriver driver;

        private NewStudnetAdmissionStep(NewAdmissionPage _pageObj, IWebDriver driverObj)
        {
            _page = _pageObj;
            driver = driverObj;
        }

        [Given("User navigates to Student Admission Page")]
        public void GivenUserNavigatesToStudentAdmissionPage()
        {
            /*
            _page.StudentButton().Click();
            _page.AdmissionNav().Click();
            _page.NewAdmissionButton().Click();
            _page.StudentFindSubmitButton().Click();
            _page.NewStudentButton().Click();
            */

            JsonHelper _jsonHelper = new JsonHelper();
            var baseUrl = _jsonHelper.BaseURL;
            driver.Navigate().GoToUrl(baseUrl + "Student/Admission/NewStudentAdmission");
        }

        [When("Enter The Student Nickname {string}")]
        public async Task WhenEnterTheStudentNickname(string nickName)
        {
            await _page.NickName(nickName);
        }

        [When("Enter The Student Mobile Number {string}")]
        public void WhenEnterTheStudentMobileNumber(string mobileNumber)
        {
            _page.MobileNumber().SendKeys(mobileNumber);
        }

        [When("Select Student Gender {string}")]
        public void WhenSelectStudentGender(string gender)
        {
            _page.SelectGender().SelectByText(gender);
        }

        [When("Select Student Religion {string}")]
        public void WhenSelectStudentReligion(string religion)
        {
            _page.SelectRelgion().SelectByText(religion);
        }

        [When("Select Student Class {string} Type")]
        public void WhenSelectStudentClassType(string classs)
        {
            _page.SelectClass().SelectByText(classs);
        }

        [When("Select Student Program {string} Name")]
        public void WhenSelectStudentProgramName(string program)
        {
            Thread.Sleep(1000);
            _page.SelectProgram(program);
        }

        [When("Select Session {string} Of Program")]
        public void WhenSelectSessionOfProgram(string session)
        {
            _page.SelectSession().SelectByText(session);
        }

        [When("Search Last Educational Institute {string}")]
        public void WhenSearchLastEducationalInstitute(string lastInstitute)
        {
            Thread.Sleep(1000);
            _page.LastInstitution(lastInstitute);
        }

        [When("Select Study Version {string} Type")]
        public void WhenSelectStudyVersionType(string studyVersion)
        {
            _page.SelectStudyVersion().SelectByText(studyVersion);
        }

        [When("Select Branch Name {string} Of Program")]
        public void WhenSelectBranchNameOfProgram(string branch)
        {
            _page.SelectBranch().SelectByText(branch);
        }

        [When("Select Attched Physical Branch {string} if Available")]
        public void WhenSelectAttchedPhysicalBranchIfAvailable(string physicalBranch)
        {
            _page.SelectPhysicalBranch(physicalBranch);

        }

        [When("Select Campus Name {string} Of Branch")]
        public void WhenSelectCampusNameOfBranch(string campus)
        {
            _page.SelectCampus().SelectByText(campus);

        }

        [When("Click On Is Student Second Timer {string}")]
        public void WhenClickOnIsStudentSecondTimer(string secondTimerStatus)
        {
            _page.SelectSecondTimerStatus(secondTimerStatus);
        }

        [When("Click On Student Academic Group {string}")]
        public void WhenClickOnStudentAcademicGroup(string academicGroup)
        {
            _page.SelectAcademicGroup(academicGroup);

        }

        [When("Select Course Name {string} Of Program")]
        public void WhenSelectCourseNameOfProgram(string course)
        {
            _page.ScrollDown();
            Thread.Sleep(500);
            // Split courses by comma and trim spaces
            var courseList = course.Split(',').Select(c => c.Trim()).ToList();

            foreach (var courses in courseList)
            {
                _page.SelectCourse(courses);
            }
        }

        [When("Select Subject {string} Based on Course {string}")]
        public void WhenSelectSubjectBasedOnCourse(string subject, string course)
        {
            _page.SelectSubject(subject, course);

        }

        [When("Select Batch Type {string} Of This Course")]
        public void WhenSelectBatchTypeOfThisCourse(string batchType)
        {
            _page.SelectbatchType(batchType);

        }

        [When("Select Batch Time {string} Of This Course")]
        public void WhenSelectBatchTimeOfThisCourse(string batchTime)
        {
            _page.SelectbatchTime(batchTime);

        }

        [When("Select Batch Name Of This Course")]
        public void WhenSelectBatchNameOfThisCourse()
        {
            Console.WriteLine("Pass as Batch Name Auto Selected");

        }

        [When("Click On Admission Payment Next Button")]
        public void WhenClickOnAdmissionPaymentNextButton()
        {
            _page.NextBtn().Click();

        }

        [Then("Show Admission Payment Details Section")]
        public void ThenShowAdmissionPaymentDetailsSection()
        {
            Console.WriteLine("Wait");
        }

        [Then("Enter Special Discount {string} Ammount")]
        public void ThenEnterSpecialDiscountAmmount(string specialDiscount)
        {
            _page.SpecialDiscount().SendKeys(specialDiscount);

        }

        [Then("Select Special Discount {string} Approved By")]
        public void ThenSelectSpecialDiscountApprovedBy(string discountBy)
        {
            _page.DiscountBy(discountBy);

        }

        [Then("Select Special Discount {string} Type")]
        public void ThenSelectSpecialDiscountType(string discountType)
        {
            _page.SelectDiscountType().SelectByText(discountType);

        }

        [Then("Enter Special Discount {string} Note")]
        public void ThenEnterSpecialDiscountNote(string discountNote)
        {
            _page.SpecialDisountNote().SendKeys(discountNote);

        }

        [When("Enter Admission Received Amount {string}")]
        public void WhenEnterAdmissionReceivedAmount(string recievedAmount)
        {
            _page.NetRecieveAmount();
            _page.RecievedAmount().SendKeys(_page.recievedAmountFetched);
        }

        [When("Click On New Admission Submit Button")]
        public void WhenClickOnNewAdmissionSubmitButton()
        {
            _page.SubmitBtn().Click();
        }

        [Then("Student should be successfully admitted")]
        public void ThenStudentShouldBeSuccessfullyAdmitted()
        {
            Console.WriteLine("Wait");
            Thread.Sleep(5000);
        }
    }
}
