using UMS.UI.Test.BusinessModel.Dto.StudentPortal;
using UMS.UI.Test.BusinessModel.Enum;
using UMS.UI.Test.Repository.Service;

namespace UMS.UI.Test.Repository.Dao.StudentPortal
{
    public class StudentPortalDao
    {
        private string _sqlQuery = string.Empty;
        private IList<SQLiteParameter>? _parameters;

        private readonly AdoDotNet _adoDotNet;
        public StudentPortalDao()
        {
            _adoDotNet = new AdoDotNet();
        }


        #region Registration

        public int SetRegistrationInfo(RegistrationDto dto, QueryType queryType)
        {
            if (QueryType.Insert == queryType)
                _sqlQuery = @"INSERT INTO Registration
                            (
                                NickName, 
                                Mobile, 
                                RegNumber, 
                                Password, 
                                BaseUrl, 
                                CreationDate
                            ) 
                            VALUES 
                            (
                                @NickName, 
                                @Mobile, 
                                @RegNumber, 
                                @Password, 
                                @BaseUrl, 
                                @CreationDate
                            );
                        ";
            else
                _sqlQuery = @"UPDATE ClassPayment 
                            SET 
                                NickName = @NickName, 
						        Mobile = @Mobile, 
						        RegNumber = @RegNumber, 
						        Password = @Password, 
                                CreationDate = @CreationDate 
                            WHERE 
                                BaseUrl = @BaseUrl";

            _parameters = new List<SQLiteParameter>();
            dto.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            foreach (var item in dto.GetType().GetProperties())
            {
                _parameters.Add(new SQLiteParameter(item.Name, item.GetValue(dto)));
            }
            return _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }

        public RegistrationDto GetRegistration()
        {
            var dto = new RegistrationDto();
            _parameters = new List<SQLiteParameter>();
            _sqlQuery = "SELECT * FROM Registration ORDER BY ROWID DESC LIMIT 1";
            //_sqlQuery = "SELECT NickName, Mobile, RegNumber, BaseUrl FROM Registration ORDER BY ROWID DESC LIMIT 1";

            var rows = _adoDotNet
                .ReadOperation(_sqlQuery, _parameters).LastOrDefault();
            if (rows != null && rows.Count > 0)
            {
                foreach (var item in dto.GetType().GetProperties())
                {
                    if (rows[item.Name] != DBNull.Value)
                        item.SetValue(dto, rows[item.Name]);
                }
            }
            return dto;
        }

        public void DeleteAllRegistrations()
        {
            _sqlQuery = "DELETE FROM Registration";
            _parameters = new List<SQLiteParameter>();

            _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }

        public void DeleteRegistrationByReg(string reg)
        {
            _sqlQuery = "DELETE FROM Registration WHERE RegNumber = @RegNumber";
            _parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@RegNumber", reg)
            };

            _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }



        #endregion

        #region Enrolment



        #endregion
    }
}
