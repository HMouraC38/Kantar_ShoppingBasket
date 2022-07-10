namespace Data.Repository.Model
{
    public class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Discount Discount { get; set; }
    }
}
