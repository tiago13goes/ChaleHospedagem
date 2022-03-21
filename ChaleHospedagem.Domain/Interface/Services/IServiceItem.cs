using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Interface.Services
{
    public interface IServiceItem : IServiceBase<Item>
    {
        bool Remove(string item);
        Item GetByNomeItem(string item);
    }
}
