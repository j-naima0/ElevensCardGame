# Elevens Card Game - 2nd Submission

This repository contains the second submission for the Elevens card game project, with improvements to the first submission.

## Updates in Second Submission

- **Improved Visual Display**: Enhanced card display with color-coding and Unicode suit symbols
- **Added Hint System**: Players can now receive hints about valid moves
- **Enhanced Statistics Tracking**: Additional stats including move counting, game duration, and highest score
- **Improved UI**: Added welcome banner and better formatted game state display
- **Game End Handling**: Better handling of win/loss conditions with visual notifications
- **Fixed Bugs**: Improved validation for card selection and move detection

## Game Rules

- The game starts with 9 cards dealt face-up on the board from a standard 52-card deck.
- Players can remove pairs of cards that sum to 11 (e.g., Ace and 10, 2 and 9, 3 and 8, etc.).
- Players can also remove sets of three face cards (Jack, Queen, and King).
- When cards are removed, new cards are dealt from the deck to fill the empty positions.
- If no valid moves remain, the player may use a one-time shuffle option.
- The player wins if all cards are successfully removed from the board.
- The player loses if there are no valid moves and the shuffle option has been used.

## Implementation

The implementation follows the UML class diagram with these classes:
- **Card**: Represents a single playing card with suit, rank, and value
- **Deck**: Manages the 52-card deck with shuffling functionality
- **Board**: Maintains the 9 face-up cards and validates moves
- **Player**: Tracks player statistics including score, wins, and losses
- **GameController**: Manages the game state and rules

## How to Play

1. Run the application
2. The game will display 9 cards on the board
3. Choose from the menu options:
   - Select pairs of cards that sum to 11
   - Select sets of J-Q-K to remove
   - Use shuffle option if stuck
   - View game state
   - Get a hint for a valid move
   - Restart or quit the game
4. Continue until you win or lose

## How to Run

1. Clone this repository
2. Build the project: `dotnet build`
3. Run the game: `dotnet run`