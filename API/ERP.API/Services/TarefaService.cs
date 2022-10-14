using API.Dtos;
using API.Interfaces.Repositories.Crud;
using API.Models;
using API.Services.Crud;
using AutoMapper;

namespace API.Services
{
    public class TarefaService : CrudService<Tarefa, TarefaDto>
    {
        public TarefaService(IMapper _mapper, ICrudRepositorio<Tarefa> _repositorio) : base(_mapper, _repositorio)
        {
        }
    }
}
