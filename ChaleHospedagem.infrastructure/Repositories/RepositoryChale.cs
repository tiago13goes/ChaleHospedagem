using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using NUnit.Framework;

namespace ChaleHospedagem.Infrastructure.Repositories
{
    public class RepositoryChale : IRepositoryChale
    {
        private IDbConnection db;
        private string tableName = "Chale";

        public RepositoryChale(IConfiguration configuration)
        {
            this.tableName = "Chale";
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch(Exception ex)
            {

            }
        }


        public void Add(Chale obj)
        {
            //var sql = "INSERT INTO @tableName (localizacao, capacidade, valorAltaEstacao, valorBaixaEstacao) VALUES(@localizacao, @capacidade, @valorAltaEstacao, @valorBaixaEstacao)";
            var sql = string.Format("INSERT INTO {0} (localizacao, capacidade, valorAltaEstacao, valorBaixaEstacao) VALUES('{1}', {2}, {3}, {4})", tableName, obj.localizacao, obj.capacidade, (double)obj.valorAltaEstacao, (double)obj.valorBaixaEstacao);
            
            var result = db.Query<Chale>(sql);
        }

        public IEnumerable<Chale> GetAll()
        {
            var sql = "SELECT * FROM @tableName";
            var result = db.Query<Chale>(sql, new { @tableName = this.tableName });
            return result;
        }

        public Chale GetById(int id)
        {
            var sql = "SELECT * FROM @tableName WHERE codChale = @id";
            var result = db.Query<Chale>(sql, new { @id = id, @tableName = this.tableName }).SingleOrDefault();
            return result;
        }

        public void Remove(Chale obj)
        {
            var sql = "DELETE FROM @tableName WHERE codChale = @id";
            var result = db.Query<Chale>(sql, new { @id = obj.codChale, @tableName = this.tableName}).SingleOrDefault();
        }

        public void Update(Chale obj)
        {
            var sql = "UPDATE @tableName SET localizacao = @localizacao, capacidade = @capacidade, valorAltaEstacao = @valorAltaEstacao, valorBaixaEstacao = @valorBaixaEstacao WHERE codChale = @id";
            var result = db.Query<Chale>(sql, new
            {
                @id = obj.codChale,
                @localizacao = obj.localizacao,
                @capacidade = obj.capacidade,
                @valorAltaEstacao = obj.valorAltaEstacao,
                @valorBaixaEstacao = obj.valorBaixaEstacao,
                @tableName = this.tableName
            });

            throw new NotImplementedException();
        }
    }
}
