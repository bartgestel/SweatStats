using System.ComponentModel.DataAnnotations;

namespace SweatStats.Models
{
    public class TrainingViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<TrainingViewModel> trainings = new List<TrainingViewModel>();
    }
}
