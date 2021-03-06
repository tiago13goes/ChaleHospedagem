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
    public class ClienteController : Controller
    {
        private readonly IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        [HttpPost("Add")]
        public JsonResult Add(Cliente Cliente)
        {
            return new JsonResult(_serviceCliente.Add(Cliente));
        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            return new JsonResult(_serviceCliente.GetAll());
        }

        [HttpGet("GetById")]
        public JsonResult GetById(int id)
        {
            return new JsonResult(_serviceCliente.GetByCod(id));
        }


        [HttpPut("Update")]
        public JsonResult Update(Cliente Cliente)
        {
            return new JsonResult(_serviceCliente.Update(Cliente));
        }

        [HttpDelete("Remove")]
        public JsonResult Remove(int cod)
        {
            return new JsonResult(_serviceCliente.Remove(cod));
        }

    }
}
