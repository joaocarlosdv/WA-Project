using API.Context;
using API.Models;
using API.Repositories.Crud;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class GrupoSegurancaRepositorio : CrudRepositorio<GrupoSeguranca>
    {
        public GrupoSegurancaRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }

        public override async Task<GrupoSeguranca> UpdateAsync(GrupoSeguranca entity)
        {
            entity.GrupoSegurancaUsuario = null;
            entity.GrupoSegurancaTransacao = null;
            entity.GrupoSegurancaEmpresa = null;

            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;            
        }

        public override async Task<GrupoSeguranca> SelectByIdAsync(int id)
        {
            return await dbContext.GrupoSeguranca
                .Include(x=>x.GrupoSegurancaUsuario).ThenInclude(y=>y.Usuario)
                .Include(x=>x.GrupoSegurancaTransacao).ThenInclude(y=>y.Transacao)
                .Include(x=>x.GrupoSegurancaEmpresa).ThenInclude(y=>y.Empresa)
                .Where(x => x.Id == id)
                .OrderByDescending(x => x.Descricao)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }        
    }
}
