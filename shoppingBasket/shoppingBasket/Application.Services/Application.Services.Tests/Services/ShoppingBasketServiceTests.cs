using Application.Services.Implementations;
using Application.Services.Interfaces;
using AutoFixture;
using Domain.Model;
using Domain.Model.Context;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Tests.Services
{
    public class ShoppingBasketServiceTests
    {
        private Mock<IBasketService> mockBasketService;
        private Mock<IDiscountService> mockDiscountService;
        private Mock<IReceiptService> mockReceiptService;

        private ShoppingBasketService service;

        private Fixture fixture; 

        [SetUp]
        public void Setup()
        {
            this.mockBasketService = new Mock<IBasketService>();
            this.mockDiscountService = new Mock<IDiscountService>();
            this.mockReceiptService = new Mock<IReceiptService>();

            this.service = new ShoppingBasketService(
                this.mockBasketService.Object,
                this.mockDiscountService.Object,
                this.mockReceiptService.Object);

            this.fixture = new Fixture();
        }

        [Test]
        public void ShoppingBasketService_GetShoppingCost_WithInvalidContext_ShouldReportError()
        {
            //arrange
            var input = this.fixture.CreateMany<string>().ToArray();
            var expectedInvalidMessage = this.fixture.Create<string>();

            var receivedContext = default(RequestContext);
            this.mockBasketService
                .Setup(m => m.AddItemsToBasket(It.IsAny<RequestContext>()))
                .Callback<RequestContext>((context) => 
                {
                    receivedContext = context;
                    context.State.IsValid = false;
                    context.State.InvalidMessage = expectedInvalidMessage;
                });

            //act
            this.service.GetShoppingCost(input);

            //assert
            this.mockBasketService.Verify(
                m => m.AddItemsToBasket(It.Is<RequestContext>(ctx => ctx.Equals(receivedContext))),
                Times.Once);

            this.mockDiscountService.Verify(
                m => m.ValidateDiscounts(It.IsAny<List<Item>>()),
                Times.Never);

            this.mockReceiptService.Verify(
                m => m.GetReceipt(It.IsAny<List<Item>>()),
                Times.Never);

            this.mockReceiptService.Verify(
                m => m.GetErrorReceipt(It.Is<string>(str => str.Equals(expectedInvalidMessage))),
                Times.Once);
        }
    }
}