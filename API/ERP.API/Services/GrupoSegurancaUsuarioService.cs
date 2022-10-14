using AutoMapper;
using API.Dtos;
using API.Interfaces.Repositories.Crud;
using API.Models;
using API.Repositories;
using API.Services.Crud;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class GrupoSegurancaUsuarioService : CrudService<GrupoSegurancaUsuario, GrupoSegurancaUsuarioDto>
    {
        GrupoSegurancaUsuarioRepositorio grupoSegurancaUsuarioRepositorio;

        public GrupoSegurancaUsuarioService(IMapper _mapper, ICrudRepositorio<GrupoSegurancaUsuario> _repositorio) : base(_mapper, _repositorio)
        {
            grupoSegurancaUsuarioRepositorio = (GrupoSegurancaUsuarioRepositorio)_repositorio;
        }

        public async Task<List<GrupoSegurancaUsuarioDto>> SelectAllByIdUsuarioAsync(int idUsuario)
        {
            return mapper.Map<List<GrupoSegurancaUsuarioDto>>(await grupoSegurancaUsuarioRepositorio.SelectAllByIdUsuarioAsync(idUsuario));
        }
    }
}
