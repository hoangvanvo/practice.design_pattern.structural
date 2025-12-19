namespace Practice.DesignPattern.Structural.Bridge.Pattern
{
    public class Tv : IDevice
    {
        public void TurnOn() => Console.WriteLine("TV turn on");
        public void TurnOff() => Console.WriteLine("TV turn off");
        public void Start() => Console.WriteLine("TV start");
        public void Stop() => Console.WriteLine("TV stop");
    }
}
