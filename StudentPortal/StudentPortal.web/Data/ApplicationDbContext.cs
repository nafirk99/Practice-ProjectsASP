using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Models.Entities;

namespace StudentPortal.web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        { 
        }

        public DbSet<Student> students { get; set; }

    }
}
