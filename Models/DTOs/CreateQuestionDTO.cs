namespace GetIt.Api.Models.DTOs;

public class CreateQuestionDTO
{
  [Required]
  public string Text { get; set; }
  public List<CreateOptionDTO> Options { get; set; } 
  
}
