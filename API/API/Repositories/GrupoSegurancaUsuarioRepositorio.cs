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
    public class GrupoSegurancaUsuarioRepositorio : CrudRepositorio<GrupoSegurancaUsuario>
    {
        public GrupoSegurancaUsuarioRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<GrupoSegurancaUsuario>> SelectAllByIdUsuarioAsync(int idUsuario)
        {
            return await dbContext.GrupoSegurancaUsuario
                .Where(x => x.Id_Usuario == idUsuario)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
