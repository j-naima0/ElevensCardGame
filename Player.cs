using System;
using System.Text;

namespace ElevensGame
{
    public class Player
    {
        // Attributes
        private int score;
        private int wins;
        private int losses;
        
        // Constructor
        public Player()
        {
            score = 0;
            wins = 0;
            losses = 0;
        }
        
        // Methods
        public void UpdateScore(int points)
        {
            score += points;
        }
        
        public void AddWin()
        {
            wins++;
        }
        
        public void AddLoss()
        {
            losses++;
        }
        
        public string GetStats()
        {
            StringBuilder stats = new StringBuilder();
            stats.AppendLine("Player Statistics:");
            stats.AppendLine("------------------");
            stats.AppendLine($"Score: {score}");
            stats.AppendLine($"Wins: {wins}");
            stats.AppendLine($"Losses: {losses}");
            
            return stats.ToString();
        }
        
        public int GetScore()
        {
            return score;
        }
        
        public int GetWins()
        {
            return wins;
        }
        
        public int GetLosses()
        {
            return losses;
        }
    }
}