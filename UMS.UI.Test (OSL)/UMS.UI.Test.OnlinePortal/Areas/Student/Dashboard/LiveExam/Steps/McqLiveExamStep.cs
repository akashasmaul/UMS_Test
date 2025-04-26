using UMS.UI.Test.BusinessModel.Dto.Exam;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Common;
using UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveExam.Pages;
using UMS.UI.Test.Repository.Service;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveExam.Steps
{
    [Binding]
    public class McqLiveExamStep
    {
        private IWebElement? _webElement;
        private SelectElement? _selectElement;
        private IList<IWebElement>? _webElements;

        private readonly ExamDto _dto;
        private readonly McqLiveExamPage _page;
        private readonly PortalCommonPage _commonPage;
        private readonly ITestOutputHelper _output;
        public McqLiveExamStep(McqLiveExamPage page, PortalCommonPage commonPage, ITestOutputHelper output)
        {
            _page = page;
            _output = output;
            _commonPage = commonPage;
            _dto = ExamUtility.GetExamInfo();
        }


        [Given(@"Goto Dashboard Live Exam")]
        public async Task GivenGotoDashboardLiveExam()
        {
            await Task.Delay(500);
            _page.GetLiveExamPage().Click();
        }

        [Then(@"Is Show Desired Mcq Live Exam")]
        public void ThenIsShowDesiredMcqLiveExam()
        {
            var counter = byte.MinValue;
            while (_page.IsDisplayExamRoutineCard(_dto.RoutineId!) == false)
            {
                _page.GetDriver().Navigate().Refresh();

                if (counter++ > 10)
                    break;
            }
        }

        [When("Click On Mcq Live Take Exam Button")]
        public async Task WhenClickOnMcqLiveTakeExamButton()
        {
            await Task.Delay(500);
            _page.GetTakeExamButton(_dto.RoutineId!)?.Click();
        }

        [When("Select Mcq Live Examinee Study Version")]
        public void WhenSelectMcqLiveExamineeStudyVersion()
        {
            _selectElement = new SelectElement(_page.GetStudyVersion());
            _selectElement.SelectByText("Bangla");
        }

        [When("Click On Start Mcq Live Exam Button")]
        public async Task WhenClickOnStartMcqLiveExamButton()
        {
            await Task.Delay(500);
            _page.GetExamStartButton().Click();
        }

        [When("Assertion Start Mcq Live Exam Info")]
        public void WhenAssertionStartMcqLiveExamInfo()
        {
            _webElement = _page.GetStartExamRoutineId();
            var routineId = _webElement.GetAttribute("value");
            Assert.Equal(routineId, _dto.RoutineId!);

            Assert.True(_page.GetExamStartPage().Displayed);
            Assert.True(_page.GetStartExamHeader().Displayed);
            Assert.True(_page.GetStartExamCountDown().Displayed);
        }

        [When("Click On Mcq Live Exam Answer Options")]
        public async Task WhenClickOnMcqLiveExamAnswerOptions()
        {
            _webElements = _page.GetMcqQuestions();
            var mcqQuestionCount = int.Parse(_dto.McqTotalQuestions!);
            var mcqAnswerOptions = int.Parse(_dto.McqAnswerOptions!);

            Assert.True(_page.GetUddipokQuestion().Displayed);
            Assert.Equal(_webElements.Count, mcqQuestionCount);

            int upperBound = mcqAnswerOptions == 4 ? 69 : 70;
            for (var index = 1; index <= _webElements.Count; index++)
            {
                var correctAnswer = (char)new Random().Next(65, upperBound);
                _page.GetMcqQuestionOption(index, correctAnswer).Click();
                await Task.Delay(500);   // UI বা ব্যাকগ্রাউন্ড কাজ ব্লক করে না।
            }
        }

        [When("Click On Mcq Live Exam Submit Button")]
        public void WhenClickOnMcqLiveExamSubmitButton()
        {
            _page.GetExamSubmitButton().Click();
            Thread.Sleep(500);
            _page.GetModalYesButton().Click();
        }

        [Then("Is Success Mcq Live Exam Submission")]
        public void ThenIsSuccessMcqLiveExamSubmission()
        {
            _webElement = _commonPage.GetActionSuccessMessage();
            Assert.True(_webElement.Displayed);
            TestHelper.ShowMessageBox(_output, _webElement.Text);
        }

    }
}
