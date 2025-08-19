using Microsoft.EntityFrameworkCore;
using UniversityMIS.Models;

namespace UniversityMIS.database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        #region DbSets
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Marks> Marks { get; set; }
        #endregion

    }
}
