using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace PromptApi.Models
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

    public string Journal { get; set; }

    public string Authentication = "Jimmyboy";

    public string AuthorName { get; set; }

    public List<int> PromptIds = new List<int>();
  }
}