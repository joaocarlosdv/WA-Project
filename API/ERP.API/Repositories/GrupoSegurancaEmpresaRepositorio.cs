using API.Context;
using API.Models;
using API.Repositories.Crud;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class GrupoSegurancaEmpresaRepositorio : CrudRepositorio<GrupoSegurancaEmpresa>
    {
        public GrupoSegurancaEmpresaRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }
        public override async Task<List<GrupoSegurancaEmpresa>> SelectAllAsync()
        {
            return await dbContext.GrupoSegurancaEmpresa
                .Include(x => x.GrupoSeguranca)
                .Include(x => x.Empresa)
                .ToListAsync();
        }
    }
}
