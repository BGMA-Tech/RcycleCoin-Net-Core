using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Concrete.Contexts
{
    public class RecycleCoinContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<RecycleProduct> RecycleProducts { get; set; }
        public DbSet<RecycleType> RecycleTypes { get; set; }
        public DbSet<UserRecycleProduct> UserRecycleProducts { get; set; }


        public RecycleCoinContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
        {
            Configuration= configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
