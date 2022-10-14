using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Interfaces.Services.Crud
{
    public interface ICrudService<T, Dto> where T : BaseEntity
    {
        List<Dto> SelectAll();
        Task<List<Dto>> SelectAllAsync();
        Task<List<Dto>> SelectAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes);
        Dto SelectById(int id);
        Task<Dto> SelectByIdAsync(int id);
        Dto Save(Dto entity);
        Task<Dto> SaveAsync(Dto entity);
        Dto Insert(Dto entity);
        Task<Dto> InsertAsync(Dto entity);
        Dto Update(Dto entity);
        Task<Dto> UpdateAsync(Dto entity);
        int Delete(Dto entity);
        Task<int> DeleteAsync(Dto entity);
        Task<int> DeleteAsync(int id);
    }
}
