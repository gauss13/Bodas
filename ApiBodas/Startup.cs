
using Entities.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.Text;

namespace ApiBodas
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // DB - EF

            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConecction"));
            //}
            // );

            services.AddDbContext<AppDbContext>(options =>
             {
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConecction"),
                     b => b.MigrationsAssembly("ApiBodas"));
             });


            // Configura CORS
            services.AddCors(options => {

                options.AddPolicy("EnableCORS", builder => {

                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });

            });


            //SPA
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
              //  configuration.RootPath = "ClientApp/dist"; //descomentar
            });


            // Midleware Repository
            services.AddScoped<IRepositorioWrapper, RepositorioWrapper>();


            // JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

                options.TokenValidationParameters = new TokenValidationParameters {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "https://localhost:44392, http://localhost:50271, http://localhost:4200",
                    ValidAudience = "https://localhost:44392, http://localhost:50271, http://localhost:4200",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superCretetdfadfgdfgdgwefrwR54WE#43d#$%@13"))
                };

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts(); //abc
            }

            //app.UseHttpsRedirection(); ////descomentar para https
            //app.UseStaticFiles(); //descomentar
            //app.UseSpaStaticFiles(); //descomentar

            app.UseCors("EnableCORS"); // activamos cors para toda la aplicacion
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });


            //descomentar este config
            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    //descomentar las 5 lineas
            //    spa.Options.SourcePath = "ClientApp";
            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }


            //});
        }
    }
}
