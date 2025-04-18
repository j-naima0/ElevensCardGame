using System;

namespace ElevensGame
{
    public class Card
    {
        // Attributes
        private string suit;
        private int rank;
        private int value;
        private ConsoleColor cardColor;

        // Constructor
        public Card(string suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
            
            // Set the value based on rank
            if (rank > 10) // Face cards (Jack, Queen, King)
            {
                this.value = 10;
            }
            else
            {
                this.value = rank;
            }
            
            // Set card color based on suit (new in second submission)
            this.cardColor = (suit == "Hearts" || suit == "Diamonds") 
                ? ConsoleColor.Red 
                : ConsoleColor.Black;
        }

        // Methods
        public int GetValue()
        {
            return this.value;
        }

        public int GetRank()
        {
            return this.rank;
        }

        public string GetSuit()
        {
            return this.suit;
        }
        
        // New in second submission
        public ConsoleColor GetColor()
        {
            return this.cardColor;
        }
        
        // New in second submission
        public bool IsFaceCard()
        {
            return rank > 10;
        }

        public override string ToString()
        {
            string rankName;
            
            switch (rank)
            {
                case 1:
                    rankName = "Ace";
                    break;
                case 11:
                    rankName = "Jack";
                    break;
                case 12:
                    rankName = "Queen";
                    break;
                case 13:
                    rankName = "King";
                    break;
                default:
                    rankName = rank.ToString();
                    break;
            }
            
            return $"{rankName} of {suit}";
        }
        
        // New in second submission - get short card name for compact display
        public string GetShortName()
        {
            string rankSymbol;
            
            switch (rank)
            {
                case 1:
                    rankSymbol = "A";
                    break;
                case 10:
                    rankSymbol = "T";
                    break;
                case 11:
                    rankSymbol = "J";
                    break;
                case 12:
                    rankSymbol = "Q";
                    break;
                case 13:
                    rankSymbol = "K";
                    break;
                default:
                    rankSymbol = rank.ToString();
                    break;
            }
            
            string suitSymbol;
            switch (suit)
            {
                case "Hearts":
                    suitSymbol = "♥";
                    break;
                case "Diamonds":
                    suitSymbol = "♦";
                    break;
                case "Clubs":
                    suitSymbol = "♣";
                    break;
                case "Spades":
                    suitSymbol = "♠";
                    break;
                default:
                    suitSymbol = suit[0].ToString();
                    break;
            }
            
            return $"{rankSymbol}{suitSymbol}";
        }
    }
}