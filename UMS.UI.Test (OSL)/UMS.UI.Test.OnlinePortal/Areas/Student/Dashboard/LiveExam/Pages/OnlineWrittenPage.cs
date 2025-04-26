using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveExam.Elements;
using UMS.UI.Test.OnlinePortal.Areas.Student.Login;

namespace UMS.UI.Test.OnlinePortal.Areas.Student.Pages
{
    public class OnlineWrittenPage
    {
        private readonly IWebDriver _driver;
        private readonly StudentLoginPage _loginPage;
        public OnlineWrittenPage(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new(driver);
        }
        public IWebElement GetLiveExamSection()
        {
            return _driver.FindElement(OnlineWrittenElement.LiveExamSection);
        }
        public IWebElement GetLiveOnlineWrittenExamName(string routineid, string examName)
        {
            return _driver.FindElement(By.XPath($"//*[@data-routineid='{routineid}']//h2[contains(text(),'{examName}')]"));
        }
        public bool ExamCardVisible(string routineid, string examName)
        {
            var element = By.XPath($"//*[@data-routineid='{routineid}']//h2[contains(text(),'{examName}')]");
            int count = 40;
            while (!WaitHelper.IsVisibleWebElement(_driver, 30, element))
            {
                if (count == 0)
                    break;
                _driver.Navigate().Refresh();
                if (_loginPage.IsVisibleDiscussionGroupButton())
                    _loginPage.GetDiscussionGroupPopupButton().Click();
                GetLiveExamSection().Click();
                count--;
            }
            //TestHelper.WaitWebElementVisible(_driver, element, 600);
            return WaitHelper.IsVisibleWebElement(_driver, 1, element);
        }
        public IWebElement GetTakeExamBtn(string routineid)
        {
            return _driver.FindElement(By.XPath($"//*[@data-routineid='{routineid}']//a[contains(@href,'routineId={routineid}')]"));
        }
        public bool TakeExamBtnClickable(string routineid)
        {
            var element = By.XPath($"//*[@data-routineid='{routineid}']//a[contains(@href,'routineId={routineid}')]");
            WaitHelper.WebElementToBeClickable(_driver, 600, element);
            return true;
        }
        public IWebElement GetVersion()
        {
            return _driver.FindElement(OnlineWrittenElement.Version);
        }
        public IWebElement GetWrittenBtn()
        {
            return _driver.FindElement(OnlineWrittenElement.WrittenBtn);
        }
        public IWebElement GetExamName()
        {
            return _driver.FindElement(OnlineWrittenElement.ExamName);
        }
        public IWebElement GetQuestionSerial(int serial)
        {
            return _driver.FindElement(By.XPath($"//*[@class='serial']//span[normalize-space()='Question {serial}']"));
        }
        public IWebElement GetUploadAnswerImage(int serial)
        {
            return _driver.FindElement(By.XPath($"//input[@id='image-file-input_{serial}']"));
        }
        public IWebElement GetUploadCompleteProgress(int index)
        {
            By UploadCompleteProgress = By.XPath($"(//div[@class='TakeExamAction add-question p-2 border rounded question-edit-update'])[{index}]");
            WaitHelper.WebElementIsVisible(_driver, 60, UploadCompleteProgress);
            return _driver.FindElement(UploadCompleteProgress);
        }
        public IWebElement GetExamSubmissionBtn()
        {

            return _driver.FindElement(OnlineWrittenElement.ExamSubmissionBtn);
        }
        public IWebElement GetYesBtn()
        {
            return _driver.FindElement(OnlineWrittenElement.YesBtn);
        }
        public IWebElement GetNoBtn()
        {
            return _driver.FindElement(OnlineWrittenElement.NoBtn);
        }
    }
}
