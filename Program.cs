using System;

namespace ElevensGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeBanner(); // New in second submission
            
            GameController game = new GameController();
            game.StartGame();
            
            bool gameRunning = true;
            
            while (gameRunning)
            {
                DisplayMenuOptions(); // Updated menu in second submission
                
                Console.Write("\nEnter your choice (1-7): ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        HandlePairSelection(game);
                        break;
                        
                    case "2":
                        HandleFaceCardSelection(game);
                        break;
                        
                    case "3":
                        game.UseShuffle();
                        break;
                        
                    case "4":
                        game.DisplayGameState();
                        break;
                        
                    case "5":
                        game.ShowHint(); // New in second submission
                        break;
                        
                    case "6":
                        Console.WriteLine("Restarting game...");
                        game.RestartGame();
                        break;
                        
                    case "7":
                        Console.WriteLine("Thanks for playing!");
                        Console.WriteLine(game.GetPlayer().GetStats());
                        gameRunning = false;
                        break;
                        
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                
                // Check if game has ended
                if ((game.CheckWin() || game.CheckLoss()) && gameRunning)
                {
                    HandleEndGame(game, ref gameRunning); // New method in second submission
                }
            }
        }
        
        // New method in second submission
        private static void DisplayWelcomeBanner()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("*                             *");
            Console.WriteLine("*    ELEVENS CARD GAME        *");
            Console.WriteLine("*                             *");
            Console.WriteLine("*******************************");
            Console.WriteLine();
        }
        
        // Updated in second submission
        private static void DisplayMenuOptions()
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Select two cards to remove (sum to 11)");
            Console.WriteLine("2. Select three face cards to remove (J-Q-K)");
            Console.WriteLine("3. Use shuffle option");
            Console.WriteLine("4. Display game state");
            Console.WriteLine("5. Get a hint"); // New option in second submission
            Console.WriteLine("6. Restart game");
            Console.WriteLine("7. Quit");
        }
        
        private static void HandlePairSelection(GameController game)
        {
            Console.Write("Enter first card position (1-9): ");
            if (!int.TryParse(Console.ReadLine(), out int card1))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                return;
            }
            
            Console.Write("Enter second card position (1-9): ");
            if (!int.TryParse(Console.ReadLine(), out int card2))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                return;
            }
            
            if (game.MakeMove(card1, card2))
            {
                Console.WriteLine("Cards successfully removed!");
                game.DisplayGameState();
            }
            else
            {
                Console.WriteLine("Invalid move! The cards must sum to 11.");
            }
        }
        
        private static void HandleFaceCardSelection(GameController game)
        {
            Console.Write("Enter first face card position (1-9): ");
            if (!int.TryParse(Console.ReadLine(), out int faceCard1))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                return;
            }
            
            Console.Write("Enter second face card position (1-9): ");
            if (!int.TryParse(Console.ReadLine(), out int faceCard2))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                return;
            }
            
            Console.Write("Enter third face card position (1-9): ");
            if (!int.TryParse(Console.ReadLine(), out int faceCard3))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                return;
            }
            
            if (game.MakeFaceCardMove(faceCard1, faceCard2, faceCard3))
            {
                Console.WriteLine("Face cards successfully removed!");
                game.DisplayGameState();
            }
            else
            {
                Console.WriteLine("Invalid move! You need one each of Jack, Queen, and King.");
            }
        }
        
        // New method in second submission
        private static void HandleEndGame(GameController game, ref bool gameRunning)
        {
            if (game.CheckWin())
            {
                Console.WriteLine("\n*********************************");
                Console.WriteLine("*       CONGRATULATIONS!        *");
                Console.WriteLine("*        YOU'VE WON!            *");
                Console.WriteLine("*********************************");
            }
            else
            {
                Console.WriteLine("\n*********************************");
                Console.WriteLine("*         GAME OVER!            *");
                Console.WriteLine("*     No more valid moves       *");
                Console.WriteLine("*********************************");
            }
            
            Console.Write("\nPlay again? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                game.RestartGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
                Console.WriteLine(game.GetPlayer().GetStats());
                gameRunning = false;
            }
        }
    }
}