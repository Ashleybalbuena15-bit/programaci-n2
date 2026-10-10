using AgendaNutricionistaApi.Data;
using AgendaNutricionistaApi.DTOs;
using AgendaNutricionistaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaNutricionistaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietPlansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DietPlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietPlanDto>>> GetDietPlans()
        {
            return await _context.DietPlans
                .Select(d => new DietPlanDto
                {
                    Id = d.Id,
                    Title = d.Title,
                    Description = d.Description,
                    TargetCalories = d.TargetCalories,
                    CreatedDate = d.CreatedDate,
                    PatientId = d.PatientId
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DietPlanDto>> GetDietPlan(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);

            if (dietPlan == null)
            {
                return NotFound();
            }

            return new DietPlanDto
            {
                Id = dietPlan.Id,
                Title = dietPlan.Title,
                Description = dietPlan.Description,
                TargetCalories = dietPlan.TargetCalories,
                CreatedDate = dietPlan.CreatedDate,
                PatientId = dietPlan.PatientId
            };
        }

        [HttpPost]
        public async Task<ActionResult<DietPlanDto>> CreateDietPlan(CreateDietPlanDto dto)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.Id == dto.PatientId);
            if (!patientExists)
            {
                return BadRequest("PatientId does not exist.");
            }

            var dietPlan = new DietPlan
            {
                Title = dto.Title,
                Description = dto.Description,
                TargetCalories = dto.TargetCalories,
                PatientId = dto.PatientId,
                CreatedDate = DateTime.Now
            };

            _context.DietPlans.Add(dietPlan);
            await _context.SaveChangesAsync();

            var result = new DietPlanDto
            {
                Id = dietPlan.Id,
                Title = dietPlan.Title,
                Description = dietPlan.Description,
                TargetCalories = dietPlan.TargetCalories,
                CreatedDate = dietPlan.CreatedDate,
                PatientId = dietPlan.PatientId
            };

            return CreatedAtAction(nameof(GetDietPlan), new { id = dietPlan.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDietPlan(int id, CreateDietPlanDto dto)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);

            if (dietPlan == null)
            {
                return NotFound();
            }

            dietPlan.Title = dto.Title;
            dietPlan.Description = dto.Description;
            dietPlan.TargetCalories = dto.TargetCalories;
            dietPlan.PatientId = dto.PatientId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietPlan(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);
            if (dietPlan == null)
            {
                return NotFound();
            }

            _context.DietPlans.Remove(dietPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
