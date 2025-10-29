namespace Practice.DesignPattern.Structural.Composite.DesignPattern
{
    // ===== COMPONENT =====
    public interface ICatalogComponent
    {
        string Name { get; }
        decimal GetTotalPrice();
        void Display(string indent = "");
    }

    // ===== LEAF =====
    public class Product : ICatalogComponent
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public decimal GetTotalPrice() => Price;

        public void Display(string indent = "")
        {
            Console.WriteLine($"{indent}- {Name}: {Price:C}");
        }
    }

    // ===== COMPOSITE =====
    public class Category : ICatalogComponent
    {
        public string Name { get; }
        private readonly List<ICatalogComponent> _children = new();

        public Category(string name) => Name = name;

        public void Add(ICatalogComponent component) => _children.Add(component);
        public void Remove(ICatalogComponent component) => _children.Remove(component);

        public decimal GetTotalPrice() => _children.Sum(c => c.GetTotalPrice());

        public void Display(string indent = "")
        {
            Console.WriteLine($"{indent}+ {Name}");
            foreach (var child in _children)
                child.Display(indent + "   ");
        }
    }
}
