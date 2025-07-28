using PuzzleBox.DTOs;

namespace PuzzleBox.Services;

public interface IPuzzleService
{
    ChallengeDTO? GetChallengeById(int id);
    PuzzleResponse SolveLevel1(PuzzleRequest request);
    PuzzleResponse SolveLevel2(PuzzleRequest request);
    }