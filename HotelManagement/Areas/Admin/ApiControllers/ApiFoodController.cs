using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Areas.Admin.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiFoodController : ControllerBase
    {
        IFoodService foodService;
        public ApiFoodController(IFoodService food)
        {
            foodService = food;
        }
        // GET: api/<ApiFoodController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiFoodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiFoodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiFoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiFoodController>/5
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var food = foodService.GetById(Id);
            if (food == null)
                return NotFound();

            foodService.Delete(foodService.GetById(Id));
            return Ok();
        }
    }
}
