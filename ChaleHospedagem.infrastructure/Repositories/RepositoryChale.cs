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

            Chale result = db.Query<Chale>(sql).FirstOrDefault();
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
            var sql = string.Format("DELETE FROM {0} WHERE codChale = {1}", tableName, obj.codChale);
            var result = db.Query<Chale>(sql).FirstOrDefault();
        }

        public void Update(Chale obj)
        {
            var sql = string.Format("UPDATE {0} SET localizacao = '{1}', capacidade = {2}, valorAltaEstacao = {3}, valorBaixaEstacao = {4} WHERE codChale = {5}",
                                   this.tableName,
                                   obj.localizacao,
                                   obj.capacidade,
                                   obj.valorAltaEstacao,
                                   obj.valorBaixaEstacao,
                                   obj.codChale
                                   );

            var result = db.QueryFirstOrDefault<dynamic>(sql);
            

        }
    }
}
