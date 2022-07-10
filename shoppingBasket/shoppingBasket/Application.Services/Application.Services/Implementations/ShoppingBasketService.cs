using Application.Services.Interfaces;
using Domain.Model.Context;

namespace Application.Services.Implementations
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly IBasketService basketService;
        private readonly IDiscountService discountService;
        private readonly IReceiptService receiptService;

        public ShoppingBasketService(
            IBasketService basketService,
            IDiscountService discountService,
            IReceiptService receiptService)
        {
            this.basketService = basketService;
            this.discountService = discountService;
            this.receiptService = receiptService;
        }

        public string GetShoppingCost(string[] items)
        {
            var context = new RequestContext(items);

            basketService.AddItemsToBasket(context);

            string receipt;
            if (context.State.IsValid)
            {
                discountService.ValidateDiscounts(context.ShoppingBasket);

                receipt = receiptService.GetReceipt(context.ShoppingBasket); 
            }
            else
            {
                receipt = receiptService.GetErrorReceipt(context.State.InvalidMessage);
            }

            return receipt;
        }
    }
}
