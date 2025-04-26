namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.Index
{
    public class DashboardPage
    {
        private readonly IWebDriver _driver;
        public DashboardPage(IWebDriver driver) => _driver = driver;


        public IWebDriver GetDriver() => _driver;

        //public IWebElement GetFbGroupPopupClose() => _driver.FindElement(DashboardElement.FbGroupPopupClose);

        public IWebElement GetStudentDashboardPage() => _driver.FindElement(DashboardElement.DashboardPage);
        public IWebElement GetLiveClass() => _driver.FindElement(DashboardElement.LiveClass);
        public IWebElement GetLiveExam() => _driver.FindElement(DashboardElement.LiveExam);
        public IWebElement GetPracticeExam() => _driver.FindElement(DashboardElement.PracticeExam);
        public IWebElement GetSolveSheet() => _driver.FindElement(DashboardElement.SolveSheet);
        public IWebElement GetQnAService() => _driver.FindElement(DashboardElement.QnAService);
        public IWebElement GetCourseContent() => _driver.FindElement(DashboardElement.CourseContent);
        public IWebElement GetDiscussionGroup() => _driver.FindElement(DashboardElement.DiscussionGroup);


    }
}
