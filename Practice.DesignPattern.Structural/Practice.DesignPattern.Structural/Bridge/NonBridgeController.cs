using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Bridge.Normal;

namespace Practice.DesignPattern.Structural.Bridge
{
    [ApiController]
    [Route("api/structural/v1/non-bridge")]
    public class NonBridgeController : ControllerBase
    {

        [HttpPost("tv/turn-on")]
        public void TurnOn([FromServices] Tv tv)
        {
            tv.TurnOn();
        }

        [HttpPost("tv/turn-off")]
        public void TurnOff([FromServices] Tv tv)
        {
            tv.TurnOff();
        }

        [HttpPost("tv/start")]
        public void Start([FromServices] Tv tv)
        {
            tv.Start();
        }

        [HttpPost("tv/stop")]
        public void Stop([FromServices] Tv tv)
        {
            tv.Stop();
        }

        [HttpPost("rd/turn-on")]
        public void TurnOn([FromServices] Radio rd)
        {
            rd.TurnOn();
        }

        [HttpPost("rd/turn-off")]
        public void TurnOff([FromServices] Radio rd)
        {
            rd.TurnOff();
        }

        [HttpPost("rd/start")]
        public void Start([FromServices] Radio rd)
        {
            rd.Start();
        }

        [HttpPost("rd/stop")]
        public void Working([FromServices] Radio rd)
        {
            rd.Stop();
        }
    }
}
