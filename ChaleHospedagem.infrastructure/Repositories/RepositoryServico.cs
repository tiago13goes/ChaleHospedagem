using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Infrastructure.Repositories
{
    public class RepositoryServico : IRepositoryServico
    {
        private IDbConnection db;
        private string tableName = "Servico";

        public RepositoryServico(IConfiguration configuration)
        {
            this.tableName = "Servico";
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(Servico obj)
        {
            var query = string.Format("INSERT INTO {0} (nomeServico, valorServico) VALUES('{1}', {2})",
                                    tableName,
                                    obj.nomeServico,
                                    obj.valorServico);

            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public IEnumerable<Servico> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Servico>(query);
            return result;
        }


        public Servico GetByCod(int cod)
        {
            var query = string.Format("SELECT * FROM {0} WHERE codServico = {1}", tableName, cod);
            var result = db.Query<Servico>(query).SingleOrDefault();
            return result;
        }

        public bool Remove(int cod)
        {
            var query = string.Format("DELETE FROM {0} WHERE codServico = {1}",
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

        public bool Update(Servico obj)
        {
            var query = "UPDATE " + tableName + " SET nomeServico = @nomeServico, valorServico = @valorServico WHERE codServico = @codServico";

            var parameters = new DynamicParameters();
            parameters.Add("codServico", obj.codServico, DbType.Int64);
            parameters.Add("nomeServico", obj.nomeServico, DbType.String);
            parameters.Add("valorServico", obj.valorServico, DbType.String);

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
