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
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM medical_records", conn);

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
                                ChargeDate = Convert.ToDateTime(reader["charge_date"]),
                                DischargeDate = Convert.ToDateTime(reader["discharge_date"]),
                                RelativePhoneNumber = reader["relative_phone_number"].ToString(),
                                PaymentType = reader["payment_type"].ToString(),
                                InpatientDays = Convert.ToInt32(reader["inpatient_days"]),
                                DoctorId = Convert.ToInt32(reader["Doctors_Specialists_specialist_id"]),
                                NurseId = Convert.ToInt32(reader["Nurses_Specialists_specialist_id"]),
                                PatientId = Convert.ToInt32(reader["Medical_Histories_patient_id"]),
                                WardId = Convert.ToInt32(reader["Subunits_Wards_ward_id"]),
                                Disease = reader["ICD_10_ICD_10_id"].ToString()
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
