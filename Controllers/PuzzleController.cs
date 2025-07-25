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
    public ActionResult<PuzzleResponse> SolveLevel1([FromBody] PuzzleRequest request)
    {
        var result = _puzzleService.SolveLevel1(request.Answer);
        return Ok(result);
    }
}