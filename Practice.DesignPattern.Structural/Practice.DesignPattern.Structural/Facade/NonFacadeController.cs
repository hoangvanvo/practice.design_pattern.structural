using Microsoft.AspNetCore.Mvc;

namespace Practice.DesignPattern.Structural.Facade
{
    [Route("api/structural/v1/non-facade")]
    [ApiController]
    public class NonFacadeController
    {
        private readonly ISmartHouse _smartHouse;

        public NonFacadeController
        (
            ISmartHouse smartHouse
        )
        {
            _smartHouse = smartHouse;
        }

        [HttpPost("turn-on-the-light")]
        public void TurnOnTheLight() => _smartHouse.TurnOnTheLight();

        [HttpPost("turn-off-the-light")]
        public void TurnOffTheLight() => _smartHouse.TurnOffTheLight();

        [HttpPost("turn-on-tv")]
        public void TurnOnTV() => _smartHouse.TurnOnTV();

        [HttpPost("turn-off-tv")]
        public void TurnOffTV() => _smartHouse.TurnOffTV();
    }
}
