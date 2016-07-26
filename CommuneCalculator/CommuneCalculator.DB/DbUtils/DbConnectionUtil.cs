using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;

namespace CommuneCalculator.DB.DbUtils
{
    public static class DbConnectionUtil
    {
        private static readonly SqlCeConnectionFactory ConnectionFactory;
        private static readonly SqlConnectionStringBuilder ConnectionStringBuilder;

        public static readonly string CommuneCalculatorDbName = "CommuneCalculator.sdf";

        static DbConnectionUtil()
        {
            var databaseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CommuneCalculator", "Database");
            if (!Directory.Exists(databaseFolderPath))
            {
                Directory.CreateDirectory(databaseFolderPath);
            }
            ConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            ConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = Path.Combine(databaseFolderPath, CommuneCalculatorDbName)
            };
        }

        internal static DbConnection CreateConnection() => ConnectionFactory.CreateConnection(ConnectionStringBuilder.ConnectionString);

        public static string DataSourcePath
        {
            get { return ConnectionStringBuilder.DataSource; }
            set { ConnectionStringBuilder.DataSource = value; }
        }
    }
}