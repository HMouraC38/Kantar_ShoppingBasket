using System;

namespace Domain.Model
{
    public class Item : ICloneable
    {
        public decimal Price { get; set; }

        public Discount? Discount { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
