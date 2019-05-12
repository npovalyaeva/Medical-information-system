using MySql.Data.MySqlClient;

namespace Specialist.Data
{
    public class SpecialistContext
    {
        public string ConnectionString { get; set; }

        public SpecialistContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
