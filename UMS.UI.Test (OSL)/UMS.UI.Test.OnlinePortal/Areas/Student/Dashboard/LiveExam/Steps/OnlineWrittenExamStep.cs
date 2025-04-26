using UMS.UI.Test.BusinessModel.Dto.Exam;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Student.Pages;
using UMS.UI.Test.Repository.Service;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Steps
{
    [Binding]
    public class OnlineWrittenExamStep
    {
        private readonly string _examName;
        private readonly string _routineId;

        private readonly ExamDto _examDto;
        private readonly OnlineWrittenPage _page;
        public OnlineWrittenExamStep(OnlineWrittenPage page)
        {
            _page = page;
            _examDto = ExamUtility.GetExamInfo();

            _examName = _examDto.ExamName!;
            _routineId = _examDto.RoutineId!;
        }

        [Given(@"Goto Online Written Exam Section")]
        public void GivenGotoOnlineWrittenExamSection()
        {
            Assert.True(_page.GetLiveExamSection().Displayed);
        }

        [When(@"Click On Online Written Exam Section")]
        public void WhenClickOnOnlineWrittenExamSection()
        {
            _page.GetLiveExamSection().Click();
        }

        [Then(@"Is Show Desired Online Written Exam")]
        public void ThenIsShowDesiredOnlineWrittenExam()
        {
            if (_page.ExamCardVisible(_routineId, _examName))
                Assert.True(_page.GetLiveOnlineWrittenExamName(_routineId, _examName).Displayed);
        }

        [When(@"Click On Online Written Take Exam Button")]
        public void WhenClickOnOnlineWrittenTakeExamButton()
        {
            if (_page.TakeExamBtnClickable(_routineId))
                _page.GetTakeExamBtn(_routineId).Click();
            else
            {
                TestHelper.ShowMessageBox("Take Exam Button Not Visible");
                Assert.True(_page.GetTakeExamBtn(_routineId).Displayed);
            }
        }

        [When(@"Select Examinee Online Written Study version")]
        public void WhenSelectExamineeOnlineWrittenStudyVersion()
        {
            IWebElement element = _page.GetVersion();
            new SelectElement(element).SelectByText("Bangla");
        }

        [When(@"Click On Online Written Start Exam Button")]
        public void WhenClickOnOnlineWrittenStartExamButton()
        {
            _page.GetWrittenBtn().Click();
        }

        [Then(@"Show Online Written Exam Information")]
        public void ThenShowOnlineWrittenExamInformation()
        {
            var exam = _page.GetExamName().Text;
            Assert.Contains(_examName, exam);
        }

        [When(@"Online Written Take Examination")]
        public void WhenOnlineWrittenTakeExamination()
        {
            var totalQuestions = int.Parse(_examDto.SaqTotalQuestions!);
            for (int i = 1; i <= totalQuestions; i++)
            {
                var question = _page.GetQuestionSerial(i).Text;

                if (question == "Question 1")
                {
                    var imgPath = AppHelper.GetFilePath("TestData\\Student\\OnlineWritten", $"OnlineWritten_{i}.jpg");
                    _page.GetUploadAnswerImage(i).SendKeys(imgPath);
                    _page.GetUploadCompleteProgress(i);
                    var imgPath2 = AppHelper.GetFilePath("TestData\\Student\\OnlineWritten", $"OnlineWritten_{i}_{i}.jpg");
                    _page.GetUploadAnswerImage(i).SendKeys(imgPath2);
                    _page.GetUploadCompleteProgress(i);
                    Assert.True(_page.GetUploadCompleteProgress(i).Displayed);
                }
                else
                {
                    var imgPath = AppHelper.GetFilePath("TestData\\Student\\OnlineWritten", $"OnlineWritten_{i}.jpg");
                    try
                    {
                        _page.GetUploadAnswerImage(i).SendKeys(imgPath);
                        _page.GetUploadCompleteProgress(i);
                        Assert.True(_page.GetUploadCompleteProgress(i).Displayed);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }

        [Then(@"Take Examination Successful")]
        public void ThenTakeExaminationSuccessful()
        {
            _page.GetExamSubmissionBtn().Click();
            Thread.Sleep(1000);
            _page.GetYesBtn().Click();
        }
    }
}
