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
    public class ServicoController : Controller
    {
        private readonly IServiceServico _serviceServico;

        public ServicoController(IServiceServico serviceServico)
        {
            _serviceServico = serviceServico;
        }

        [HttpPost("Add")]
        public JsonResult Add(Servico Servico)
        {
            return new JsonResult(_serviceServico.Add(Servico));
        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            return new JsonResult(_serviceServico.GetAll());
        }

        [HttpGet("GetById")]
        public JsonResult GetById(int id)
        {
            return new JsonResult(_serviceServico.GetByCod(id));
        }


        [HttpPut("Update")]
        public JsonResult Update(Servico Servico)
        {
            return new JsonResult(_serviceServico.Update(Servico));
        }

        [HttpDelete("Remove")]
        public JsonResult Remove(int cod)
        {
            return new JsonResult(_serviceServico.Remove(cod));
        }

    }
}
