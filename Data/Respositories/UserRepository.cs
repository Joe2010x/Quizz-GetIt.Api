using GetIt.Api.Models;
using GetIt.Api.Models.DTOs;
using GetIt.Api.Data.IRepositories;

namespace GetIt.Api.Data.Repositories;

public class UserRepository : IUserRepository
{
  private readonly GetItAppContext _context;

  public UserRepository(GetItAppContext context) => _context = context;

  public async Task<IEnumerable<User>> GetUsers()
  {
    return await _context.Users.ToListAsync();
  }

  public async Task<QuizResultDTO> GetUserQuizResult(int quizId, int userId)
  {
    var quiz = await _context.Quizzes
      .Include(q => q.Questions)
      .ThenInclude(q => q.Options)
      .FirstOrDefaultAsync(q => q.Id == quizId);

    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    var userResult = await _context.Results.Where(r => r.UserId == userId).ToListAsync();
    
    var quizResult = new QuizResultDTO()
    {
      Username = user.Name,
      QuizTitle = quiz.Title,
      Questions = quiz.Questions.Select(q => new QuestionResultDTO()
      {
        Text = q.Text,
        Options = q.Options.Select(o => new OptionResultDTO()
        {
          Text = o.Text,
          IsCorrect = o.IsCorrect,
          WasChosen = userResult.Any(r => r.OptionId == o.Id)
        }
        ).ToList()
      }).ToList()
    };
    quizResult.Questions.ForEach(q => q.IsAnswerCorrect = CheckAnswers(q.Options));
    quizResult.Score = CalculateScore(quizResult.Questions);
    
    return quizResult;
  }

  private double CalculateScore(List<QuestionResultDTO> questions)
  {
    return 100 * questions.Where(q => q.IsAnswerCorrect).Count() / questions.Count();
  }

  private bool CheckAnswers(List<OptionResultDTO> options)
  {
    foreach (var option in options)
    {
      if (option.IsCorrect && option.WasChosen)
      {
        return true;
      }
    }
    return false;
  }

  public async Task<User> GetUser(int id)
  {
    return await _context.Users.FirstOrDefaultAsync(r => r.Id == id);
  }

  public async Task<User> CreateUser(CreateUserDTO userDto)
  {
    var newUser = new User()
    {
      Name = userDto.Name
    };

    _context.Users.Add(newUser);
    await _context.SaveChangesAsync();

    return newUser;
  }
}
