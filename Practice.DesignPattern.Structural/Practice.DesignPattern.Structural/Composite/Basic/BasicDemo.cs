namespace Practice.DesignPattern.Structural.Composite.Basic
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Category
    {
        public string Name { get; }
        public List<Product> Products { get; } = new();
        public List<Category> SubCategories { get; } = new();

        public Category(string name)
        {
            Name = name;
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var product in Products)
                total += product.Price;
            foreach (var sub in SubCategories)
                total += sub.GetTotalPrice();
            return total;
        }
    }
}
