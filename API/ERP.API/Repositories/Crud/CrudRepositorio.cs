using API.Context;
using API.Interfaces.Repositories.Crud;
using API.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Repositories.Crud
{
    public class CrudRepositorio<T> : ICrudRepositorio<T> where T : BaseEntity
    {
        protected readonly ApiContext dbContext;
        protected DbSet<T> DbSet => dbContext.Set<T>();

        public CrudRepositorio(ApiContext dbContext)
        {
            this.dbContext = dbContext;
        }        

        public virtual List<T> SelectAll()
        {
            var lista = dbContext.Set<T>()
                .ToList();
            return lista;
        }        
        public virtual async Task<List<T>> SelectAllAsync()
        {
            try
            {
                var lista = await dbContext.Set<T>()
                .ToListAsync();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
        public virtual async Task<List<T>> SelectAllAsync(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>>[] includes)
        {
            try
            {  
                var lista = dbContext.Set<T>();

                if (predicate != null)
                {
                    lista.Where(predicate);
                }                

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        lista.Include(include);
                    }
                }

                return await lista.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual T SelectById(int id)
        {
            return dbContext.Set<T>()
                .FirstOrDefault(e => e.Id == id);
        }
        public virtual async Task<T> SelectByIdAsync(int id)
        {
            return await dbContext.Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public virtual T Insert(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public virtual async Task<T> InsertAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<T>> InsertRangeAsync(List<T> list)
        {
            await dbContext.Set<T>().AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
            return list;
        }

        public virtual T Update(T entity)
        {
            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }
        public virtual async Task<T> UpdateAsync(T entity)
        {
            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual int Delete(T entity)
        {
            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
            return dbContext.SaveChanges();
        }
        public virtual async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteRangeAsync(List<T> list)
        {
            dbContext.Set<T>().RemoveRange(list);
            return await dbContext.SaveChangesAsync();


            //var db = new MyDbContext();
            //var itemsToDelete = db.MyTable.Where(x => !x.active);
            //db.MyTable.RemoveRange(itemsToDelete);
            //db.SaveChanges();
        }
    }
}
