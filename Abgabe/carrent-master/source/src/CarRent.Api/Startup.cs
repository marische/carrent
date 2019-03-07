using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Api.CarManagement.Domain;
using CarRent.Api.CarManagement.Persistence;
using CarRent.Api.ContractManagement.BusinessLogic;
using CarRent.Api.ContractManagement.Persistence;
using CarRent.Api.CustomerManagement.BusinessLogic;
using CarRent.Api.CustomerManagement.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CarRent.Api
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
            services.AddLogging(lb => lb.AddConsole());
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarRepository, MySqlCarRepository>(sp => new MySqlCarRepository(Configuration.GetConnectionString("Marina")));
            services.AddTransient<IContractRepository, MySqlContractRepository>(sp => new MySqlContractRepository(Configuration.GetConnectionString("Marina")));
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, MySqlCustomerRepository>(sp => new MySqlCustomerRepository(Configuration.GetConnectionString("Marina")));

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
