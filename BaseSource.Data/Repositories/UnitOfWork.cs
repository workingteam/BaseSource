using BaseSource.Data;
using BaseSource.Data.Infrastructure;
using BaseSource.Data.Repositories;

namespace ShiningKnight.Data.Repositories
{
    public sealed class UnitOfWork : DisposableObject, IUnitOfWork
    {
        private IDbFactory _factory;
        private IBaseSourceDbContext _context;

        //private IClientRepository _clientRepository;
        //private IClientAdminRepository _clientAdminRepository;
        //private IClientSiteRepository _clientSiteRepository;

        public UnitOfWork()
        {
            _factory = CreateObject(() => new DbFactory());
            _context = _factory.Init();
        }

        public UnitOfWork(IBaseSourceDbContext context)
        {
            _context = context;
        }

        int IUnitOfWork.SaveChanges()
        {
            return SaveChanges();
        }

        //IAccountRepository IUnitOfWork.AccountRepository => AccountRepository;
        //IProfileRepository IUnitOfWork.ProfileRepository => ProfileRepository;
        //IClientRepository IUnitOfWork.ClientRepository => ClientRepository;
       

        private int SaveChanges()
        {
            return _context.SaveChanges();
        }

        //private IAccountRepository AccountRepository => _accountRepository ?? (_accountRepository = new AccountRepository(_context));
        //private IProfileRepository ProfileRepository => _profileRepository ?? (_profileRepository = new ProfileRepository(_context));
        //private IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(_context));
        
        protected override void DisposeCore()
        {
            _factory = null;
            _context = null;

            //_clientRepository = null;
            //_clientAdminRepository = null;
            //_clientSiteRepository = null;
      

            base.DisposeCore();
        }
    }
}