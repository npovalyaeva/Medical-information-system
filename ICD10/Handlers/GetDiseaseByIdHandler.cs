using Disease.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disease.Handlers
{
    public class GetDiseaseByIdHandler
    {
        private readonly DiseaseContext _context;

        public GetDiseaseByIdHandler(DiseaseContext context)
        {
            _context = context;
        }

        public List<Model.Disease> Handle(string ICD10Code)
        {
            List<Model.Disease> list = new List<Model.Disease>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("SELECT * FROM icd_10 WHERE ICD_10_id = '{0}'", ICD10Code);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Model.Disease()
                            {
                                Id = reader["ICD_10_id"].ToString(),
                                Subcategory = reader["subcategory"].ToString(),
                                Category = reader["category"].ToString(),
                                Block = reader["block"].ToString(),
                                Chapter= reader["chapter"].ToString()
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

