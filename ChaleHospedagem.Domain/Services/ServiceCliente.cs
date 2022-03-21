using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Interface.Services;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Services
{
    public class ServiceCliente : IServiceCliente
    {

        private readonly IRepositoryCliente _repository;

        public ServiceCliente(IRepositoryCliente repository)
        {
            _repository = repository;
        }


        public bool Add(Cliente obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _repository.GetAll();
        }

        public Cliente GetByCod(int cod)
        {
            return _repository.GetByCod(cod);
        }

        public bool Remove(int cod)
        {
            return _repository.Remove(cod);
        }

        public bool Update(Cliente obj)
        {
            return _repository.Update(obj);
        }
    }
}
