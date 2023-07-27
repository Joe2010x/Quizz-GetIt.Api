namespace GetIt.Api.Models;

public class Option
{
  public int Id { get; set; }
  public string Text { get; set; }
  public bool IsCorrect { get; set; }
  public int QuestionId { get; set; }
  
}
