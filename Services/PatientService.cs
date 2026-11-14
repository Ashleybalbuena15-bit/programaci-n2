using AgendaNutricionistaApi.Contracts;
using AgendaNutricionistaApi.Models;
using AgendaNutricionistaApi.Repositories;

namespace AgendaNutricionistaApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() => await _patientRepository.GetAllAsync();

        public async Task<Patient?> GetByIdAsync(int id) => await _patientRepository.GetByIdAsync(id);

        public async Task AddAsync(Patient patient) => await _patientRepository.AddAsync(patient);

        public async Task UpdateAsync(Patient patient) => await _patientRepository.UpdateAsync(patient);

        public async Task DeleteAsync(int id) => await _patientRepository.DeleteAsync(id);
    }
}
