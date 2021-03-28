using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseEntityFrameworkCoreMvc.Models.Database
{
    public partial class TestDatabaseDbContext : DbContext
    {
        public TestDatabaseDbContext()
        {
        }

        public TestDatabaseDbContext(DbContextOptions<TestDatabaseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Japanese_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
