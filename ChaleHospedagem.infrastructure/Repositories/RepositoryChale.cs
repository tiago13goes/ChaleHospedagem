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
            catch (Exception ex)
            {

            }
        }


        public void Add(Chale obj)
        {
            var sql = string.Format("INSERT INTO {0} (localizacao, capacidade, valorAltaEstacao, valorBaixaEstacao) VALUES('{1}', {2}, {3}, {4})",
                                    tableName,
                                    obj.localizacao,
                                    obj.capacidade,
                                    (double)obj.valorAltaEstacao,
                                    (double)obj.valorBaixaEstacao);

            
            bool success = db.Execute(sql) > 0;
        }

        public IEnumerable<Chale> GetAll()
        {
            var sql = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Chale>(sql);
            return result;
        }


        public Chale GetById(int id)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE codChale = {1}", tableName, id);
            var result = db.Query<Chale>(sql).SingleOrDefault();
            return result;
        }

        public void Remove(Chale obj)
        {
            var sql = string.Format("DELETE FROM {0} WHERE codChale = {1}",
                                    tableName,
                                    obj.codChale);
            
            var query = string.Format("DELETE FROM {0} WHERE codChale = @codChale", tableName);

            var parameters = new DynamicParameters();
            parameters.Add("codChale", obj.codChale, DbType.Int64);

            var teste = db.Query<Chale>(query, parameters).FirstOrDefault();
            bool success = db.Execute(query, parameters) > 0;

        }

        public void Update(Chale obj)
        {
            var query = "UPDATE " + tableName + " SET localizacao = @localizacao, capacidade = @capacidade, valorAltaEstacao = @valorAltaEstacao, valorBaixaEstacao = @valorBaixaEstacao WHERE codChale = @codChale";

            var parameters = new DynamicParameters();
            parameters.Add("codChale", obj.codChale, DbType.Int64);
            parameters.Add("localizacao", obj.localizacao, DbType.String);
            parameters.Add("capacidade", obj.capacidade, DbType.Int64);
            parameters.Add("valorAltaEstacao", obj.valorAltaEstacao, DbType.Double);
            parameters.Add("valorBaixaEstacao", obj.valorBaixaEstacao, DbType.Double);
            
            bool success = db.Execute(query, parameters) > 0;
        }
    }
}
