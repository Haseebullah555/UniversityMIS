using Microsoft.EntityFrameworkCore;

namespace UniversityMIS.database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        #region DbSets
        
        #endregion

    }
}
