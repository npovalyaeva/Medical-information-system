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
        [HttpPost("[action]")]
        public bool CreateMedicalSpecialist([FromBody] CreateSpecialistCommand request)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            CreateSpecialistHandler handler = new CreateSpecialistHandler(context);
            return handler.Handle(request);
        }

        [HttpPut("[action]")]
        public bool UpdateSpecialist(int specialistId, [FromBody] CreateSpecialistCommand request)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            UpdateSpecialistHandler handler = new UpdateSpecialistHandler(context);
            return handler.Handle(specialistId, request);
        }

        [HttpGet("[action]")]
        public IEnumerable<Specialist.Model.Specialist> GetSpecialistByEmailAndPassword(string email, string password)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            GetSpecialistByEmailAndPasswordHandler handler = new GetSpecialistByEmailAndPasswordHandler(context);
            return handler.Handle(email, password);
        }

    }
}