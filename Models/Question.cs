namespace GetIt.Api.Models;

public class Question
{
  public int Id { get; set; }
  [Required]
  public string Text { get; set; }
  public int QuizId { get; set; }
  public List<Option> Options { get; set; }

}
