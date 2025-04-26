using UMS.UI.Test.BusinessModel.Enum.Student;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Pages;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Steps
{
    [Binding]
    public class ProgramEnrolmentStep(ProgramEnrolmentPage page)
    {
        private string? _courseId;
        private string? _courseFee;
        private string? _programSession;
        private string? _minimumPaymentAmount;
        private SelectElement? _selectElement;
        private IWebElement? _webElement;
        private IList<IWebElement>? _webElements;
        private readonly ProgramEnrolmentPage _page = page;


        [Given(@"Goto Student Program Enrolment Page")]
        public void GivenGotoStudentProgramEnrolmentPage()
        {
            _page.GetAddCourseMenu().Click();
        }

        [When(@"Select Student Program Class Type ""([^""]*)""")]
        public void WhenSelectStudentProgramClassType(string classType)
        {
            _webElement = _page.GetStudentClassType();
            _selectElement = new SelectElement(_webElement);
            _selectElement.SelectByText(classType);
        }

        [When(@"Click On Enroll Now Button ""([^""]*)"" ""([^""]*)""")]
        public void WhenClickOnEnrollNowButton(string program, string session)
        {
            _programSession = $"{program} {session}";
            if (TestHelper.IsNumber(program))
            {
                _page.GetEnrollNowButtonById(program, session).Click();
            }
            else
            {
                _page.GetEnrollNowButtonByText(program, session).Click();
            }
        }

        [When(@"Select Desire Course Name ""([^""]*)""")]
        public void WhenSelectDesireCourseName(string course)
        {
            _webElements = _page.GetCourseList();
            _webElement = _webElements
                .Single(c =>
                c.GetAttribute("data-course-id") == course ||
                c.GetAttribute("data-course-name") == course);

            _webElement.Click();

            _courseId = _webElement.GetAttribute("data-course-id");
            //_dto.Course += string.IsNullOrEmpty(_dto.Course) ? _courseId : ',' + _courseId;
            _minimumPaymentAmount = _webElement.GetAttribute("data-publicminpayment");
        }

        [When(@"Click On Student Course Next Button")]
        public void WhenClickOnStudentCourseNextButton()
        {
            _courseFee = _page.GetCourseFee().Text;
            _page.GetSubmitButton().Click();
        }

        [When(@"Select Student Institute Name ""([^""]*)""")]
        public void WhenSelectStudentInstituteName(string institute)
        {
            _page.GetInstituteName().SendKeys(institute);
            Task.Delay(500);
            _page.GetInstituteSelect().Click();
        }

        [When(@"Select Student Study Version ""([^""]*)""")]
        public void WhenSelectStudentStudyVersion(string version)
        {
            _webElement = _page.GetStudyVersion();
            _selectElement = new SelectElement(_webElement);
            _selectElement.SelectByText(version);
        }

        [When(@"Select Student Course Branch ""([^""]*)""")]
        public void WhenSelectStudentCourseBranch(string branch)
        {
            _webElement = _page.GetBranch();
            _selectElement = new SelectElement(_webElement);
            _selectElement.SelectByText(branch);
        }

        [When(@"Select Attached Physical Branch ""([^""]*)""")]
        public void WhenSelectAttachedPhysicalBranch(string branch)
        {
            _webElement = _page.GetAttachedPhysicalBranch();
            if (_webElement != null)
            {
                _selectElement = new SelectElement(_webElement);
                _selectElement.SelectByText(branch);
            }
        }

        [When(@"Select Mbbs Or Dbs Second Time Status ""([^""]*)""")]
        public void WhenSelectMbbsOrDbsSecondTimeStatus(string mbbsDbs)
        {
            _webElements = _page.GetMbbsDbsStatuses();
            if (_webElements != null && _webElements.Count > 0)
            {
                var dicItems = new Dictionary<string, string>
                {
                    { "First Timer", "10" },
                    { "Second Timer", "20" },
                    { "MBBS/BDS Enrolled", "30" }
                };

                _webElements
                    .Single(x => x.GetAttribute("value") == dicItems[mbbsDbs])
                    .Click();
            }
        }

        [When(@"Select Student Academic Study Group ""([^""]*)""")]
        public void WhenSelectStudentAcademicStudyGroup(string studyGroup)
        {
            _webElements = _page.GetAcademicGroups();
            if (_webElements != null && _webElements.Count > 0)
            {
                _ = Enum.TryParse(studyGroup, out StudyGroup matchedGroup);
                _webElements
                    .Single(x => x.GetAttribute("value") == $"{Convert.ToInt32(matchedGroup)}")
                    .Click();
            }
        }

        private void SelectCourseBatchTypeTimeName(IWebElement webElement)
        {
            _selectElement = new SelectElement(webElement);
            _webElement = _selectElement.Options
                .Skip(1)
                .FirstOrDefault(x => x.Enabled);

            if (_webElement != null)
            {
                var value = _webElement.GetAttribute("value");
                _selectElement.SelectByValue(value);
            }
        }

        [When(@"Select Course Batch Type, Time & Name ""([^""]*)""")]
        public void WhenSelectCourseBatchTypeTimeName(string course)
        {
            course = TestHelper.IsNumber(course) ? course : _courseId!;

            Thread.Sleep(3000);
            _webElement = _page.GetBatchType(course);
            SelectCourseBatchTypeTimeName(_webElement);
            Thread.Sleep(3000);
            _webElement = _page.GetBatchTime(course);
            SelectCourseBatchTypeTimeName(_webElement);
            Thread.Sleep(3000);
            _webElement = _page.GetBatchName(course);
            SelectCourseBatchTypeTimeName(_webElement);
        }

        [When(@"Click On Course Payment Next Button")]
        public void WhenClickOnCoursePaymentNextButton()
        {
            Assert.Equal(_page.GetCourseFee().Text, _courseFee);
            _page.GetSubmitButton().Click();
        }

        [When(@"Enter Student Payment Amount ""([^""]*)""")]
        public void WhenEnterStudentPaymentAmount(string paymentAmount)
        {
            var courseFee = int.Parse(_courseFee!, NumberStyles.AllowThousands);
            var payableAmount = _page.GetPayableAmount().GetAttribute("value");
            Assert.Equal(payableAmount, $"{courseFee}");

            paymentAmount = Convert.ToDouble(paymentAmount) > Convert.ToDouble(_minimumPaymentAmount!) ?
                paymentAmount : $"{Convert.ToDouble(_minimumPaymentAmount!)}";

            _page.GetPaymentAmount().SendKeys(paymentAmount);
        }

        [When(@"Select Student Payment Method ""([^""]*)""")]
        public void WhenSelectStudentPaymentMethod(string paymentMethod)
        {
            _webElements = _page.GetPaymentMethods();
            if (_webElements != null && _webElements.Count > 0)
            {
                var dicItems = new Dictionary<string, string>
                {
                    { "bKash Web Payment", "1" },
                    { "Nagad Web Payment", "2" },
                };

                _webElements
                    .Single(x => x.GetAttribute("value") == dicItems[paymentMethod])
                    .Click();
            }
        }

        [When(@"Click On ProceedToPay Button With Terms&Condition")]
        public void WhenClickOnProceedToPayButtonWithTermsCondition()
        {
            _page.GetTermsAndCondition().Click();
            Task.Delay(500);
            _page.GetSubmitButton().Click();
        }

        [When(@"Click On Ssl Commerz Payment Success Button")]
        public void WhenClickOnSslCommerzPaymentSuccessButton()
        {
            _page.GetSuccessButton().Click();
        }

        [Then(@"Is Success Student Program Course Enrollment")]
        public void ThenIsSuccessStudentProgramCourseEnrollment()
        {
            _webElement = _page.GetCongratulations();
            Assert.True(_webElement.Displayed);
            //Assert.Equal("CONGRATULATIONS!", _webElement.Text);
            //Assert.True(_page.GetDashboardButton().Displayed);
        }

    }
}
