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
    public class ToDoItem3Controller : ControllerBase
    {
        private IRepository _repository;

        public ToDoItem3Controller(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPut]
        public async Task<ActionResult<List<ToDoItem>>> CreateAsync(
            [Required] ToDoItem toDoItem)
        {
            if (toDoItem == null)
                return BadRequest(new Dictionary<string, string>() { { "message", "ToDoItem is required" } });

            await _repository.UpsertAsync(toDoItem);
            if (await _repository.GetAsync(toDoItem.Id) == toDoItem)
            {
                return Ok();
            }

            return new ObjectResult(null) { StatusCode = 500 };
        }
    }
}
