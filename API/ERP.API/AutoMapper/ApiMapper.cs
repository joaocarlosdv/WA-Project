using AutoMapper;
using API.Dtos;
using API.Models;

namespace API.AutoMapper
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<Tarefa, TarefaDto>();
            CreateMap<TarefaDto, Tarefa>();
        }
    }
}
