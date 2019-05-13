using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Data
{
    public class DoctorContext
    {
        public string ConnectionString { get; set; }

        public DoctorContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
