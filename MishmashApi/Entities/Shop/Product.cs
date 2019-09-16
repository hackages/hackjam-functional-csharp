using Newtonsoft.Json;

namespace MishmashApi.Entities.Shop
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
