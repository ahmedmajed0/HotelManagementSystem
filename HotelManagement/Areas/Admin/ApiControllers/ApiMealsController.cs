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
    public class ApiMealsController : ControllerBase
    {
        IMeelService meelService;
        public ApiMealsController(IMeelService meal)
        {
            meelService = meal; ;
    }
        // GET: api/<ApiMealsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiMealsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiMealsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiMealsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiMealsController>/5
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var meal = meelService.GetById(Id);
            if (meal == null)
                return NotFound();

            meelService.Delete(meelService.GetById(Id));
            return Ok();
        }
    }
}
