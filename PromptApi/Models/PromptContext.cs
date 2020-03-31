using Microsoft.EntityFrameworkCore;

namespace PromptApi.Models
{
  public class PromptContext : DbContext
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Prompt>()
          .HasData(
              new Prompt { PromptId = 2, Title = "Dave's Story", Content = "Dave had a story, but then again, so does everyone", AuthorName = "Dave", Journal = "Daves Journal" },
              new Prompt { PromptId = 1, Title = "Matilda", Content = "Jimmy is a dude, pretty cool dude, but is not a template writing-prompt, funny how that works", AuthorName = "Jimmyboy", Journal = "Jimmy Journal" }
          );
    }
    public PromptContext(DbContextOptions<PromptContext> options)
        : base(options)
    {
    }

    public DbSet<Prompt> Prompts { get; set; }
  }
}