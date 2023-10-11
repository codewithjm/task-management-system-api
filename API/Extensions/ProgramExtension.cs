
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using API.Middlewares;
using Business;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Contexts;
using Serilog;
using Utilities;


namespace API.Extensions;

[ExcludeFromCodeCoverage]
public static class ProgramExtension
{
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        _ = builder.Host.UseSerilog((_, lc) => lc
            .Enrich.FromLogContext()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.File(GetSerilogFileConfig(), rollingInterval: RollingInterval.Day));
        
        _ = builder.Services.Configure((JsonOptions opt) =>
        {
            opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            opt.SerializerOptions.PropertyNameCaseInsensitive = true;
            opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        });
        _ = builder.Services.AddEndpointsApiExplorer();
        var securityScheme = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JSON Web Token based security",
        };
        var securityRequirements = new OpenApiSecurityRequirement()
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
                Array.Empty<string>()
            }
        };
        var securityContactInfo = new OpenApiContact()
        {
            Name = "Task Management API",
            Email = "www.taskmanagement.com",
            Url = new Uri("https://taskmanagement.com")
        };
        var securityInfo = new OpenApiInfo()
        {
            Version = "v1",
            Title = "TMS API",
            Description = "One stop shop of all the apis of Web API.",
            Contact = securityContactInfo
        };
        _ = builder.Services.AddSwaggerGen(options => {
            options.SwaggerDoc("v1", securityInfo);
            //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            options.EnableAnnotations();
            options.DocInclusionPredicate((_, _) => true);

            options.AddSecurityDefinition("Bearer", securityScheme);
            options.AddSecurityRequirement(securityRequirements);
        });

        _ = builder.Services.AddAuthorization(o =>
        {
            o.AddPolicy("Access:ADMIN", p => p.
            RequireAuthenticatedUser().
            RequireClaim("Role", "ADMIN"));
        });

         
        _ = builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.FromMinutes(5)
            };
        });

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(option => option.AllowAnyOrigin()
                .AllowAnyMethod().AllowAnyHeader());
        });
        //builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
        builder.Services.AddBusiness();
        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddUtilities(builder.Configuration);
        return builder;
    }

    private static string GetSerilogFileConfig()
    {
        string logPath = AppDomain.CurrentDomain.BaseDirectory;
        return @$"{logPath}\logs\log-.txt";
    }

    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        var ti = CultureInfo.CurrentCulture.TextInfo;
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
                                 c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                 $"TMS Api - {ti.ToTitleCase(app.Environment.EnvironmentName)} - v1"));
        }
        else
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
                                 c.SwaggerEndpoint("/api/swagger/v1/swagger.json",
                                 $"TMS Api - {ti.ToTitleCase(app.Environment.EnvironmentName)} - v1"));
        }


        app.UseCors();

        _ = app.UseAuthentication();
        _ = app.UseAuthorization();

        _ = app.UseHttpsRedirection();
        _ = app.UseMiddleware<GlobalErrorHandlingMiddleware>();

        using (var scope = app.Services.CreateScope())
        {
            var dataContext = scope.ServiceProvider.GetRequiredService<TmsDbContext>();
            ////dataContext.Database.Migrate(); 
        }


        return app;
    }

}