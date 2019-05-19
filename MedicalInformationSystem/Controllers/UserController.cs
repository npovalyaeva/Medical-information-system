using MedicalInformationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Specialist.Data;
using Specialist.Handlers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationSystem.Controllers
{
    [Route("api/auth")]
    //[ApiController]
    public class UserController : Controller
    {
        // GET api/values
        [HttpPost, Route("sign-in")]
        public IActionResult Login([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            List<Specialist.Model.Specialist> specialists = new List<Specialist.Model.Specialist>();
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            GetSpecialistByEmailAndPasswordHandler handler = new GetSpecialistByEmailAndPasswordHandler(context);
            specialists = handler.Handle(user.Email, user.Password);

            if (specialists.Count == 1)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:3000",
                    audience: "http://localhost:3000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
