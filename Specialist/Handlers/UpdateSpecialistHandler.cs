using MySql.Data.MySqlClient;
using Specialist.Data;
using Specialist.Commands;
using Mapster;

namespace Specialist.Handlers
{
    public class UpdateSpecialistHandler
    {
        private readonly SpecialistContext _context;

        public UpdateSpecialistHandler(SpecialistContext context)
        {
            _context = context;
        }

        public bool Handle(int specialistId, CreateSpecialistCommand request)
        {
            var model = request.Adapt<Model.Specialist>();
            string tempHash = Hash.FindHash(model.PasswordHash);
            model.PasswordHash = tempHash;

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("UPDATE specialists SET last_name = '{1}', first_name= '{2}', middle_name = '{3}', " +
                    "email = '{4}', password_hash = '{5}', birthday = '{6}', education = '{7}', position = '{8}', " +
                    "admission_date = '{9}', dismissal_date = '{10}', wage_rate = '{11}', " +
                    "Subunits_subunit_id = '{12}', Units_unit_id = '{13}', Parlours_parlour_id = '{14}' WHERE specialist_id = {0}",
                    specialistId.ToString(),
                    model.LastName,
                    model.FirstName,
                    model.MiddleName,
                    model.Email,
                    model.PasswordHash,
                    model.Birthday.ToString("yyyy-MM-dd HH:mm:ss"),
                    model.Education,
                    model.Position,
                    model.AdmissionDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    model.DismissalDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    model.WageRate.ToString(),
                    model.SubunitId.ToString(),
                    model.UnitId.ToString(),
                    model.ParlourId.ToString());

                MySqlCommand cmd = new MySqlCommand(query, conn);

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
