using AutoMapper;
using API.Dtos;
using API.Interfaces.Repositories;
using API.Interfaces.Repositories.Crud;
using API.Interfaces.Services;
using API.Interfaces.Services.Crud;
using API.Models;
using API.Repositories;
using API.Services.Crud;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace API.Services
{
    public class TesteService : CrudService<Teste, TesteDto>
    {
        TesteRepositorio testeRepositorio;

        public TesteService(IMapper _mapper, ICrudRepositorio<Teste> _repositorio, ICrudRepositorio<Teste> _testeRepositorio) : base(_mapper, _repositorio)
        {
            testeRepositorio = (TesteRepositorio) _testeRepositorio;
        }

        //public List<Teste> TesteSelectAll()
        //{
        //    return testeRepositorio.TesteSelectAll();
        //}

        public List<TesteDto> SelectAllByNomeLike(string nome)
        {
            return mapper.Map<List<TesteDto>>(testeRepositorio.SelectAllByNomeLike(nome));
        }
        public async Task<List<TesteDto>> SelectAllByNomeLikeAsync(string nome)
        {
            var lista = await testeRepositorio.SelectAllByNomeLikeAsync(nome);
            var listaDto = mapper.Map<List<TesteDto>>(lista);
            return listaDto;
        }        
    }
}

