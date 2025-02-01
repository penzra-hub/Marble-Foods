using FluentValidation;
using MarbleFoods.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text;
using MarbleFoods.Application.Services.MFServices;
using MarbleFoods.Application.Services.MFServiceInterface;
using MarbleFoods.Application.Repository.MFRepositoryInterface;
using MarbleFoods.Application.Repository.MFRepository;
using Serilog;
using MarbleFoods.Data;
using Microsoft.EntityFrameworkCore;
using MarbleFoods.Infrastructure.Commons;

namespace MarbleFoods.Presentation.Middlewares
{
    public static class ServicesCollections
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration, ILoggingBuilder loggerProv)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddHttpClient();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddControllers();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<Access>(configuration.GetSection("Access"));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MFLocalConnection"));
            });

            //Register Dependency Injection Here
            services.AddScoped<IAuthorisationService, AuthorisationService>();
            services.AddScoped<IAuthorisationRepo, AuthorisationRepo>();


            //Authorization Header
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Access:Issuer"],
                    ValidAudience = configuration["Access:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Access:ApiKey"] ?? "")),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    RoleClaimType = ClaimTypes.Role
                };
            });

            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            //Swagger Docs
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MarbleFoods API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            //CORs Config
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddHealthChecks();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
            services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN");

            //Register Logging
            var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
            loggerProv.ClearProviders();
            loggerProv.AddSerilog(logger);

            services.AddEndpointsApiExplorer();

            services.AddAuthorization(c =>
            {
                c.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                c.AddPolicy(Policies.OperationsManager, Policies.OperationsManagerPolicy());
                c.AddPolicy(Policies.WarehouseSupervisor, Policies.WarehouseSupervisorPolicy());
                c.AddPolicy(Policies.ProcurementManager, Policies.ProcurementManagerPolicy());
                c.AddPolicy(Policies.QualityControlSpecialist, Policies.QualityControlSpecialistPolicy());
                c.AddPolicy(Policies.WarehousePersonnel, Policies.WarehousePersonnelPolicy());
            });

            return services;
        }
    }
}
