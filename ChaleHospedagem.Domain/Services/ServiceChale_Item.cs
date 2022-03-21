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
    public class ServiceChale_Item : IServiceChale_Item
    {

        private readonly IRepositoryChale_Item _repository;

        public ServiceChale_Item(IRepositoryChale_Item repository)
        {
            _repository = repository;
        }


        public bool Add(Chale_Item obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<Chale_Item> GetAll()
        {
            return _repository.GetAll();
        }

        public Chale_Item GetByCod(int cod)
        {
            return _repository.GetByCod(cod);
        }

        public bool Remove(int cod)
        {
            return _repository.Remove(cod);
        }

        public bool Remove(Chale_Item obj)
        {
            return _repository.Remove(obj);
        }

        public bool Update(Chale_Item obj)
        {
            return _repository.Update(obj);
        }
    }
}
