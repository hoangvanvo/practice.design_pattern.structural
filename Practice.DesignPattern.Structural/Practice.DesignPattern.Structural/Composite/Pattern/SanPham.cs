namespace Practice.DesignPattern.Structural.Composite.Pattern
{
    public class SanPham : IPriceComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public double GetTotalPrice() => this.Price;
    }
}
