using Application.Services.Interfaces;
using Domain.Model;
using Domain.Model.AvailableItems;
using System;
using System.Collections.Generic;

namespace Application.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private List<Item> multiBuyDiscountItems;
        private int soupCount;

        public DiscountService()
        {
            this.multiBuyDiscountItems = new List<Item>();
            this.soupCount = 0;
        }

        public void ValidateDiscounts(List<Item> basket)
        {
            foreach (var item in basket)
            {
                //Checks how many soups there are
                if (item is Soup)
                {
                    soupCount++;
                }

                //If item has no Discount, there is nothing to do
                if (item.Discount is null)
                {
                    continue;
                }

                //Removes all Discounts with due expiry date
                this.RemoveOutdatedDiscount(item);

                //Removes all Discounts that are not of valid type, also groups all breads
                switch (item.Discount.DiscountType)
                {
                    case Domain.Model.Enums.DiscountType.ItemDiscount:
                        break;
                    case Domain.Model.Enums.DiscountType.MultiBuyDiscount:
                        this.multiBuyDiscountItems.Add(item);
                        break;
                    default:
                        item.Discount = null;
                        break;
                }
            }

            //Removes excessive breads discount, considering amount of soup items in basket
            this.RemoveExcessiveDiscount(multiBuyDiscountItems);
        }

        public void RemoveExcessiveDiscount(List<Item> multiBuyDiscountItems)
        {
            //if there are not at least 2 soup items, then all bread items will have discount removed
            if (multiBuyDiscountItems.Count > 0 && soupCount < 2)
            {
                foreach (var item in multiBuyDiscountItems)
                {
                    item.Discount = null;
                }
                return;
            }

            if (multiBuyDiscountItems.Count > 0
                && soupCount >= 2)
            {
                //for each 2 soup items, we can have one bread discount, once there are not atleast 2 soup items, bread discounts are removed
                for (var i = 0; i < multiBuyDiscountItems.Count; soupCount -= 2, i++)
                {
                    if (soupCount >= 2)
                    {
                        continue;
                    }
                    multiBuyDiscountItems[i].Discount = null;
                }
            }
        }

        private void RemoveOutdatedDiscount(Item item)
        {
            if (!this.isValidExpiryDate(item.Discount))
            {
                item.Discount = null;
            }
        }

        private bool isValidExpiryDate(Discount itemDiscount)
        {
            if (itemDiscount.ExpiryDate.HasValue
                && itemDiscount.ExpiryDate.Value.ToUnixTimeMilliseconds() < DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
            {
                return false;
            }
            return true;
        }
    }
}
