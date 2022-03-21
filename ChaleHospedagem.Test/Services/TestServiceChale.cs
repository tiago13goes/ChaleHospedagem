using ChaleHospedagem.Domain.Interface.Repositories;
using ChaleHospedagem.Domain.Interface.Services;
using ChaleHospedagem.Domain.Models;
using ChaleHospedagem.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace ChaleHospedagem.Test.Services
{
    public class TestServiceChale
    {
        [Fact]
        public void Post_Chale()
        {
            Chale chale = new()
            {
                codChale = 0,
                capacidade = 9999999,
                localizacao = "Post_Chale_Test",
                valorAltaEstacao = 9999999,
                valorBaixaEstacao = 999999,
            };

            IServiceChale _serviceChale = new Mock<IServiceChale>().Object;
            //ServiceChale _serviceChale = new ServiceChale(new Mock<IRepositoryChale>().Object);

            bool result = _serviceChale.Add(chale);
            Assert.True(result);
        }
    }
}
