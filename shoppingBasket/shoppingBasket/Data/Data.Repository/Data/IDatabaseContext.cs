namespace Data.Repository.Data
{
    public interface IDatabaseContext
    {
        Model.Item Get(string itemName);
    }
}
