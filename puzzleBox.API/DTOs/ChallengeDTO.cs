namespace PuzzleBox.DTOs;

    public class ChallengeDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Difficulty { get; set; }
    public int Points { get; set; }
    public string? Clue { get; set; }
    public string? Answer { get; set; } // kept internally, not sent to frontend
}