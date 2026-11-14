using AgendaNutricionistaApi.Models;

namespace AgendaNutricionistaApi.Contracts
{
    public interface IDietPlanService
    {
        Task<IEnumerable<DietPlan>> GetAllAsync();
        Task<DietPlan?> GetByIdAsync(int id);
        Task AddAsync(DietPlan dietPlan);
        Task UpdateAsync(DietPlan dietPlan);
        Task DeleteAsync(int id);
    }
}
