using Microsoft.AspNetCore.Mvc;
using AgendaNutricionistaApi.Models;
using AgendaNutricionistaApi.Repositories;

namespace AgendaNutricionistaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietPlansController : ControllerBase
    {
        private readonly IDietPlanRepository _dietPlanRepository;

        public DietPlansController(IDietPlanRepository dietPlanRepository)
        {
            _dietPlanRepository = dietPlanRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietPlan>>> GetDietPlans()
        {
            var dietPlans = await _dietPlanRepository.GetAllAsync();
            return Ok(dietPlans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DietPlan>> GetDietPlan(int id)
        {
            var dietPlan = await _dietPlanRepository.GetByIdAsync(id);
            if (dietPlan == null) return NotFound();
            return Ok(dietPlan);
        }

        [HttpPost]
        public async Task<ActionResult<DietPlan>> PostDietPlan(DietPlan dietPlan)
        {
            await _dietPlanRepository.AddAsync(dietPlan);
            return CreatedAtAction(nameof(GetDietPlan), new { id = dietPlan.Id }, dietPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDietPlan(int id, DietPlan dietPlan)
        {
            if (id != dietPlan.Id) return BadRequest();
            await _dietPlanRepository.UpdateAsync(dietPlan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietPlan(int id)
        {
            await _dietPlanRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
