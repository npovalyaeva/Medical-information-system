using MedicalRecord.Data;
//using MedicalRecord.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers
{
    [Route("api/records")]
    public class MedicalRecordController : Controller
    {
        [HttpGet()]
        public IEnumerable<Record> GetAllMedicalRecords()
        {
            var list = new List<Record>();
            list.Add(new Record() { RecordId = 123, FirstName = "Настена", LastName = "Дайгод", PatientId = 1, ICD10 = "Е50.0", Year = 2016, ChargeDate = "01.03.2019" });
            list.Add(new Record() { RecordId = 222, FirstName = "Надюша", LastName = "Поваляева", PatientId = 2, ICD10 = "Е50.1", Year = 2008, ChargeDate = "03.03.2019" });
            return list;
            /* MedicalRecordContext context = HttpContext.RequestServices.GetService(typeof(MedicalRecordContext)) as MedicalRecordContext;
             MedicalRecord.Handlers.GetAllMedicalRecordsHandler handler = new MedicalRecord.Handlers.GetAllMedicalRecordsHandler(context);
             return handler.Handle(); */
        }
    }
}
