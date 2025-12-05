namespace Practice.DesignPattern.Structural.Flyweight.DTO
{
    public class BuildingFlyweight
    {
        public string Type { get; }
        public byte[] Model3D { get; }
        public byte[] Texture { get; }

        public BuildingFlyweight(string type, byte[] model, byte[] texture)
        {
            Type = type;
            Model3D = model;
            Texture = texture;
        }

        public void Render(int x, int y)
        {
            Console.WriteLine($"Render {Type} at ({x},{y})");
        }
    }

    public class BuildingFlyweightFactory
    {
        private readonly Dictionary<string, BuildingFlyweight> _cache = new();

        public BuildingFlyweight GetBuilding(string type)
        {
            if (!_cache.TryGetValue(type, out var flyweight))
            {
                flyweight = new BuildingFlyweight(
                    type,
                    Array.Empty<byte>(), // giả lập load từ file nặng
                    Array.Empty<byte>()
                );

                _cache[type] = flyweight;
            }

            return flyweight;
        }
    }

    public class BuildingContext
    {
        public int X { get; }
        public int Y { get; }
        public BuildingFlyweight Flyweight { get; }

        public BuildingContext(int x, int y, BuildingFlyweight flyweight)
        {
            X = x;
            Y = y;
            Flyweight = flyweight;
        }

        public void Render()
        {
            Flyweight.Render(X, Y);
        }
    }
}
