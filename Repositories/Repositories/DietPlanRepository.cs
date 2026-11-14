using Microsoft.EntityFrameworkCore;
using AgendaNutricionistaApi.Data;
using AgendaNutricionistaApi.Models;

namespace AgendaNutricionistaApi.Repositories
{
    public class DietPlanRepository : IDietPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public DietPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DietPlan>> GetAllAsync()
        {
            return await _context.DietPlans.ToListAsync();
        }

        public async Task<DietPlan?> GetByIdAsync(int id)
        {
            return await _context.DietPlans.FindAsync(id);
        }

        public async Task AddAsync(DietPlan dietPlan)
        {
            await _context.DietPlans.AddAsync(dietPlan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DietPlan dietPlan)
        {
            _context.DietPlans.Update(dietPlan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);
            if (dietPlan != null)
            {
                _context.DietPlans.Remove(dietPlan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
