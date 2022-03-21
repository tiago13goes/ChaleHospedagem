using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Interface.Services
{
    public interface IServiceHospedagem_Servico : IServiceBase<Hospedagem_Servico>
    {
        bool Remove(Hospedagem_Servico obj);
        Hospedagem_Servico GetByHospedagemServico(Hospedagem_Servico obj);
    }
}
