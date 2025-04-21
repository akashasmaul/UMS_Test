namespace UMS.UI.Test.BusinessModel.Enum.Exam
{
    public enum ExamType : byte
    {
        MCQ = 1,
        Written = 2,
        TemplatedWritten = 3,
        OnlineWritten = 4,
    }

    public enum ExamPlatform : byte
    {
        InBranchExam = 1,
        LiveExam = 2,
        PracticeExam = 3,
    }

    public enum SubjectType : byte
    {
        Single = 1,
        Multiple = 2,
        Combined = 3,
    }
}
