using UMS.UI.Test.BusinessModel.Dto.Student;
using UMS.UI.Test.BusinessModel.Enum;
using UMS.UI.Test.Repository.Service;

namespace UMS.UI.Test.Repository.Dao.Student
{
    public class StudentDao
    {
        private string _sqlQuery = string.Empty;
        private IList<SQLiteParameter>? _parameters;

        private readonly AdoDotNet _adoDotNet;
        public StudentDao()
        {
            _adoDotNet = new AdoDotNet();
        }


        public int SetAdmissionInfo(AdmissionDto admission, QueryType queryType)
        {
            if (QueryType.Insert == queryType)
                _sqlQuery = @"INSERT INTO AdmissionInfo 
                            (
                                NickName, 
                                RegisterNo, 
                                RollNumber, 
                                MobileNo, 
                                Organization, 
                                ClassType, 
                                Program, 
                                Session, 
                                Version, 
                                Branch, 
                                Campus, 
                                Is2ndTime, 
                                Course, 
                                TotalCourseFee, 
                                OfferedDiscount, 
                                PrevStdDiscount, 
                                SpecialDiscount, 
                                SpDiscountType, 
                                PayableAmount, 
                                PaidAmount, 
                                DueAmount, 
                                ActionType, 
                                CreationDate
                            ) 
                            VALUES 
                            (
                                @NickName, 
                                @RegisterNo, 
                                @RollNumber, 
                                @MobileNo, 
                                @Organization, 
                                @ClassType, 
                                @Program, 
                                @Session, 
                                @Version, 
                                @Branch, 
                                @Campus, 
                                @Is2ndTime, 
                                @Course, 
                                @TotalCourseFee, 
                                @OfferedDiscount, 
                                @PrevStdDiscount, 
                                @SpecialDiscount, 
                                @SpDiscountType, 
                                @PayableAmount, 
                                @PaidAmount, 
                                @DueAmount, 
                                @ActionType, 
                                @CreationDate
                            );
                        ";
            else
                _sqlQuery = @"UPDATE AdmissionInfo 
                            SET 
                                RegisterNo = @RegisterNo, 
                                CreationDate = @CreationDate 
                            WHERE 
                                NickName = @NickName";

            _parameters = new List<SQLiteParameter>();
            admission.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            foreach (var item in admission.GetType().GetProperties())
            {
                _parameters.Add(new SQLiteParameter(item.Name, item.GetValue(admission)));
            }
            return _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }

        public AdmissionDto GetAdmissionInfo()
        {
            var admission = new AdmissionDto();
            _parameters = new List<SQLiteParameter>();
            _sqlQuery = "SELECT * FROM AdmissionInfo ORDER BY ROWID DESC LIMIT 1";

            var rows = _adoDotNet
                .ReadOperation(_sqlQuery, _parameters).LastOrDefault();
            if (rows != null && rows.Count > 0)
            {
                foreach (var item in admission.GetType().GetProperties())
                {
                    if (rows[item.Name] != DBNull.Value)
                        item.SetValue(admission, rows[item.Name]);
                }
                //admission.RegisterNo = rows["RegisterNo"].ToString()!;
            }
            return admission;
        }

    }
}
