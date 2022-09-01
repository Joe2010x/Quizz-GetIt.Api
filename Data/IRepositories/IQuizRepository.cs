using GetIt.Api.Models;
using GetIt.Api.Models.DTOs;

namespace GetIt.Api.Data.IRepositories;

public interface IQuizRepository
{
  Task<QuizDTO> GetQuiz(int id);
  Task<List<Quiz>> GetQuizzes();
  Task AddQuiz(CreateQuizDTO quiz);
  Task RemoveQuiz(int id);
}
