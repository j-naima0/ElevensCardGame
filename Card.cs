using System;

namespace ElevensGame
{
    public class Card
    {
        // Attributes
        private string suit;
        private int rank;
        private int value;

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
    }
}