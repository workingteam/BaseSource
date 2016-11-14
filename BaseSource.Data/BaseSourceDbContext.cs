using BaseSource.Common;
using System.Data.Entity;

namespace BaseSource.Data
{
    internal class BaseSourceDbContext : DbContext, IBaseSourceDbContext
    {
        public BaseSourceDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<BaseSourceDbContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
    }
}