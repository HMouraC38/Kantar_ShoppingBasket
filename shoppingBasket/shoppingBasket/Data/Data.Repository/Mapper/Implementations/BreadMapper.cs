using Data.Repository.Mapper.Interfaces;
using Domain.Model.AvailableItems;

namespace Data.Repository.Mapper.Implementations
{
    public class BreadMapper : ItemMapper, IItemMapper<Bread>
    {
        public BreadMapper(IDiscountMapper discountMapper)
            : base(discountMapper)
        {
        }

        public new Bread Map(Model.Item input)
        {
            var mappedItem = base.Map(input);

            return new Bread(mappedItem);
        }
    }
}
