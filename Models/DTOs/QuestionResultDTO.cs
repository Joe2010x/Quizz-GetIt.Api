namespace GetIt.Api.Models.DTOs
{
  public class QuestionResultDTO
  {
    public string Text { get; set; }
    public bool IsAnswerCorrect { get; set; }
    public List<OptionResultDTO> Options { get; set; }
    
  }
}
