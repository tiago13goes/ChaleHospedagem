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
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly IDbConnection db;
        private readonly string tableName = "Cliente";

        public RepositoryCliente(IConfiguration configuration)
        {
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(Cliente obj)
        {
            var query = string.Format("INSERT INTO {0} (bairroCliente, CEPCliente, cidadeCliente, codCliente, enderecoCliente, estadoCliente, nascimentoCliente, rgCliente) VALUES('{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}', '{8}' )",
                                    tableName,
                                    obj.bairroCliente,
                                    obj.CEPCliente,
                                    obj.cidadeCliente,
                                    obj.codCliente,
                                    obj.enderecoCliente,
                                    obj.estadoCliente,
                                    obj.nascimentoCliente.ToShortDateString(),
                                    obj.rgCliente);

            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Cliente> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Cliente>(query);
            return result;
        }


        public Cliente GetByCod(int cod)
        {
            string query = string.Format("SELECT * FROM {0} WHERE codCliente = {1}", tableName, cod);
            var result = db.Query<Cliente>(query).SingleOrDefault();
            return result;
        }

        public bool Remove(int cod)
        {
            string query = string.Format("DELETE FROM {0} WHERE codCliente = {1}",
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

        public bool Update(Cliente obj)
        {
            string query = "UPDATE " + tableName + " SET codCliente = @codCliente," +
                                                      "bairroCliente = @bairroCliente," +
                                                      "CEPCliente = @CEPCliente," +
                                                      "cidadeCliente = @cidadeCliente," +
                                                      "enderecoCliente = @enderecoCliente," +
                                                      "estadoCliente = @estadoCliente," +
                                                      "nascimentoCliente = @nascimentoCliente," +
                                                      "rgCliente = @rgCliente" +
                                                      "WHERE codCliente = @codCliente";

            var parameters = new DynamicParameters();
            parameters.Add("codCliente", obj.codCliente, DbType.Int64);
            parameters.Add("bairroCliente", obj.bairroCliente, DbType.String);
            parameters.Add("CEPCliente", obj.CEPCliente, DbType.String);
            parameters.Add("cidadeCliente", obj.cidadeCliente, DbType.String);
            parameters.Add("enderecoCliente", obj.enderecoCliente, DbType.String);
            parameters.Add("estadoCliente", obj.estadoCliente, DbType.String);
            parameters.Add("nascimentoCliente", obj.nascimentoCliente, DbType.Date);
            parameters.Add("rgCliente", obj.rgCliente, DbType.String);

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
