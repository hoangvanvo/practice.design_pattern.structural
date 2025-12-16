using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Flyweight.DTO;

namespace Practice.DesignPattern.Structural.Flyweight
{
    [Route("api/structural/v1/flyweight")]
    [ApiController]
    public class FlyweightController : ControllerBase
    {
        private readonly BuildingFlyweightFactory _factory;

        public FlyweightController(BuildingFlyweightFactory factory)
        {
            _factory = factory;
        }

        [HttpGet("basic")]
        public IActionResult Basic()
        {
            var buildings = new List<Building>();

            for (int i = 0; i < 1_000_000; i++)
            {
                buildings.Add(new Building
                {
                    Type = "Apartment",
                    Model3D = Array.Empty<byte>(),
                    Texture = Array.Empty<byte>(),
                    X = Random.Shared.Next(0, 10000),
                    Y = Random.Shared.Next(0, 10000)
                });
            }
            return Ok();
        }

        [HttpGet("pattern")]
        public IActionResult Pattern()
        {
            var buildings = new List<BuildingContext>();

            for (int i = 0; i < 1_000_000; i++)
            {
                var flyweight = _factory.GetBuilding("Apartment");
                buildings.Add(new BuildingContext(
                    Random.Shared.Next(0, 10000),
                    Random.Shared.Next(0, 10000),
                    flyweight
                ));
            }

            return Ok("Loaded 1 million building with flyweight.");
        }
    }
}
