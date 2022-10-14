using API.Context;
using API.Models;
using API.Repositories.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class TarefaRepositorio : CrudRepositorio<Tarefa>
    {
        public TarefaRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }
    }
}
