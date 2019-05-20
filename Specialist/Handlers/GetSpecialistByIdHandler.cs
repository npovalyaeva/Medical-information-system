using MySql.Data.MySqlClient;
using Specialist.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specialist.Handlers
{
    public class GetSpecialistByIdHandler
    {
        private readonly SpecialistContext _context;

        public GetSpecialistByIdHandler(SpecialistContext context)
        {
            _context = context;
        }

        public List<Model.Specialist> Handle(int specialistId)
        {
            List<Model.Specialist> list = new List<Model.Specialist>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("SELECT hospital_database.specialists.`last_name`, hospital_database.specialists.`first_name`, " +
                    "hospital_database.specialists.`middle_name`, hospital_database.specialists.`specialist_id`, " +
                    "hospital_database.specialists.`birthday`, hospital_database.specialists.`education`, " +
                    "hospital_database.specialists.`position`, hospital_database.specialists.`admission_date`, " +
                    "hospital_database.specialists.`wage_rate`, hospital_database.specialists.`Parlours_parlour_id`, " +
                    "hospital_database.units.`unit_name`, hospital_database.subunits.`subunit_name`, " +
                    "hospital_database.doctors.`qualification`, hospital_database.doctors.`diploma_speciality`, " +
                    "hospital_database.nurses.`post_number` " +
                    "FROM hospital_database.specialists " +
                    "LEFT JOIN hospital_database.doctors " +
                    "ON hospital_database.specialists.`specialist_id` = hospital_database.doctors.`Specialists_specialist_id` " +
                    "LEFT JOIN hospital_database.nurses " +
                    "ON hospital_database.specialists.`specialist_id` = hospital_database.nurses.`Specialists_specialist_id` " +
                    "LEFT JOIN hospital_database.units " +
                    "ON hospital_database.specialists.`Units_unit_id` = hospital_database.units.`unit_id` " +
                    "LEFT JOIN hospital_database.subunits " +
                    "ON hospital_database.specialists.`Subunits_subunit_id` = hospital_database.subunits.`subunit_id` " +
                    "WHERE hospital_database.specialists.`specialist_id` = '{0}'",
                    specialistId);
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
                                Birthday = reader["birthday"].ToString(),
                                Education = reader["education"].ToString(),
                                Position = reader["position"].ToString(),
                                AdmissionDate = reader["admission_date"].ToString(),
                                WageRate = Convert.ToDecimal(reader["wage_rate"]),
                                Subunit = reader["subunit_name"].ToString(),
                                Unit = reader["unit_name"].ToString(),
                                Parlour = Convert.ToInt32(reader["Parlours_parlour_id"]),

                                DiplomaSpeciality = reader["diploma_speciality"].ToString(),
                                Qualification = reader["qualification"].ToString() == "" ? -1 : Convert.ToInt32(reader["qualification"]),
                                PostNumber = reader["post_number"].ToString() == "" ? - 1 : Convert.ToInt32(reader["post_number"]),
                                IsDoctor = reader["diploma_speciality"].ToString() == "" ? false : true

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
