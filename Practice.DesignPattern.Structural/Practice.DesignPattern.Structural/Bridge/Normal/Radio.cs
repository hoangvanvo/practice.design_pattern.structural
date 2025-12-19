namespace Practice.DesignPattern.Structural.Bridge.Normal
{
    public class Radio
    {
        public void TurnOn() => Console.WriteLine("Radio turn on");
        public void TurnOff() => Console.WriteLine("Radio turn off");
        public void Start() => Console.WriteLine("Radio start");
        public void Stop() => Console.WriteLine("Radio stop");
    }
}
