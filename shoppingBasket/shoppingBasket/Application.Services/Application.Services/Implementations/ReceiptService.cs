using Application.Services.Interfaces;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private const string OutputPrefix = "Shopping Cost\n";
        private const string SubTotalPrefix = "Subtotal: €";
        private const string TotalPricePrefix = "Total price: €";
        private const string DefaultDiscountReport = "(No offers available)\n";
        private const string ErrorPrefix = "Whoops! something went wrong, ";

        public string GetErrorReceipt(string invalidContextMessage)
        {
            return OutputPrefix + ErrorPrefix + invalidContextMessage;
        }

        public string GetReceipt(List<Item> basket)
        {
            var subtotal = this.CalculateSubTotal(basket);
            var discountReceipt = this.GenerateDiscountReceipt(basket, out var totalDiscount);
            var total = this.CalculateTotal(subtotal, totalDiscount);

            //builds receipt output
            return OutputPrefix +
                this.GenerateSubTotalReport(subtotal) +
                discountReceipt +
                this.GenerateTotalReport(total);
        }

        private string GenerateSubTotalReport(decimal subtotal)
        {
            return SubTotalPrefix + subtotal.ToString("N2") + "\n";
        }
        private string GenerateTotalReport(decimal total)
        {
            return TotalPricePrefix + total.ToString("N2") + "\n";
        }

        private decimal CalculateSubTotal(List<Item> basket)
        {
            decimal subTotal = 0;
            foreach (var entry in basket)
            {
                subTotal += entry.Price;
            }

            return subTotal;
        }

        private decimal CalculateTotal(decimal subTotal, decimal discount)
        {
            return subTotal - discount;
        }

        private string GenerateDiscountReceipt(List<Item> basket, out decimal totalDiscount)
        {
            var itemsWithDiscount = basket.Where(entry => entry.Discount != null).ToList();

            var discountReport = string.Empty;

            totalDiscount = 0;

            foreach (var entry in itemsWithDiscount)
            {
                var itemDiscount = entry.Price * (decimal)entry.Discount.DiscountPercentage;

                discountReport += $"{entry.GetType().Name} {entry.Discount.DiscountPercentage.ToString("N2")}% off: -€{itemDiscount.ToString("N2")}\n";
                totalDiscount += itemDiscount;
            }

            return discountReport.Equals(string.Empty) ? DefaultDiscountReport : discountReport;
        }
    }
}
