using UMS.UI.Test.BusinessModel.Dto.Teacher;
using UMS.UI.Test.BusinessModel.Enum;
using UMS.UI.Test.BusinessModel.Enum.Teacher;
using UMS.UI.Test.Repository.Service;

namespace UMS.UI.Test.Repository.Dao.Teacher
{
    public class TeacherDao
    {
        private string _sqlQuery = string.Empty;
        private IList<SQLiteParameter>? _parameters;

        private readonly AdoDotNet _adoDotNet;
        public TeacherDao()
        {
            _adoDotNet = new AdoDotNet();
        }


        #region ClassPayment

        public int SetClassPaymentInfo(ClassPaymentDto dto, QueryType queryType)
        {
            if (QueryType.Insert == queryType)
                _sqlQuery = @"INSERT INTO ClassPayment
                            (
                                Organization, 
                                Program, 
                                Session, 
                                Course, 
                                Branch, 
                                Campus, 
                                ClassType,
                                HeldDate,  
                                TPin, 
                                TotalAmount, 
                                MFSCharge, 
                                GrandTotal, 
                                SheetNo, 
                                VoucherNo, 
                                CreationDate
                            ) 
                            VALUES 
                            (
                                @Organization, 
                                @Program, 
                                @Session, 
                                @Course, 
                                @Branch, 
                                @Campus, 
                                @ClassType,
                                @HeldDate,  
                                @TPin, 
                                @TotalAmount, 
                                @MFSCharge, 
                                @GrandTotal, 
                                @SheetNo, 
                                @VoucherNo, 
                                @CreationDate
                            );
                        ";
            else
                _sqlQuery = @"UPDATE ClassPayment 
                            SET 
                                MFSCharge = @MFSCharge, 
						        GrandTotal = @GrandTotal, 
						        SheetNo = @SheetNo, 
						        VoucherNo = @VoucherNo, 
                                CreationDate = @CreationDate 
                            WHERE 
                                TPin = @TPin
                             AND
                                VoucherNo IS NULL OR ''";

            _parameters = new List<SQLiteParameter>();
            dto.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            foreach (var item in dto.GetType().GetProperties())
            {
                _parameters.Add(new SQLiteParameter(item.Name, item.GetValue(dto)));
            }
            return _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }

        public ClassPaymentDto GetClassPayment()
        {
            var dto = new ClassPaymentDto();
            _parameters = new List<SQLiteParameter>();
            _sqlQuery = "SELECT * FROM ClassPayment ORDER BY ROWID ASC LIMIT 1";

            var rows = _adoDotNet
                .ReadOperation(_sqlQuery, _parameters).LastOrDefault();
            if (rows != null && rows.Count > 0)
            {
                foreach (var item in dto.GetType().GetProperties())
                {
                    if (rows[item.Name] != DBNull.Value)
                        item.SetValue(dto, rows[item.Name]);
                }
                //admission.RegisterNo = rows["RegisterNo"].ToString()!;
            }
            return dto;
        }

        public List<ClassPaymentDto> GetAllClassPaymentsInfo()
        {
            var classPayments = new List<ClassPaymentDto>();
            _parameters = new List<SQLiteParameter>();
            _sqlQuery = "SELECT * FROM ClassPayment ORDER BY ROWID ASC";

            var rowsList = _adoDotNet.ReadOperation(_sqlQuery, _parameters);

            if (rowsList != null && rowsList.Count > 0)
            {
                foreach (var rows in rowsList)
                {
                    var dto = new ClassPaymentDto();
                    foreach (var item in dto.GetType().GetProperties())
                    {
                        if (rows.ContainsKey(item.Name) && rows[item.Name] != DBNull.Value)
                        {
                            item.SetValue(dto, rows[item.Name]);
                        }
                    }
                    classPayments.Add(dto);
                }
            }

            return classPayments;
        }

        public decimal GetTotalAmountByTPin(string tpin)
        {
            decimal totalAmount = 0;
            _parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@TPin", tpin)
            };
            _sqlQuery = "SELECT SUM(TotalAmount) FROM ClassPayment WHERE TPin = @TPin";

            var result = _adoDotNet.ScalarOperation(_sqlQuery, _parameters);

            if (result != DBNull.Value && result != null)
            {
                totalAmount = Convert.ToDecimal(result);
            }

            return totalAmount;
        }

        public decimal GetTotalAmountByTPinAndBranch(string tpin, string branch)
        {
            decimal totalAmount = 0;
            _parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@TPin", tpin),
                new SQLiteParameter("@Branch", branch)
            };
            _sqlQuery = "SELECT SUM(TotalAmount) FROM ClassPayment WHERE TPin = @TPin AND Branch = @Branch";

            var result = _adoDotNet.ScalarOperation(_sqlQuery, _parameters);

            if (result != DBNull.Value && result != null)
            {
                totalAmount = Convert.ToDecimal(result);
            }

            return totalAmount;
        }


        public void DeleteAllClassPayments()
        {
            _sqlQuery = "DELETE FROM ClassPayment";
            _parameters = new List<SQLiteParameter>();

            _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }

        public void DeleteClassPaymentsByTPin(string tpin)
        {
            _sqlQuery = "DELETE FROM ClassPayment WHERE TPin = @TPin";
            _parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@TPin", tpin)
            };

            _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }

        public List<ClassPaymentDto> GetDataByTPin(string tpin, string branch)
        {
            List<ClassPaymentDto> dataList = new List<ClassPaymentDto>();

            _parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@TPin", tpin),
                new SQLiteParameter("@Branch", branch)
            };

            _sqlQuery = "SELECT * FROM ClassPayment WHERE TPin = @TPin AND Branch = @Branch";

            var rows = _adoDotNet.ReadOperation(_sqlQuery, _parameters);

            foreach (var row in rows)
            {
                var data = new ClassPaymentDto();
                foreach (var property in data.GetType().GetProperties())
                {
                    if (row.ContainsKey(property.Name) && row[property.Name] != DBNull.Value)
                    {
                        property.SetValue(data, row[property.Name]);
                    }
                }
                dataList.Add(data);
            }

            return dataList;
        }

        public List<int> GetUniqueTPins()
        {
            List<int> tpinList = new List<int>();

            _sqlQuery = "SELECT DISTINCT TPin, Branch FROM ClassPayment";

            var rows = _adoDotNet.ReadOperation(_sqlQuery, new List<SQLiteParameter>());

            foreach (var row in rows)
            {
                if (row["TPin"] != DBNull.Value)
                {
                    tpinList.Add(Convert.ToInt32(row["TPin"]));
                }
            }

            return tpinList;
        }

        public List<(int TPin, string Branch)> GetUniqueTPinsPerBranch()
        {
            List<(int, string)> tpinList = new List<(int, string)>();

            _sqlQuery = "SELECT DISTINCT TPin, Branch FROM ClassPayment";

            var rows = _adoDotNet.ReadOperation(_sqlQuery, new List<SQLiteParameter>());

            foreach (var row in rows)
            {
                if (row["TPin"] != DBNull.Value && row["Branch"] != DBNull.Value)
                {
                    int tpin = Convert.ToInt32(row["TPin"]);
                    string branch = row["Branch"].ToString()!;
                    tpinList.Add((tpin, branch));
                }
            }

            return tpinList;
        }

        #endregion


        #region MaterialsPayment

        public int SetMaterialsInfo(MaterialsPaymentDto dto, QueryType queryType)
        {
            if (QueryType.Insert == queryType)
                _sqlQuery = @"INSERT INTO MaterialsPayment
                            (
                                Organization, 
                                Program, 
                                Session, 
                                EntryDate, 
                                TPIN, 
                                ForBranch, 
                                MaterialType,
                                Amount,  
                                EntryCount,
                                TotalAmount, 
                                MFSCharge, 
                                GrandTotal, 
                                SheetNo, 
                                VoucherNo, 
                                Status, 
                                CreationDate
                            ) 
                            VALUES 
                            (
                                @Organization, 
						        @Program, 
						        @Session, 
						        @EntryDate, 
						        @TPIN, 
						        @ForBranch, 
						        @MaterialType, 
						        @Amount, 
						        @EntryCount, 
						        @TotalAmount, 
						        @MFSCharge, 
						        @GrandTotal, 
						        @SheetNo, 
						        @VoucherNo, 
						        @Status, 
						        @CreationDate
                            );
                        ";
            else if (QueryType.Update == queryType)
                _sqlQuery = @"UPDATE MaterialsPayment 
                            SET
                                MaterialType = @MaterialType,
                                Amount = @Amount,
						        TotalAmount = @TotalAmount, 
						        MFSCharge = @MFSCharge, 
						        GrandTotal = @GrandTotal, 
						        SheetNo = @SheetNo, 
						        VoucherNo = @VoucherNo, 
                                Status = @Status, 
                                CreationDate = @CreationDate 
                            WHERE 
                                --TPIN = @TPIN
                            --AND
                                --Status = 'Pending'
                            --AND
                                Id = @Id";

            _parameters = new List<SQLiteParameter>();
            dto.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            foreach (var item in dto.GetType().GetProperties())
            {
                _parameters.Add(new SQLiteParameter(item.Name, item.GetValue(dto)));
            }
            return _adoDotNet.WriteOperation(_sqlQuery, _parameters);
        }

        public MaterialsPaymentDto GetMaterialsInfo(EntryStatus entrytStatus)
        {
            var dto = new MaterialsPaymentDto();
            _parameters = new List<SQLiteParameter>();
            _sqlQuery = @$"SELECT * FROM 
                                MaterialsPayment 
                            WHERE 
                                Status = '{entrytStatus}' ORDER BY ID DESC LIMIT 1";

            var rows = _adoDotNet
                .ReadOperation(_sqlQuery, _parameters).LastOrDefault();
            if (rows != null && rows.Count > 0)
            {
                foreach (var item in dto.GetType().GetProperties())
                {
                    if (rows[item.Name] != DBNull.Value)
                        item.SetValue(dto, rows[item.Name]);
                }
                //admission.RegisterNo = rows["RegisterNo"].ToString()!;
            }
            return dto;
        }

        public IList<MaterialsPaymentDto> GetMaterialsInfos(EntryStatus entrytStatus)
        {
            _parameters = new List<SQLiteParameter>();
            var dtos = new List<MaterialsPaymentDto>();

            _sqlQuery = @$"SELECT * FROM 
                                MaterialsPayment 
                            WHERE 
                                Status = '{entrytStatus}'";

            var rows = _adoDotNet.ReadOperation(_sqlQuery, _parameters);
            if (rows != null && rows.Count > 0)
            {
                foreach (var row in rows)
                {
                    var dto = new MaterialsPaymentDto();
                    foreach (var item in dto.GetType().GetProperties())
                    {
                        if (row[item.Name] != DBNull.Value)
                            item.SetValue(dto, row[item.Name]);
                    }
                    dtos.Add(dto);
                }
                //admission.RegisterNo = rows["RegisterNo"].ToString()!;
            }
            return dtos;
        }

        #endregion


        #region QnA2Payment
        #endregion

    }
}
