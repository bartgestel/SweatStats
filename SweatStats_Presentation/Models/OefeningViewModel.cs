using System.ComponentModel.DataAnnotations;

namespace SweatStats.Models
{
    public class OefeningViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public int Sets { get; set; }
        [Required]
        public int minReps { get; set; }
        [Required]
        public int maxReps { get; set; }
        [Required]
        public decimal weightKg { get; set; }
        public List<OefeningViewModel> oefeningen = new List<OefeningViewModel>();
    }
}
