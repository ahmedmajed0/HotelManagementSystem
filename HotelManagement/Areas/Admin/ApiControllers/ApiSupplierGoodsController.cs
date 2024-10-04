using Bl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Areas.Admin.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSupplierGoodsController : ControllerBase
    {
        IGoodsService goodsService;
        public ApiSupplierGoodsController(IGoodsService goods)
        {
            goodsService = goods;
        }
        // GET: api/<ApiSupplierGoodsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiSupplierGoodsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiSupplierGoodsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiSupplierGoodsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiSupplierGoodsController>/5
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var SupGoods = goodsService.GetById(Id);
            if (SupGoods == null)
                return NotFound();

            goodsService.Delete(goodsService.GetById(Id));
            return Ok();
        }
    }
}
