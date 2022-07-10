namespace Data.Repository.Mapper.Interfaces
{
    public interface IMapper<in T, out T1>
        where T : class
        where T1 : class
    {
        T1 Map(T input);
    }
}
