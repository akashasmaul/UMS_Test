using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveExam.Elements;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveExam.Pages
{
    public class McqLiveExamPage
    {
        private readonly IWebDriver _driver;
        public McqLiveExamPage(IWebDriver driver) => _driver = driver;


        public IWebDriver GetDriver() => _driver;

        public IWebElement GetLiveExamPage() => _driver.FindElement(McqLiveExamElement.LiveExamPage);

        public bool IsDisplayExamRoutineCard(string r_Id)
        {
            var second = 0;
            var timeWebElement = GetRoutineCardTime();
            if (timeWebElement != null && timeWebElement.Text != "Live Now")
            {
                var seconds = timeWebElement.Text.Split(':');
                second = (int.Parse(seconds[0]) * 60) + int.Parse(seconds[1]);
            }

            second = second > 0 ? second + 2 : 25;
            return WaitHelper.IsVisibleWebElement(_driver, second, By.XPath($"//a[contains(@href,'routineId={r_Id}')]"));
        }

        public IWebElement? GetRoutineCardTime()
        {
            try { return _driver.FindElement(By.XPath("//span[contains(@Id,'countDownShow')]")); } catch { return null; };
        }

        public IWebElement? GetRoutineCard(string r_Id)
        {
            try { return _driver.FindElement(By.XPath($"//*[@data-routineid='{r_Id}']")); } catch { return null; }
        }

        public IWebElement? GetTakeExamButton(string r_Id)
        {
            try { return _driver.FindElement(By.XPath($"//a[contains(@href,'routineId={r_Id}')]")); } catch { return null; }
        }

        public IWebElement GetStudyVersion() => _driver.FindElement(McqLiveExamElement.StudyVersion);
        public IWebElement GetExamStartButton() => _driver.FindElement(McqLiveExamElement.ExamStartButton);
        public IWebElement GetStartExamRoutineId() => _driver.FindElement(McqLiveExamElement.ExamRoutineId);
        public IWebElement GetExamStartPage() => _driver.FindElement(McqLiveExamElement.ExamStartPage);
        public IWebElement GetStartExamHeader() => _driver.FindElement(McqLiveExamElement.StartExamHeader);
        public IWebElement GetStartExamCountDown() => _driver.FindElement(McqLiveExamElement.StartExamCountDown);
        public IList<IWebElement> GetMcqQuestions() => _driver.FindElements(McqLiveExamElement.McqQuestion);

        public IWebElement GetMcqQuestionOption(int questionNo, char correctAnswer)
        {
            return _driver.FindElement(By.XPath($"//span[contains(@rel,'{questionNo}-{correctAnswer}')]"));
        }

        public IWebElement GetUddipokQuestion() => _driver.FindElement(McqLiveExamElement.UddipokQuestion);
        public IWebElement GetExamSubmitButton() => _driver.FindElement(McqLiveExamElement.ExamSubmitButton);
        public IWebElement GetModalYesButton() => _driver.FindElement(McqLiveExamElement.ModalYesButton);
        //public IWebElement GetExamSubmitSuccessMessage() => _driver.FindElement(McqLiveExamElement.ExamSubmitSuccess);

    }
}
