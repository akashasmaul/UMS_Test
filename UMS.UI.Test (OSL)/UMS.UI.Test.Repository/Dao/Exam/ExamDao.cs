using UMS.UI.Test.BusinessModel.Dto.Exam;
using UMS.UI.Test.Repository.Service;

namespace UMS.UI.Test.Repository.Dao.Exam
{
    public static class ExamDao
    {
        private static string sqlQuery = string.Empty;
        private static IList<SQLiteParameter>? parameters;

        private static readonly AdoDotNet adoDotNet;
        static ExamDao()
        {
            adoDotNet = new AdoDotNet();
        }


        public static int SetExamInfo(ExamDto exam)
        {
            parameters = new List<SQLiteParameter>();
            sqlQuery = "SELECT COUNT(*) FROM ExamInfo WHERE ExamName = @ExamName";
            parameters.Add(new SQLiteParameter("ExamName", exam.ExamName));

            var count = adoDotNet.ScalarOperation(sqlQuery, parameters);
            // Decide whether to insert or update
            if ((long)count > 0)
                sqlQuery = @"UPDATE ExamInfo
                            SET 
                                Organization = @Organization, 
                                Program = @Program, 
                                Session = @Session, 
                                Course = @Course, 
                                ExamType = @ExamType, 
                                Version = @Version, 
                                McqFullMarks = @McqFullMarks, 
                                SaqFullMarks = @SaqFullMarks, 
                                ExamPlatform = @ExamPlatform, 
                                IsMarksCalculation = @IsMarksCalculation, 
                                IsWord = @IsWord, 
                                ExamSubjectType = @ExamSubjectType, 
                                McqAnswerOptions = @McqAnswerOptions, 
                                McqSubject = @McqSubject, 
                                SaqSubject = @SaqSubject, 
                                IsClassEvaluation = @IsClassEvaluation, 
                                McqTotalQuestions = @McqTotalQuestions, 
                                SaqTotalQuestions = @SaqTotalQuestions, 
                                McqQuestionsCount = @McqQuestionsCount, 
                                SaqQuestionsCount = @SaqQuestionsCount, 
                                McqUniqueSet = @McqUniqueSet, 
                                SaqUniqueSet = @SaqUniqueSet,
                                IsPrintPdf = @IsPrintPdf,
                                ExamId = @ExamId,
                                ExamName = @ExamName, 
                                ExamCode = @ExamCode, 
                                ExamStartTime = @ExamStartTime, 
                                RoutineId = @RoutineId, 
                                CreationDate = @CreationDate
                            WHERE 
                                ExamName = @ExamName;";
            else
                sqlQuery = @"INSERT INTO ExamInfo (
                                Organization, 
                                Program, 
                                Session, 
                                Course, 
                                ExamType, 
                                Version, 
                                McqFullMarks, 
                                SaqFullMarks, 
                                ExamPlatform, 
                                IsMarksCalculation, 
                                IsWord, 
                                ExamSubjectType, 
                                McqAnswerOptions, 
                                McqSubject, 
                                SaqSubject, 
                                IsClassEvaluation, 
                                McqTotalQuestions, 
                                SaqTotalQuestions, 
                                McqQuestionsCount, 
                                SaqQuestionsCount, 
                                McqUniqueSet, 
                                SaqUniqueSet,
                                IsPrintPdf,
                                ExamId,
                                ExamName, 
                                ExamCode, 
                                ExamStartTime, 
                                RoutineId, 
                                CreationDate) 
                            VALUES(
                                @Organization, 
                                @Program, 
                                @Session, 
                                @Course, 
                                @ExamType, 
                                @Version, 
                                @McqFullMarks, 
                                @SaqFullMarks, 
                                @ExamPlatform, 
                                @IsMarksCalculation, 
                                @IsWord, 
                                @ExamSubjectType, 
                                @McqAnswerOptions, 
                                @McqSubject, 
                                @SaqSubject, 
                                @IsClassEvaluation, 
                                @McqTotalQuestions, 
                                @SaqTotalQuestions, 
                                @McqQuestionsCount, 
                                @SaqQuestionsCount, 
                                @McqUniqueSet, 
                                @SaqUniqueSet,
                                @IsPrintPdf,
                                @ExamId,
                                @ExamName, 
                                @ExamCode, 
                                @ExamStartTime, 
                                @RoutineId, 
                                @CreationDate);";

            exam.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Set parameters for both insert and update
            foreach (var item in exam.GetType().GetProperties())
            {
                parameters.Add(new SQLiteParameter(item.Name, item.GetValue(exam)));
            }
            return adoDotNet.WriteOperation(sqlQuery, parameters);
        }

        public static ExamDto GetExamInfo()
        {
            var exam = new ExamDto();
            parameters = new List<SQLiteParameter>();
            sqlQuery = "SELECT * FROM ExamInfo ORDER BY ROWID DESC LIMIT 1";

            var exams = adoDotNet
                .ReadOperation(sqlQuery, parameters).LastOrDefault();
            if (exams != null)
            {
                foreach (var item in exam.GetType().GetProperties())
                {
                    item.SetValue(exam, exams[item.Name].ToString());
                }
                //exam.Organization = exams["Organization"].ToString()!;
            }
            return exam;
        }

    }
}
