using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Commands
{
    public class CreateMedicalRecordCommand
    {
        public int RecordId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PatientId { get; set; }

        public string ICD10 { get; set; }

        public int Year { get; set; }

        public string ChargeDate { get; set; }
    }
}
