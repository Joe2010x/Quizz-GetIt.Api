using GetIt.Api.Models.DTOs;
using GetIt.Api.Models;

namespace GetIt.Api.Data.IRepositories;

public interface IUserRepository
{
  Task<IEnumerable<User>> GetUsers();
  Task<User> GetUser(int id);
  Task<User> CreateUser(CreateUserDTO userDto);
  Task<QuizResultDTO> GetUserQuizResult(int quizId, int userId);
  
}
