namespace Data.Repository.Mapper.Interfaces
{
    public interface IItemMapper<out T> : IMapper<Model.Item, T>
        where T : class
    {
    }
}
