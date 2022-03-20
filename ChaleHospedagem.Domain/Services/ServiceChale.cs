using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Interface.Services;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Services
{
    public class ServiceChale : IServiceChale
    {

        private readonly IRepositoryChale _repository;

        public ServiceChale(IRepositoryChale repository)
        {
            _repository = repository;
        }


        public void Add(Chale obj)
        {
            _repository.Add(obj);
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
