using GetIt.Api.Models;
using GetIt.Api.Models.DTOs;
using GetIt.Api.Data.IRepositories;

namespace GetIt.Api.Data.Repositories;

public class QuizRepository : IQuizRepository
{
  private readonly GetItAppContext _context;

  public QuizRepository(GetItAppContext context) => _context = context;
  public async Task<QuizDTO> GetQuiz(int id)
  {
    var quiz = await _context.Quizzes
      .Include(q => q.Questions)
      .ThenInclude(q => q.Options)
      .FirstOrDefaultAsync(q => q.Id == id);

    return ConvertQuiz(quiz);
  }

  public async Task<List<Quiz>> GetQuizzes()
  {
    var quizzes = await _context.Quizzes
      .Include(q => q.Questions)
      .ThenInclude(q => q.Options).ToListAsync();

    return quizzes;
  }

  private QuizDTO ConvertQuiz(Quiz quiz)
  {
    return new QuizDTO()
    {
      Id = quiz.Id,
      Title = quiz.Title,
      Date = quiz.Date,
      Questions = ConvertQuestion(quiz.Questions)
    };
  }

  private List<QuestionDTO> ConvertQuestion(List<Question> questions)
  {
    return questions.Select(q => new QuestionDTO()
    {
      Id = q.Id,
      Text = q.Text,
      QuizId = q.QuizId,
      Options = ConvertOption(q.Options)
    }).ToList();
  }

  private List<OptionDTO> ConvertOption(List<Option> options)
  {
    return options.Select(o => new OptionDTO()
    {
      Id = o.Id,
      Text = o.Text,
      QuestionId = o.QuestionId
    }).ToList();
  }

  public async Task AddQuiz(CreateQuizDTO DTO)
  {
    var quiz = new Quiz()
    {
      Title = DTO.Title,
      Questions = DTO.Questions.Select(q => new Question()
      {
        Text = q.Text,
        Options = q.Options.Select(o => new Option()
        {
          Text = o.Text,
          IsCorrect = o.IsCorrect
        }).ToList()
      }
      ).ToList()
    };
    _context.Add(quiz);
    await _context.SaveChangesAsync();
  }

  public async Task RemoveQuiz(int id)
  {
    var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
    _context.Remove(quiz);
    await _context.SaveChangesAsync();
  }

}