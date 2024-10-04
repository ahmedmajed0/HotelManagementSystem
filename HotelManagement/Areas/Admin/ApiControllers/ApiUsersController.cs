using Bl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUsersController : ControllerBase
    {
        UserManager<ApplicationUser> userManager;


        public ApiUsersController(UserManager<ApplicationUser> umanager)
        {
            userManager = umanager;

        }
        // GET: api/<ApiUsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiUsersController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string userid)
        {
            var user = await userManager.FindByIdAsync(userid);

            if (user == null)
                return NotFound();

            await userManager.DeleteAsync(user);
            return Ok();
        }
    }
}
