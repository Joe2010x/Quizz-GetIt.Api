using GetIt.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GetIt.Api.Data;
public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new GetItAppContext(
        serviceProvider.GetRequiredService<DbContextOptions<GetItAppContext>>()))
    // Look for any movies.
    {
      if (context.Quizzes.Any()) { return; }
      context.Quizzes.AddRange(
          new Quiz()
          {
            Title = "Introduction to C# .NET",
            Date = DateTime.Now,
            Questions = new List<Question>()
            {
              new Question()
              {
                Text = "When was C# released?",
                Options = new List<Option>()
                {
                  new Option()
                  {
                    Text = "~1990",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "~1995",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "~2000",
                    IsCorrect = true
                  },
                  new Option()
                  {
                    Text = "~2005",
                    IsCorrect = false
                  }
                }
              },
              new Question()
              {
                Text = "Which company developed the C# language?",
                Options = new List<Option>()
                {
                  new Option()
                  {
                    Text = "Apple",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "Facebook",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "Google",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "Microsoft",
                    IsCorrect = true
                  }
                }
              },
              new Question()
              {
                Text = "What describes the C#?",
                Options = new List<Option>()
                {
                  new Option()
                  {
                    Text = "Dynamic typed language",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "Static and strong typed language",
                    IsCorrect = true
                  }
                }
              },
              new Question()
              {
                Text = "When was the first version of .NET Framework released?",
                Options = new List<Option>()
                {
                  new Option()
                  {
                    Text = "1995",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "2000",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "2002",
                    IsCorrect = true
                  },
                  new Option()
                  {
                    Text = "2005",
                    IsCorrect = false
                  }
                }
              },
              new Question()
              {
                Text = "Which languages does .NET support?",
                Options = new List<Option>()
                {
                  new Option()
                  {
                    Text = "C#, VB.NET and Java",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "C#, F# and Java",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "C#, VB.NET and F#",
                    IsCorrect = true
                  },
                  new Option()
                  {
                    Text = "C#, VB.NET and C++",
                    IsCorrect = false
                  }
                }
              },
              new Question()
              {
                Text = "What does the .NET provide except language support?",
                Options = new List<Option>()
                {
                  new Option()
                  {
                    Text = "Common Language Runtime (CLR) and Framework Class Library (FCL)",
                    IsCorrect = true
                  },
                  new Option()
                  {
                    Text = "C# Runtime (CSR) and Dotnet Class Library (DCL)",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "Java Runtime Environment (JRE) and Framework Class Library (FCL)",
                    IsCorrect = false
                  },
                  new Option()
                  {
                    Text = "J Runtime Environment (JRE) and J-Framework Class Library (JFCL)",
                    IsCorrect = false
                  }
                }
              },
            }
          }
      );
      context.SaveChanges();
    }
  }
}