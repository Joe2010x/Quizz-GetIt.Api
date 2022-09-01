using GetIt.Api.Models;

namespace GetIt.Api.Data;

public class GetItAppContext : DbContext
{
  public GetItAppContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Option> Options { get; set; }
  public DbSet<Question> Questions { get; set; }
  public DbSet<Quiz> Quizzes { get; set; }
  public DbSet<Result> Results { get; set; }
  public DbSet<User> Users { get; set; }
}