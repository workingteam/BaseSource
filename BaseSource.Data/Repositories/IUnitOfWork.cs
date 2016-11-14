using System;

namespace BaseSource.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        //IClientRepository ClientRepository { get; }
        //IProfileRepository ProfileRepository { get; }
        //IAccountRepository AccountRepository { get; }
      
    }
}
