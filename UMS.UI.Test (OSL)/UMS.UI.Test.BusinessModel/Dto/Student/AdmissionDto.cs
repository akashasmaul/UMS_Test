namespace UMS.UI.Test.BusinessModel.Dto.Student
{
    public sealed class AdmissionDto
    {
        public string? NickName { get; set; }
        public string? RegisterNo { get; set; }
        public string? RollNumber { get; set; }
        public string? MobileNo { get; set; }
        public string? Organization { get; set; }
        public string? ClassType { get; set; }
        public string? Program { get; set; }
        public string? Session { get; set; }
        public string? Version { get; set; }
        public string? Branch { get; set; }
        public string? Campus { get; set; }
        public string? Is2ndTime { get; set; }
        public string? Course { get; set; }
        public string? TotalCourseFee { get; set; }
        public string? OfferedDiscount { get; set; }
        public string? PrevStdDiscount { get; set; }
        public string? SpecialDiscount { get; set; }
        public string? SpDiscountType { get; set; }
        public string? PayableAmount { get; set; }
        public string? PaidAmount { get; set; }
        public string? DueAmount { get; set; }
        public string? ActionType { get; set; }
        public string? CreationDate { get; set; } //= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
