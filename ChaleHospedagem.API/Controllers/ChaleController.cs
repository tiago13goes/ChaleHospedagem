using ChaleHospedagem.Domain.Interface.Services;
using ChaleHospedagem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaleHospedagem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChaleController : Controller
    {
        private readonly IServiceChale _serviceChale;
        

        public ChaleController(IServiceChale serviceChale)
        {
            _serviceChale = serviceChale;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            this.Add();
            return View();
        }


        [HttpGet("Add")]
        public IActionResult Add()
        {
            Chale chale = new Chale()
            {
                capacidade = 1,
                localizacao = "São Paulo - SP",
                valorAltaEstacao = 120.99,
                valorBaixaEstacao = 99.99
            };

            _serviceChale.Add(chale);
            return View();
        }

    }
}
