namespace Practice.DesignPattern.Structural.Flyweight.Pattern
{
    public class GachFlyweightFactory
    {
        private readonly Dictionary<string, IGachFlyweight> _cache = new();

        public IGachFlyweight GetFlyweight(string loaiGach)
        {
            if (!_cache.TryGetValue(loaiGach, out var flyweight))
            {
                flyweight = new GachFlyweight(
                    LoadColor(loaiGach),
                    LoadShape(loaiGach)
                );
                _cache[loaiGach] = flyweight;
            }
            return flyweight;
        }

        private byte[] LoadColor(string loaiGach)
        {
            // giả lập dữ liệu nặng 10MB lấy từ file theo loại gạch
            return new byte[10 * 1024 * 1024];
        }

        private byte[] LoadShape(string loaiGach)
        {
            // giả lập dữ liệu nặng 10MB lấy từ file theo loại gạch
            return new byte[10 * 1024 * 1024];
        }
    }
}
