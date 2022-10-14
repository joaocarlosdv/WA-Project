using AutoMapper;
using API.Interfaces.Repositories.Crud;
using API.Interfaces.Services.Crud;
using API.Models;
using API.Models.Base;
using API.Repositories.Crud;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services.Crud
{    
    public class CrudService<T, Dto> : ICrudService<T, Dto> where T : BaseEntity
    {
        public readonly IMapper mapper;
        public readonly ICrudRepositorio<T> repositorio;

        public CrudService(IMapper _mapper, ICrudRepositorio<T> _repositorio)
        {
            this.mapper = _mapper;
            this.repositorio = _repositorio;
        }        

        public virtual List<Dto> SelectAll()
        {
            var lista = mapper.Map<List<Dto>>(repositorio.SelectAll());
            return lista;
        }
        public virtual async Task<List<Dto>> SelectAllAsync()
        {
            var lista = await repositorio.SelectAllAsync();
            var dto = mapper.Map<List<Dto>>(lista);  
            return dto;
        }

        public virtual async Task<List<Dto>> SelectAllAsync(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>>[] includes)
        {
            var lista = await repositorio.SelectAllAsync(predicate, includes);
            var dto = mapper.Map<List<Dto>>(lista);
            return dto;
        }

        public virtual Dto SelectById(int id)
        {
            return mapper.Map<Dto>(repositorio.SelectById(id));
        }
        public virtual async Task<Dto> SelectByIdAsync(int id)
        {
            return mapper.Map<Dto>(await repositorio.SelectByIdAsync(id));
        }

        public virtual Dto Save(Dto entity)
        {
            var obj = mapper.Map<T>(entity);
            if (obj.Id == 0)
            {
                return mapper.Map<Dto>(repositorio.Insert(obj));
            }
            else
            {
                return mapper.Map<Dto>(repositorio.Update(obj));
            }   
        }
        public virtual async Task<Dto> SaveAsync(Dto entity)
        {
            var obj = mapper.Map<T>(entity);
            if (obj.Id == 0)
            {
                return mapper.Map<Dto>(await repositorio.InsertAsync(obj));
            }
            else
            {
                return mapper.Map<Dto>(await repositorio.UpdateAsync(obj));
            }    
        }

        public virtual Dto Insert(Dto entity)
        {
            var obj = mapper.Map<T>(entity);
            return mapper.Map<Dto>(repositorio.Insert(obj));
        }
        public virtual async Task<Dto> InsertAsync(Dto entity)
        {            
            var obj = mapper.Map<T>(entity);
            return mapper.Map<Dto>(await repositorio.InsertAsync(obj));
        }

        public virtual Dto Update(Dto entity)
        {
            var obj = mapper.Map<T>(entity);
            return mapper.Map<Dto>(repositorio.Update(obj));
        }
        public virtual async Task<Dto> UpdateAsync(Dto entity)
        {
            var obj = mapper.Map<T>(entity);
            return mapper.Map<Dto>(await repositorio.UpdateAsync(obj));
        }

        public virtual int Delete(Dto entity)
        {
            return repositorio.Delete(mapper.Map<T>(entity));
        }
        public virtual async Task<int> DeleteAsync(Dto entity)
        {
            return await repositorio.DeleteAsync(mapper.Map<T>(entity));
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            T obj = await repositorio.SelectByIdAsync(id);
            return await repositorio.DeleteAsync(obj);
        }
    }
}
