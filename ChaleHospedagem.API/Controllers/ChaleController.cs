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
            _serviceChale.Add(chale);
            return new JsonResult(true);
        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            var result = _serviceChale.GetAll();
            return new JsonResult(result);
        }

        [HttpGet("GetById")]
        public JsonResult GetById(int id)
        {
            var result = _serviceChale.GetById(id);
            return new JsonResult(result);
        }


        [HttpPut("Update")]
        public JsonResult Update(Chale chale)
        {
            _serviceChale.Update(chale);
            return new JsonResult(true);
        }

        [HttpDelete("Remove")]
        public JsonResult Remove(Chale chale)
        {
            _serviceChale.Remove(chale);
            return new JsonResult(true);
        }

    }
}
