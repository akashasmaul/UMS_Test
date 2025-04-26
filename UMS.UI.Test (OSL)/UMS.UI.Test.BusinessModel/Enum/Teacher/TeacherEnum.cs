namespace UMS.UI.Test.BusinessModel.Enum.Teacher
{
    public enum EntryStatus : byte
    {
        Pending,
        Update,
        Delete,
        Approved,
        Cancelled
    }
    public enum PaymentStatus : byte
    {
        CashPayment,
        CashPreparation,
        CashFinalize,
        MFSPreparation,
        MFSFinalize,
    }
}
