using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Interface.Repository;
using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Interface.Services;
using ChaleHospedagem.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaleHospedagem.API
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
            //services.AddDbContext<AppicationDbContext>(options=>options.UseSqlServer())
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChaleHospedagem.API", Version = "v1" });
            });

            RegistrarDependencias(services);
        }


        public void RegistrarDependencias(IServiceCollection services)
        {
            #region Servicos

            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IServiceChale, ServiceChale>();

            #endregion

            #region Repositório

            //services.AddScoped<IRepositoryCliente, RepositoryCliente>();
            services.AddScoped<IRepositoryChale, RepositoryChale>(); //why RepositoryChale is not being referenced????


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChaleHospedagem.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
