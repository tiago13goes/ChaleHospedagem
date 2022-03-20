using ChaleHospedagem.Domain.Interface.Repository;
using ChaleHospedagem.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public bool Add(TEntity obj)
        {
            return repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Remove(TEntity obj)
        {
            return repository.Remove(obj);
        }

        public bool Update(TEntity obj)
        {
            return repository.Update(obj);
        }
    }
}
