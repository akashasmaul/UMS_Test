namespace UMS.UI.Test.BusinessModel.Enum.Student
{
    public enum Batch : byte
    {
        Type = 1,
        Time = 2,
        Name = 3,
    }

    public enum StudyGroup : byte
    {
        Science = 10,
        Humanities = 20,
        Commerce = 30,
    }

    public enum PaymentType : byte
    {
        NewAdmission,
        OldAdmission,
        Complementary,
        AddCourse,
        AddSubject,
        CancelSubject,
        CancelCourse,
        DuePayment,
        VisitedEntry,
        VisitedAdmission,
        ProgramMigration,
    }
}
