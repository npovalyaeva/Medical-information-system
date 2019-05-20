using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specialist.Data
{
    public class SpecialistNameContext
    {
        public string ConnectionString { get; set; }

        public SpecialistNameContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
