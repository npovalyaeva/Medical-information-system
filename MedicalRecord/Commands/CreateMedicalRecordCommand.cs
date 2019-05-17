using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Commands
{
    public class CreateMedicalRecordCommand
    {
        public int Year { get; set; }

        public int RecordId { get; set; }

        public DateTime ChargeDate { get; set; }

        public DateTime DischargeDate { get; set; }

        public string RelativePhoneNumber { get; set; }

        public string PaymentType { get; set; }

        public int InpatientDays { get; set; }

        public int DoctorId { get; set; }

        public int NurseId { get; set; }

        public int PatientId { get; set; }

        public int WardId { get; set; }

        public string Disease { get; set; }
    }
}
