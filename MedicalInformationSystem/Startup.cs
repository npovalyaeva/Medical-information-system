using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MedicalInformationSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", corsBuilder =>
            {
                corsBuilder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            }));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:3000",
                    ValidAudience = "http://localhost:3000",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0);

            services.AddMvc()/*.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)*/;
            services.Add(new ServiceDescriptor(typeof(Specialist.Data.SpecialistContext), new Specialist.Data.SpecialistContext(Configuration.GetConnectionString("DefaultConnection"))));
            //services.Add(new ServiceDescriptor(typeof(Doctor.Data.DoctorContext), new Doctor.Data.DoctorContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(MedicalRecord.Data.FullMedicalRecordContext), new MedicalRecord.Data.FullMedicalRecordContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(MedicalRecord.Data.MedicalRecordContext), new MedicalRecord.Data.MedicalRecordContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(Specialist.Data.SpecialistNameContext), new Specialist.Data.SpecialistNameContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.AddSwaggerGen(swagger =>
            {
                swagger.DescribeAllEnumsAsStrings();
                swagger.DescribeAllParametersInCamelCase();
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Medical Information System Swagger" });
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical Information System Swagger");
            });

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
