namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.Index
{
    [Binding]
    public class DashboardStep
    {
        private IWebElement? _webElement;
        private readonly DashboardPage _page;
        public DashboardStep(DashboardPage page)
        {
            _page = page;
        }


        [Given(@"Goto Student Dashboard")]
        public void GivenGotoStudentDashboard()
        {
            _webElement = _page.GetStudentDashboardPage();
            Assert.True(_webElement.Displayed);
        }

        [When(@"Click On Dashboard Live Class")]
        public void WhenClickOnDashboardLiveClass()
        {
            _page.GetLiveClass().Click();
            _page.GetDriver().Navigate().Back();
        }

        [When(@"Click On Dashboard Live Exam")]
        public void WhenClickOnDashboardLiveExam()
        {
            _page.GetLiveExam().Click();
            _page.GetDriver().Navigate().Back();
        }

        [When(@"Click On Dashboard Practice Exam")]
        public void WhenClickOnDashboardPracticeExam()
        {
            _page.GetPracticeExam().Click();
            _page.GetDriver().Navigate().Back();
        }

        [When(@"Click On Dashboard Solve Sheet")]
        public void WhenClickOnDashboardSolveSheet()
        {
            _page.GetSolveSheet().Click();
            _page.GetDriver().Navigate().Back();
        }

        [When(@"Click On Dashboard QnA Service")]
        public void WhenClickOnDashboardQnAService()
        {
            _page.GetQnAService().Click();
            _page.GetDriver().Navigate().Back();
        }

        [When(@"Click On Dashboard Course & Content")]
        public void WhenClickOnDashboardCourseContent()
        {
            _page.GetCourseContent().Click();
            _page.GetDriver().Navigate().Back();
        }

        [When(@"Click On Dashboard Discussion Group")]
        public void WhenClickOnDashboardDiscussionGroup()
        {
            _page.GetDiscussionGroup().Click();
            _page.GetDriver().Navigate().Back();
        }

    }
}
