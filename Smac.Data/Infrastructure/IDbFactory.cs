using System;

namespace Smac.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SmacDbContext Init();
    }
}