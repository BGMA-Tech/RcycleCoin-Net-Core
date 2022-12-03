using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RcycleCoinContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AutomationSystemConnectionString"));
            });

            //services.AddScoped<IUserDal, EfUserDal>();

            return services;
        }
    }
}
