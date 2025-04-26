using UMS.UI.Test.BusinessModel.Dto.Exam;

namespace UMS.UI.Test.Repository.Service
{
    public static class ExamUtility
    {
        //private const string basePath = "bin\\Debug\\net8.0";
        //public const string dataFolder = "Data";
        //public const string fileName = "ExamData.txt";
        public const string domainName = "UMS.UI.Test.Repository";

        private static string GetExamDataTextFilePath()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory;
            var rootPath = Directory.GetParent(filePath)!.Parent!.Parent!.Parent!.Parent!.FullName;
            string examDataPath = Path.Combine(rootPath, domainName, "Data\\ExamData.txt");
            //return Path.Combine(filePath, "Data\\ExamData.txt");
            return examDataPath;
        }

        public static void InsertExamInfo(ExamDto examInfo)
        {
            var filePath = GetExamDataTextFilePath();
            if (File.Exists(filePath) == false)
            {
                File.Create(filePath).Close();
            }

            using (var writer = new StreamWriter(filePath, false))
            {
                foreach (var item in examInfo.GetType().GetProperties())
                    writer.WriteLine($"{item.Name}: {item.GetValue(examInfo)}");

                /*
                writer.WriteLine($"Organization: {examInfo.Organization}");
                writer.WriteLine($"Program: {examInfo.Program}");
                writer.WriteLine($"Session: {examInfo.Session}");
                writer.WriteLine($"Course: {examInfo.Course}");
                writer.WriteLine($"ExamType: {examInfo.ExamType}");
                writer.WriteLine($"Version: {examInfo.Version}");
                writer.WriteLine($"McqFullMarks: {examInfo.McqFullMarks}");
                writer.WriteLine($"SaqFullMarks: {examInfo.SaqFullMarks}");
                writer.WriteLine($"ExamPlatform: {examInfo.ExamPlatform}");
                writer.WriteLine($"IsMarksCalculation: {examInfo.IsMarksCalculation}");
                writer.WriteLine($"IsWord: {examInfo.IsWord}");
                writer.WriteLine($"ExamSubjectType: {examInfo.ExamSubjectType}");
                writer.WriteLine($"McqAnswerOptions: {examInfo.McqAnswerOptions}");
                writer.WriteLine($"McqSubject: {examInfo.McqSubject}");
                writer.WriteLine($"SaqSubject: {examInfo.SaqSubject}");
                writer.WriteLine($"IsClassEvaluation: {examInfo.IsClassEvaluation}");
                writer.WriteLine($"McqTotalQuestions: {examInfo.McqTotalQuestions}");
                writer.WriteLine($"SaqTotalQuestions: {examInfo.SaqTotalQuestions}");
                writer.WriteLine($"McqQuestionsCount: {examInfo.McqQuestionsCount}");
                writer.WriteLine($"SaqQuestionsCount: {examInfo.SaqQuestionsCount}");
                writer.WriteLine($"McqUniqueSet: {examInfo.McqUniqueSet}");
                writer.WriteLine($"SaqUniqueSet: {examInfo.SaqUniqueSet}");
                writer.WriteLine($"ExamName: {examInfo.ExamName}");
                writer.WriteLine($"ExamCode: {examInfo.ExamCode}");
                writer.WriteLine($"ExamStartTime: {examInfo.ExamStartTime}");
                writer.WriteLine($"RoutineId: {examInfo.RoutineId}");
                */
            }
            Console.WriteLine("Exam inserted successfully.");
        }

        public static ExamDto GetExamInfo()
        {
            var examInfo = new ExamDto();
            using (var reader = new StreamReader(GetExamDataTextFilePath()))
            {
                foreach (var item in examInfo.GetType().GetProperties())
                {
                    item.SetValue(examInfo, reader.ReadLine()!.Split(": ")[1].Trim());
                    //Convert.ChangeType(reader.ReadLine().Split(':'), i.PropertyType);
                }
                /*
                string line;
                while ((line = reader.ReadLine()!) != null)
                {
                    if (line.StartsWith("Organization:"))
                    {
                        examInfo.Organization = line.Substring("Organization: ".Length);
                    }
                    else if (line.StartsWith("Program:"))
                    {
                        examInfo.Program = line.Substring("Program: ".Length);
                    }
                    else if (line.StartsWith("Session:"))
                    {
                        examInfo.Session = line.Substring("Session: ".Length);
                    }
                    else if (line.StartsWith("Course:"))
                    {
                        examInfo.Course = line.Substring("Course: ".Length);
                    }
                    else if (line.StartsWith("ExamType:"))
                    {
                        examInfo.ExamType = line.Substring("ExamType: ".Length);
                    }
                    else if (line.StartsWith("Version:"))
                    {
                        examInfo.Version = line.Substring("Version: ".Length);
                    }
                    else if (line.StartsWith("McqFullMarks:"))
                    {
                        examInfo.McqFullMarks = line.Substring("McqFullMarks: ".Length);
                    }
                    else if (line.StartsWith("SaqFullMarks:"))
                    {
                        examInfo.SaqFullMarks = line.Substring("SaqFullMarks: ".Length);
                    }
                    else if (line.StartsWith("ExamPlatform:"))
                    {
                        examInfo.ExamPlatform = line.Substring("ExamPlatform: ".Length);
                    }
                    else if (line.StartsWith("IsMarksCalculation:"))
                    {
                        examInfo.IsMarksCalculation = line.Substring("IsMarksCalculation: ".Length);
                    }
                    else if (line.StartsWith("IsWord:"))
                    {
                        examInfo.IsWord = line.Substring("IsWord: ".Length);
                    }
                    else if (line.StartsWith("ExamSubjectType:"))
                    {
                        examInfo.ExamSubjectType = line.Substring("ExamSubjectType: ".Length);
                    }
                    else if (line.StartsWith("McqAnswerOptions:"))
                    {
                        examInfo.McqAnswerOptions = line.Substring("McqAnswerOptions: ".Length);
                    }
                    else if (line.StartsWith("McqSubject:"))
                    {
                        examInfo.McqSubject = line.Substring("McqSubject: ".Length);
                    }
                    else if (line.StartsWith("SaqSubject:"))
                    {
                        examInfo.SaqSubject = line.Substring("SaqSubject: ".Length);
                    }
                    else if (line.StartsWith("IsClassEvaluation:"))
                    {
                        examInfo.IsClassEvaluation = line.Substring("IsClassEvaluation: ".Length);
                    }
                    else if (line.StartsWith("McqTotalQuestions:"))
                    {
                        examInfo.McqTotalQuestions = line.Substring("McqTotalQuestions: ".Length);
                    }
                    else if (line.StartsWith("SaqTotalQuestions:"))
                    {
                        examInfo.SaqTotalQuestions = line.Substring("SaqTotalQuestions: ".Length);
                    }
                    else if (line.StartsWith("McqQuestionsCount:"))
                    {
                        examInfo.McqQuestionsCount = line.Substring("McqQuestionsCount: ".Length);
                    }
                    else if (line.StartsWith("SaqQuestionsCount:"))
                    {
                        examInfo.SaqQuestionsCount = line.Substring("SaqQuestionsCount: ".Length);
                    }
                    else if (line.StartsWith("McqUniqueSet:"))
                    {
                        examInfo.McqUniqueSet = line.Substring("McqUniqueSet: ".Length);
                    }
                    else if (line.StartsWith("SaqUniqueSet:"))
                    {
                        examInfo.SaqUniqueSet = line.Substring("SaqUniqueSet: ".Length);
                    }
                    else if (line.StartsWith("ExamName:"))
                    {
                        examInfo.ExamName = line.Substring("ExamName: ".Length);
                    }
                    else if (line.StartsWith("ExamCode:"))
                    {
                        examInfo.ExamCode = line.Substring("ExamCode: ".Length);
                    }
                    else if (line.StartsWith("ExamStartTime:"))
                    {
                        examInfo.ExamStartTime = line.Substring("ExamStartTime: ".Length);
                    }
                    else if (line.StartsWith("RoutineId:"))
                    {
                        examInfo.RoutineId = line.Substring("RoutineId: ".Length);
                    }
                }
                */
            }
            return examInfo;
        }

        public static void UpdateExamInfo(string property, string uniqueSet)
        {
            string filePath = GetExamDataTextFilePath();
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith($"{property}:"))
                {
                    lines[i] = $"{property}: {uniqueSet}";
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"{property} Update successfully.");
        }

    }

}
