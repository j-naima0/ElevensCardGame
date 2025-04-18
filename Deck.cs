using System;
using System.Collections.Generic;

namespace ElevensGame
{
    public class Deck
    {
        // Attributes
        private List<Card> cards;
        
        // Constructor
        public Deck()
        {
            cards = new List<Card>();
            InitializeDeck();
        }
        
        // Initialize deck with 52 cards
        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            
            foreach (string suit in suits)
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }
        
        // Methods
        public void Shuffle()
        {
            Random random = new Random();
            
            // Fisher-Yates shuffle algorithm
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        
        public Card DealCard()
        {
            if (IsEmpty())
            {
                return null;
            }
            
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        
        public bool IsEmpty()
        {
            return cards.Count == 0;
        }
        
        public int GetRemainingCardCount()
        {
            return cards.Count;
        }
    }
}