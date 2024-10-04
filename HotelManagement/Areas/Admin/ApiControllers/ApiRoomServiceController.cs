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
    public class ApiRoomServiceController : ControllerBase
    {
        ICleanService cleanService;
        public ApiRoomServiceController(ICleanService clean)
        {
            cleanService = clean;
        }
        // GET: api/<ApiRoomServiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiRoomServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiRoomServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiRoomServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiRoomServiceController>/5
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var roomserv = cleanService.GetById(Id);
            if (roomserv == null)
                return NotFound();

            cleanService.Delete(cleanService.GetById(Id));
            return Ok();
        }
    }
}
