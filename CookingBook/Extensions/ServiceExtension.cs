using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Configuration.Mapper;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using AutoMapper;
using CookingBook.Validators;
using CookingBook.Validators.Product;
using FluentValidation.AspNetCore;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CookingBook.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UsersService>();
            services.AddScoped<IUserResolverService, UserResolverService>();
            services.AddScoped<IProductService, ProductService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }

        public static void AddJWTAuthenticatoin(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContex>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("CookingBook"));
            });
        }

        public static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new ProductProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddCorsSettings(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Token-Expired", "InvalidRefreshToken", "InvalidCredentials")
                .Build());
            });
        }

        public static void AddMVCWithFluentValidation(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<PasswordValidator>();
                config.RegisterValidatorsFromAssemblyContaining<UserRegisterValidator>();
                config.RegisterValidatorsFromAssemblyContaining<ProductAddValidator>();
                config.RegisterValidatorsFromAssemblyContaining<ProductUpdateValidator>();
                config.RegisterValidatorsFromAssemblyContaining<ProductCategoryAddValidator>();
                config.RegisterValidatorsFromAssemblyContaining<ProductCategoryUpdateValidator>();
            });
        }

    }
}
