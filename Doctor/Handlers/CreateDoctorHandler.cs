using Doctor.Commands;
using Doctor.Data;
using Mapster;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Handlers
{
    public class CreateDoctorHandler
    {
        private readonly DoctorContext _context;

        public CreateDoctorHandler(DoctorContext context)
        {
            _context = context;
        }

        public bool Handle(CreateDoctorCommand request)
        {
            var model = request.Adapt<Model.Doctor>();
            string tempHash = Specialist.Data.Hash.FindHash(model.PasswordHash);
            model.PasswordHash = tempHash;

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("INSERT INTO specialists(last_name, first_name, middle_name, email, password_hash, birthday, education, position, admission_date, dismissal_date, wage_rate, Subunits_subunit_id, Units_unit_id, Parlours_parlour_id) " +
                    "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');" +
                    "INSERT INTO doctors(Specialists_specialist_id, diploma_speciality, qualification) " +
                    "VALUES(LAST_INSERT_ID(), '{14}', '{15}')",
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
                    model.ParlourId.ToString(),
                    model.DiplomaSpeciality,
                    model.Qualification.ToString());
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
