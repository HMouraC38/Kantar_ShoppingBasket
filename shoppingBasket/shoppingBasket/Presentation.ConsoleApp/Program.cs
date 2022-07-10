using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ShoppingBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Bootstrapper.Setup();

            var output = serviceProvider
                .GetService<IShoppingBasketService>()
                .GetShoppingCost(args);

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(output);
        }
    }
}
