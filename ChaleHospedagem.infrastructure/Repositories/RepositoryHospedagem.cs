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
    public class RepositoryHospedagem : IRepositoryHospedagem
    {
        private IDbConnection db;
        private string tableName = "Hospedagem";

        public RepositoryHospedagem(IConfiguration configuration)
        {
            this.tableName = "Hospedagem";
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(Hospedagem obj)
        {
            var query = string.Format("INSERT INTO {0} (codChale, codHospedagem, dataFim, dataInicio, estado, qtdPessoas, valorFinal) VALUES({1}, {2}, '{3}', '{4}', '{5}', {6}, {7})",
                                    tableName,
                                    obj.codChale,
                                    obj.codHospedagem,
                                    obj.dataFim.ToShortDateString(),
                                    obj.dataInicio.ToShortDateString(),
                                    obj.estado,
                                    obj.qtdPessoas,
                                    obj.valorFinal);

            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Hospedagem> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Hospedagem>(query);
            return result;
        }


        public Hospedagem GetByCod(int cod)
        {
            var query = string.Format("SELECT * FROM {0} WHERE codHospedagem = {1}", tableName, cod);
            var result = db.Query<Hospedagem>(query).SingleOrDefault();
            return result;
        }

        public bool Remove(int cod)
        {
            var query = string.Format("DELETE FROM {0} WHERE codHospedagem = {1}",
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

        public bool Update(Hospedagem obj)
        {
            var query = "UPDATE " + tableName + " SET codChale = @codChale, codHospedagem = codHospedagem, dataFim = @dataFim, dataInicio = @dataInicio, estado = @estado, qtdPessoas = @qtdPessoas, valorFinal = @valorFinal WHERE codHospedagem = @codHospedagem";

            var parameters = new DynamicParameters();
            parameters.Add("codHospedagem", obj.codHospedagem, DbType.Int64);
            parameters.Add("codChale", obj.codChale, DbType.Int64);
            parameters.Add("dataFim", obj.dataFim, DbType.DateTime);
            parameters.Add("dataInicio", obj.dataInicio, DbType.DateTime);
            parameters.Add("desconto", obj.desconto, DbType.Double);
            parameters.Add("estado", obj.estado, DbType.Int64);
            parameters.Add("qtdPessoas", obj.qtdPessoas, DbType.Int64);
            parameters.Add("valorFinal", obj.valorFinal, DbType.Double);

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
