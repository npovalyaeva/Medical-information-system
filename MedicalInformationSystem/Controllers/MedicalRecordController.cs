using MedicalRecord.Data;
using MedicalRecord.Handlers;
using MedicalRecord.Model;
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
        public IEnumerable<MedicalRecord.Model.MedicalRecord> GetAllMedicalRecords()
        {
            MedicalRecordContext context = HttpContext.RequestServices.GetService(typeof(MedicalRecordContext)) as MedicalRecordContext;
            GetAllMedicalRecordsHandler handler = new GetAllMedicalRecordsHandler(context);
            return handler.Handle();
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalRecord.Model.FullMedicalRecord> GetMedicalRecordById(int year, int id)
        {
            FullMedicalRecordContext context = HttpContext.RequestServices.GetService(typeof(FullMedicalRecordContext)) as FullMedicalRecordContext;
            GetFullMedicalRecordByIdHandler handler = new GetFullMedicalRecordByIdHandler(context);
            return handler.Handle(year, id);
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalRecord.Model.FullMedicalRecord> GetFullMedicalRecordsByDoctorId(int doctorId)
        {
            FullMedicalRecordContext context = HttpContext.RequestServices.GetService(typeof(FullMedicalRecordContext)) as FullMedicalRecordContext;
            GetFullMedicalRecordsByDoctorIdHandler handler = new GetFullMedicalRecordsByDoctorIdHandler(context);
            return handler.Handle(doctorId);
        }
    }
}
