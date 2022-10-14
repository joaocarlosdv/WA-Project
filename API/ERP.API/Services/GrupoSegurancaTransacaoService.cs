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
    public class GrupoSegurancaTransacaoService : CrudService<GrupoSegurancaTransacao, GrupoSegurancaTransacaoDto>
    {
        public GrupoSegurancaTransacaoService(IMapper _mapper, ICrudRepositorio<GrupoSegurancaTransacao> _repositorio) : base(_mapper, _repositorio)
        {
        }

        public void DeleteByIdGrupoSeguranca(int idGrupoSeguranca)
        {
            List<GrupoSegurancaTransacao> lista = repositorio.SelectAll().Where(x => x.Id_GrupoSeguranca == idGrupoSeguranca).ToList();
            foreach(var obj in lista)
            {
                repositorio.DeleteAsync(obj);
            }
        }

        public async Task<int> DeleteByIdGrupoSegurancaIdTransacao(int idGrupoSeguranca)
        {
            List<GrupoSegurancaTransacao> lista = repositorio.SelectAll().Where(x => x.Id_GrupoSeguranca == idGrupoSeguranca).ToList();
            if (lista.Count > 0)
            {
                return await repositorio.DeleteRangeAsync(lista);
            }

            return 0;
        }

        public async Task<List<GrupoSegurancaTransacaoDto>> InsertTransacoes(List<GrupoSegurancaTransacaoDto> lista)
        {
            await DeleteByIdGrupoSegurancaIdTransacao(lista[0].Id_GrupoSeguranca);
            var retorno = await repositorio.InsertRangeAsync(mapper.Map<List<GrupoSegurancaTransacao>>(lista));
            return mapper.Map<List<GrupoSegurancaTransacaoDto>>(retorno);
        }
    }
}
