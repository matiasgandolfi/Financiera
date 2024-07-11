using Financiera.Data;
using Financiera.Data.Interfaces;
using Financiera.Data.Repositorio;
using Financiera.Data.Servicios;
using Financiera.Utilidades;
using Financiera.WebAPI.Controllers.Errores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Financiera.Logic.Servicios.Interfaces;
using Financiera.Logic.Servicios;
using Financiera.Models.DTOs;

namespace Financiera.WebAPI.Extensiones
{
    public static class ServicioAplicacionExtension
    {
        public static IServiceCollection AgregarServiciosAplicacion(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Ingresas Bearer [espacio] token \r\n\r\n" +
                                    "Ejemplo: Bearer ejoy^887889999999900000",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicacionDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ITokenServicio, TokenServicio>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errores = actionContext.ModelState
                                    .Where(e => e.Value.Errors.Count > 0)
                                    .SelectMany(x => x.Value.Errors)
                                    .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidacionErrorResponse
                    {
                        Errores = errores
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ApiResponse>();

            services.AddScoped<ICuentaServicio, CuentaServicio>();


            return services;
        }
    }
}
