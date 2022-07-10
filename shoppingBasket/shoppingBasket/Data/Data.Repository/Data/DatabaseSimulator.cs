using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository.Data
{
    //This serves as mock for database, due to extreme lack of time
    public class DatabaseSimulator : IDatabaseContext
    {
        private readonly List<Model.Item> mockDatabase;

        public DatabaseSimulator()
        {
            this.mockDatabase = GetData();
        }

        public Model.Item Get(string itemName)
        {
            return this.mockDatabase.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase));
        }

        private List<Model.Item> GetData()
        {
            return new List<Model.Item>()
            {
                new Model.Item
                {
                    Name = "Soup",
                    Price = 0.65M,
                },
                new Model.Item
                {
                    Name = "Bread",
                    Price = 0.80M,
                    Discount = new Model.Discount
                    {
                        DiscountType = "MultiBuyDiscount",
                        DiscountPercentage = 0.5
                    }
                },
                new Model.Item
                {
                    Name = "Milk",
                    Price = 1.30M,
                },
                new Model.Item
                {
                    Name = "Apples",
                    Price = 1,
                    Discount = new Model.Discount
                    {
                        DiscountType = "ItemDiscount",
                        DiscountPercentage = 0.1,
                        ExpiryDate = "7/17/2022 12:00:00AM +5:00"
                    }
                }
            };
        }
    }
}
