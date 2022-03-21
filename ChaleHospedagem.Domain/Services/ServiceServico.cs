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
    public class ServiceServico : IServiceServico
    {

        private readonly IRepositoryServico _repository;

        public ServiceServico(IRepositoryServico repository)
        {
            _repository = repository;
        }


        public bool Add(Servico obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<Servico> GetAll()
        {
            return _repository.GetAll();
        }

        public Servico GetByCod(int cod)
        {
            return _repository.GetByCod(cod);
        }

        public bool Remove(int cod)
        {
            return _repository.Remove(cod);
        }

        public bool Update(Servico obj)
        {
            return _repository.Update(obj);
        }
    }
}
