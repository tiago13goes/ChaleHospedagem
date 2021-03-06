using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Interface.Services
{
    public interface IServiceTelefone : IServiceBase<Telefone>
    {
        bool Remove(Telefone telefone);
    }
}
