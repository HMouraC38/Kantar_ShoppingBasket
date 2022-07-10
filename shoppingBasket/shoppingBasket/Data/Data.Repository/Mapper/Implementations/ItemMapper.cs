using Data.Repository.Mapper.Interfaces;

namespace Data.Repository.Mapper.Implementations
{
    public abstract class ItemMapper
    {
        private readonly IDiscountMapper discountMapper;

        protected ItemMapper(IDiscountMapper discountMapper)
        {
            this.discountMapper = discountMapper;
        }

        protected Domain.Model.Item Map(Model.Item input)
        {
            if (input is null)
            {
                return null;
            }

            var discount = this.discountMapper.Map(input.Discount);

            return new Domain.Model.Item
            {
                Price = input.Price,
                Discount = discount
            };
        }
    }
}
