namespace Practice.DesignPattern.Structural.Composite.Pattern
{
    public class Hop : IPriceComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SanPham> Products { get; set; }
        public List<Hop> Boxs { get; set; }

        public double GetTotalPrice() => (Products.Any()? Products.Sum(s => s.GetTotalPrice()) : 0.0) + (Boxs.Any()? Boxs.Sum(s => s.GetTotalPrice()) : 0.0);
    }
}
