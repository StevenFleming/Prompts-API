using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Prompt.Models
{
  public class Prompt
  {
    public int PromptId { get; set; }
    [Required]


    [StringLength(20)]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    
    public string AuthorName { get; set; }
  }
}