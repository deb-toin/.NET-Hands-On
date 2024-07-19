using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetshopApi.Models;

namespace Basic_ASPNET_API_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetshopItemsController : ControllerBase
    {
        private readonly PetshopContext _context;
        public PetshopItemsController(PetshopContext context)
        {
            _context = context;
        }

        // GET: api/PetshopItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetshopItem>>> GetPetshopItems()
        {
            return await _context.PetshopItems.ToListAsync();
        }

        // GET: api/PetshopItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetshopItem>> GetPetshopItem(long id)
        {
            var petshopItem = await _context.PetshopItems.FindAsync(id);

            if (petshopItem == null)
            {
                return NotFound();
            }
            return petshopItem;
        }

        // GET: api/PetshopItems/name/Snoopy
        [HttpGet("/name/{name}")]
        public async Task<ActionResult<PetshopItem>> GetPetshopItemByName(string name)
        {
            var petshopItem = await _context.PetshopItems.Where(b => b.Name.Contains($"{name}")).ToListAsync();

            if (petshopItem.Count == 0)
            {
                return NotFound($"No {name} was welcomed here");
            }
            
            return Ok(petshopItem);
        }

        // GET: api/PetshopItems/spec/Dog
        [HttpGet("/spec/{species}")]
        public async Task<ActionResult<PetshopItem>> GetPetshopItemBySpec(string species)
        {
            var petshopItem = await _context.PetshopItems.Where(b => b.Species.Contains($"{species}")).ToListAsync();

            if (petshopItem.Count == 0)
            {
                return NotFound($"No {species} are listed at this moment");
            }

            return Ok(petshopItem);
        }

        // GET: api/PetshopItems/toBeAdopted
        [HttpGet("/toBeAdopted")]
        public async Task<ActionResult<PetshopItem>> GetPetshopItemNonAdopted()
        {
            var petshopItem = await _context.PetshopItems.Where(b => b.IsAdopted == false).ToListAsync();
            if (petshopItem.Count == 0)
            {
                return NotFound("Yay everyone has been adopted !");
            }
            return Ok(petshopItem);
        }

        // PUT: api/PetshopItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetshopItem(long id, PetshopItem petshopItem)
        {
            if (id != petshopItem.Id)
            {
                return BadRequest("You have to provide an id.");
            }
            if (petshopItem.Name == ""){
                ModelState.AddModelError("petshopItem.Name","You have to provide a name.");
                return BadRequest("You have to provide a name.");
            }
            if (petshopItem.Species == ""){
                ModelState.AddModelError("petshopItem.Species","You have to provide a species.");
                return BadRequest("You have to provide a species.");
            }
            if (petshopItem.Pedigree == ""){
                ModelState.AddModelError("petshopItem.Pedigree","You have to provide a pedigree/race.");
                return BadRequest("You have to provide a pedigree/race.");
            }
            if (petshopItem.Colour == ""){
                ModelState.AddModelError("petshopItem.Colour","You have to provide a fur/skin/feather colour.");
                return BadRequest("You have to provide a fur/skin/feather colour.");
            }
            _context.Entry(petshopItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetshopItemExists(id))
                {
                    return NotFound($"No animal found under id {id}");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PetshopItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetshopItem>> PostPetshopItem(PetshopItem petshopItem)
        {
            if (petshopItem.Name == ""){
                ModelState.AddModelError("petshopItem.Name","You have to provide a name.");
                return BadRequest("You have to provide a name.");
            }
            if (petshopItem.Species == ""){
                ModelState.AddModelError("petshopItem.Species","You have to provide a species.");
                return BadRequest("You have to provide a species.");
            }
            if (petshopItem.Pedigree == ""){
                ModelState.AddModelError("petshopItem.Pedigree","You have to provide a pedigree/race.");
                return BadRequest("You have to provide a pedigree/race.");
            }
            if (petshopItem.Colour == ""){
                ModelState.AddModelError("petshopItem.Colour","You have to provide a fur/skin/feather colour.");
                return BadRequest("You have to provide a fur/skin/feather colour.");
            }
            _context.PetshopItems.Add(petshopItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPetshopItem), new { id = petshopItem.Id }, petshopItem);
        }

        // DELETE: api/PetshopItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetshopItem(long id)
        {
            var petshopItem = await _context.PetshopItems.FindAsync(id);
            if (petshopItem == null)
            {
                return NotFound();
            }

            _context.PetshopItems.Remove(petshopItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetshopItemExists(long id)
        {
            return _context.PetshopItems.Any(e => e.Id == id);
        }
    }
}
