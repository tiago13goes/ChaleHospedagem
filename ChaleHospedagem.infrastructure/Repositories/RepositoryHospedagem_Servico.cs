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
    public class RepositoryHospedagem_Servico : IRepositoryHospedagem_Servico
    {
        private readonly IDbConnection db;
        private readonly string tableName = "Hospedagem_Servico";

        public RepositoryHospedagem_Servico(IConfiguration configuration)
        {
            this.tableName = "Hospedagem_Servico";
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(Hospedagem_Servico obj)
        {
            var sql = string.Format("INSERT INTO {0} (codHospedagem, codServico, dataServico) VALUES({1}, {2}, '{3}')",
                                    tableName,
                                    obj.codHospedagem,
                                    obj.codServico,
                                    obj.dataServico.ToShortDateString());

            try
            {
                return db.Execute(sql) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Hospedagem_Servico> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Hospedagem_Servico>(query);
            return result;
        }


        public Hospedagem_Servico GetByCod(int codServico)
        {
            throw new NotImplementedException();
            
        }

        public Hospedagem_Servico GetByHospedagemServico(Hospedagem_Servico obj)
        {
            var query = string.Format("SELECT * FROM {0} WHERE codHospedagem = {1} AND codServico = {2}", tableName, obj.codHospedagem, obj.codServico);
            var result = db.Query<Hospedagem_Servico>(query).SingleOrDefault();
            return result;
        }

        public bool Remove(int codServico)
        {
            throw new NotImplementedException();
            
        }

        public bool Remove(Hospedagem_Servico obj)
        {
            var query = string.Format("DELETE FROM {0} WHERE codHospedagem = {1} AND codServico = {2}",
                                    tableName,
                                    obj.codHospedagem,
                                    obj.codServico);

            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Update(Hospedagem_Servico obj)
        {
            var query = "UPDATE " + tableName + " SET dataServico = @dataServico WHERE codHospedagem = @codHospedagem AND codServico = @codServico";

            var parameters = new DynamicParameters();
            parameters.Add("codHospedagem", obj.codHospedagem, DbType.Int64);
            parameters.Add("codServico", obj.codServico, DbType.Int64);
            parameters.Add("dataServico", obj.dataServico, DbType.DateTime);

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
