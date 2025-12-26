namespace Practice.DesignPattern.Structural.Facade.Pattern
{
    public class SHouseFacade : ISmartHouseFacade
    {
        private readonly ISmartHouse _smartHouse;

        public SHouseFacade(ISmartHouse smartHouse)
        {
            _smartHouse = smartHouse;
        }

        public void TurnOffMovieMode()
        {
            _smartHouse.TurnOffTV();
            _smartHouse.TurnOnTheLight();
            _smartHouse.MoRemCua();
        }

        public void TurnOnMovieMode()
        {
            _smartHouse.TurnOnTV();
            _smartHouse.TurnOffTheLight();
            _smartHouse.DongRemCua();
        }
    }
}
