using FluentValidation.AspNetCore;
using hogwartsAPI.Abstractions;
using hogwartsAPI.Application;
using hogwartsAPI.DataAccess;
using hogwartsAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace hogwartsAPI
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
            services.AddControllers();
            AddSwagger(services);

            //Comunication Data Access
            services.AddDbContext<APIDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("hogwartsAPI")));


            //Comunication services
            services.AddScoped(typeof(InterfaceApplication<>), typeof(Application<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IDbContext<>), typeof(DataAccess.Dbcontext<>));

        }


        private void AddSwagger(IServiceCollection services)
        { 
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"HogwartsAPI{groupName}",
                    Version = groupName,
                    Description = "Hogwarts API",
                    Contact = new OpenApiContact
                    {
                        Name = "HogwartsAPI",
                      
                    }
                });
            });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, APIDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.Migrate();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hogwarts API V1");
            });
        }
    }
}
