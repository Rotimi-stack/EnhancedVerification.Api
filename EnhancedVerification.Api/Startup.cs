using EnhancedKyc.Infrastructure;
using EnhancedKyc.Infrastructure.Persistence.Context;
using EnhancedKyc.Infrastructure.Persistence.Extension;
using EnhancedKyc.Infrastructure.ServiceIntegration.EnhancedKycVerification;
using EnhancedKycVerification.Application;
using EnhancedKycVerification.Application.Common.Interface;
using EnhancedVerification.Shared.LogService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnhancedVerification.Api
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
            services.AddScoped<IKycContext, KycContext>();
            services.AddDbContext<KycContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           // services.ConfigureSqlContext(Configuration);
            services.AddControllers();
            services.AddControllers();
            services.AddHttpClient();
            services.AddScoped<ILogWritter, LogWritter>();
            services.AddScoped<EnhancedKycVerificationInterface, EnhancedKycVerificationService>();
            services.AddCors();
            services.AddMvc();
            services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);
            services.AddApplication();
            services.AddInfrastructure();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

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
