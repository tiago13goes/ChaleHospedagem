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


        public bool Add(Chale obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<Chale> GetAll()
        {
            return _repository.GetAll();
        }

        public Chale GetByCod(int cod)
        {
            return _repository.GetByCod(cod);
        }

        public bool Remove(int cod)
        {
            return _repository.Remove(cod);
        }

        public bool Update(Chale obj)
        {
            return _repository.Update(obj);
        }
    }
}
