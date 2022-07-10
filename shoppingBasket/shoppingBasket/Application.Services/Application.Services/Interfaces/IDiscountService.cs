using Domain.Model;
using System.Collections.Generic;

namespace Application.Services.Interfaces
{
    public interface IDiscountService
    {
        void ValidateDiscounts(List<Item> shoppingBasket);
    }
}
