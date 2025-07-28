using Microsoft.AspNetCore.Mvc;
using PuzzleBox.Services;
using PuzzleBox.DTOs;

namespace PuzzleBox.API.Controllers;

[ApiController]
[Route("api/puzzle")]
public class PuzzleController : ControllerBase
{
    private readonly IPuzzleService _puzzleService;

    public PuzzleController(IPuzzleService puzzleService)
    {
        _puzzleService = puzzleService;
    }

    [HttpGet("challenge/{id}")]
    public IActionResult GetChallenge(int id)
    {
        var challenge = _puzzleService.GetChallengeById(id);

        if (challenge == null)
        {
            return NotFound(new { message = "Challenge not found." });
        }

        // Strip the answer field before returning to the frontend
        return Ok(new
        {
            challenge.Id,
            challenge.Title,
            challenge.Description,
            challenge.Difficulty,
            challenge.Points,
            challenge.Clue,
            iconKey = challenge.Id 
        });
    }

    [HttpPost("level{levelId:int}")]
    public IActionResult SolveChallenge(int levelId, [FromBody] PuzzleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Answer))
        {
            return BadRequest(new PuzzleResponse
            {
                Success = false,
                Message = "Answer cannot be empty."
            });
        }

        PuzzleResponse response;

        switch (levelId)
        {
            case 1:
                response = _puzzleService.SolveLevel1(request);
                break;
            case 2:
                response = _puzzleService.SolveLevel2(request);
                break;
            default:
                return BadRequest(new PuzzleResponse
                {
                    Success = false,
                    Message = $"Level {levelId} is not implemented."
                });
        }

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }
}