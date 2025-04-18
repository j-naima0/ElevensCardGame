using System;

namespace ElevensGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Elevens Card Game!");
            Console.WriteLine("-----------------------------");
            
            GameController game = new GameController();
            game.StartGame();
            
            bool gameRunning = true;
            
            while (gameRunning)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Select two cards to remove (sum to 11)");
                Console.WriteLine("2. Select three face cards to remove (J-Q-K)");
                Console.WriteLine("3. Use shuffle option");
                Console.WriteLine("4. Display game state");
                Console.WriteLine("5. Restart game");
                Console.WriteLine("6. Quit");
                
                Console.Write("\nEnter your choice (1-6): ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter first card position (1-9): ");
                        if (!int.TryParse(Console.ReadLine(), out int card1))
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                            break;
                        }
                        
                        Console.Write("Enter second card position (1-9): ");
                        if (!int.TryParse(Console.ReadLine(), out int card2))
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                            break;
                        }
                        
                        if (game.MakeMove(card1, card2))
                        {
                            Console.WriteLine("Cards successfully removed!");
                            game.DisplayGameState();
                            
                            if (game.CheckWin() || game.CheckLoss())
                            {
                                Console.Write("\nPlay again? (y/n): ");
                                if (Console.ReadLine().ToLower() == "y")
                                {
                                    game.RestartGame();
                                }
                                else
                                {
                                    gameRunning = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move! The cards must sum to 11.");
                        }
                        break;
                        
                    case "2":
                        Console.Write("Enter first face card position (1-9): ");
                        if (!int.TryParse(Console.ReadLine(), out int faceCard1))
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                            break;
                        }
                        
                        Console.Write("Enter second face card position (1-9): ");
                        if (!int.TryParse(Console.ReadLine(), out int faceCard2))
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                            break;
                        }
                        
                        Console.Write("Enter third face card position (1-9): ");
                        if (!int.TryParse(Console.ReadLine(), out int faceCard3))
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                            break;
                        }
                        
                        if (game.MakeFaceCardMove(faceCard1, faceCard2, faceCard3))
                        {
                            Console.WriteLine("Face cards successfully removed!");
                            game.DisplayGameState();
                            
                            if (game.CheckWin() || game.CheckLoss())
                            {
                                Console.Write("\nPlay again? (y/n): ");
                                if (Console.ReadLine().ToLower() == "y")
                                {
                                    game.RestartGame();
                                }
                                else
                                {
                                    gameRunning = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move! You need one each of Jack, Queen, and King.");
                        }
                        break;
                        
                    case "3":
                        game.UseShuffle();
                        break;
                        
                    case "4":
                        game.DisplayGameState();
                        break;
                        
                    case "5":
                        Console.WriteLine("Restarting game...");
                        game.RestartGame();
                        break;
                        
                    case "6":
                        Console.WriteLine("Thanks for playing!");
                        gameRunning = false;
                        break;
                        
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}