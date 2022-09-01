using GetIt.Api.Models;
using GetIt.Api.Data.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace GetIt.Api.Data.Repositories;

public class ResultRepository : IResultRepository
{
  private readonly GetItAppContext _context;

  public ResultRepository(GetItAppContext context) => _context = context;

  public async Task<IEnumerable<Result>> GetResults()
  {
    return await _context.Results.ToListAsync();
  }

  public async Task<Result> GetResult(int id)
  {
    return await _context.Results.FirstOrDefaultAsync(r => r.Id == id);
  }

  public async Task<ActionResult<IEnumerable<Result>>> GetUserResults(int userId)
  {
    return await _context.Results.Where(r => r.UserId == userId).ToListAsync();
  }

  public async Task<Result> CreateResult(Result userResult)
  {
    _context.Results.Add(userResult);
    await _context.SaveChangesAsync();

    return userResult;
  }
}
