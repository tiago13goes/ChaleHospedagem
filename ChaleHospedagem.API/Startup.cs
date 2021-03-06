using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Interface.Services;
using ChaleHospedagem.Domain.Services;
using ChaleHospedagem.Infrastructure.Repositories;
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
//using ChaleHospedagem.Infrastructure;

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

            services.AddScoped<IServiceChale, ServiceChale>();
            services.AddScoped<IServiceChale_Item, ServiceChale_Item>();
            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IServiceHospedagem, ServiceHospedagem>();
            services.AddScoped<IServiceHospedagem_Servico, ServiceHospedagem_Servico>();
            services.AddScoped<IServiceItem, ServiceItem>();
            services.AddScoped<IServiceServico, ServiceServico>();
            services.AddScoped<IServiceTelefone, ServiceTelefone>();

            #endregion

            #region Reposit?rio

            services.AddScoped<IRepositoryChale, RepositoryChale>();
            services.AddScoped<IRepositoryChale_Item, RepositoryChale_Item>();
            services.AddScoped<IRepositoryCliente, RepositoryCliente>();
            services.AddScoped<IRepositoryHospedagem, RepositoryHospedagem>();
            services.AddScoped<IRepositoryHospedagem_Servico, RepositoryHospedagem_Servico>();
            services.AddScoped<IRepositoryItem, RepositoryItem>();
            services.AddScoped<IRepositoryServico, RepositoryServico>();
            services.AddScoped<IRepositoryTelefone, RepositoryTelefone>();


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
