namespace GetIt.Api.Models.DTOs;

public class QuizResultDTO
{
  public string Username { get; set; }
  public double Score { get; set; }
  public string QuizTitle { get; set; }
  public List<QuestionResultDTO> Questions { get; set; }
  
}
