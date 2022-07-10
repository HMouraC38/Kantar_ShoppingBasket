namespace Data.Repository.Repository.Interfaces
{
    public interface IItemRepository
    {
        bool TryGetItem(string name, out Model.Item item);
    }
}
