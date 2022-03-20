using ChaleHospedagem.Domain.Interface.Service;
using ChaleHospedagem.Domain.Models;
using ChaleHospedagem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaleHospedagem.Domain.Interface.Repository;

namespace ChaleHospedagem.Domain.Services
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente repositoryCliente;

        public ServiceCliente(IRepositoryCliente repositoryCliente)
            : base(repositoryCliente)
        {
            this.repositoryCliente = repositoryCliente;
        }
    }
}
