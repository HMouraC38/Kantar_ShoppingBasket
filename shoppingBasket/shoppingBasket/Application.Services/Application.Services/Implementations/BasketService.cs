using Application.Services.Interfaces;
using Data.Repository.Mapper.Interfaces;
using Data.Repository.Repository.Interfaces;
using Domain.Model;
using Domain.Model.Context;
using System;
using System.Linq;

namespace Application.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IItemRepository itemRepository;
        private readonly IItemMapperFactory itemMapperFactory;

        private string InvalidItemMessage = "can't find item with the name {0}";

        public BasketService(
            IItemRepository itemRepository,
            IItemMapperFactory itemMapperFactory)
        {
            this.itemRepository = itemRepository;
            this.itemMapperFactory = itemMapperFactory;
        }

        public void AddItemsToBasket(RequestContext context)
        {
            foreach(var itemName in context.RequestedItems)
            {
                //Check if an item with the same type has already been added.
                var processedItem = context.ShoppingBasket
                    .FirstOrDefault(item =>
                        item.GetType().Name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase));

                //If so, then there is no need to get the same information twice
                if(processedItem != null) 
                {
                    context.ShoppingBasket.Add((Item)processedItem.Clone());
                    continue;
                }
                
                //If item information is yet to be fetched, then use itemRepository
                if(this.itemRepository.TryGetItem(itemName, out var dataItem))
                {
                    var mappedItem = this.itemMapperFactory.MapToDomain(dataItem);

                    context.ShoppingBasket.Add(mappedItem);
                }
                //If item not found, then set context state and exit
                else
                {
                    context.State.IsValid = false;
                    context.State.InvalidMessage = string.Format(InvalidItemMessage, itemName);
                    return;
                }
            }
        }
    }
}
