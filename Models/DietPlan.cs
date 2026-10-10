using System;

namespace AgendaNutricionistaApi.Models
{
    public class DietPlan
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double TargetCalories { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
