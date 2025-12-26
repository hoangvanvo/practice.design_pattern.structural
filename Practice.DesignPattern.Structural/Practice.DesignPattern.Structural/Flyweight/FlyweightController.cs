using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Flyweight.Pattern;

namespace Practice.DesignPattern.Structural.Flyweight
{
    [Route("api/structural/v1/flyweight")]
    [ApiController]
    public class FlyweightController : ControllerBase
    {
        private readonly GachFlyweightFactory _gachFlyweightFactory;
        private static readonly Random _random = new();

        public FlyweightController
        (
            GachFlyweightFactory gachFlyweightFactory
        )
        {
            _gachFlyweightFactory = gachFlyweightFactory;
        }

        [HttpPost("tao-gach")]
        public List<GachNew> TaoGach()
        {
            var list = new List<GachNew>();
            var listLoai = new List<string>() { "GO", "DA", "XI MANG" };
            for (int i = 0; i < 100; i++)
            {
                var loaiGach = listLoai[Random.Shared.Next(listLoai.Count)];
                var flyweight = _gachFlyweightFactory.GetFlyweight(loaiGach);
                var gach = new GachNew(flyweight, i, i, i);
                list.Add(gach);
            }
            return list;
        }
    }
}
