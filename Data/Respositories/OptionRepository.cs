using GetIt.Api.Models;
using GetIt.Api.Data.IRepositories;

namespace GetIt.Api.Data.Repositories;

public class OptionRepository : IOptionRepository
{
  private readonly GetItAppContext _context;

  public OptionRepository(GetItAppContext context) => _context = context;

  public async Task<Option> Get(int id)
  {
    return await _context.Options.FirstOrDefaultAsync(o => o.Id == id);
  }
}