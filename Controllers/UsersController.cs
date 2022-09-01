using GetIt.Api.Data.IRepositories;
using GetIt.Api.Models;
using GetIt.Api.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GetIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUserRepository _userRepo;

  public UsersController(IUserRepository userRepo)
  {
    _userRepo = userRepo;
  }

  [HttpGet]
  public async Task<IEnumerable<User>> GetUsers()
  {
    return await _userRepo.GetUsers();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<User>> GetUser(int id)
  {
    return await _userRepo.GetUser(id);
  }

  [HttpPost]
  public async Task<ActionResult<User>> CreateUser(CreateUserDTO userDto)
  {
    var user = await _userRepo.CreateUser(userDto);
    var userIdDto = new UserIdDTO() { Id = user.Id };

    return CreatedAtAction(nameof(GetUser), new { Id = user.Id }, userIdDto);
  }

  [HttpGet("{userId}/quizzes/{quizId}")]
  public async Task<ActionResult<QuizResultDTO>> GetUserQuizResult(int userId, int quizId) 
  {
    return await _userRepo.GetUserQuizResult(quizId, userId);
  } 
  
}
