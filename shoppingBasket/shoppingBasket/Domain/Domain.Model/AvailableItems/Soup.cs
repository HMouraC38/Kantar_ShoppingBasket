namespace Domain.Model.AvailableItems
{
    public class Soup : Item
    {
        public Soup(Item item)
        {
            this.Discount = item.Discount;
            this.Price = item.Price;
        }
    }
}
