using API.Controllers.Crud;
using API.Dtos;
using API.Interfaces.Services.Crud;
using API.Models;

namespace API.Controllers
{
    public class TarefaController : CrudController<Tarefa, TarefaDto>
    {
        public TarefaController(ICrudService<Tarefa, TarefaDto> service) : base(service)
        {
        }
    }
}
