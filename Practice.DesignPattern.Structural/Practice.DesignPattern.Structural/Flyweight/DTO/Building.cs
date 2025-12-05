namespace Practice.DesignPattern.Structural.Flyweight.DTO
{
    public class Building
    {
        public string Type { get; set; } // "Apartment", "Office", ...
        public byte[] Model3D { get; set; }     // File 3D nặng 1MB
        public byte[] Texture { get; set; }     // Texture nặng 500KB

        // Extrinsic
        public int X { get; set; }
        public int Y { get; set; }
    }
}
