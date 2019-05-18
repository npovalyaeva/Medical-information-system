using MySql.Data.MySqlClient;
using Specialist.Data;
using Specialist.Commands;
using Mapster;

namespace Specialist.Handlers
{
    public class UpdateSpecialistPasswordHandler
    {
        private readonly SpecialistContext _context;

        public UpdateSpecialistPasswordHandler(SpecialistContext context)
        {
            _context = context;
        }

        public bool Handle(int id, string password)
        {
            string passwordHash = Hash.FindHash(password);
            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE specialists SET password_hash = '{0}' WHERE specialist_id = '{1}'", 
                    passwordHash, id), conn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.CloseAsync();
                }
            }

            return true;
        }
    }
}



