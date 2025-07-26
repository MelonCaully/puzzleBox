using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PuzzleBox.DTOs;
using Xunit;

namespace puzzleBox.Tests;

public class PuzzleControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PuzzleControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task SolveLevel1_ReturnsCorrect_WhenHashMatches()
    {
        // Arrange
        var correctHash = ComputeSha256("boot.dev");
        var request = new PuzzleRequest { Answer = correctHash };

        // Act
        var response = await _client.PostAsJsonAsync("/api/puzzle/level1", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<PuzzleResponse>();
        body!.Success.Should().BeTrue();
        body.Message.Should().Contain("Proceed");
    }

    [Fact]
    public async Task SolveLevel1_ReturnsBadRequest_WhenHashIsWrong()
    {
        // Arrange
        var request = new PuzzleRequest { Answer = "wronghash" };

        // Act
        var response = await _client.PostAsJsonAsync("/api/puzzle/level1", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var body = await response.Content.ReadFromJsonAsync<PuzzleResponse>();
        body!.Success.Should().BeFalse();
    }

    private static string ComputeSha256(string input)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
    }
}
