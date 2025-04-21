using System.Data;
using System.Data.SQLite;

namespace UMS.UI.Test.Repository.Service
{
    public class AdoDotNet
    {
        public const string baseFolder = "bin\\Debug\\net8.0";
        public const string dataFolder = "Data";
        public const string dbFileName = "UmsTestDB.db";
        public const string domainName = "UMS.UI.Test.Repository";

        private readonly string? connectionString;
        private readonly SQLiteConnection sqlConnection;

        public AdoDotNet()
        {
            connectionString = GetConnectionString(AppContext.BaseDirectory);
            sqlConnection = new SQLiteConnection(connectionString);
        }

        public static string GetConnectionString(string dbFilePath)
        {
            dbFilePath = Path.GetFullPath(Path.Combine(dbFilePath, @"../../../../"));
            dbFilePath = Path.Combine(dbFilePath, $"{domainName}\\bin\\{dataFolder}\\{dbFileName}");
            return $"Data Source={dbFilePath};Version=3;";
        }

        private SQLiteCommand CommandExecute(string sqlQuery, IList<SQLiteParameter> parameters)
        {
            SQLiteCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = sqlQuery;

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddRange(parameters.ToArray());
            return sqlCommand;
        }

        public object ScalarOperation(string sqlQuery, IList<SQLiteParameter> parameters)
        {
            using var sqlCommand = CommandExecute(sqlQuery, parameters);
            return sqlCommand.ExecuteScalar();
        }

        public int WriteOperation(string sqlQuery, IList<SQLiteParameter> parameters)
        {
            using var sqlCommand = CommandExecute(sqlQuery, parameters);
            return sqlCommand.ExecuteNonQuery();
        }

        public IList<Dictionary<string, object>> ReadOperation(string sqlQuery, IList<SQLiteParameter> parameters)
        {
            var queryResults = new List<Dictionary<string, object>>();
            //using var sqlCommand = CommandExecute(sqlQuery, parameters);
            //using var sqlDataReader = sqlCommand.ExecuteReader();
            using var sqlDataReader = CommandExecute(sqlQuery, parameters).ExecuteReader();

            while (sqlDataReader.Read())
            {
                var rowColumns = new Dictionary<string, object>();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    rowColumns.Add(sqlDataReader.GetName(i), sqlDataReader.GetValue(i));

                queryResults.Add(rowColumns);
            }
            //sqlConnection.Close();
            return queryResults;
        }

    }
}
