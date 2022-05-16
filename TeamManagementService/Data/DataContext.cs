global using TeamManagementService.Models;
using Microsoft.EntityFrameworkCore;


namespace TeamManagementService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        public DbSet<BusinessUnitCategory> BusinessUnitCategories { get; set; }

        public DbSet<BusinessUnitMember> BusinessUnitMembers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<BusinessUnitCategory>(buc => {              
                buc.HasOne<BusinessUnit>() 
                    .WithMany()
                    .HasForeignKey(c => c.BU_Id);
            });

            builder.Entity<BusinessUnitMember>(bum => {
                bum.HasOne<BusinessUnit>()
                    .WithMany()
                    .HasForeignKey(c => c.BU_Id);
            });

            builder.Entity<Employee>(ee => {
                ee.HasOne<BusinessUnit>()
                    .WithMany()
                    .HasForeignKey(c => c.BU_Id);
            });


            base.OnModelCreating(builder);

        }
    }
}
