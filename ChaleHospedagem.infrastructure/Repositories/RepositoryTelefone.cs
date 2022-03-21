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
    public class RepositoryTelefone : IRepositoryTelefone
    {
        private readonly IDbConnection db;
        private readonly string tableName = "Telefone";

        public RepositoryTelefone(IConfiguration configuration)
        {
            this.tableName = "Telefone";
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(Telefone obj)
        {
            var sql = string.Format("INSERT INTO {0} (codCliente, telefone) VALUES({1}, '{2}')",
                                    tableName,
                                    obj.codCliente,
                                    obj.telefone);

            try
            {
                return db.Execute(sql) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Telefone> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Telefone>(query);
            return result;
        }


        //this method is not necessary
        public Telefone GetByCod(int codTelefone)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int codTelefone)//it has to include another parameter (telefone)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Telefone telefone)
        {
            var query = $"DELETE FROM {tableName} WHERE codTelefone = '{telefone.telefone}' AND codCliente = {telefone.telefone}";

            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //this method is not necessary, or you delete a telefone or add a new one
        public bool Update(Telefone obj) //it has to change for old cell phone to new cellphone
        {
            throw new NotImplementedException();
        }
    }
}
