using System.Collections.Generic;

namespace Domain.Model.Context
{
    public class RequestContext
    {
        public RequestContext(string[] input)
        {
            this.RequestedItems = input;
            this.ShoppingBasket = new List<Item>();
            this.State = new State();
        }

        public string[] RequestedItems { get; set; }

        public List<Item> ShoppingBasket { get; set; }

        public State State { get; set; }
    }
}
