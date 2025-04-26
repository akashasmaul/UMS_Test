namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.Index
{
    public static class DashboardElement
    {
        //public static By FbGroupPopupClose => By.XPath("//img[@class='cursor-pointer']");
        public static By DashboardPage => By.XPath("//*[contains(@class,'uuu-dashboard')]");
        public static By LiveClass => By.XPath("//a[@href='/Dashboard/LiveClass']");
        public static By LiveExam => By.XPath("//a[@href='/Dashboard/LiveExam']");
        public static By PracticeExam => By.XPath("//section//a[@href='/Routine/PracticeExam']");
        public static By SolveSheet => By.XPath("//section//a[@href='/Routine/QuestionAndSolveSheet']");
        public static By QnAService => By.XPath("//section//a[@href='/QnA/Course']");
        public static By CourseContent => By.XPath("//section//a[@href='/Content/Index?id=2']");
        public static By DiscussionGroup => By.XPath("//section//a[@href='/DiscussionGroup/Index']");

    }
}
