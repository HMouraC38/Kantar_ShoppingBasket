using Application.Services.Implementations;
using Application.Services.Interfaces;
using Data.Repository.Data;
using Data.Repository.Mapper.Implementations;
using Data.Repository.Mapper.Interfaces;
using Data.Repository.Repository.Implementations;
using Data.Repository.Repository.Interfaces;
using Domain.Model.AvailableItems;
using Microsoft.Extensions.DependencyInjection;

namespace ShoppingBasket
{
    internal static class Bootstrapper
    {
        public static ServiceProvider Setup()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            return services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //services
            services.AddSingleton<IShoppingBasketService, ShoppingBasketService>();
            services.AddSingleton<IBasketService, BasketService>();
            services.AddSingleton<IDiscountService, DiscountService>();
            services.AddSingleton<IReceiptService, ReceiptService>();

            //repository
            services.AddSingleton<IItemRepository, ItemRepository>();

            //Hammer (sorry)
            services.AddSingleton<IDatabaseContext, DatabaseSimulator>();

            //Mappers
            services.AddSingleton<IDiscountMapper, DiscountMapper>();
            services.AddSingleton<IItemMapper<Apples>, ApplesMapper>();
            services.AddSingleton<IItemMapper<Milk>, MilkMapper>();
            services.AddSingleton<IItemMapper<Soup>, SoupMapper>();
            services.AddSingleton<IItemMapper<Bread>, BreadMapper>();

            services.AddSingleton<IItemMapperFactory, ItemMapperFactory>();
        }
    }
}
