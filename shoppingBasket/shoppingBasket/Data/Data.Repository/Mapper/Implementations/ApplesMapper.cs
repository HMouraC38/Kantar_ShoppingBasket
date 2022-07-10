using Data.Repository.Mapper.Interfaces;
using Data.Repository.Model;
using Domain.Model.AvailableItems;

namespace Data.Repository.Mapper.Implementations
{
    public class ApplesMapper : ItemMapper, IItemMapper<Apples>
    {
        public ApplesMapper(IDiscountMapper discountMapper)
            : base(discountMapper)
        {
        }

        public new Apples Map(Item input)
        {
            var mappedItem = base.Map(input);

            return new Apples(mappedItem);
        }
    }
}
