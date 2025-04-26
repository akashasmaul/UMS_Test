namespace UMS.UI.Test.OnlinePortal.Areas.Student.Dashboard.LiveExam.Elements
{
    public static class McqLiveExamElement
    {
        public static By LiveExamPage => By.XPath("//a[@href='/Dashboard/LiveExam']");
        public static By StudyVersion => By.XPath("//select[@id='examVersion']");
        public static By ExamStartButton => By.XPath("//button[@name='mcqBtn']");
        public static By ExamRoutineId => By.XPath("//input[@name='routineId']");
        public static By ExamStartPage => By.XPath("//div[@class='TakeExamWrapper']");
        public static By StartExamHeader => By.XPath("//div[@id='TakeExamHeader']");
        public static By StartExamCountDown => By.XPath("//div[@id='slickyElement']");
        public static By McqQuestion => By.XPath("//div[@class='row questionBlock']");
        public static By UddipokQuestion => By.XPath("//div[contains(@class,'uddipokText')]");
        public static By MCQSolveAnswers => By.XPath("//div[contains(@class,'solveText')]");
        public static By ExamSubmitButton => By.XPath("//button[@id='examSubmission']");
        public static By ModalYesButton => By.XPath("//button[normalize-space()='Yes']");
        public static By SubmitModalNoBtn => By.XPath("//button[normalize-space()='No']");
        public static By ExamSubmitSuccess => By.XPath("//*[@class='alert alert-success']");

        //div[@class='row question']
        //div[contains(@class,'questionOption')]
        //input[@name='StudentAnswer']

    }
}
