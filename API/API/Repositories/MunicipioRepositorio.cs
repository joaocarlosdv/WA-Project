using API.Context;
using API.Models;
using API.Repositories.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class MunicipioRepositorio : CrudRepositorio<Municipio>
    {
        public MunicipioRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }
    }
}
