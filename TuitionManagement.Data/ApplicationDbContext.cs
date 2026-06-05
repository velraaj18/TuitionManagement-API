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
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<BatchSchedule> BatchSchedules { get; set; }
        public DbSet<StudentBatch> StudentBatches { get; set; }
    }
}