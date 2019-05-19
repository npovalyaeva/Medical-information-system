using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Data
{
    public class FullMedicalRecordContext
    {
        public string ConnectionString { get; set; }

        public FullMedicalRecordContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
