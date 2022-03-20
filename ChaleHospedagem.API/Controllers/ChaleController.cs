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

        [HttpPost("Add")]
        public JsonResult Add(Chale chale)
        {
            return new JsonResult(_serviceChale.Add(chale));
        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            return new JsonResult(_serviceChale.GetAll());
        }

        [HttpGet("GetById")]
        public JsonResult GetById(int id)
        {
            return new JsonResult(_serviceChale.GetById(id));
        }


        [HttpPut("Update")]
        public JsonResult Update(Chale chale)
        {
            return new JsonResult(_serviceChale.Update(chale));
        }

        [HttpDelete("Remove")]
        public JsonResult Remove(Chale chale)
        {
            return new JsonResult(_serviceChale.Remove(chale));
        }

    }
}
