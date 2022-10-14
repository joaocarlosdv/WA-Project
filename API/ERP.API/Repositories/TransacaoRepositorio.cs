using API.Context;
using API.Models;
using API.Repositories.Crud;

namespace API.Repositories
{
    public class TransacaoRepositorio : CrudRepositorio<Transacao>
    {
        public TransacaoRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }
    }
}
