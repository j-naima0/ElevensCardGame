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
        private int pairsMade; // New in second submission
        private int faceCardSetsMade; // New in second submission
        private int highestScore; // New in second submission
        
        // Constructor
        public Player()
        {
            score = 0;
            wins = 0;
            losses = 0;
            pairsMade = 0;
            faceCardSetsMade = 0;
            highestScore = 0;
        }
        
        // Methods
        public void UpdateScore(int points)
        {
            score += points;
            
            // Update highest score if needed (new in second submission)
            if (score > highestScore)
            {
                highestScore = score;
            }
        }
        
        public void AddWin()
        {
            wins++;
        }
        
        public void AddLoss()
        {
            losses++;
        }
        
        // New methods in second submission
        public void AddPairMade()
        {
            pairsMade++;
        }
        
        public void AddFaceCardSetMade()
        {
            faceCardSetsMade++;
        }
        
        public string GetStats()
        {
            StringBuilder stats = new StringBuilder();
            stats.AppendLine("Player Statistics:");
            stats.AppendLine("------------------");
            stats.AppendLine($"Current Score: {score}");
            stats.AppendLine($"Highest Score: {highestScore}");
            stats.AppendLine($"Wins: {wins}");
            stats.AppendLine($"Losses: {losses}");
            
            // New stats in second submission
            if (wins + losses > 0)
            {
                double winRate = (double)wins / (wins + losses) * 100;
                stats.AppendLine($"Win Rate: {winRate:F1}%");
            }
            
            stats.AppendLine($"Pairs Made: {pairsMade}");
            stats.AppendLine($"Face Card Sets Made: {faceCardSetsMade}");
            
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
        
        // New getters in second submission
        public int GetPairsMade()
        {
            return pairsMade;
        }
        
        public int GetFaceCardSetsMade()
        {
            return faceCardSetsMade;
        }
        
        public int GetHighestScore()
        {
            return highestScore;
        }
    }
}