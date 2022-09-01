namespace GetIt.Api.Models.DTOs;

public class QuizDTO 
{
  public int Id {get;set;}
  [Required]
  public string Title { get; set; }
  [DataType(DataType.Date)]
  public DateTime Date { get; set; }
  public List<QuestionDTO> Questions { get; set; }
  
}
