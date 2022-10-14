using AutoMapper;
using API.Dtos;
using API.Interfaces.Repositories.Crud;
using API.Models;
using API.Services.Crud;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class EmpresaService : CrudService<Empresa, EmpresaDto>
    {        
        public EmpresaService(IMapper _mapper, ICrudRepositorio<Empresa> _repositorio) : base(_mapper, _repositorio)
        {
        }

        public override async Task<List<EmpresaDto>> SelectAllAsync()
        {
            var lista = await repositorio.SelectAllAsync();
            var dto = mapper.Map<List<EmpresaDto>>(lista);
            return dto;
        }
        public override async Task<EmpresaDto> SelectByIdAsync(int id)
        {
            var obj = await repositorio.SelectByIdAsync(id);
            var dto = mapper.Map<EmpresaDto>(obj);
            return dto;
        }
    }
}
