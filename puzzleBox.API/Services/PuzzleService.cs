using PuzzleBox.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PuzzleBox.Services;

public class PuzzleService : IPuzzleService
{
    private readonly List<ChallengeDTO> _challenges;
    public PuzzleService()
    {
        // Mock challenge data for now; eventually pull from DB
        _challenges = new List<ChallengeDTO>
        {
            new ChallengeDTO
            {
                Id = 1,
                Title = "SHA256 Hash Encrypt",
                Description = "Encrypt 'boot.dev' into a SHA256 hash",
                Difficulty = "Easy",
                Points = 100,
                Clue = "You can always use a SHA256 hash generator",
                Answer = "eaeb48f2467ffa3a896cff3a9df077fb191f5c4df1bc94d2d974c293c32a1a98"
            },
            new ChallengeDTO
            {
                Id = 2,
                Title = "Hex ASCII Decryption",
                Description = "Hex color #7072496d454167456e hides a word when converted to ASCII. What is it?",
                Difficulty = "Medium",
                Points = 200,
                Clue = "",
                Answer = "prImEAgEn"
            },
            new ChallengeDTO
            {
                Id = 3,
                Title = "Morse API Call",
                Description = "Translate the following Morse code: .... .- -.-. -.- .- - .... --- -.",
                Difficulty = "Medium",
                Points = 200,
                Clue = "",
                Answer = "HACKATHON"
            }
        };
    }

    public ChallengeDTO? GetChallengeById(int id)
    {
        return _challenges.FirstOrDefault(c => c.Id == id);
    }
    public PuzzleResponse SolveLevel1(PuzzleRequest request)
    {

        string correct = ComputeSha256Hash("boot.dev");

        if (request.Answer.Trim().ToLower() == correct)
        {
            return new PuzzleResponse
            {
                Message = "Correct!",
                Success = true,
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
        string correct = "prImEAgEn";

        if (request.Answer.Trim() == correct)
        {
            return new PuzzleResponse
            {
                Message = "Correct!",
                Success = true
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

    public PuzzleResponse SolveLevel3(PuzzleRequest request)
    {
        string correct = "HACKATHON";

        if (request.Answer.Trim() == correct)
        {
            return new PuzzleResponse
            {
                Message = "Correct!",
                Success = true
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
    
    private string ComputeSha256Hash(string rawData)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}