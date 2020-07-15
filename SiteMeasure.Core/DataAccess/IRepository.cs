using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiteMeasure.Core.DataAccess
{
    public interface IRepository<T> where T : class
    {
        bool Any(Expression<Func<T, bool>> predicate);

        T Add(T obj);
        T Update(T obj);
        void Delete(Guid id);
        bool Contains(T entity);

        Task<T> AddAsync(T obj);
        void AddOrUpdate(IEnumerable<T> objs);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> obj);
        Task DeleteAsync(Guid id);
        void Delete(T obj);
        void DeleteRange(IEnumerable<T> obj);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy<T2>(Expression<Func<T, bool>> predicate, params Expression<Func<T, T2>>[] paths);
        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithIncludies(params Expression<Func<T, object>>[] includeProperties);


        T GetById(Guid id);
        T GetByIdWithIncludies(Guid id, params Expression<Func<T, object>>[] includeProperties);
    }
}
