using System.Collections.Generic;

namespace AgendaNutricionistaApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdentificationCard { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<DietPlan> DietPlans { get; set; } = new List<DietPlan>();
    }
}
