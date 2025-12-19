namespace Practice.DesignPattern.Structural.Bridge.Pattern
{
    public class DeviceAction //Abstract class đại diện cho các hành động của thiết bị
    {
        private readonly IDevice _device;
        public DeviceAction(IDevice device) 
        {
            _device = device;
        }

        public void TurnOn() => _device.TurnOn();
        public void TurnOff() => _device.TurnOff();
        public void Working()
        {
            _device.Start();
            _device.Stop();
        }
    }
}
