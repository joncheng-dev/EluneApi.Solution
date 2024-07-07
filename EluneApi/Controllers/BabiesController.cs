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

  }
}