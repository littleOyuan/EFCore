using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.EntityFrameworkCore
{
    public partial class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) :
            base(options)
        {

        }

        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}
