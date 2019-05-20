using MedicalHistory.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalHistory.Handlers
{
    public class GetNameByIdHandler
    {
        private readonly NameContext _context;

        public GetNameByIdHandler(NameContext context)
        {
            _context = context;
        }

        public List<Model.Name> Handle(int id)
        {
            List<Model.Name> list = new List<Model.Name>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("SELECT * FROM medical_histories WHERE patient_id = '{0}'", id);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Model.Name()
                            {
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString()
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
