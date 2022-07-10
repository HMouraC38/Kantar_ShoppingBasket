namespace Domain.Model.AvailableItems
{
    public class Milk : Item
    {
        public Milk(Item item)
        {
            this.Discount = item.Discount;
            this.Price = item.Price;
        }
    }
}
