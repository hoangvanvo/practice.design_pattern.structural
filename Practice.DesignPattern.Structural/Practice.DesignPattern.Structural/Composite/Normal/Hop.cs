namespace Practice.DesignPattern.Structural.Composite.Normal
{
    public class Hop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SanPham> Products { get; set; }
        public List<Hop> Boxs { get; set; }
    }
}
