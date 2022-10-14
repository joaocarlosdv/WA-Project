using API.Context;
using API.Dtos;
using API.Interfaces.Repositories;
using API.Models;
using API.Repositories.Crud;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class TesteRepositorio : CrudRepositorio<Teste>
    {        
        public TesteRepositorio(ApiContext dbContext) : base(dbContext)
        {
        }

        //public List<Teste> TesteSelectAll()
        //{
        //    string connectionString = "User ID=postgres;Password=123;Host=localhost;Port=5432;Database=erp;Pooling=true;SearchPath=public";
        //    NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        //    conn.Open();

        //    string sql = "Select * from teste";

        //    NpgsqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = sql;
        //    cmd.CommandTimeout = 7200;

        //    DataTable dt = new DataTable();
        //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    conn.Close();

        //    List<Teste> lista = new List<Teste>();
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        lista.Add(new Teste { Id = Convert.ToInt32(dr["Id"].ToString()),
        //                              Nome = dr["Nome"].ToString(),
        //                              DataNascimento = (DateTime?)Convert.ToDateTime(dr["DataNascimento"].ToString()),
        //                              AnoAdmissao = Convert.ToInt32(dr["AnoAdmissao"].ToString()),
        //                              Salario = Convert.ToDecimal(dr["Salario"].ToString()),
        //                              Ativo = Convert.ToBoolean(dr["Ativo"].ToString()),
        //                              AlteracaoUsuario = dr["AlteracaoUsuario"].ToString(),
        //                              AlteracaoDataHora = Convert.ToDateTime(dr["AlteracaoDataHora"].ToString())
        //        });
        //    }

        //    return lista;
        //}

        public List<Teste> SelectAllByNomeLike(string nome)
        {
            return dbContext.Teste
                .Where(x => x.Nome.Contains(nome))
                .OrderBy(x => x.Nome)
                .AsNoTracking()
                .ToList();
        }

        public async Task<List<Teste>> SelectAllByNomeLikeAsync(string nome)
        {
            return await dbContext.Teste
                .Where(x => x.Nome.Contains(nome))
                .OrderBy(x => x.Nome)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
