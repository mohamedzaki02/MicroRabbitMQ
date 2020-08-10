using System;
using System.Net;
using DatingApp.Helpers;
using FluentValidation;
using MediatR;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MicroRabbit.Banking.API
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

            services.AddDbContext<BankingDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("BankingDbConnection"));
            });

            services.AddSwaggerGen(opts => opts.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking MicroService", Version = "v1" }));

            services.AddMediatR(typeof(Startup));

            
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                    builder.Run(async ctx =>
                    {
                        ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorObj = ctx.Features.Get<IExceptionHandlerFeature>();
                        if (errorObj != null)
                        {
                            ctx.Response.AddApplicationError(errorObj.Error.Message);
                            await ctx.Response.WriteAsync(errorObj.Error.Message);
                        }
                    }));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
