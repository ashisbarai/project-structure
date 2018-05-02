using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using Architecture.Infrastructure.Configurations;

namespace Architecture.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppConnectionString")
        {
            
        }

        public int Commit()
        {
            return SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(EmployeeConfiguration).Assembly);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}