using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Interface.Repositories
{
    public interface IRepositoryItem : IRepositoryBase<Item>
    {
        bool Remove(string item);
        Item GetByNomeItem(string item);
    }
}
