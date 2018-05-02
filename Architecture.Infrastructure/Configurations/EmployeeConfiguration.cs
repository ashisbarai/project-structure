using System.Data.Entity.ModelConfiguration;
using Architecture.Core.Entities;

namespace Architecture.Infrastructure.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(128);
            Property(p => p.Email).IsRequired().HasMaxLength(50);
            Property(p => p.Address).IsRequired().HasMaxLength(256);
        }
    }
}