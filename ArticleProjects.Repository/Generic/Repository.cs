using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ArticleProject.Entities.Models;
using ArticleProjects.Repository.Extensions;
using Nuevo.Repository.UnitOfWork;

namespace ArticleProjects.Repository.Generic
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        #region Ctor

        private readonly DbSet<T> _dbSet;


        public Repository(IUnitOfWork unitOfWork)
        {
            _dbSet = unitOfWork.GetDbContext().Set<T>();
        }

        #endregion

        public IQueryable<T> Find(Expression<Func<T, bool>> filter = null, Func<IIncludable<T>, IIncludable> includes = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (includes != null)
                query = query.IncludeMultiple(includes);


            return query;
        }

        public T GetById(int id, Func<IIncludable<T>, IIncludable> includes = null)
        {
            var query = _dbSet.AsQueryable();

            if (includes != null)
                query = query.IncludeMultiple(includes);

            return query.FirstOrDefault(e => e.Id == id);
        }

        public void Create(T entity)
        {
            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;

            _dbSet.Update(entity);
        }

        public void Delete(int id, bool forceDelete = true)
        {
            var entity = GetById(id);
            if (forceDelete)
            {
                _dbSet.Remove(entity);
            }
            else
            {
                entity.StatusId = -1;
                Update(entity);
            }
        }
    }
}
