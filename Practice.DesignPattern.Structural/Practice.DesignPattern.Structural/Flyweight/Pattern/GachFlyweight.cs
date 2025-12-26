namespace Practice.DesignPattern.Structural.Flyweight.Pattern
{
    public class GachFlyweight : IGachFlyweight
    {
        public byte[] Color { get; }
        public byte[] Shape { get; }

        public GachFlyweight(byte[] color, byte[] shape)
        {
            Color = color;
            Shape = shape;
        }
    }
}
