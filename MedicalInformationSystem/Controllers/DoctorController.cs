//using Doctor.Commands;
//using Doctor.Data;
//using Doctor.Handlers;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MedicalInformationSystem.Controllers
//{
//    [Route("api/[controller]")]
//    public class DoctorController : Controller
//    {
//        [HttpPost("[action]")]
//        public bool CreateDoctor([FromBody] CreateDoctorCommand request)
//        {
//            DoctorContext context = HttpContext.RequestServices.GetService(typeof(DoctorContext)) as DoctorContext;
//            CreateDoctorHandler handler = new CreateDoctorHandler(context);
//            return handler.Handle(request);
//        }
//    }
//}
