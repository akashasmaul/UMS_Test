namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveExam.Elements
{
    public static class OnlineWrittenElement
    {
        public static By LiveExamSection => By.XPath("//h3[normalize-space()='Live Exam']");
        public static By LiveExamName => By.XPath("//*[@data-routineid='60462']//h2[contains(text(),'Live Single Online Wr_04102340-')]");
        public static By TakeExamBtn => By.XPath("//*[@data-routineid='60462']//a[contains(@href,'routineId=60462')]");
        public static By Version => By.XPath("//select[@id='examVersion']");
        public static By WrittenBtn => By.XPath("//button[@name='writtenBtn']");
        public static By ExamName => By.XPath("//*[@id='TakeExamHeader']//h2");
        public static By QuestionSerial => By.XPath("//*[@class='serial']//span[normalize-space()='Question 1']");
        public static By UploadAnswerImage => By.XPath("//input[@id='uploadAnswer_1']");
        public static By UploadCompleteProgress => By.XPath("//div[@role='progressbar' and normalize-space()='Upload Complete']");
        public static By ExamSubmissionBtn => By.XPath("//button[@id='examSubmission']");
        public static By YesBtn => By.XPath("//button[normalize-space()='Yes']");
        public static By NoBtn => By.XPath("//button[normalize-space()='No']");
    }
}
