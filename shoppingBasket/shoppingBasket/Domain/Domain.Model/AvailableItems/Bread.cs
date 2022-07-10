namespace Domain.Model.AvailableItems
{
    public class Bread : Item
    {
        public Bread(Item item)
        {
            this.Discount = item.Discount;
            this.Price = item.Price;
        }
    }
}
