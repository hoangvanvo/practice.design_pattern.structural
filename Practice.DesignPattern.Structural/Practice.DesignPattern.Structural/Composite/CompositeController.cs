using Microsoft.AspNetCore.Mvc;

namespace Practice.DesignPattern.Structural.Composite
{
    [Route("api/structural/v1/composite")]
    [ApiController]
    public class CompositeController : ControllerBase
    {
        public CompositeController() { }

        [HttpGet("basic")]
        public string BasicDemo()
        {
            var phone = new Basic.Category("Phone");
            phone.Products.Add(new Basic.Product("iPhone 15", 32000));
            phone.Products.Add(new Basic.Product("Samsung S24", 25000));

            var laptop = new Basic.Category("Laptop");
            laptop.Products.Add(new Basic.Product("MacBook Pro", 50000));

            var root = new Basic.Category("Electronics");
            root.SubCategories.Add(phone);
            root.SubCategories.Add(laptop);

            DisplayCategory(root);
            return $"\nTổng giá trị: {root.GetTotalPrice():C}";
        }

        private void DisplayCategory(Basic.Category category, string indent = "")
        {
            Console.WriteLine($"{indent}+ {category.Name}");

            foreach (var product in category.Products)
                Console.WriteLine($"{indent}   - {product.Name}: {product.Price:C}");

            foreach (var sub in category.SubCategories)
                DisplayCategory(sub, indent + "   ");
        }

        [HttpGet("pattern")]
        public string PatternDemo()
        {
            // Tạo cấu trúc tree
            var root = new DesignPattern.Category("Electronics");

            var phone = new DesignPattern.Category("Phone");
            phone.Add(new DesignPattern.Product("iPhone 15", 32000));
            phone.Add(new DesignPattern.Product("Samsung S24", 25000));
            phone.Add(new DesignPattern.Product("Xiaomi 14", 15000));

            var laptop = new DesignPattern.Category("Laptop");
            laptop.Add(new DesignPattern.Product("MacBook Pro", 50000));
            laptop.Add(new DesignPattern.Product("Dell XPS", 40000));
            laptop.Add(new DesignPattern.Product("HP Spectre", 35000));

            root.Add(phone);
            root.Add(laptop);

            // HIỂN THỊ TOÀN CÂY
            root.Display();

            // TÍNH TỔNG GIÁ
            return $"\nTổng giá trị tất cả sản phẩm: {root.GetTotalPrice():C}";
        }
    }
}
