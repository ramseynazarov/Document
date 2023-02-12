using Document.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Document.Extensions;

public  static class ServiceRegistrations
{
    public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<DataContext>(builder => builder.UseSqlite(configuration.GetConnectionString("DB_CONNECTIONS")).UseLazyLoadingProxies());

}