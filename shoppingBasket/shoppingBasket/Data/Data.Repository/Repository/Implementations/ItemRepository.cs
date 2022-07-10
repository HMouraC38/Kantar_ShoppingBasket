using Data.Repository.Data;
using Data.Repository.Repository.Interfaces;

namespace Data.Repository.Repository.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDatabaseContext dbContext;

        public ItemRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool TryGetItem(string name, out Model.Item item)
        {
            item = dbContext.Get(name);

            return item is null ? false : true;
        }
    }
}
