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

    [HttpGet("start")]
    public IActionResult Start()
    {
        return Ok(new PuzzleStartResponse
        {
            Message = "Welcome to the Puzzle Box! To begin, send a POST to /api/puzzle/level1 with the SHA256 hash of the word 'start'."
        });
    }

    [HttpPost("level1")]
    public IActionResult SolveLevel1([FromBody] PuzzleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Answer))
        {
            return BadRequest(new PuzzleResponse
            {
                Success = false,
                Message = "Answer cannot be empty."
            });
        }

        var response = _puzzleService.SolveLevel1(request);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("level2")]
    public IActionResult SolveLevel2([FromBody] PuzzleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Answer))
        {
            return BadRequest(new PuzzleResponse
            {
                Success = false,
                Message = "Anser cannot be empty"
            });
        }

        var repsonse = _puzzleService.SolveLevel2(request);
        return Ok();
    }
}