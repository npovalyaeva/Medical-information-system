using MedicalRecord.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Handlers
{
    public class GetAllMedicalRecordsHandler
    {
        private readonly MedicalRecordContext _context;

        public GetAllMedicalRecordsHandler(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Model.MedicalRecord> Handle()
        {
            List<Model.MedicalRecord> list = new List<Model.MedicalRecord>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "SELECT medical_records.year, medical_records.record_id, medical_records.Medical_Histories_patient_id, " +
                    "medical_records.ICD_10_ICD_10_id, medical_records.charge_date, medical_histories.last_name, " +
                    "medical_histories.first_name " +
                    "FROM medical_records " +
                    "INNER JOIN medical_histories " +
                    "ON medical_histories.patient_id = medical_records.Medical_Histories_patient_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Model.MedicalRecord()
                            {
                                Year = Convert.ToInt32(reader["year"]),
                                RecordId = Convert.ToInt32(reader["record_id"]),
                                ChargeDate = reader["charge_date"].ToString(),
                                PatientId = Convert.ToInt32(reader["Medical_Histories_patient_id"]),
                                ICD10 = reader["ICD_10_ICD_10_id"].ToString(),
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
