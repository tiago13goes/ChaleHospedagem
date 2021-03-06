using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Interface.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        bool Add(TEntity obj);

        bool Update(TEntity obj);

        bool Remove(int cod);

        IEnumerable<TEntity> GetAll();

        TEntity GetByCod(int cod);
    }


}
