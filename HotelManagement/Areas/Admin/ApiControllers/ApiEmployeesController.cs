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
    public class ApiEmployeesController : ControllerBase
    {
        IEmployeeService employeeService;
        public ApiEmployeesController(IEmployeeService emp)
        {
            employeeService = emp;
        }
        // GET: api/<ApiEmployeesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiEmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiEmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiEmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiEmployeesController>/5
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var employee = employeeService.GetById(Id);
            if (employee == null)
                return NotFound();

            employeeService.Delete(employeeService.GetById(Id));
            return Ok();
        }
    }
}
