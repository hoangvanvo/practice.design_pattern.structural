namespace Practice.DesignPattern.Structural.Composite.Normal
{
    public class PriceRepository
    {
        public void TotalPrice(Hop[] boxs, double total)
        {
            foreach (var box in boxs)
            {
                total += box.Products.Sum(s => s.Price);
                if (box.Boxs.Any())
                {
                    TotalPrice(boxs: box.Boxs.ToArray(), total: total);
                }
            }
        }
    }
}
