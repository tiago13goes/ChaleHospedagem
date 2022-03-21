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
    public class ServiceItem : IServiceItem
    {

        private readonly IRepositoryItem _repository;

        public ServiceItem(IRepositoryItem repository)
        {
            _repository = repository;
        }


        public bool Add(Item obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<Item> GetAll()
        {
            return _repository.GetAll();
        }

        public Item GetByCod(int cod)
        {
            return _repository.GetByCod(cod);
        }

        public Item GetByNomeItem(string item)
        {
            return _repository.GetByNomeItem(item);
        }

        public bool Remove(int cod)
        {
            return _repository.Remove(cod);
        }

        public bool Remove(string item)
        {
            return _repository.Remove(item);
        }

        public bool Update(Item obj)
        {
            return _repository.Update(obj);
        }
    }
}
