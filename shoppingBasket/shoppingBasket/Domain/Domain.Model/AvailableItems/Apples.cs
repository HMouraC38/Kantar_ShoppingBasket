namespace Domain.Model.AvailableItems
{
    public class Apples : Item
    {
        public Apples(Item item)
        {
            this.Discount = item.Discount;
            this.Price = item.Price;
        }
    }
}
