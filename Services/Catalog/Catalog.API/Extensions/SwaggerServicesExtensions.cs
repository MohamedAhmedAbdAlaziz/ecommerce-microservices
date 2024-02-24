﻿using Microsoft.OpenApi.Models;

namespace Catalog.API.Extensions
{
    public static class SwaggerServicesExtensions
    {
        public static IServiceCollection AddswaggerDocmentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkiNet API", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                c.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
        public static IApplicationBuilder UseSwaggerDocmentation(this IApplicationBuilder host)
        {
            host.UseSwagger();
            host.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "skiNet API v1");
            });


            return host;
        }
    }
}