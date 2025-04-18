# Elevens Card Game - Final Submission

This repository contains the final submission for the Elevens card game project, a console-based implementation of the classic solitaire card game.

## Game Overview

Elevens is a single-player card game where the objective is to remove all cards from the board by finding:
- Pairs of cards that sum to 11 (e.g., Ace and 10, 2 and 9, 3 and 8, etc.)
- Sets of three face cards (Jack, Queen, and King)

## Game Rules

1. The game starts with 9 cards dealt face-up from a standard 52-card deck.
2. The player must find and remove valid combinations:
   - Two cards that sum to 11 (Ace = 1, Jack/Queen/King = 10)
   - Three cards that are Jack, Queen, and King (in any order)
3. When cards are removed, new cards are dealt from the deck to fill the empty positions.
4. If no valid moves remain, the player may use a one-time shuffle option.
5. The player wins if all cards are successfully removed from the board.
6. The player loses if there are no valid moves and the shuffle option has been used.

## Features Implemented

- **Complete Game Logic**: Full implementation of all Elevens game rules
- **Visual Card Display**: Color-coded cards with suit symbols
- **Player Statistics**: Tracking of score, wins, losses, pairs made, and face card sets
- **Game Timing**: Measurement of move count and game duration
- **Hint System**: Option to receive suggestions for valid moves
- **Game State Display**: Clear visualization of the current board state
- **End Game Detection**: Proper handling of win and loss conditions

## Implementation Details

The project follows an object-oriented design with these core classes:

1. **Card Class**: Represents a playing card with suit, rank, and value
2. **Deck Class**: Manages the 52-card deck with shuffling and dealing functionality
3. **Board Class**: Maintains the game board and validates moves
4. **Player Class**: Tracks player statistics
5. **GameController Class**: Manages the overall game flow and rules
6. **Program Class**: Provides the console interface for interaction

## How to Play

1. Run the application
2. The game displays 9 cards on the board
3. Choose from the menu options:
   - Select two cards to remove (sum to 11)
   - Select three face cards to remove (J-Q-K)
   - Use shuffle option
   - Display game state
   - Get a hint
   - Restart game
   - Quit
4. Continue until you win or lose

## How to Run

1. Clone this repository
2. Build the project: `dotnet build`
3. Run the game: `dotnet run`

## Project Structure

```
ElevensGame/
├── Card.cs             # Playing card representation
├── Deck.cs             # 52-card deck management
├── Board.cs            # Game board logic
├── Player.cs           # Player statistics tracking
├── GameController.cs   # Game rules and flow management
├── Program.cs          # Console interface
└── README.md           # This file
```

## Future Enhancements

While this implementation fulfills all requirements, potential future enhancements could include:
- Graphical user interface
- Save/load game functionality
- Multiple difficulty levels
- Animation effects
- Sound effects
- Customizable card backs