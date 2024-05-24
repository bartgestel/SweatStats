namespace SweatStats.Models;

public class OefeningLogViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Reps { get; set; }
    public decimal WeightKg { get; set; }
    public DateTime Date { get; set; }
}