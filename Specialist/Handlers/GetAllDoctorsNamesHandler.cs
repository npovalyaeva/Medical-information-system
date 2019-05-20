using MySql.Data.MySqlClient;
using Specialist.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specialist.Handlers
{
    public class GetAllDoctorsNamesHandler
    {
        private readonly SpecialistNameContext _context;

        public GetAllDoctorsNamesHandler(SpecialistNameContext context)
        {
            _context = context;
        }

        public List<Model.Name> Handle()
        {
            List<Model.Name> list = new List<Model.Name>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("SELECT specialists.last_name, specialists.first_name, " +
                    "specialists.middle_name, specialists.specialist_id " +
                    "FROM specialists " +
                    "INNER JOIN doctors " +
                    "ON specialists.specialist_id = doctors.Specialists_specialist_id");
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Model.Name()
                            {
                                Id = Convert.ToInt32(reader["specialist_id"]),
                                LastName = reader["last_name"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                MiddleName = reader["middle_name"].ToString()
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
