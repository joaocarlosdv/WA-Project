using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Interfaces.Repositories.Crud
{
    public interface ICrudRepositorio<T> where T : BaseEntity
    {
        List<T> SelectAll();
        Task<List<T>> SelectAllAsync();
        Task<List<T>> SelectAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes);
        T SelectById(int id);
        Task<T> SelectByIdAsync(int id);
        T Insert(T entity);
        Task<T> InsertAsync(T entity);
        Task<List<T>> InsertRangeAsync(List<T> list);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteRangeAsync(List<T> list);
    }
}
