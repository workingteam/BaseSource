using BaseSource.Common;
using BaseSource.Data;
using BaseSource.Data.Infrastructure;

namespace BaseSource.Data.Infrastructure
{
    public class DbFactory : DisposableObject, IDbFactory
    {
        private IBaseSourceDbContext _context;
        public DbFactory(IBaseSourceDbContext context)
        {
            _context = context;
        }

        public DbFactory()
        {

        }

        public IBaseSourceDbContext Init()
        {
            if (_context != null) return _context;

            _context = CreateObject(() => new BaseSourceDbContext(Constants.CONNECTION_STRING));

            return _context;
        }


        protected override void DisposeCore()
        {
            _context = null;
        }
    }
}