using AgendaNutricionistaApi.Data;
using AgendaNutricionistaApi.DTOs;
using AgendaNutricionistaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaNutricionistaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            return await _context.Patients
                .Select(p => new PatientDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    IdentificationCard = p.IdentificationCard,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                IdentificationCard = patient.IdentificationCard,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email
            };
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IdentificationCard = dto.IdentificationCard,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var result = new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                IdentificationCard = patient.IdentificationCard,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email
            };

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, CreatePatientDto dto)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.IdentificationCard = dto.IdentificationCard;
            patient.PhoneNumber = dto.PhoneNumber;
            patient.Email = dto.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
