using Data.Repository.Mapper.Interfaces;
using Domain.Model.Enums;
using System;

namespace Data.Repository.Mapper.Implementations
{
    public class DiscountMapper : IDiscountMapper
    {
        public Domain.Model.Discount Map(Model.Discount input)
        {
            if (input is null || !Enum.TryParse<DiscountType>(input.DiscountType, true, out var itemDiscountType))
            {
                return null;
            }

            var expirtyDate = DateTimeOffset.TryParse(input.ExpiryDate, out var dateTimeOffset) ? dateTimeOffset : null as DateTimeOffset?;

            return new Domain.Model.Discount
            {
                DiscountType = itemDiscountType,
                DiscountPercentage = input.DiscountPercentage,
                ExpiryDate = expirtyDate
            };
        }
    }
}
