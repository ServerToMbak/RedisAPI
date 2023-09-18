using Microsoft.AspNetCore.Mvc;
using RedisAPI.Data;
using RedisAPI.Models;

namespace RedisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;

        public PlatformsController(IPlatformRepo repo)
        {
            _repo = repo;    
        }   

        [HttpPost]
        public ActionResult<Platform> CreatePlatform(Platform plat)
        {
           _repo.CreatePlatform(plat);
           return CreatedAtRoute(nameof(GetPlatformById),new {Id = plat.Id}, plat);
        }


        [HttpGet("{id}", Name ="GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string id)
        {
            var platform = _repo.getPlatformById(id);
            if(platform != null)
            {
                return Ok(platform);
            }
            return NotFound();  
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms() 
        {
            return Ok(_repo.GetAllPlatforms());
        }
    }
}