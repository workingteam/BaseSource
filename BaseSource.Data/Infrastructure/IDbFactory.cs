using System;

namespace BaseSource.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        IBaseSourceDbContext Init();
    }
}
