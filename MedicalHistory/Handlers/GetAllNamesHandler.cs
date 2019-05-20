using MedicalHistory.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalHistory.Handlers
{
    public class GetAllNamesHandler
    {
            private readonly NameContext _context;

            public GetAllNamesHandler(NameContext context)
            {
                _context = context;
            }

            public List<Model.Name> Handle()
            {
                List<Model.Name> list = new List<Model.Name>();

                using (MySqlConnection conn = _context.GetConnection())
                {
                    conn.Open();

                    string query = string.Format("SELECT last_name, first_name, " +
                        "FROM medical_histories");
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Model.Name()
                                {
                                    LastName = reader["last_name"].ToString(),
                                    FirstName = reader["first_name"].ToString()
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
