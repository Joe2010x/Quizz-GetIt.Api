namespace GetIt.Api.Models.DTOs;

public class QuestionDTO
{
  public int Id { get; set; }
  [Required]
  public string Text { get; set; }
  public int QuizId { get; set; }
  public List<OptionDTO> Options { get; set; } 
  
}
