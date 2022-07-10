using Domain.Model;

namespace Data.Repository.Mapper.Interfaces
{
    public interface IItemMapperFactory
    {
        Item MapToDomain(Model.Item input);
    }
}
