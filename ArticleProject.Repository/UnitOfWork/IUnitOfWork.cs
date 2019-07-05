using ArticleProject.Domain.Common;
using ArticleProject.Entities.Models;
using System;

namespace ArticleProject.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ResultModel Commit();

        ArticleDBContext GetDbContext();
    }
}
