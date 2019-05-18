using MySql.Data.MySqlClient;
using Specialist.Data;
using Specialist.Commands;
using Mapster;

namespace Specialist.Handlers
{
    public class UpdateSpecialistEmailHandler
    {
        private readonly SpecialistContext _context;

        public UpdateSpecialistEmailHandler(SpecialistContext context)
        {
            _context = context;
        }

        public bool Handle(int id, string email)
        {

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE specialists SET email = '{0}' WHERE specialist_id = '{1}'", email, id), conn);

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



