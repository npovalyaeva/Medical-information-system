using Mapster;
using MySql.Data.MySqlClient;
using Specialist.Commands;
using Specialist.Data;

namespace Specialist.Handlers
{
    public class CreateSpecialistHandler
    {
        private readonly SpecialistContext _context;

        public CreateSpecialistHandler(SpecialistContext context)
        {
            _context = context;
        }

        public bool Handle(CreateSpecialistCommand request)
        {
            var model = request.Adapt<Model.Specialist>();
            string tempHash = Hash.FindHash(model.PasswordHash);
            model.PasswordHash = tempHash;

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("INSERT INTO specialists(last_name, first_name, middle_name, " +
                    "email, password_hash, birthday, education, position, " +
                    "admission_date, dismissal_date, wage_rate, " +
                    "Subunits_subunit_id, Units_unit_id, Parlours_parlour_id) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')",
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
