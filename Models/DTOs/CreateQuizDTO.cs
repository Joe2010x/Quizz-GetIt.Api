namespace GetIt.Api.Models.DTOs;

public class CreateQuizDTO 
{
  [Required]
  public string Title { get; set; }
  [DataType(DataType.Date)]
  public DateTime Date { get; set; }
  public List<CreateQuestionDTO> Questions { get; set; }
  
}
