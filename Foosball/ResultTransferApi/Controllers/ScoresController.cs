using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ResultTransferApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ScoresController : Controller
    {
        private readonly ScoresContext _context;

        public ScoresController(ScoresContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IEnumerable<Scores> GetAll()
        {
            return _context.Scores.ToList();
        }

        [HttpGet("{id}", Name = "GetScores")]
        public IActionResult GetById(long id)
        {
            var item = _context.Scores.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Scores item)
        {
            _context.Scores.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetScores", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Scores item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var score = _context.Scores.FirstOrDefault(t => t.Id == id);
            if (score == null)
            {
                return NotFound();
            }

            score.RedTeamScore = item.RedTeamScore;
            score.BlueTeamScore = item.BlueTeamScore;

            _context.Scores.Update(score);
            _context.SaveChanges();
            return new NoContentResult();
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(long id, [FromBody] Scores item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var score = _context.Scores.FirstOrDefault(t => t.Id == id);
            if (score == null)
            {
                return NotFound();
            }
            if (item.RedTeamScore > score.RedTeamScore)
                score.RedTeamScore = item.RedTeamScore;
            if (item.BlueTeamScore > score.RedTeamScore)
                score.BlueTeamScore = item.BlueTeamScore;
            _context.Scores.Update(score);
            _context.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var score = _context.Scores.FirstOrDefault(t => t.Id == id);
            if (score == null)
            {
                return NotFound();
            }

            _context.Scores.Remove(score);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}