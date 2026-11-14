using AgendaNutricionistaApi.Models;

namespace AgendaNutricionistaApi.Repositories
{
    public interface IDietPlanRepository
    {
        Task<IEnumerable<DietPlan>> GetAllAsync();
        Task<DietPlan?> GetByIdAsync(int id);
        Task AddAsync(DietPlan dietPlan);
        Task UpdateAsync(DietPlan dietPlan);
        Task DeleteAsync(int id);
    }
}
