using AgendaNutricionistaApi.Contracts;
using AgendaNutricionistaApi.Models;
using AgendaNutricionistaApi.Repositories;

namespace AgendaNutricionistaApi.Services
{
    public class DietPlanService : IDietPlanService
    {
        private readonly IDietPlanRepository _dietPlanRepository;

        public DietPlanService(IDietPlanRepository dietPlanRepository)
        {
            _dietPlanRepository = dietPlanRepository;
        }

        public async Task<IEnumerable<DietPlan>> GetAllAsync() => await _dietPlanRepository.GetAllAsync();

        public async Task<DietPlan?> GetByIdAsync(int id) => await _dietPlanRepository.GetByIdAsync(id);

        public async Task AddAsync(DietPlan dietPlan) => await _dietPlanRepository.AddAsync(dietPlan);

        public async Task UpdateAsync(DietPlan dietPlan) => await _dietPlanRepository.UpdateAsync(dietPlan);

        public async Task DeleteAsync(int id) => await _dietPlanRepository.DeleteAsync(id);
    }
}
