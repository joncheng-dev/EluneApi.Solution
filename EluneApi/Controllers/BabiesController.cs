using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EluneApi.Models;

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
  }
}