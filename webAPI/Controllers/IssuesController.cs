using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IssuesController(ApplicationDbContext context)
        {
            _context = context;
            if (!_context.Issues.Any())
            {
                Issue issue = new Issue
                {
                    Name = "issue",
                    Description = "issue",
                    Status = Status.Open,
                    CreatedAt = DateTime.UtcNow.Date,
                    UpdatedAt = DateTime.UtcNow.Date,
                    PlanFinishingDate = DateTime.UtcNow.Date.AddDays(1),
                    FactFinishingDate = DateTime.UtcNow.Date.AddDays(2),
                    AuthorId = "e31f3e59-8975-4af3-ac12-be8f7f480d65",
                    AssigneeId = "f04dd6c1-d467-42d8-8add-f08fab51df62"
                };
                _context.Issues.Add(issue);
                _context.SaveChangesAsync();
            }
        }

        // GET: api/Issues
        [HttpGet]
        public IEnumerable<Issue> GetIssues()
        {
            return _context.Issues;
        }

        // GET: api/Issues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return Ok(issue);
        }

        // PUT: api/Issues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssue([FromRoute] int id, [FromBody] Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != issue.Id)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(issue);
        }

        // POST: api/Issues
        [HttpPost]
        public async Task<IActionResult> PostIssue([FromBody] Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (issue.Status != Status.Open)
            {
                issue.Status = Status.Open;
            }

            //var createdAt = issue.CreatedAt;
            //var updatedAt = issue.UpdatedAt;

            //if (String.IsNullOrEmpty(createdAt.ToString()))
            //{
            //    createdAt = DateTime.UtcNow.Date;
            //}

            //if (String.IsNullOrEmpty(updatedAt.ToString()) ||
            //    updatedAt.CompareTo(createdAt) < 0 )
            //{
            //    updatedAt = createdAt;
            //}

            //issue.CreatedAt = createdAt;
            //issue.UpdatedAt = updatedAt;

            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssue", new { id = issue.Id }, issue);
        }

        // DELETE: api/Issues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();

            return Ok(issue);
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.Id == id);
        }
    }
}