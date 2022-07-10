using Domain.Model;
using System.Collections.Generic;

namespace Application.Services.Interfaces
{
    public interface IReceiptService
    {
        string GetReceipt(List<Item> shoppingBasket);

        string GetErrorReceipt(string InvalidMessage);
    }
}
