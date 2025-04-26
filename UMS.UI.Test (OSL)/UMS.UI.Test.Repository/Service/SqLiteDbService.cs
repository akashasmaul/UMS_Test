namespace UMS.UI.Test.Repository.Service
{
    public class SqLiteDbService : AdoDotNet
    {
        //private const string _folderName = "Data";
        //private const string _dbFileName = "UmsTestDB.db";
        //private const string _domainName = "UMS.UI.Test.Repository";

        private static string GetCurrentDomainName(string domainPath)
        {
            if (domainPath is null)
            {
                throw new ArgumentNullException(nameof(domainPath));
            }

            var domainNames = new[] { "ERP", "OnlinePortal" };
            return domainNames.Single(d => domainPath.Contains(d));
        }

        private static string GetSourseDbPath()
        {
            var sourcePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../"));
            return Path.Combine(sourcePath!, $"{domainName}/{dataFolder}/{dbFileName}");
        }

        private static string GetTargetDbPath()
        {
            var targetPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../"));
            return Path.Combine(targetPath, $"{domainName}/bin/{dataFolder}/{dbFileName}");
        }

        public static void SqLiteSchemaDbVerify()
        {
            var sourceFile = GetSourseDbPath();
            var targetFile = GetTargetDbPath();
            var dataFolder = Path.Combine(targetFile.Split(AdoDotNet.dataFolder)[0], AdoDotNet.dataFolder);

            if (Directory.Exists(dataFolder) == false)
            {
                Directory.CreateDirectory(dataFolder);
            }

            if (File.Exists(targetFile) == false)
            {
                File.Copy(sourceFile, targetFile);
            }
            else
            {
                var sourceVersion = Convert.ToDateTime(File.GetLastWriteTime(sourceFile));
                var targetVersion = Convert.ToDateTime(File.GetLastWriteTime(targetFile));

                var sourseUserVersion = Convert.ToInt64(GetSqLiteDbVersion(sourceFile));
                var targetUserVersion = Convert.ToInt64(GetSqLiteDbVersion(targetFile));

                if (sourceVersion > targetVersion || sourseUserVersion > targetUserVersion)
                {
                    File.Copy(sourceFile, targetFile, true);
                }
            }
        }

        private static object GetSqLiteDbVersion(string dbPath)
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            var connection = new SQLiteConnection(connectionString);

            var query = "PRAGMA user_version";
            using var command = new SQLiteCommand(query, connection);
            connection.Open();
            return command.ExecuteScalar();
        }

    }
}
