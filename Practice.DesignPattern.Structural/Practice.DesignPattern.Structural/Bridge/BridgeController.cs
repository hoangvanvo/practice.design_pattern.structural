using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Bridge.Pattern;

namespace Practice.DesignPattern.Structural.Bridge
{
    [ApiController]
    [Route("api/structural/v1/bridge")]
    public class BridgeController : ControllerBase
    {

        [HttpPost("device/turn-on")]
        public void TurnOn([FromServices] IDevice device)
        {
            var deviceAction = new DeviceAction(device);
            deviceAction.TurnOn();
        }

        [HttpPost("device/turn-off")]
        public void TurnOff([FromServices] IDevice device)
        {
            var deviceAction = new DeviceAction(device);
            deviceAction.TurnOff();
        }

        [HttpPost("device/working")]
        public void Working([FromServices] IDevice device)
        {
            var deviceAction = new DeviceAction(device);
            deviceAction.Working();
        }
    }
}
