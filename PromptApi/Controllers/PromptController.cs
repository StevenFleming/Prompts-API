using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PromptApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace PromptApi.Controllers

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
    public ActionResult<IEnumerable<Prompt>> Get(string title, string content, string authorName, string journal)
    {
      var query = _db.Prompts.AsQueryable();

      if (title != null)
      {
        query = query.Where(entry => entry.Title == title);
      }

      if (content != null)
      {
        query = query.Where(entry => entry.Content == content);
      }

      if (authorName != null)
      {
        query = query.Where(entry => entry.AuthorName == authorName);
      }

      if (journal != null)
      {
        query = query.Where(entry => entry.Journal == journal);
      }

      return query.ToList();
    }

    // GET api/prompts/random
    [HttpGet("random")]
    public ActionResult<Prompt> GetRandom()
    {

      Random rnd = new Random();
      var query = _db.Prompts.AsQueryable();
      var queryList = query.ToList();
      var RandomNum = rnd.Next(0, queryList.Count - 1);
      return queryList[RandomNum];
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

      if (prompt.Authentication == prompt.AuthorName)
      {
        _db.Entry(prompt).State = EntityState.Modified;
      }
      _db.SaveChanges();
    }

    // DELETE api/prompts/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var promptToDelete = _db.Prompts.FirstOrDefault(entry => entry.PromptId == id);
      if (promptToDelete.Authentication == promptToDelete.AuthorName)
      {
        _db.Prompts.Remove(promptToDelete);
      }
      _db.SaveChanges();
    }
  }
}
