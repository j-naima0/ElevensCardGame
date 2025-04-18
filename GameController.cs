using System;

namespace ElevensGame
{
    public class GameController
    {
        // Attributes
        private Deck deck;
        private Board board;
        private Player player;
        private bool shuffleUsed;
        private int moveCount; // New in second submission
        private DateTime gameStartTime; // New in second submission
        
        // Constructor
        public GameController()
        {
            deck = new Deck();
            board = new Board();
            player = new Player();
            shuffleUsed = false;
            moveCount = 0;
            gameStartTime = DateTime.Now;
        }
        
        // Methods
        public void StartGame()
        {
            // Initialize deck and shuffle
            deck = new Deck();
            deck.Shuffle();
            
            // Reset board
            board = new Board();
            
            // Deal initial cards
            board.RefillCards(deck);
            
            // Reset shuffle usage
            shuffleUsed = false;
            
            // Reset move count and start time (new in second submission)
            moveCount = 0;
            gameStartTime = DateTime.Now;
            
            Console.WriteLine("Game started! The board has been set up.");
            board.DisplayCards();
        }
        
        public bool CheckWin()
        {
            // Win condition 1: All cards are removed from the board
            if (board.AreAllCardsRemoved())
            {
                return true;
            }
            
            // Win condition 2: Only one card remains
            // This is covered by the board.AreAllCardsRemoved() check
            
            return false;
        }
        
        public bool CheckLoss()
        {
            // Loss condition: No valid moves and no shuffle option
            return !board.IsValidMoveAvailable() && shuffleUsed;
        }
        
        public void RestartGame()
        {
            StartGame();
        }
        
        public bool MakeMove(int card1Index, int card2Index)
        {
            // Adjust indices to 0-based
            card1Index--;
            card2Index--;
            
            if (board.RemovePair(card1Index, card2Index))
            {
                // Successful move
                moveCount++; // Increment move count (new in second submission)
                player.UpdateScore(10);
                player.AddPairMade(); // New in second submission
                
                // Refill the board
                board.RefillCards(deck);
                
                // Check game status
                if (CheckWin())
                {
                    player.AddWin();
                    
                    // Display game duration (new in second submission)
                    TimeSpan gameDuration = DateTime.Now - gameStartTime;
                    Console.WriteLine($"Congratulations! You've won the game in {moveCount} moves and {gameDuration.TotalSeconds:F1} seconds!");
                    Console.WriteLine(player.GetStats());
                }
                else if (CheckLoss())
                {
                    player.AddLoss();
                    Console.WriteLine("Game over! No more valid moves available.");
                    Console.WriteLine(player.GetStats());
                }
                
                return true;
            }
            
            return false;
        }
        
        public bool MakeFaceCardMove(int card1Index, int card2Index, int card3Index)
        {
            // Adjust indices to 0-based
            card1Index--;
            card2Index--;
            card3Index--;
            
            if (board.RemoveFaceCardSet(card1Index, card2Index, card3Index))
            {
                // Successful move
                moveCount++; // Increment move count (new in second submission)
                player.UpdateScore(15);
                player.AddFaceCardSetMade(); // New in second submission
                
                // Refill the board
                board.RefillCards(deck);
                
                // Check game status
                if (CheckWin())
                {
                    player.AddWin();
                    
                    // Display game duration (new in second submission)
                    TimeSpan gameDuration = DateTime.Now - gameStartTime;
                    Console.WriteLine($"Congratulations! You've won the game in {moveCount} moves and {gameDuration.TotalSeconds:F1} seconds!");
                    Console.WriteLine(player.GetStats());
                }
                else if (CheckLoss())
                {
                    player.AddLoss();
                    Console.WriteLine("Game over! No more valid moves available.");
                    Console.WriteLine(player.GetStats());
                }
                
                return true;
            }
            
            return false;
        }
        
        public bool UseShuffle()
        {
            if (shuffleUsed)
            {
                Console.WriteLine("You've already used your shuffle option this game.");
                return false;
            }
            
            Console.WriteLine("Shuffling the remaining cards and dealing a new board...");
            
            // Create a new deck with remaining cards
            deck = new Deck();
            deck.Shuffle();
            board = new Board();
            board.RefillCards(deck);
            
            shuffleUsed = true;
            board.DisplayCards();
            
            return true;
        }
        
        public void DisplayGameState()
        {
            // Enhanced game state display (new in second submission)
            TimeSpan gameDuration = DateTime.Now - gameStartTime;
            Console.WriteLine($"Game Stats: Moves: {moveCount} | Time: {gameDuration.TotalSeconds:F1} seconds");
            Console.WriteLine($"Cards remaining in deck: {deck.GetRemainingCardCount()}");
            board.DisplayCards();
            Console.WriteLine($"Current score: {player.GetScore()}");
            Console.WriteLine($"Shuffle option used: {(shuffleUsed ? "Yes" : "No")}");
            
            // Show hint availability (new in second submission)
            var validMoves = board.FindValidMoves();
            if (validMoves.Count > 0)
            {
                Console.WriteLine($"Valid moves available: {validMoves.Count}");
            }
            else
            {
                Console.WriteLine("No valid moves available.");
                
                if (!shuffleUsed)
                {
                    Console.WriteLine("Consider using the shuffle option.");
                }
            }
        }
        
        // New method in second submission
        public void ShowHint()
        {
            var validMoves = board.FindValidMoves();
            
            if (validMoves.Count == 0)
            {
                Console.WriteLine("No valid moves available.");
                
                if (!shuffleUsed)
                {
                    Console.WriteLine("Consider using the shuffle option.");
                }
                
                return;
            }
            
            // Select a random valid move to show as a hint
            Random random = new Random();
            int moveIndex = random.Next(validMoves.Count);
            int[] move = validMoves[moveIndex];
            
            if (move.Length == 2)
            {
                Console.WriteLine($"Hint: Try selecting cards at positions {move[0] + 1} and {move[1] + 1}");
            }
            else if (move.Length == 3)
            {
                Console.WriteLine($"Hint: Try selecting face cards at positions {move[0] + 1}, {move[1] + 1}, and {move[2] + 1}");
            }
        }
        
        public Player GetPlayer()
        {
            return player;
        }
        
        public Board GetBoard()
        {
            return board;
        }
        
        // New in second submission
        public int GetMoveCount()
        {
            return moveCount;
        }
    }
}