using Microsoft.EntityFrameworkCore;

namespace Share.Domain.UserCenter.Entity
{
    public class MysqlDbContext : DbContext
    {
        static DbContextOptions<MysqlDbContext> _defaultOptions = null;
        public static void SetDefaultOptions(DbContextOptions<MysqlDbContext> options)
        {
            _defaultOptions = options;
        }
        public MysqlDbContext() : base(_defaultOptions)
        {
        }
        public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
