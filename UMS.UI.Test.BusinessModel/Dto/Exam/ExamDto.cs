namespace UMS.UI.Test.BusinessModel.Dto.Exam
{
    public sealed class ExamDto
    {
        /*
        public string? UniqueSet { get; set; }
        public string? ImportWordQuestion { get; set; }
        public string? SetGenerate { get; set; }
        public string? OnlineExamPermission { get; set; }
        public string? ExaminerPermission { get; set; }
        public string? PrintPermission { get; set; }
        public string? QuestionViewPermission { get; set; }
        */
        public string? Organization { get; set; }
        public string? Program { get; set; }
        public string? Session { get; set; }
        public string? Course { get; set; }
        public string? ExamType { get; set; }
        public string? Version { get; set; }
        public string? McqFullMarks { get; set; }
        public string? SaqFullMarks { get; set; }
        public string? ExamPlatform { get; set; }
        public string? IsMarksCalculation { get; set; }
        public string? IsWord { get; set; }
        public string? ExamSubjectType { get; set; }
        public string? McqAnswerOptions { get; set; }
        public string? McqSubject { get; set; }
        public string? SaqSubject { get; set; }
        public string? IsClassEvaluation { get; set; }
        public string? McqTotalQuestions { get; set; }
        public string? SaqTotalQuestions { get; set; }
        public string? McqQuestionsCount { get; set; }
        public string? SaqQuestionsCount { get; set; }
        public string? McqUniqueSet { get; set; }
        public string? SaqUniqueSet { get; set; }
        public string? IsPrintPdf { get; set; } //isPrintFromUploadedPdf
        public string? ExamId { get; set; }
        public string? ExamName { get; set; }
        public string? ExamCode { get; set; }
        public string? ExamStartTime { get; set; }
        public string? RoutineId { get; set; }
        public string? CreationDate { get; set; }// = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
