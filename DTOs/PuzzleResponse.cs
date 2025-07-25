namespace PuzzleBox.DTOs
{
    public class PuzzleResponse
    {
        public string Message { get; set; } = string.Empty;
        public int? Level { get; set; } = null; // Optional: useful if you want to track progress
        public int? Object { get; set; } = null; // Optional: can return base64 strings, hints, etc.
    }
}