using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Dapper;
using Persistence.Repositories.Dapper.Configs;
using Persistence.Repositories.Dapper.Interface;
using Persistence.Repositories.EF;
using Persistence.Repositories.EF.Interfaces;

namespace Persistence;

public static class ServiceRegistration
{
    public static void AddPersistence(this IServiceCollection service, IConfiguration configuration)
    {
        var tmsConnectionString = configuration["ConnectionStrings:TMS"]; 

        service.AddDbContext<TmsDbContext>(options => options.UseSqlServer(tmsConnectionString));

        service.AddSingleton<IDbConnectionFactory>(_ => new SqlServerConnectionFactory(tmsConnectionString));
        service.AddScoped<IQueryRepositories, QueryRepositories>();
        service.AddScoped<IEntityWork,  EntityWork>();  
        
    }
}