using PuzzleBox.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PuzzleBox.Services;

public class PuzzleService : IPuzzleService
{
    public PuzzleResponse SolveLevel1(PuzzleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Answer))
        {
            return new PuzzleResponse { Message = "Answer cannot be empty" };
        }

        string correct = ComputeSha256Hash("boot.dev");

        if (request.Answer.Trim().ToLower() == correct)
        {
            return new PuzzleResponse
            {
                Message = "Correct! Proceed to /api/puzzle/level2",
                Level = 2
            };
        }
        else
        {
            return new PuzzleResponse
            {
                Message = "Incorrect. Try Again"
            };
        }
    }
    
    private string ComputeSha256Hash(string rawData)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}