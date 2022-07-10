using Domain.Model.Enums;
using System;

namespace Domain.Model
{
    public class Discount
    {
        public double DiscountPercentage { get; set; }

        public DateTimeOffset? ExpiryDate { get; set; }

        public DiscountType DiscountType { get; set; }
    }
}
