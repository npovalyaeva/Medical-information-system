using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Specialist.Data;
using Specialist.Handlers;
using Specialist.Commands;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class SpecialistController : Controller
    {
        [HttpPut("[action]")]
        public bool UpdateSpecialist(int specialistId, [FromBody] CreateSpecialistCommand request)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            UpdateSpecialistHandler handler = new UpdateSpecialistHandler(context);
            return handler.Handle(specialistId, request);
        }

    }
}