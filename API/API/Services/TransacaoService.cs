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
    public class TransacaoService : CrudService<Transacao, TransacaoDto>
    {
        public TransacaoService(IMapper _mapper, ICrudRepositorio<Transacao> _repositorio) : base(_mapper, _repositorio)
        {
        }
    }
}
