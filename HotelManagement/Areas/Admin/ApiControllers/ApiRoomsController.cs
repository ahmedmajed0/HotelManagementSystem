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
    public class ApiRoomsController : ControllerBase
    {
        IRoomService roomService;
        public ApiRoomsController(IRoomService room)
        {
            roomService = room;
        }
        // GET: api/<ApiRoomsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiRoomsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiRoomsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiRoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiRoomsController>/5
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var room = roomService.GetById(Id);
            if (room == null)
                return NotFound();

            roomService.Delete(roomService.GetById(Id));
            return Ok();
        }
    }
}
