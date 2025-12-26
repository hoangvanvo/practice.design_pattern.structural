namespace Practice.DesignPattern.Structural.Flyweight.Pattern
{
    public class GachNew
    {
        public IGachFlyweight Base { get; }
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public GachNew(IGachFlyweight gachBase, int x, int y, int z)
        {
            Base = gachBase;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
