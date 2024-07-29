using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EluneApi.Models;
using EluneApi;

namespace EluneApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BabiesController : ControllerBase
  {
    private readonly EluneApiContext _db;

    public BabiesController(EluneApiContext db)
    {
      _db = db;
    }

    // GET: api/babies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Baby>>> Get()
    {
      return await _db.Babies.ToListAsync();
    }

    // GET: api/Babies/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Baby>> GetBaby(int id)
    {
      Baby baby = await _db.Babies.FindAsync(id);

      if (baby == null)
      {
        return NotFound();
      }

      return baby;
    }

    // POST api/babies
    [HttpPost]
    public async Task<ActionResult<Baby>> Post(Baby baby)
    {
      _db.Babies.Add(baby);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetBaby), new { id = baby.BabyId }, baby);
    }

    // PUT: api/babies/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Baby baby)
    {
      if (id != baby.BabyId)
      {
        return BadRequest();
      }

      _db.Babies.Update(baby);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BabyExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool BabyExists(int id)
    {
      return _db.Babies.Any(e => e.BabyId == id);
    }

    // DELETE: api/Babies/6
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBaby(int id)
    {
      Baby baby = await _db.Babies.FindAsync(id);
      if(baby == null)
      {
        return NotFound();
      }

      _db.Babies.Remove(baby);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // GET: api/Babies/{babyId}/SleepTimes
    [HttpGet("{babyId}/SleepTimes")]
    public async Task<ActionResult<IEnumerable<SleepTime>>> GetSleepTimesByBabyId(int babyId)
    {
      var sleepTimes = await _db.SleepTimes
        .Where(s => s.BabyId == babyId)
        .ToListAsync();

      if (sleepTimes == null || sleepTimes.Count == 0)
      {
        return NotFound();
      }

      return sleepTimes;
    }

    // GET: api/Babies/{babyId}/SleepTimes/{sleepTimeId}
    [HttpGet("{babyId}/SleepTimes/{sleepTimeId}")]
    public async Task<ActionResult<SleepTime>> GetSleepTime(int babyId, int sleepTimeId)
    {
      var sleepTime = await _db.SleepTimes
        .Where(s => s.BabyId == babyId && s.SleepTimeId == sleepTimeId)
        .FirstOrDefaultAsync();

      if (sleepTime == null)
      {
        return NotFound();
      }

      return sleepTime;
    }

    // POST: api/Babies/{babyId}/SleepTimes
    [HttpPost("{babyId}/SleepTimes")]
    public async Task<ActionResult<SleepTime>> PostSleepTime(int babyId, [FromBody] SleepTime sleepTime)
    {
      var baby = await _db.Babies.FindAsync(babyId);

      if (baby == null)
      {
        return NotFound($"Baby with ID {babyId} not found.");
      }

      sleepTime.BabyId = babyId;
      sleepTime.Baby = baby;

      // Add sleep time to database
      _db.SleepTimes.Add(sleepTime);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetSleepTime), new {babyId, sleepTimeId = sleepTime.SleepTimeId}, sleepTime);
    }

    // DELETE: api/Babies/{babyId}/SleepTimes/{sleepTimeId}
    [HttpDelete("{babyId}/SleepTimes/{sleepTimeId}")]
    public async Task<IActionResult> DeleteSleepTime(int babyId, int sleepTimeId)
    {
      var sleepTime = await _db.SleepTimes
        .FirstOrDefaultAsync(s => s.BabyId == babyId && s.SleepTimeId == sleepTimeId);

      if (sleepTime == null)
      {
        return NotFound();
      }

      _db.SleepTimes.Remove(sleepTime);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // GET: api/Babies/{babyId}/FeedingTimes
    [HttpGet("{babyId}/FeedingTimes")]
    public async Task<ActionResult<IEnumerable<FeedingTime>>> GetFeedingTimesByBabyId(int babyId)
    {
      var feedingTimes = await _db.FeedingTimes
        .Where(s => s.BabyId == babyId)
        .ToListAsync();

      if (feedingTimes == null || feedingTimes.Count == 0)
      {
        return NotFound();
      }

      return feedingTimes;
    }

    // GET: api/Babies/{babyId}/FeedingTimes/{feedingTimeId}
    [HttpGet("{babyId}/FeedingTimes/{feedingTimeId}")]
    public async Task<ActionResult<FeedingTime>> GetFeedingTime(int babyId, int feedingTimeId)
    {
      var feedingTime = await _db.FeedingTimes
        .Where(s => s.BabyId == babyId && s.FeedingTimeId == feedingTimeId)
        .FirstOrDefaultAsync();

      if (feedingTime == null)
      {
        return NotFound();
      }

      return feedingTime;
    }

    // POST: api/Babies/{babyId}/FeedingTimes
    [HttpPost("{babyId}/FeedingTimes")]
    public async Task<ActionResult<FeedingTime>> PostFeedingTime(int babyId, [FromBody] FeedingTime feedingTime)
    {
      var baby = await _db.Babies.FindAsync(babyId);

      if (baby == null)
      {
        return NotFound($"Baby with ID {babyId} not found.");
      }

      feedingTime.BabyId = babyId;
      feedingTime.Baby = baby;

      // Add feeding time to database
      _db.FeedingTimes.Add(feedingTime);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetFeedingTime), new {babyId, feedingTimeId = feedingTime.FeedingTimeId}, feedingTime);
    }

    // DELETE: api/Babies/{babyId}/FeedingTimes/{feedingTimeId}
    [HttpDelete("{babyId}/FeedingTimes/{feedingTimeId}")]
    public async Task<IActionResult> DeleteFeedingTime(int babyId, int feedingTimeId)
    {
      var feedingTime = await _db.FeedingTimes
        .FirstOrDefaultAsync(f => f.BabyId == babyId && f.FeedingTimeId == feedingTimeId);

      if (feedingTime == null)
      {
        return NotFound();
      }

      _db.FeedingTimes.Remove(feedingTime);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // GET: api/Babies/{babyId}/BathroomTimes
    [HttpGet("{babyId}/BathroomTimes")]
    public async Task<ActionResult<IEnumerable<BathroomTime>>> GetBathroomTimesByBabyId(int babyId)
    {
      var bathroomTimes = await _db.BathroomTimes
        .Where(s => s.BabyId == babyId)
        .ToListAsync();

      if(bathroomTimes == null || bathroomTimes.Count == 0)
      {
        return NotFound();
      }

      return bathroomTimes;
    }

    // GET: api/Babies/{babyId}/BathroomTimes/{bathroomTimeId}
    [HttpGet("{babyId}/BathroomTimes/{bathroomTimeId}")]
    public async Task<ActionResult<BathroomTime>> GetBathroomTime(int babyId, int bathroomTimeId)
    {
      var bathroomTime = await _db.BathroomTimes
        .Where(s => s.BabyId == babyId && s.BathroomTimeId == bathroomTimeId)
        .FirstOrDefaultAsync();

      if (bathroomTime == null)
      {
        return NotFound();
      }

      return bathroomTime;
    }

    // POST: api/Babies/{babyId}/BathroomTimes
    [HttpPost("{babyId}/BathroomTimes")]
    public async Task<ActionResult<BathroomTime>> PostBathroomTime(int babyId, [FromBody] BathroomTime bathroomTime)
    {
      var baby = await _db.Babies.FindAsync(babyId);

      if (baby == null)
      {
        return NotFound($"Baby with ID {babyId} not found.");
      }

      bathroomTime.BabyId = babyId;
      bathroomTime.Baby = baby;

      // Add bathroom time to database
      _db.BathroomTimes.Add(bathroomTime);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBathroomTime), new {babyId, bathroomTimeId = bathroomTime.BathroomTimeId}, bathroomTime);
    }

    // DELETE: api/Babies/{babyId}/BathroomTimes/{bathroomTimeId}
    [HttpDelete("{babyId}/BathroomTimes/{bathroomTimeId}")]
    public async Task<IActionResult> DeleteBathroomTime(int babyId, int bathroomTimeId)
    {
      var bathroomTime = await _db.BathroomTimes
          .FirstOrDefaultAsync(b => b.BabyId == babyId && b.BathroomTimeId == bathroomTimeId);

      if (bathroomTime == null)
      {
          return NotFound();
      }

      _db.BathroomTimes.Remove(bathroomTime);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}