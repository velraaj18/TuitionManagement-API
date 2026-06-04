using Microsoft.EntityFrameworkCore;
using TuitionManagement.Data.Models;

namespace TuitionManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}