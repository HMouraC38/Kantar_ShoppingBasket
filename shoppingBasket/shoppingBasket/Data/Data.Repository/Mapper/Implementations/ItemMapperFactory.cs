using Data.Repository.Mapper.Interfaces;
using Domain.Model.AvailableItems;
using Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Mapper.Implementations
{
    public class ItemMapperFactory : IItemMapperFactory
    {
        private readonly IItemMapper<Apples> applesItemMapper;
        private readonly IItemMapper<Bread> breadItemMapper;
        private readonly IItemMapper<Soup> soupItemMapper;
        private readonly IItemMapper<Milk> milkItemMapper;

        public ItemMapperFactory(
            IItemMapper<Apples> applesItemMapper,
            IItemMapper<Bread> breadItemMapper,
            IItemMapper<Soup> soupItemMapper,
            IItemMapper<Milk> milkItemMapper)
        {
            this.applesItemMapper = applesItemMapper;
            this.breadItemMapper = breadItemMapper;
            this.soupItemMapper = soupItemMapper;
            this.milkItemMapper = milkItemMapper;
        }

        public Domain.Model.Item MapToDomain(Model.Item input)
        {
            if (input != null && Enum.IsDefined(typeof(ItemType), input.Name))
            {
                switch (input.Name)
                {
                    case "Apples":
                        return applesItemMapper.Map(input);

                    case "Milk":
                        return milkItemMapper.Map(input);

                    case "Soup":
                        return soupItemMapper.Map(input);

                    case "Bread":
                        return breadItemMapper.Map(input);

                    default:
                        return null;
                }
            }

            return null;
        }
    }
}
