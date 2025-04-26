namespace UMS.UI.Test.ERP.Areas.Exam
{
    public static class ExamCommonElement
    {
        // Area
        public static By ExamArea => By.XPath("//*[@href='/Exam']");
        // public static By ExamArea => By.XPath("//a[normalize-space()='Exam']");

        // Exam Area Menu
        public static By ExamAndAnswerMenuGroup => By.XPath("//*[@href='#collapse_102']");


    }
}
