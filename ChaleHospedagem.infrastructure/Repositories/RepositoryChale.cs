using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaleHospedagem.infrastructure.Context;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace ChaleHospedagem.infrastructure.Repositories
{
    public class RepositoryChale : IRepositoryChale
    {
        private IDbConnection db;
        private string tableName = "Chale";

        public RepositoryChale(IConfiguration configuration)
        {
            var configurationR = configuration.GetConnectionString("DefaultConnection");
            this.db = new SqlConnection(configurationR);
        }


        public void Add(Chale obj)
        {
            var sql = "SELECT * FROM " + tableName;
            db.Query<Chale>(sql);
            throw new NotImplementedException();
        }

        public IEnumerable<Chale> GetAll()
        {
            throw new NotImplementedException();
        }

        public Chale GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Chale obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Chale obj)
        {
            throw new NotImplementedException();
        }
    }
}
