using System;
using ArticleProject.Entities.Models;

namespace ArticleProject.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ArticleDBContext _dbContext;

        public UnitOfWork(ArticleDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public ArticleDBContext GetDbContext()
        {
            return _dbContext;
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
