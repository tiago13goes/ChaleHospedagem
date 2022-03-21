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
    public class RepositoryItem : IRepositoryItem
    {
        private IDbConnection db;
        private string tableName = "Item";

        public RepositoryItem(IConfiguration configuration)
        {
            this.tableName = "Item";
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(Item obj)
        {
            var sql = string.Format("INSERT INTO {0} (nomeItem, descricaoItem) VALUES('{1}', '{2}')",
                                    tableName,
                                    obj.nomeItem,
                                    obj.descricaoItem);

            try
            {
                return db.Execute(sql) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Item> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Item>(query);
            return result;
        }


        public Item GetByNomeItem(string nomeItem)
        {
            var query = string.Format("SELECT * FROM {0} WHERE nomeItem = '{1}'", tableName, nomeItem);
            var result = db.Query<Item>(query).SingleOrDefault();
            return result;
        }

        public Item GetByCod(int cod)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int nomeItem)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string nomeItem)
        {
            var query = string.Format("DELETE FROM {0} WHERE nomeItem = '{1}'",
                                   tableName,
                                   nomeItem);

            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Update(Item obj)
        {
            var query = "UPDATE " + tableName + " SET descricaoItem = @descricaoItem WHERE nomeItem = @nomeItem";

            var parameters = new DynamicParameters();
            parameters.Add("nomeItem", obj.nomeItem, DbType.String);
            parameters.Add("descricaoItem", obj.descricaoItem, DbType.String);

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
