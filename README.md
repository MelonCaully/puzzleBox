# PuzzleBox

## Run the project 

- Run this comamnd in prefered shell: ```dotnet run```

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