using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Facade.Pattern;

namespace Practice.DesignPattern.Structural.Facade
{
    [Route("api/structural/v1/facade")]
    [ApiController]
    public class FacadeController : ControllerBase
    {
        private readonly ISmartHouseFacade _smartHouseFacade;

        public FacadeController
        (
            ISmartHouseFacade smartHouseFacade
        )
        {
            _smartHouseFacade = smartHouseFacade;
        }

        [HttpPost("on-movie-mode")]
        public void OnMovieMode()
        {
            _smartHouseFacade.TurnOnMovieMode();
        }

        [HttpPost("off-movie-mode")]
        public void OffMovieMode()
        {
            _smartHouseFacade.TurnOffMovieMode();
        }
    }
}
