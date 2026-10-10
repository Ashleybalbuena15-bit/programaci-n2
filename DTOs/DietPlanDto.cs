using System;

namespace AgendaNutricionistaApi.DTOs
{
    public class DietPlanDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double TargetCalories { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PatientId { get; set; }
    }

    public class CreateDietPlanDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double TargetCalories { get; set; }
        public int PatientId { get; set; }
    }
}
