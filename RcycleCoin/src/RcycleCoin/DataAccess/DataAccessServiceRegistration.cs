using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RecycleCoinContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RecycleCoinConnectionString"));
            });

            services.AddScoped<IRecycleProductDal, EfRecycleProductDal>();
            services.AddScoped<IRecycleTypeDal, EfRecycleTypeDal>();
            services.AddScoped<IUserRecycleProductDal, EfUserRecycleProductDal>();

            return services;
        }
    }
}
