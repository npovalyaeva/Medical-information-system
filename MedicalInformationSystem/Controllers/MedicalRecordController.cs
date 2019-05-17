using MedicalRecord.Data;
//using MedicalRecord.Handlers;
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
            MedicalRecord.Handlers.GetAllMedicalRecordsHandler handler = new MedicalRecord.Handlers.GetAllMedicalRecordsHandler(context);
            return handler.Handle();
        }
    }
}
