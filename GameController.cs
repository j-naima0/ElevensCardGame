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
        
        // Constructor
        public GameController()
        {
            deck = new Deck();
            board = new Board();
            player = new Player();
            shuffleUsed = false;
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
                player.UpdateScore(10);
                
                // Refill the board
                board.RefillCards(deck);
                
                // Check game status
                if (CheckWin())
                {
                    player.AddWin();
                    Console.WriteLine("Congratulations! You've won the game!");
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
                player.UpdateScore(15);
                
                // Refill the board
                board.RefillCards(deck);
                
                // Check game status
                if (CheckWin())
                {
                    player.AddWin();
                    Console.WriteLine("Congratulations! You've won the game!");
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
            Console.WriteLine($"Cards remaining in deck: {deck.GetRemainingCardCount()}");
            board.DisplayCards();
            Console.WriteLine($"Current score: {player.GetScore()}");
            Console.WriteLine($"Shuffle option used: {(shuffleUsed ? "Yes" : "No")}");
        }
        
        public Player GetPlayer()
        {
            return player;
        }
        
        public Board GetBoard()
        {
            return board;
        }
    }
}