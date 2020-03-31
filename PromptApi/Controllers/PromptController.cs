using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prompt.Models;
using Microsoft.EntityFrameworkCore;

namespace Prompt.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PromptsController : ControllerBase
  {
    private PromptContext _db;

    public PromptsController(PromptContext db)
    {
      _db = db;
    }

    // GET api/prompts
    [HttpGet]
    public ActionResult<IEnumerable<Prompt>> Get(string title, string content, string authorName)
    {
      var query = _db.Prompts.AsQueryable();

      if (title != null)
      {
        query = query.Where(entry => entry.title == title);
      }

      if (content != null)
      {
        query = query.Where(entry => entry.content == content);
      }

      if (AuthorName != null)
      {
        query = query.Where(entry => entry.authorName == authorName);
      }

      return query.ToList();
    }

    // POST api/prompts
    [HttpPost]
    public void Post([FromBody] Prompt prompt)
    {
      _db.Prompts.Add(prompt);
      _db.SaveChanges();
    }

    // GET api/prompts/5
    [HttpGet("{id}")]
    public ActionResult<Prompt> Get(int id)
    {
      return _db.Prompts.FirstOrDefault(entry => entry.PromptId == id);
    }

    // PUT api/prompts/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Prompt prompt)
    {
      prompt.PromptId = id;
      _db.Entry(prompt).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/prompts/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var promptToDelete = _db.Prompts.FirstOrDefault(entry => entry.PromptId == id);
      _db.Prompts.Remove(promptToDelete);
      _db.SaveChanges();
    }
  }
}
