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
    public class EmpresaRepositorio : CrudRepositorio<Empresa>
    {
        public EmpresaRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Empresa>> SelectAllAsync()
        {
            return await dbContext.Empresa
                .Include(x => x.Municipio)
                .OrderBy(x => x.RazaoSocial)
                .ToListAsync();
        }

        public override async Task<Empresa> SelectByIdAsync(int id)
        {
            return await dbContext.Empresa
                .Include(x => x.Municipio)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
