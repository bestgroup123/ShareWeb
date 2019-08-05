using Microsoft.EntityFrameworkCore;

namespace Share.Domain.ResourceCenter.Entity
{
    public class MysqlDb_Resource : DbContext
    {
        static DbContextOptions<MysqlDb_Resource> _defaultOptions = null;
        public static void SetDefaultOptions(DbContextOptions<MysqlDb_Resource> options)
        {
            _defaultOptions = options;
        }
        public MysqlDb_Resource() : base(_defaultOptions)
        {
        }
        public MysqlDb_Resource(DbContextOptions<MysqlDb_Resource> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
