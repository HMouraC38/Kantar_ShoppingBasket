using Data.Repository.Mapper.Interfaces;
using Domain.Model.AvailableItems;

namespace Data.Repository.Mapper.Implementations
{
    public class SoupMapper : ItemMapper, IItemMapper<Soup>
    {
        public SoupMapper(IDiscountMapper discountMapper)
            : base(discountMapper)
        {
        }

        public new Soup Map(Model.Item input)
        {
            var mappedItem = base.Map(input);

            return new Soup(mappedItem);
        }
    }
}
