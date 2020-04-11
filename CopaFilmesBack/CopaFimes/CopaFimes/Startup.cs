using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFimes.Domain.Model;
using CopaFimes.Domain.Services;
using CopaFimes.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace CopaFimes
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

            services.AddSwaggerGen(s =>
               s.SwaggerDoc("v1", new OpenApiInfo
               {
                   Title = "CopaFilmes",
                   Version = "v1",
                   Contact = new OpenApiContact { Name = "Rodrigo Lima", Email = "rodrigolima2@hotmail.com" }
               }));

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .WithHeaders(HeaderNames.AccessControlAllowHeaders, "Content-Type")
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));

            services.AddScoped<IFilmeService, FilmeService>();

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

            app.UseCors("ApiCorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "CopaFilmes v1");
            });
        }
    }
}
