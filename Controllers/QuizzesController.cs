using GetIt.Api.Data.IRepositories;
using GetIt.Api.Models;
using GetIt.Api.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GetIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
  private readonly IQuizRepository _quizRepo;

  public QuizzesController(IQuizRepository quizRepo)
  {
    _quizRepo = quizRepo;
  }
  [HttpGet]
  public async Task<ActionResult<List<Quiz>>> GetQuizzes()
  {
    return await _quizRepo.GetQuizzes();
  } 

  [HttpGet("{id}")]
  public async Task<ActionResult<QuizDTO>> GetDTOQuiz(int id)
  {
    return Ok(await _quizRepo.GetQuiz(id));
  }

  [HttpPost]
  public async Task<ActionResult> AddQuiz(CreateQuizDTO quiz)
  {
    await _quizRepo.AddQuiz(quiz);
    return Ok();
  } 
  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteQuiz(int id)
  {
    await _quizRepo.RemoveQuiz(id);

    return Ok();
  }
}
