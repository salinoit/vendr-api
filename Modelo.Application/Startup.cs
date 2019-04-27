using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using Vendr.Infra.CrossCutting.Identity.Configuration;

using Vendr.Service.Services;
using Vendr.Domain.Interfaces;
using Vendr.Infra.Data.Repository;
using Vendr.Infra.Data.Dapper;
using Vendr.Domain.Entities;
using Vendr.Domain.Dto;
using AutoMapper;


namespace Vendr.Application
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
            //CONFIG
            services.AddSingleton<IConfiguration>(Configuration);

            //SERVICES
            services.AddScoped< IService<Vendedor>, VendedorService>();
            services.AddScoped<IService<ProdutoServico>, ProdutoService>();

            //REPOSITORIES
            services.AddScoped<IRepositoryAsync<Vendedor>, VendedorRepository>();
            services.AddScoped<IRepositoryAsync<ProdutoServico>, ProdutoRepository>();
            services.AddScoped<IRepositoryAsync<Perfil>, PerfilRepository>();

            //DAPPER
            services.AddScoped<IProdutoDapper, ProdutoDapper>();

            //OTHERS
            services.AddDbContext<Vendr.Infra.Data.Context.DBContext>();
            services.AddSecurity(Configuration);

            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<Vendr.Infra.Data.Dapper.ProdutoDapper.AutoMapperProfile>());

            services.AddAutoMapper();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
