using ChaleHospedagem.Domain.Models;
using ChaleHospedagem.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace ChaleHospedagem.infrastructure.Repositories
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private IDbConnection db;
        private string tableName = "Cliente";
        private readonly IConfiguration _configuration;

        public RepositoryCliente(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<Cliente> GetAll()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                this.db = new SqlConnection(connection);
            }
            catch (Exception ex)
            {
            }
            
            
            var sql = "SELECT * FROM " + tableName;
            IEnumerable<Cliente> result = null;

            try
            {
                result = this.db.Query<Cliente>(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public void Add(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente obj)
        {
            throw new NotImplementedException();
        }
    }


  
}
