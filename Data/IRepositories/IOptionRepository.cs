using GetIt.Api.Models;

namespace GetIt.Api.Data.IRepositories;

public interface IOptionRepository
{
  Task<Option> Get(int id);
}