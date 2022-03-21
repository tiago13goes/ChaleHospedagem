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
    public class ServiceTelefone : IServiceTelefone
    {

        private readonly IRepositoryTelefone _repository;

        public ServiceTelefone(IRepositoryTelefone repository)
        {
            _repository = repository;
        }


        public bool Add(Telefone obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<Telefone> GetAll()
        {
            return _repository.GetAll();
        }

        public Telefone GetByCod(int cod)
        {
            return _repository.GetByCod(cod);
        }

        public bool Remove(int cod)
        {
            return _repository.Remove(cod);
        }

        public bool Update(Telefone obj)
        {
            return _repository.Update(obj);
        }
    }
}
