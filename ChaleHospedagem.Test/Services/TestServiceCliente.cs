using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Interface.Services;
using ChaleHospedagem.Domain.Models;
using ChaleHospedagem.Domain.Services;
using ChaleHospedagem.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChaleHospedagem.Test.Services
{
    public class TestServiceCliente
    {
     
        [Fact]
        public void Post_Cliente()
        {
            var _serviceCliente = new ServiceCliente(new Mock<IRepositoryCliente>().Object);

            Cliente cliente = new()
            {
                codCliente = 0,
                bairroCliente = "Butantã",
                CEPCliente = "12345-678",
                cidadeCliente = "São Paulo",
                enderecoCliente = "rua mmdc",
                estadoCliente = "SP",
                nascimentoCliente = DateTime.Now,
                rgCliente = "12.345.678-9"
            };

            var result = _serviceCliente.Add(cliente);
            Assert.True(result);
        }
    }
}
