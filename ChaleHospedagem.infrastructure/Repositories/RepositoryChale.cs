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
        private readonly IDbConnection db;
        private readonly string tableName = "Chale";

        public RepositoryChale(IConfiguration configuration)
        {
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {

            }
        }

        public bool Add(Chale obj)
        {
            var sql = string.Format("INSERT INTO {0} (localizacao, capacidade, valorAltaEstacao, valorBaixaEstacao) VALUES('{1}', {2}, {3}, {4})",
                                    tableName,
                                    obj.localizacao,
                                    obj.capacidade,
                                    obj.valorAltaEstacao,
                                    obj.valorBaixaEstacao);

            try
            {
                return db.Execute(sql) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Chale> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Chale>(query);
            return result;
        }


        public Chale GetByCod(int cod)
        {
            var query = string.Format("SELECT * FROM {0} WHERE codChale = {1}", tableName, cod);
            var result = db.Query<Chale>(query).SingleOrDefault();
            return result;
        }

        public bool Remove(int cod)
        {
            var query = string.Format("DELETE FROM {0} WHERE codChale = {1}",
                                    tableName,
                                    cod);

            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Update(Chale obj)
        {
            var query = "UPDATE " + tableName + " SET localizacao = @localizacao, capacidade = @capacidade, valorAltaEstacao = @valorAltaEstacao, valorBaixaEstacao = @valorBaixaEstacao WHERE codChale = @codChale";

            var parameters = new DynamicParameters();
            parameters.Add("codChale", obj.codChale, DbType.Int64);
            parameters.Add("localizacao", obj.localizacao, DbType.String);
            parameters.Add("capacidade", obj.capacidade, DbType.Int64);
            parameters.Add("valorAltaEstacao", obj.valorAltaEstacao, DbType.Double);
            parameters.Add("valorBaixaEstacao", obj.valorBaixaEstacao, DbType.Double);

            try
            {
                return db.Execute(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
