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
    public class ServiceHospedagem_Servico : IServiceHospedagem_Servico
    {

        private readonly IRepositoryHospedagem_Servico _repository;

        public ServiceHospedagem_Servico(IRepositoryHospedagem_Servico repository)
        {
            _repository = repository;
        }


        public bool Add(Hospedagem_Servico obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<Hospedagem_Servico> GetAll()
        {
            return _repository.GetAll();
        }

        public Hospedagem_Servico GetByCod(int cod)
        {
            return _repository.GetByCod(cod);
        }

        public Hospedagem_Servico GetByHospedagemServico(Hospedagem_Servico obj)
        {
            return _repository.GetByHospedagemServico(obj);
        }

        public bool Remove(int cod)
        {
            return _repository.Remove(cod);
        }

        public bool Remove(Hospedagem_Servico obj)
        {
            return _repository.Remove(obj);
        }

        public bool Update(Hospedagem_Servico obj)
        {
            return _repository.Update(obj);
        }
    }
}
