using GetIt.Api.Data.IRepositories;
using GetIt.Api.Models;
using GetIt.Api.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GetIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResultsController : ControllerBase
{
  private readonly IResultRepository _resultRepo;
  private readonly IOptionRepository _optionRepo;

  public ResultsController(IResultRepository resultRepo, IOptionRepository optionRepo)
  {
    _resultRepo = resultRepo;
    _optionRepo = optionRepo;
  }

  [HttpGet]
  public async Task<IEnumerable<Result>> GetResults()
  {
    return await _resultRepo.GetResults();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Result>> GetResult(int id)
  {
    return await _resultRepo.GetResult(id);
  }

  [HttpGet("users/{userId}")]
  public async Task<ActionResult<IEnumerable<Result>>> GetUserResults(int userId)
  {
    return await _resultRepo.GetUserResults(userId);
  }

  [HttpPost]
  public async Task<ActionResult<ResultDTO>> CreateResult(Result userResult)
  {
    var result = await _resultRepo.CreateResult(userResult);
    var option = await _optionRepo.Get(userResult.OptionId);

    var resultDto = new ResultDTO()
    {
      OptionId = option.Id,
      IsCorrect = option.IsCorrect
    };
    return CreatedAtAction(nameof(GetResult), new { Id = result.Id }, resultDto);
  }
  
}
