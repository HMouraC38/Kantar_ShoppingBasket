using Domain.Model.Context;

namespace Application.Services.Interfaces
{
    public interface IBasketService
    {
        void AddItemsToBasket(RequestContext context);
    }
}
