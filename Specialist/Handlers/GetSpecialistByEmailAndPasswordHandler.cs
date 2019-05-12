using MySql.Data.MySqlClient;
using Specialist.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specialist.Handlers
{
    public class GetSpecialistByEmailAndPasswordHandler
    {
        private readonly SpecialistContext _context;

        public GetSpecialistByEmailAndPasswordHandler(SpecialistContext context)
        {
            _context = context;
        }

        public List<Model.Specialist> Handle(string specialistEmail, string specialistPassword)
        {
            List<Model.Specialist> list = new List<Model.Specialist>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("SELECT * FROM Specialists WHERE (email, password_hash) = ('{0}', '{1}')",
                    specialistEmail, Hash.FindHash(specialistPassword));
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Model.Specialist()
                            {
                                Id = Convert.ToInt32(reader["specialist_id"]),
                                LastName = reader["last_name"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                MiddleName = reader["middle_name"].ToString(),
                                Email = reader["email"].ToString(),
                                PasswordHash = reader["password_hash"].ToString(),
                                Birthday = DateTime.Parse(reader["birthday"].ToString()),
                                Education = reader["education"].ToString(),
                                Position = reader["position"].ToString(),
                                AdmissionDate = DateTime.Parse(reader["admission_date"].ToString()),
                                DismissalDate = DateTime.Parse(reader["dismissal_date"].ToString()),
                                WageRate = Convert.ToDecimal(reader["wage_rate"]),
                                SubunitId = Convert.ToInt32(reader["Subunits_subunit_id"]),
                                UnitId = Convert.ToInt32(reader["Units_unit_id"]),
                                ParlourId = Convert.ToInt32(reader["Parlours_parlour_id"])
                            });
                        }
                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    conn.CloseAsync();
                }
            }
            return list;
        }
    }
}
