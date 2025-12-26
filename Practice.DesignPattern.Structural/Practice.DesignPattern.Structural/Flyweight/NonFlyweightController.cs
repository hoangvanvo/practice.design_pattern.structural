using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Flyweight.Normal;

namespace Practice.DesignPattern.Structural.Flyweight
{
    [Route("api/structural/v1/non-flyweight")]
    [ApiController]
    public class NonFlyweightController
    {
        [HttpPost("do-something")]
        public List<Gach> DoSomething()
        {
            var list = new List<Gach>();
            for (int i = 0; i < 100; i++)
            {
                var gach = new Gach()
                {
                    color = new byte[10 * 1024 * 1024], //10MB
                    shape = new byte[10 * 1024 * 1024], //10MB
                    x = i,
                    y = i,
                    z = i,
                };
                list.Add(gach);
            }
            return list;
        }
    }
}
