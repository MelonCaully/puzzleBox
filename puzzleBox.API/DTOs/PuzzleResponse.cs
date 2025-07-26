namespace PuzzleBox.DTOs
{
    public class PuzzleResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public int? Level { get; set; } 
        public int? Object { get; set; } 
    }
}