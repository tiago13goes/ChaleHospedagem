using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Interface.Services
{
    public interface IServiceChale_Item : IServiceBase<Chale_Item>
    {
        bool Remove(Chale_Item obj);
    }
}
