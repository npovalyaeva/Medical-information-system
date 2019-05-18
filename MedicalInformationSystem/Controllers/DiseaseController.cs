using Disease.Data;
using Disease.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalInformationSystem.Controllers
{
    [Route("api/[controller]")]
    public class DiseaseController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Disease.Model.Disease> GetDiseaseByICD10Code(string ICD10Code)
        {
            DiseaseContext context = HttpContext.RequestServices.GetService(typeof(DiseaseContext)) as DiseaseContext;
            GetDiseaseByIdHandler handler = new GetDiseaseByIdHandler(context);
            return handler.Handle(ICD10Code);
        }

        [HttpGet("[action]")]
        public IEnumerable<Disease.Model.Disease> GetAllDiseasesByChapter(string chapter)
        {
            DiseaseContext context = HttpContext.RequestServices.GetService(typeof(DiseaseContext)) as DiseaseContext;
            GetAllDiseasesByChapterHandler handler = new GetAllDiseasesByChapterHandler(context);
            return handler.Handle(chapter);
        }

        [HttpGet("[action]")]
        public IEnumerable<Disease.Model.Disease> GetAllDiseasesByBlock(string block)
        {
            DiseaseContext context = HttpContext.RequestServices.GetService(typeof(DiseaseContext)) as DiseaseContext;
            GetAllDiseasesByBlockHandler handler = new GetAllDiseasesByBlockHandler(context);
            return handler.Handle(block);
        }

        [HttpGet("[action]")]
        public IEnumerable<Disease.Model.Disease> GetAllDiseasesByCategory(string category)
        {
            DiseaseContext context = HttpContext.RequestServices.GetService(typeof(DiseaseContext)) as DiseaseContext;
            GetAllDiseasesByCategoryHandler handler = new GetAllDiseasesByCategoryHandler(context);
            return handler.Handle(category);
        }
    }
}
