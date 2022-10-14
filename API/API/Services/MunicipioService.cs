using AutoMapper;
using API.Dtos;
using API.Interfaces.Repositories.Crud;
using API.Models;
using API.Services.Crud;

namespace API.Services
{
    public class MunicipioService : CrudService<Municipio, MunicipioDto>
    {
        public MunicipioService(IMapper _mapper, ICrudRepositorio<Municipio> _repositorio) : base(_mapper, _repositorio)
        {
        }
    }
}
