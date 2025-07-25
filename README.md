# PuzzleBox API (Backend)

This is the backend for the **PuzzleBox** hackathon project — a multi-step API puzzle game where users solve HTTP-based challenges to progress through puzzle levels.

Built with **C#** and **ASP.NET Core (.NET 8)**.

## Architecture and Request Flow

                      ┌────────────────────────┐
                      │  HTTP Client (e.g. curl│
                      │  Postman, browser)     │
                      └────────────┬───────────┘
                                   │
                    Sends HTTP request (GET/POST)
                                   │
                                   ▼
                      ┌────────────────────────┐
                      │  PuzzleController      │
                      │  (e.g., Start(),       │
                      │  SolveLevel1())        │
                      └────────────┬───────────┘
                                   │
                    Calls service via DI (_puzzleService)
                                   │
                                   ▼
                      ┌────────────────────────┐
                      │  PuzzleService         │
                      │  (Business Logic)      │
                      └────────────┬───────────┘
                                   │
                       Handles puzzle logic,
                  e.g., validate hash, return message
                                   │
                                   ▼
                      ┌─────────────────────────────┐
                      │  DTOs (e.g., PuzzleResponse,│
                      │  PuzzleRequest)             │
                      └────────────┬────────────────┘
                                   │
                    Response converted to JSON
                                   │
                                   ▼
                      ┌────────────────────────┐
                      │  HTTP Response         │
                      │  (JSON Payload)        │
                      └────────────────────────┘
### Summary of Request Flow
1. User sends HTTP request to /api/puzzle/start or /api/puzzle/level1. 
1. PuzzleController receives the request and uses IPuzzleService.
1. PuzzleService contains the core logic for solving puzzles.
1. DTOs (like PuzzleResponse) define the shape of data sent back.
1. The app returns a JSON response with the result.

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio or VS Code (or any C# IDE)
- Swagger UI enabled for development

### Run the API Locally

```bash
dotnet run
```
The API UI will be availabe at ```https://localhost:<port>/swagger```

## 🔐 CORS Configuration

For frontend development on localhost:3000, CORS is enabled in Program.cs.
```
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

app.UseCors();
```

## 👥 Authors

- Malone — Backend Engineer (C#, API design)
- Rae — Frontend Engineer (React, UX/UI)

## 🛠️ Todo

 Implement /api/puzzle/level2 and beyond

 Add error handling and rate limiting

 Connect with React frontend

 Add logging and telemetry (if time allows)

