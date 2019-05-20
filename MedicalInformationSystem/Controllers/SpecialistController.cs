using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Specialist.Data;
using Specialist.Handlers;
using Specialist.Commands;
using Specialist.Model;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class SpecialistController : Controller
    {
        //[HttpPost("[action]")]
        //public bool CreateSpecialist([FromBody] CreateSpecialistCommand request)
        //{
        //    SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
        //    CreateSpecialistHandler handler = new CreateSpecialistHandler(context);
        //    return handler.Handle(request);
        //}

        [HttpPut("[action]")]
        public bool UpdateSpecialistEmail(int specialistId, string specialistEmail)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            UpdateSpecialistEmailHandler handler = new UpdateSpecialistEmailHandler(context);
            return handler.Handle(specialistId, specialistEmail);
        }

        [HttpPut("[action]")]
        public bool UpdateSpecialistPassword(int specialistId, string specialistPassword)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            UpdateSpecialistPasswordHandler handler = new UpdateSpecialistPasswordHandler(context);
            return handler.Handle(specialistId, specialistPassword);
        }

        [HttpGet("[action]")]
        public IEnumerable<Specialist.Model.Specialist> GetSpecialistById(int id)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            GetSpecialistByIdHandler handler = new GetSpecialistByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpGet("[action]")]
        public IEnumerable<Specialist.Model.Specialist> GetSpecialistByEmailAndPassword(string email, string password)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            GetSpecialistByEmailAndPasswordHandler handler = new GetSpecialistByEmailAndPasswordHandler(context);
            return handler.Handle(email, password);
        }

        [HttpGet("[action]")]
        public IEnumerable<Specialist.Model.Name> GetAllDoctorsNames()
        {
            SpecialistNameContext context = HttpContext.RequestServices.GetService(typeof(SpecialistNameContext)) as SpecialistNameContext;
            GetAllDoctorsNamesHandler handler = new GetAllDoctorsNamesHandler(context);
            return handler.Handle();
        }

    }
}