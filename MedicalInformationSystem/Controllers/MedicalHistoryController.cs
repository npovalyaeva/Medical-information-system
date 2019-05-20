using MedicalHistory.Data;
using MedicalHistory.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalInformationSystem.Controllers
{
    [Route("api/[controller]")]
    public class MedicalHistoryController : Controller
    {
        [HttpGet()]
        public IEnumerable<MedicalHistory.Model.Name> GetNameById(int id)
        {
            //NameContext context = HttpContext.RequestServices.GetService(typeof(NameContext)) as NameContext;
            //GetNameByIdHandler handler = new GetNameByIdHandler(context);
            //return handler.Handle(id);
            return null;
        }

        //[HttpGet()]
        //public IEnumerable<MedicalHistory.Model.Name> GetAllNames()
        //{
        //    NameContext context = HttpContext.RequestServices.GetService(typeof(NameContext)) as NameContext;
        //    GetAllNamesHandler handler = new GetAllNamesHandler(context);
        //    return handler.Handle();
        //}
    }
}
