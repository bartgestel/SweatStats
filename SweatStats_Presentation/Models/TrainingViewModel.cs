using System.ComponentModel.DataAnnotations;

namespace SweatStats.Models
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";

        public List<TrainingViewModel> trainings = new List<TrainingViewModel>();

        public List<OefeningViewModel> oefeningen = new List<OefeningViewModel>();
    }
}
