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


using AutoFixture;
using NSubstitute;
//using NUnit.Framework;

namespace ChaleHospedagem.Test.Services
{
    public class ServiceChaleTest
    {
        private readonly IServiceChale _serviceChale;
        private readonly IRepositoryChale _repositoryChale;

        public ServiceChaleTest()
        {
            this._serviceChale = new Mock<IServiceChale>().Object;
            this._repositoryChale = new Mock<IRepositoryChale>().Object;
        }

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

            bool result = _serviceChale.Add(chale);
            Assert.True(result);
        }




        //[Fact]
        //public void Post_Chale2()
        //{
        //    Chale chale = new Chale()
        //    {
        //        codChale = 0,
        //        capacidade = 9999999,
        //        localizacao = "Post_Chale_Test",
        //        valorAltaEstacao = 9999999,
        //        valorBaixaEstacao = 999999,
        //    };

        //    IRepositoryChale repository = Substitute.For<IRepositoryChale>();

        //    //bool result = _serviceChale.Add(chale);
        //    bool result = new ServiceChale(repository).Add(chale);
        //    Assert.True(result);
        //}

    }
}
