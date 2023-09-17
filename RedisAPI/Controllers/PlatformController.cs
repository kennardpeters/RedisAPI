using Microsoft.AspNetCore.Mvc;
using RedisAPI.Data;
using RedisAPI.Models;
using Microsoft.AspNetCore.Authorization; 



namespace RedisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PlatformsController: ControllerBase
    {   
        private readonly IPlatformRepo _repo;
        public PlatformsController(IPlatformRepo repo)
        {
            _repo = repo;
        }

        // [Authorize]
        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string id)
        {
            var platform = _repo.GetPlatformById(id);

            if(platform != null) {
                return Ok(platform);
            }

            return NotFound();
        }

        // [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            return Ok(_repo.GetAllPlatforms());
        }

        // [Authorize]
        [HttpPost]
        public ActionResult<Platform> CreatePlatform(Platform platform)
        {
            _repo.CreatePlatform(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platform.Id}, platform);
        }

    }
}