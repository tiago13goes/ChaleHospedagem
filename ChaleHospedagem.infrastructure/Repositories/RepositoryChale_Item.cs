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
    public class RepositoryChale_Item : IRepositoryChale_Item
    {
        private IDbConnection db;
        private string tableName = "Chale_Item";

        public RepositoryChale_Item(IConfiguration configuration)
        {
            this.tableName = "Chale_Item";
            try
            {
                this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(Chale_Item obj)
        {
            var sql = string.Format("INSERT INTO {0} (codChale, nomeItem) VALUES({1}, '{2}')",
                                    tableName,
                                    obj.codChale,
                                    obj.nomeItem);

            try
            {
                return db.Execute(sql) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Chale_Item> GetAll()
        {
            var query = string.Format("SELECT * FROM {0}", tableName);
            var result = db.Query<Chale_Item>(query);
            return result;
        }


        //this method is not necessary
        public Chale_Item GetByCod(int codChale)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Chale_Item chale_Item)
        {
            var query = string.Format("DELETE FROM {0} WHERE codChale = {1} AND nomeItem = '{2}'",
                                    tableName,
                                    chale_Item.codChale, chale_Item.nomeItem);
            try
            {
                return db.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Remove(int cod)
        {
            throw new NotImplementedException();
        }


        //there's no way to update it, you have to delete an item or add a new one
        public bool Update(Chale_Item obj)
        {
            throw new NotImplementedException();
        }


    }
}
