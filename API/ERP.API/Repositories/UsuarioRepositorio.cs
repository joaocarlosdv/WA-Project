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
    public class UsuarioRepositorio : CrudRepositorio<Usuario>
    {
        public UsuarioRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Usuario>> SelectAllByFiltrosAsync(string nome, string login, string email)
        {
            return await dbContext.Usuario
                .Where(x => (x.Nome.Contains(nome) || nome == null) && (x.Login.Contains(login) || login == null) && (x.Email.Contains(email) || email == null))
                .OrderByDescending(x => x.Nome)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Usuario> UpdateAsync(Usuario entity)
        {
            var entry = dbContext.Entry(entity);
            entry.Property(x => x.Senha).IsModified = false;
            entry.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Usuario> SelectByLoginAsync(string login)
        {
            return await dbContext.Usuario
                .Where(x => x.Login == login && x.Ativo)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
