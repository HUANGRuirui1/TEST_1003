using ConsoleApp1.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ToDoItem2Controller : ControllerBase
    {
        private IRepository _repository;

        public ToDoItem2Controller(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetSpecificAsync(
            [Required] long id)
        {
            var list = await _repository.GetAsync(id);
            return Ok(list);
        }
    }
}
