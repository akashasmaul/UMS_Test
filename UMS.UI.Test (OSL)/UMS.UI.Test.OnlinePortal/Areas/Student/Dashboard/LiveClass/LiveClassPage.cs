namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveClass
{
    public class LiveClassPage
    {
        private readonly IWebDriver _driver;
        public LiveClassPage(IWebDriver driver) => _driver = driver;
        public IWebDriver GetDriver => _driver;
        public IWebElement GetDashboard() => _driver.FindElement(LiveClassElement.Dashboard);
        public IWebElement GetLiveClass() => _driver.FindElement(LiveClassElement.LiveClass);
        public IWebElement GetLiveClassHeading() => _driver.FindElement(LiveClassElement.LiveClassHeading);
        public IWebElement GetLiveClassJoinNowBtn() => _driver.FindElement(LiveClassElement.LiveClassJoinNowBtn);
        public IWebElement GetClassRoutineBox() => _driver.FindElement(LiveClassElement.ClassRoutineBox);
    }
}
