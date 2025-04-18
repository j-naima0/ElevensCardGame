# Elevens Card Game - 1st Submission

This repository contains the first submission for the Elevens card game project, focusing on class design and partial implementation.

## Project Overview

Elevens is a solitaire card game where players remove pairs of cards that sum to 11 or sets of face cards (Jack, Queen, King) from a board of 9 cards. The game continues until all cards are removed (win) or no valid moves remain (loss).

## Partial Implementation

This submission includes:

- **Complete class structure** following the UML design
- **Implementation of core classes**:
  - Card: Represents a playing card with suit, rank, and value
  - Deck: Manages the 52-card deck with shuffling and dealing functionality
  - Board: Handles the game board, card selection, and move validation
  - Player: Tracks player statistics
  - GameController: Manages game state and rules
- **Basic console interface** for playing the game

## Current Game Features

- Dealing and displaying cards
- Selecting cards and validating moves
- Removing pairs that sum to 11
- Removing sets of Jack, Queen, King
- Tracking score, wins, and losses
- One-time shuffle option
- Win/loss condition checking

## Future Enhancements

- Graphical user interface
- Advanced game features
- Performance optimizations
- Save/load functionality

## How to Run

1. Clone this repository
2. Build the project: `dotnet build`
3. Run the game: `dotnet run`

## Project Structure

```
ElevensGame/
├── Card.cs
├── Deck.cs
├── Board.cs
├── Player.cs
├── GameController.cs
├── Program.cs
└── README.md
```