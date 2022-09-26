using Microsoft.EntityFrameworkCore;
using SavingsDev.API.Entities;

namespace SavingsDev.API.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<FinancialObjective> Objectives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialObjective>(e =>
            {
                e.HasKey(of => of.Id);

                e.Property(of => of.ValueObject)
                 .HasColumnType("decimal(18,4)");

                e.HasMany(of => of.Operations)
                 .WithOne()
                 .HasForeignKey(op => op.IdObjective)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Operation>(e =>
            {
                e.HasKey(op => op.Id);

                e.Property(op => op.Value)
                 .HasColumnType("decimal(18,4)");
            });

        }
    }
}