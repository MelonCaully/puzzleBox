using PuzzleBox.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PuzzleBox.Services;

public class PuzzleService : IPuzzleService
{
    public PuzzleResponse SolveLevel1(PuzzleRequest request)
    {

        string correct = ComputeSha256Hash("boot.dev");

        if (request.Answer.Trim().ToLower() == correct)
        {
            return new PuzzleResponse
            {
                Message = "Correct! Proceed to /api/puzzle/level2",
                Success = true,
                Level = 2
            };
        }
        else
        {
            return new PuzzleResponse
            {
                Message = "Incorrect. Try Again",
                Success = false
            };
        }
    }

    public PuzzleResponse SolveLevel2(PuzzleRequest request)
    {
        return new PuzzleResponse
        {
            Message = "Correct! Proceed to api/puzzle/level3",
            Success = true
        };
    }
    
    private string ComputeSha256Hash(string rawData)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}