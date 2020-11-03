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
    public class ToDoItem1Controller : ControllerBase
    {
        private IRepository _repository;

        public ToDoItem1Controller(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return Ok(list);
        }
    }
}
