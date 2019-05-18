using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disease.Data
{
    public class DiseaseContext
    {
        public string ConnectionString { get; set; }

        public DiseaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
