using AutoMapper;
using API.Dtos;
using API.Interfaces.Repositories.Crud;
using API.Models;
using API.Repositories;
using API.Services.Crud;
using System.Threading.Tasks;

namespace API.Services
{
    public class GrupoSegurancaService : CrudService<GrupoSeguranca, GrupoSegurancaDto>
    {
        GrupoSegurancaRepositorio grupoSegurancaRepositorio;

        public GrupoSegurancaService(IMapper _mapper, ICrudRepositorio<GrupoSeguranca> _repositorio) : base(_mapper, _repositorio)
        {
            grupoSegurancaRepositorio = (GrupoSegurancaRepositorio)_repositorio;
        }

        public async override Task<GrupoSegurancaDto> SelectByIdAsync(int id)
        {
            return mapper.Map<GrupoSegurancaDto>(await grupoSegurancaRepositorio.SelectByIdAsync(id));
        }

        public override async Task<GrupoSegurancaDto> SaveAsync(GrupoSegurancaDto entity)
        {
            var obj = mapper.Map<GrupoSeguranca>(entity);
            if (obj.Id == 0)
            {
                return mapper.Map<GrupoSegurancaDto>(await repositorio.InsertAsync(obj));
            }
            else
            {
                return mapper.Map<GrupoSegurancaDto>(await grupoSegurancaRepositorio.UpdateAsync(obj));
            }
        }
    }
}
