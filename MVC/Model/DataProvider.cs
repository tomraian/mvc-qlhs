using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace MVC
{
    class DataProvider
    {
        protected static string _connectionString;
        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
        public bool Connect()
        {
            try
            {
                connection = new SqlConnection(_connectionString);
                if(connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public void Disconnect()
        {
            connection.Close();
        }
        public DataTable loadTable(string strStore,string table)
        {
            try
            {
                command = new SqlCommand(strStore, connection);
                command.Parameters.Add("@tenbang", SqlDbType.NVarChar).Value = table;
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public void InsertHS(string strStore, string mahs, string tenhs, string ngaysinh, string diachi, string malop, float dtb)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@mahs", SqlDbType.NChar).Value = mahs;
            command.Parameters.Add("@tenhs", SqlDbType.NVarChar).Value = tenhs;
            command.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = ngaysinh;
            command.Parameters.Add("@diachi", SqlDbType.Text).Value = diachi;
            command.Parameters.Add("@malop", SqlDbType.NChar).Value = malop;
            command.Parameters.Add("@dtb", SqlDbType.Float).Value = dtb;
            command.ExecuteNonQuery();
        }
        public void executeNonQuery(string strStore)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }
        public object executeScalar(string strStore)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteScalar();
        }

    }
}
