namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveClass
{
    [Binding]
    public class LiveClassStep
    {

        private readonly LiveClassPage _page;
        private readonly ITestOutputHelper _output;
        private string? isInteractive;

        public LiveClassStep(LiveClassPage page, ITestOutputHelper output)
        {
            _page = page;
            _output = output;
        }

        [Given(@"Navigate to the Live Class")]
        public void GivenNavigateToTheLiveClass()
        {
            _page.GetDashboard().Click();
            _page.GetLiveClass().Click();
            Thread.Sleep(1000);
        }

        [Then(@"Is Showing Live Class Section")]
        public void ThenIsShowingLiveClassSection()
        {
            try
            {
                Assert.Equal("LIVE CLASS", _page.GetLiveClassHeading().Text);
            }
            catch (Exception)
            {
                Assert.Fail("Live Class Page is not showing");
            }

        }

        [When(@"Click On Live Class Join Now")]
        public void WhenClickOnLiveClassJoinNow()
        {
            try
            {
                isInteractive = _page.GetClassRoutineBox().GetAttribute("data-is-interactive");
                if (_page.GetLiveClassJoinNowBtn().Displayed && isInteractive == "False")
                {
                    _page.GetLiveClassJoinNowBtn().Click();
                    Thread.Sleep(1000);
                }
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("No live class found.");
            }
        }
    }
}
