using PuzzleBox.DTOs;

namespace PuzzleBox.Services;

public class PuzzleService : IPuzzleService
{
    public PuzzleResponse SolveLevel1(string answer)
    {
        // Validate hash or answer logic
        return new PuzzleResponse
        {
            Message = "Correct! Proceed to /api/puzzle/level2",
            Level = 2
        };
    }
}