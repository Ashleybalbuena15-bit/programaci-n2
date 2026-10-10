using AgendaNutricionistaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaNutricionistaApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
    }
}
