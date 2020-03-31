using Microsoft.EntityFrameworkCore;

namespace Prompt.Models
{
  public class PromptContext : DbContext
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Prompt>()
          .HasData(
              new Prompt { PromptId = 1, Title = "Matilda", Content = "Jimmy is a dude, pretty cool dude, but is not a template writing-prompt, funny how that works", AuthorName = "Jimmyboy" }
          );
    }
    public PromptContext(DbContextOptions<PromptContext> options)
        : base(options)
    {
    }

    public DbSet<Prompt> Prompts { get; set; }
  }
}