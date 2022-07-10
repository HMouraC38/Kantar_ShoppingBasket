using Data.Repository.Mapper.Interfaces;
using Data.Repository.Model;
using Domain.Model.AvailableItems;

namespace Data.Repository.Mapper.Implementations
{
    public class MilkMapper : ItemMapper, IItemMapper<Milk>
    {
        public MilkMapper(IDiscountMapper discountMapper)
            : base(discountMapper)
        {
        }

        public new Milk Map(Item input)
        {
            var mappedItem = base.Map(input);

            return new Milk(mappedItem);
        }
    }
}
