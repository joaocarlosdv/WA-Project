using AutoMapper;
using API.Dtos;
using API.Interfaces.Repositories.Crud;
using API.Models;
using API.Services.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class GrupoSegurancaEmpresaService : CrudService<GrupoSegurancaEmpresa, GrupoSegurancaEmpresaDto>
    {
        public GrupoSegurancaEmpresaService(IMapper _mapper, ICrudRepositorio<GrupoSegurancaEmpresa> _repositorio) : base(_mapper, _repositorio)
        {
        }
    }
}
