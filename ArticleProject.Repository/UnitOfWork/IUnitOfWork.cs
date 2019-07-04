using ArticleProject.Entities.Models;
using System;

namespace ArticleProject.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        ArticleDBContext GetDbContext();
    }
}
