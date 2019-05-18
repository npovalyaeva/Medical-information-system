using MedicalRecord.Data;
using MedicalRecord.Handlers;
using MedicalRecord.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalInformationSystem.Controllers
{
    [Route("api/[controller]")]
    public class MedicalRecordController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<MedicalRecord.Model.MedicalRecord> GetAllMedicalRecords()
        {
            MedicalRecordContext context = HttpContext.RequestServices.GetService(typeof(MedicalRecordContext)) as MedicalRecordContext;
            GetAllMedicalRecordsHandler handler = new GetAllMedicalRecordsHandler(context);
            return handler.Handle();
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalRecord.Model.MedicalRecord> GetMedicalRecordById(int year, int id)
        {
            MedicalRecordContext context = HttpContext.RequestServices.GetService(typeof(MedicalRecordContext)) as MedicalRecordContext;
            GetMedicalRecordByIdHandler handler = new GetMedicalRecordByIdHandler(context);
            return handler.Handle(year, id);
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalRecord.Model.MedicalRecord> GetMedicalRecordsByDoctorId(int doctorId)
        {
            MedicalRecordContext context = HttpContext.RequestServices.GetService(typeof(MedicalRecordContext)) as MedicalRecordContext;
            GetMedicalRecordsByDoctorIdHandler handler = new GetMedicalRecordsByDoctorIdHandler(context);
            return handler.Handle(doctorId);
        }
    }
}
