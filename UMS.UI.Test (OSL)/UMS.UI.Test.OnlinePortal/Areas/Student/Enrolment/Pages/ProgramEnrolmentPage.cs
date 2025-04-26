using UMS.UI.Test.OnlinePortal.Areas.Common;
using UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Elements;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Pages
{
    public class ProgramEnrolmentPage
    {
        private readonly IWebDriver _driver;
        public ProgramEnrolmentPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetAddCourseMenu() => _driver.FindElement(PortalCommonElement.AddCourseMenu);
        public IWebElement GetStudentClassType() => _driver.FindElement(ProgramEnrolmentElement.StudentClassType);
        public IWebElement GetEnrollNowButtonById(string program, string session)
        {
            Thread.Sleep(200);
            return _driver.FindElement(ProgramEnrolmentElement.EnrollNowButtonById(program, session));
        }
        public IWebElement GetEnrollNowButtonByText(string program, string session)
        {
            Thread.Sleep(200);
            return _driver.FindElement(ProgramEnrolmentElement.EnrollNowButtonByText(program, session));
        }
        public IList<IWebElement> GetEnrollPrograms() => _driver.FindElements(ProgramEnrolmentElement.EnrollPrograms);
        public IList<IWebElement> GetCourseList() => _driver.FindElements(ProgramEnrolmentElement.CourseList);
        public IWebElement GetCourseFee() => _driver.FindElement(ProgramEnrolmentElement.CourseFee);
        public IWebElement GetInstituteName() => _driver.FindElement(ProgramEnrolmentElement.InstituteName);
        public IWebElement GetInstituteSelect() => _driver.FindElement(ProgramEnrolmentElement.InstituteSelect);
        public IWebElement GetStudyVersion() => _driver.FindElement(ProgramEnrolmentElement.StudyVersion);
        public IWebElement GetBranch() => _driver.FindElement(ProgramEnrolmentElement.Branch);
        public IWebElement? GetAttachedPhysicalBranch()
        {
            try { return _driver.FindElement(ProgramEnrolmentElement.AttachedPhysicalBranch); }
            catch { return null; }
        }
        public IList<IWebElement>? GetMbbsDbsStatuses()
        {
            try { return _driver.FindElements(ProgramEnrolmentElement.MbbsDbsStatus); } catch { return null; }
        }
        public IList<IWebElement>? GetAcademicGroups()
        {
            try { return _driver.FindElements(ProgramEnrolmentElement.AcademicGroup); } catch { return null; }
        }
        public IWebElement GetBatchType(string courseId) => _driver.FindElement(ProgramEnrolmentElement.BatchType(courseId));
        //public IWebElement GetBatchType(string courseId)
        //{
        //    //WaitHelper.IsInvisibleWebElement(_driver, 10, PortalCommonElement.ShowProcessing);
        //    //WaitHelper.WebElementIsVisible(_driver, 10, ProgramEnrolmentElement.BatchType(courseId));
        //    return _driver.FindElement(ProgramEnrolmentElement.BatchType(courseId));
        //}
        //public IWebElement GetBatchTime(string courseId)
        //{
        //    //WaitHelper.WebElementIsInvisible(_driver, 10, PortalCommonElement.ShowProcessing);
        //    //WaitHelper.WebElementIsVisible(_driver, 10, ProgramEnrolmentElement.BatchTime(courseId));
        //    return _driver.FindElement(ProgramEnrolmentElement.BatchTime(courseId));
        //}
        public IWebElement GetBatchTime(string courseId) => _driver.FindElement(ProgramEnrolmentElement.BatchTime(courseId));
        //public IWebElement GetBatchName(string courseId)
        //{
        //    //WaitHelper.WebElementIsInvisible(_driver, 10, PortalCommonElement.ShowProcessing);
        //    //WaitHelper.WebElementIsVisible(_driver, 10, ProgramEnrolmentElement.BatchName(courseId));
        //    return _driver.FindElement(ProgramEnrolmentElement.BatchName(courseId));
        //}
        public IWebElement GetBatchName(string courseId) => _driver.FindElement(ProgramEnrolmentElement.BatchName(courseId));
        public IWebElement GetPayableAmount() => _driver.FindElement(ProgramEnrolmentElement.PayableAmount);
        public IWebElement GetPaymentAmount() => _driver.FindElement(ProgramEnrolmentElement.PaymentAmount);
        public IList<IWebElement> GetPaymentMethods() => _driver.FindElements(ProgramEnrolmentElement.PaymentMethod);
        public IWebElement GetTermsAndCondition() => _driver.FindElement(ProgramEnrolmentElement.TermsAndCondition);

        public IWebElement GetSubmitButton() => _driver.FindElement(ProgramEnrolmentElement.SubmitButton);
        public IWebElement GetSuccessButton() => _driver.FindElement(ProgramEnrolmentElement.SuccessButton);
        public IWebElement GetCongratulations() => _driver.FindElement(ProgramEnrolmentElement.Congratulations);
        public IWebElement GetDashboardButton() => _driver.FindElement(ProgramEnrolmentElement.DashboardButton);

    }
}
