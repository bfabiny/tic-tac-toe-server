# tic-tac-toe-server
.Net Core API for determining the next move for Tic Tac Toe
This can be used in conjunction with the React App in the `tic-tac-toe` repository to play.

### Endpoints

These endpoints are supported:
1. `GET /api/move` - Returns the string array "This is the", "Tic Tac Toe Server". Used to display on a page to indicate that it is running to assist with debugging React App dev
2. `GET /api/move/{id}` - Returns a string "value". THis should really be removed.
3. `POST /api/move` - Accepts a `Current State` object containing 
- nextMove (char)
- currentBoard (string[]) with the current state of the tic tac toe board 
Returns a string array with the new state of the tic tac toe board.