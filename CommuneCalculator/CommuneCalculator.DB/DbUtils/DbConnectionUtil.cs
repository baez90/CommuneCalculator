using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;

namespace CommuneCalculator.DB.DbUtils
{
    internal static class DbConnectionUtil
    {
        private static readonly SqlCeConnectionFactory ConnectionFactory;
        private static readonly string ConnectionString;

        static DbConnectionUtil()
        {
            var databaseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WGRechner", "Database");
            if (!Directory.Exists(databaseFolderPath))
            {
                Directory.CreateDirectory(databaseFolderPath);
            }
            ConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            var conStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = Path.Combine(databaseFolderPath, "WGRechner.sdf")
            };
            ConnectionString = conStringBuilder.ConnectionString;
        }

        internal static DbConnection CreateConnection() => ConnectionFactory.CreateConnection(ConnectionString);
    }
}