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
    public class HospedagemController : Controller
    {
        private readonly IServiceHospedagem _serviceHospedagem;

        public HospedagemController(IServiceHospedagem serviceHospedagem)
        {
            _serviceHospedagem = serviceHospedagem;
        }

        [HttpPost("Add")]
        public JsonResult Add(Hospedagem Hospedagem)
        {
            return new JsonResult(_serviceHospedagem.Add(Hospedagem));
        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            return new JsonResult(_serviceHospedagem.GetAll());
        }

        [HttpGet("GetById")]
        public JsonResult GetById(int id)
        {
            return new JsonResult(_serviceHospedagem.GetByCod(id));
        }


        [HttpPut("Update")]
        public JsonResult Update(Hospedagem Hospedagem)
        {
            return new JsonResult(_serviceHospedagem.Update(Hospedagem));
        }

        [HttpDelete("Remove")]
        public JsonResult Remove(int cod)
        {
            return new JsonResult(_serviceHospedagem.Remove(cod));
        }

    }
}
