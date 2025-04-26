namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveClass
{
    public class LiveClassElement
    {
        public static By Dashboard => By.XPath("//li[a[@href='/Dashboard' and @title='Dashboard']]");
        public static By LiveClass => By.XPath("//a[@href='/Dashboard/LiveClass']");
        public static By LiveClassHeading => By.XPath("//div[@class='head p-4 text-center']/h1[text()='LIVE CLASS']");
        public static By LiveClassJoinNowBtn => By.XPath("//div[@class='card-footer text-center bg-transparent border-0']//button[text()='Join Now']");
        public static By ClassRoutineBox => By.XPath("//div[@class='card dashboard-routine-item classRoutineBox']");

    }
}
