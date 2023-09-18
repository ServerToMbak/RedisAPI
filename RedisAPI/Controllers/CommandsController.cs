using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisAPI.Data;
using RedisAPI.Models;

namespace RedisAPI.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class CommandsController :ControllerBase
    {
        private readonly ICommandRepo _repo;

        public CommandsController(ICommandRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommand(Command command)
        {
            return Ok(await _repo.CreaateCommand(command));

        }

        [HttpGet]
        public async Task<ActionResult>  GetCommandsBySetId([FromQuery]string id)
        {
            return Ok(await _repo.GetCommandsBySetId(id));
        }
    }
}