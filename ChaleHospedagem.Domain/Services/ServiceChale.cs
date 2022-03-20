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
        }

        public IEnumerable<Chale> GetAll()
        {
            return _repository.GetAll();
        }

        public Chale GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Chale obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Chale obj)
        {
            _repository.Update(obj);
        }
    }
}
