using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace pacs_common
{
    public class SqlHelper
    {
        private static string connString = null;

        public static void SetConnectionString(string name)
        {
            connString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static DataTable Query(string sql, OracleParameter[] pars)
        {
            OracleConnection conn = new OracleConnection(connString);

            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Parameters.AddRange(pars);
            DataTable dataTable = new DataTable();
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            conn.Close();
            return dataTable;
        }

        public static int Execute(string sql, OracleParameter[] pars)
        {
            int result = 0;
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Parameters.AddRange(pars);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
