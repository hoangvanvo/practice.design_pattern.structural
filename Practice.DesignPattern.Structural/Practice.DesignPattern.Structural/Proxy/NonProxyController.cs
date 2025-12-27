using Microsoft.AspNetCore.Mvc;

namespace Practice.DesignPattern.Structural.Proxy
{
    [Route("api/structural/v1/non-proxy")]
    [ApiController]
    public class NonProxyController
    {
        private readonly IService _service;

        public NonProxyController
        (
            IService service
        )
        {
            _service = service;
        }

        [HttpPost("gap-giam-doc")]
        public void GapGiamDoc([FromQuery] string name)
        {
            _service.GapGiamDoc(name);
        }
    }
}
