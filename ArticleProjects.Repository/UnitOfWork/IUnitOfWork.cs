using Nuevo.Entities.Data;
using System;

namespace Nuevo.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        ApplicationDbContext GetDbContext();
    }
}
