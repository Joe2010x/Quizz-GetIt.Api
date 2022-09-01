namespace GetIt.Api.Models;

public class Quiz 
{
  public int Id {get;set;}
  [Required]
  public string Title { get; set; }
  [DataType(DataType.Date)]
  public DateTime Date { get; set; }
  public List<Question> Questions { get; set; }

}
