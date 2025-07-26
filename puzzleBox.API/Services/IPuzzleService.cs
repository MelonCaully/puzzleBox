using PuzzleBox.DTOs;

namespace PuzzleBox.Services;

    public interface IPuzzleService
    {
        PuzzleResponse SolveLevel1(PuzzleRequest request);
    }