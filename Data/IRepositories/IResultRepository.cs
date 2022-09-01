using GetIt.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetIt.Api.Data.IRepositories;

public interface IResultRepository
{
  Task<IEnumerable<Result>> GetResults();
  Task<Result> GetResult(int id);
  Task<Result> CreateResult(Result userResult);
  Task<ActionResult<IEnumerable<Result>>> GetUserResults(int userId);
}
