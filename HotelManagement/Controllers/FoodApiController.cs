using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodApiController : ControllerBase
    {
        IFoodService foodService;
        public FoodApiController(IFoodService food)
        {
            foodService = food;
        }
        // GET: api/<FoodApiController>
        [HttpGet]
        public IEnumerable<TbFood> Get()
        {
            return foodService.GetAll();
        }

        // GET api/<FoodApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FoodApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
