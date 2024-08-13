using crud_1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace crud_1
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Salary)
                .IsRequired()
                .HasColumnType("money");

                entity.Property(e => e.AddedOn)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");
            });
        }
    }
}
