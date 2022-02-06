using MartianRobots.Core;
using MartianRobots.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MartianRobots.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExploreController : ControllerBase
    {
        private readonly IExploreService _exploreService;

        public ExploreController(IExploreService exploreService)
        {
            _exploreService = exploreService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            var world = new World(new Coordinate(5, 3));
            var robot1 = new Robot(
                new Position(new Coordinate(1, 1), Orientation.East),
                new List<Instruction> {
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward
                }
            );
            var robot2 = new Robot(
                new Position(new Coordinate(3, 2), Orientation.North),
                new List<Instruction> {
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Left,
                    Instruction.Left,
                    Instruction.Forward,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Left,
                    Instruction.Left
                }
            );
            var robot3 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.West),
                new List<Instruction> {
                    Instruction.Left,
                    Instruction.Left,
                    Instruction.Forward,
                    Instruction.Forward,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Left,
                    Instruction.Forward,
                    Instruction.Left
                }
            );
            return _exploreService.ExploreWorld(world, new List<Robot> { robot1, robot2, robot3 });
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
