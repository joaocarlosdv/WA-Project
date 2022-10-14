using AutoMapper;
using API.Dtos;
using API.Functions;
using API.Interfaces.Repositories.Crud;
using API.Interfaces.Services.Crud;
using API.Models;
using API.Repositories;
using API.Services.Crud;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;

namespace API.Services
{
    public class UsuarioService : CrudService<Usuario, UsuarioDto>
    {
        UsuarioRepositorio usuarioRepositorio;
        GrupoSegurancaUsuarioService grupoSegurancaUsuarioService;
        GrupoSegurancaService grupoSegurancaService;
        public UsuarioService(
            IMapper _mapper,
            ICrudRepositorio<Usuario> _repositorio,
            ICrudService<GrupoSeguranca, GrupoSegurancaDto> _grupoSegurancaService,
            ICrudService<GrupoSegurancaUsuario, GrupoSegurancaUsuarioDto> _grupoSegurancaUsuarioService) : base(_mapper, _repositorio)
        {
            usuarioRepositorio = (UsuarioRepositorio)_repositorio;
            grupoSegurancaService = (GrupoSegurancaService)_grupoSegurancaService;
            grupoSegurancaUsuarioService = (GrupoSegurancaUsuarioService)_grupoSegurancaUsuarioService;
        }

        public async Task<List<UsuarioDto>> SelectAllByFiltrosAsync(string nome, string login, string email)
        {
            var lista = await usuarioRepositorio.SelectAllByFiltrosAsync(nome, login, email);
            var listaDto = mapper.Map<List<UsuarioDto>>(lista);
            return listaDto;
        }

        public override async Task<UsuarioDto> SaveAsync(UsuarioDto entity)
        {            
            var obj = mapper.Map<Usuario>(entity);
            if (obj.Id == 0)
            {
                obj.Senha = ClassFuncions.criptoMD5(entity.Senha);
                return mapper.Map<UsuarioDto>(await repositorio.InsertAsync(obj));
            }
            else
            {
                return mapper.Map<UsuarioDto>(await usuarioRepositorio.UpdateAsync(obj));
            }
        }

        public async Task<UsuarioAutenticadoDto> Login(string login, string senha)
        {
            UsuarioAutenticadoDto autenticado = new UsuarioAutenticadoDto();
            autenticado.DataCriacao = DateTime.Now;
            autenticado.DataExpiracao = DateTime.Now.AddMinutes(30);
            autenticado.Autenticado = true;

            var usuario = await usuarioRepositorio.SelectByLoginAsync(login);
            if (usuario != null && usuario.Senha == ClassFuncions.criptoMD5(senha))
            {
                autenticado.Usuario = mapper.Map<UsuarioDto>(usuario);

                var listaGrupos = await grupoSegurancaUsuarioService.SelectAllByIdUsuarioAsync(usuario.Id);
                foreach(var obj in listaGrupos)
                {
                    var grupo = await grupoSegurancaService.SelectByIdAsync(obj.Id_GrupoSeguranca);
                    autenticado.Grupos.Add(grupo.Descricao);
                    foreach (var transacao in grupo.GrupoSegurancaTransacao)
                    {
                        if (autenticado.Transacoes.Where(x=>x.Codigo == transacao.Transacao.Codigo).Count() == 0)
                        {
                            autenticado.Transacoes.Add(transacao.Transacao);
                        }
                    }
                }                

                #region Gerar Token
                ClaimsIdentity identity = new ClaimsIdentity(
                            new GenericIdentity(autenticado.Usuario.Id.ToString(), "Login"),
                            new[] {
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                                new Claim("id", autenticado.Usuario.Id.ToString()),
                                new Claim("email", autenticado.Usuario.Email)
                            }
                        );
                var handler = new JwtSecurityTokenHandler();

                SecurityKey Key;
                using (var provider = new RSACryptoServiceProvider(2048))
                {
                    Key = new RsaSecurityKey(provider.ExportParameters(true));
                }

                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = "Authentication",
                    Audience = "ERPAPI",
                    SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature),
                    Subject = identity,
                    NotBefore = autenticado.DataCriacao,
                    Expires = autenticado.DataExpiracao
                });

                autenticado.Token = handler.WriteToken(securityToken);
                #endregion Gerar Token

                return autenticado;
            }
            return null;
        }
    }
}
