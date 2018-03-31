using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Factory
{
    public class Connection
    {
        private SqlConnection _Conn;
        private SqlCommand _Command;
        private string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnDB"].ToString();

        public Connection()
        {
            _Conn = new SqlConnection(_ConnectionString);
        }

        public void OpenConnection()
        {
            if (_Conn.State == ConnectionState.Broken)
            {
                _Conn.Close();
                _Conn.Open();
            }
            else
            {
                _Conn.Open();
            }
        }

        public void InsertCommand(string command, CommandType type)
        {
            _Command = new SqlCommand()
            {
                Connection = _Conn,
                CommandText = command,
                CommandType = type
            };
        }

        public void ExculteNonQuery()
        {
            _Command.ExecuteNonQuery();
        }

        public SqlDataReader ExeculteReader()
        {
            return _Command.ExecuteReader();
        }
        public void CloseConnection()
        {
            if (_Conn.State == ConnectionState.Open)
                _Conn.Close();        
        }
    }
}
