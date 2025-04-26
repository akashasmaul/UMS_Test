using OfficeOpenXml;

namespace UMS.UI.Test.BusinessModel.Helper
{
    public static class ExcelHelper
    {
        private static readonly string filePath = AppHelper.GetFilePath("TestData\\Exam\\Excel", "LatexQuestion.xlsx");
        private static readonly string sheetNameMcq = "mcq";
        private static readonly string mcqWithVersionSheet = "McqWithVersion";
        private static readonly string sheetNameOw = "ow";
        private static readonly string owWithVersionSheet = "OwWithVersion";
        private static readonly string sheetNameUddipok = "uddipok";

        public static List<McqQuestion> GetMcqQuestion(string subject = "0")
        {
            List<McqQuestion> dataList = new List<McqQuestion>();

            FileInfo fileInfo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetNameMcq];

                if (worksheet == null)
                {
                    Console.WriteLine($"Sheet '{sheetNameMcq}' not found.");
                    return dataList;
                }

                int rowCount = worksheet.Dimension.Rows;
                int columnCount = worksheet.Dimension.Columns;


                // Assuming your class has properties as per the Excel headers
                Dictionary<string, int> headerDictionary = new Dictionary<string, int>();
                for (int col = 1; col <= columnCount; col++)
                {
                    string header = worksheet.Cells[1, col].Value?.ToString()!.Trim()!;
                    if (!string.IsNullOrEmpty(header))
                        headerDictionary[header] = col;
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    McqQuestion data = new McqQuestion();

                    foreach (var property in typeof(McqQuestion).GetProperties())
                    {
                        string propertyName = property.Name;
                        if (headerDictionary.ContainsKey(propertyName))
                        {
                            int col = headerDictionary[propertyName];
                            string cellValue = worksheet.Cells[row, col].Value?.ToString()!;
                            property.SetValue(data, cellValue);
                        }
                    }

                    if (data.Subject == subject)
                    {
                        dataList.Add(data);
                    }
                    else if (subject == "0")
                    {
                        dataList.Add(data);
                    }
                }
            }

            return dataList;
        }

        public static List<OnlineWrittenQuestion> GetOnlineWrittenQuestion(string subject = "0")
        {
            List<OnlineWrittenQuestion> dataList = new List<OnlineWrittenQuestion>();

            FileInfo fileInfo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetNameOw];

                if (worksheet == null)
                {
                    Console.WriteLine($"Sheet '{sheetNameOw}' not found.");
                    return dataList;
                }

                int rowCount = worksheet.Dimension.Rows;
                int columnCount = worksheet.Dimension.Columns;


                // Assuming your class has properties as per the Excel headers
                Dictionary<string, int> headerDictionary = new Dictionary<string, int>();
                for (int col = 1; col <= columnCount; col++)
                {
                    string header = worksheet.Cells[1, col].Value?.ToString()!.Trim()!;
                    if (!string.IsNullOrEmpty(header))
                        headerDictionary[header] = col;
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    OnlineWrittenQuestion data = new OnlineWrittenQuestion();

                    foreach (var property in typeof(OnlineWrittenQuestion).GetProperties())
                    {
                        string propertyName = property.Name;
                        if (headerDictionary.ContainsKey(propertyName))
                        {
                            int col = headerDictionary[propertyName];
                            string cellValue = worksheet.Cells[row, col].Value?.ToString()!;
                            property.SetValue(data, cellValue);
                        }
                    }

                    if (data.Subject == subject)
                    {
                        dataList.Add(data);
                    }
                    else if (subject == "0")
                    {
                        dataList.Add(data);
                    }
                }
            }

            return dataList;
        }

        public static List<Uddipok> GetUddipok()
        {
            var fileInfo = new FileInfo(filePath);
            var uddipokList = new List<Uddipok>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetNameUddipok];

                if (worksheet == null)
                {
                    Console.WriteLine($"Sheet '{sheetNameUddipok}' not found.");
                    return uddipokList;
                }

                int rowCount = worksheet.Dimension.Rows;
                int columnCount = worksheet.Dimension.Columns;


                // Assuming your class has properties as per the Excel headers
                var headerDictionary = new Dictionary<string, int>();
                for (int col = 1; col <= columnCount; col++)
                {
                    string header = worksheet.Cells[1, col].Value?.ToString()!.Trim()!;
                    if (!string.IsNullOrEmpty(header))
                        headerDictionary[header] = col;
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    var uddipok = new Uddipok();
                    foreach (var property in typeof(Uddipok).GetProperties())
                    {
                        string propertyName = property.Name;
                        if (headerDictionary.ContainsKey(propertyName))
                        {
                            int col = headerDictionary[propertyName];
                            string cellValue = worksheet.Cells[row, col].Value?.ToString()!;
                            property.SetValue(uddipok, cellValue);
                        }
                    }

                    uddipokList.Add(uddipok);
                }
            }

            return uddipokList;
        }

        public static List<McqQuestionByVersion> GetMcqQuestionByVersion(string subject = "0", string version = "0")
        {
            var fileInfo = new FileInfo(filePath);
            var mcqQuestions = new List<McqQuestionByVersion>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[mcqWithVersionSheet];

                if (worksheet == null)
                {
                    Console.WriteLine($"Sheet '{sheetNameMcq}' not found.");
                    return mcqQuestions;
                }

                int rowCount = worksheet.Dimension.Rows;
                int columnCount = worksheet.Dimension.Columns;


                // Assuming your class has properties as per the Excel headers
                var headerDictionary = new Dictionary<string, int>();
                for (int col = 1; col <= columnCount; col++)
                {
                    string header = worksheet.Cells[1, col].Value?.ToString()!.Trim()!;
                    if (!string.IsNullOrEmpty(header))
                        headerDictionary[header] = col;
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    var mcqQuestion = new McqQuestionByVersion();
                    foreach (var property in typeof(McqQuestionByVersion).GetProperties())
                    {
                        string propertyName = property.Name;
                        if (headerDictionary.ContainsKey(propertyName))
                        {
                            int col = headerDictionary[propertyName];
                            string cellValue = worksheet.Cells[row, col].Value?.ToString()!;
                            property.SetValue(mcqQuestion, cellValue);
                        }
                    }

                    if (mcqQuestion.Subject == subject && mcqQuestion.Version == version)
                    {
                        mcqQuestions.Add(mcqQuestion);
                    }
                    else if (mcqQuestion.Subject == subject && version == "0")
                    {
                        mcqQuestions.Add(mcqQuestion);
                    }
                    else if (subject == "0" && mcqQuestion.Version == version)
                    {
                        mcqQuestions.Add(mcqQuestion);
                    }
                    else if (subject == "0" && version == "0")
                    {
                        mcqQuestions.Add(mcqQuestion);
                    }
                }
            }

            return mcqQuestions;
        }

        public static List<OwQuestionByVersion> GetOwQuestionByVersion(string subject = "0", string version = "0")
        {
            var fileInfo = new FileInfo(filePath);
            var owQuestions = new List<OwQuestionByVersion>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[owWithVersionSheet];

                if (worksheet == null)
                {
                    Console.WriteLine($"Sheet '{sheetNameMcq}' not found.");
                    return owQuestions;
                }

                int rowCount = worksheet.Dimension.Rows;
                int columnCount = worksheet.Dimension.Columns;


                // Assuming your class has properties as per the Excel headers
                Dictionary<string, int> headerDictionary = new Dictionary<string, int>();
                for (int col = 1; col <= columnCount; col++)
                {
                    string header = worksheet.Cells[1, col].Value?.ToString()!.Trim()!;
                    if (!string.IsNullOrEmpty(header))
                        headerDictionary[header] = col;
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    var owQuestion = new OwQuestionByVersion();
                    foreach (var property in typeof(OwQuestionByVersion).GetProperties())
                    {
                        string propertyName = property.Name;
                        if (headerDictionary.ContainsKey(propertyName))
                        {
                            int col = headerDictionary[propertyName];
                            string cellValue = worksheet.Cells[row, col].Value?.ToString()!;
                            property.SetValue(owQuestion, cellValue);
                        }
                    }

                    if (owQuestion.Subject == subject && owQuestion.Version == version)
                    {
                        owQuestions.Add(owQuestion);
                    }
                    else if (owQuestion.Subject == subject && version == "0")
                    {
                        owQuestions.Add(owQuestion);
                    }
                    else if (subject == "0" && owQuestion.Version == version)
                    {
                        owQuestions.Add(owQuestion);
                    }
                    else if (subject == "0" && version == "0")
                    {
                        owQuestions.Add(owQuestion);
                    }
                }
            }

            return owQuestions;
        }
    }

    public class McqQuestion
    {
        public string? Subject { get; set; }
        public string? Version { get; set; }
        public string? BanglaQuestion { get; set; }
        public string? EnglishQuestion { get; set; }
        public string? BOptionA { get; set; }
        public string? EOptionA { get; set; }
        public string? BOptionB { get; set; }
        public string? EOptionB { get; set; }
        public string? BOptionC { get; set; }
        public string? EOptionC { get; set; }
        public string? BOptionD { get; set; }
        public string? EOptionD { get; set; }
        public string? BOptionE { get; set; }
        public string? EOptionE { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? IsShuffle { get; set; }
        public string? IsShowOption { get; set; }
        public string? BanglaSolve { get; set; }
        public string? EnglishSolve { get; set; }
    }

    public class OnlineWrittenQuestion
    {
        public string? Subject { get; set; }
        public string? Version { get; set; }
        public string? BanglaQuestion { get; set; }
        public string? EnglishQuestion { get; set; }
        public string? BanglaSampleAnswer { get; set; }
        public string? EnglishSampleAnswer { get; set; }
        public string? Marks { get; set; }
    }

    public class Uddipok
    {
        public string? UddipokBn { get; set; }
        public string? UddipokEn { get; set; }
    }

    public class McqQuestionByVersion
    {
        public string? UniqueSet { get; set; }
        public string? Subject { get; set; }
        public string? Version { get; set; }
        public string? Question { get; set; }
        public string? OptionA { get; set; }
        public string? OptionB { get; set; }
        public string? OptionC { get; set; }
        public string? OptionD { get; set; }
        public string? OptionE { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? IsShuffle { get; set; }
        public string? IsShowOption { get; set; }
        public string? Solve { get; set; }
    }

    public class OwQuestionByVersion
    {
        public string? UniqueSet { get; set; }
        public string? Subject { get; set; }
        public string? Version { get; set; }
        public string? Question { get; set; }
        public string? SampleAnswer { get; set; }
        public string? Marks { get; set; }
    }
}
