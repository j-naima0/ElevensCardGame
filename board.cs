using System;
using System.Collections.Generic;
using System.Text;

namespace ElevensGame
{
    public class Board
    {
        // Attributes
        private List<Card> activeCards;
        private const int BOARD_SIZE = 9;
        
        // Constructor
        public Board()
        {
            activeCards = new List<Card>(BOARD_SIZE);
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                activeCards.Add(null);
            }
        }
        
        // Methods
        public void DisplayCards()
        {
            StringBuilder display = new StringBuilder();
            
            display.AppendLine("Current Board:");
            display.AppendLine("-------------");
            
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] != null)
                {
                    display.AppendLine($"{i + 1}: {activeCards[i]}");
                }
                else
                {
                    display.AppendLine($"{i + 1}: [Empty]");
                }
            }
            
            Console.WriteLine(display.ToString());
        }
        
        public bool SelectCard(int cardIndex)
        {
            if (cardIndex < 0 || cardIndex >= activeCards.Count)
            {
                return false;
            }
            
            return activeCards[cardIndex] != null;
        }
        
        public bool RemovePair(int card1Index, int card2Index)
        {
            // Check if indices are valid
            if (card1Index < 0 || card1Index >= activeCards.Count ||
                card2Index < 0 || card2Index >= activeCards.Count)
            {
                return false;
            }
            
            Card card1 = activeCards[card1Index];
            Card card2 = activeCards[card2Index];
            
            // Check if both cards exist
            if (card1 == null || card2 == null)
            {
                return false;
            }
            
            // Check if it's a valid pair
            if (IsValidPair(card1, card2))
            {
                activeCards[card1Index] = null;
                activeCards[card2Index] = null;
                return true;
            }
            
            return false;
        }
        
        public bool RemoveFaceCardSet(int card1Index, int card2Index, int card3Index)
        {
            // Check if indices are valid
            if (card1Index < 0 || card1Index >= activeCards.Count ||
                card2Index < 0 || card2Index >= activeCards.Count ||
                card3Index < 0 || card3Index >= activeCards.Count)
            {
                return false;
            }
            
            Card card1 = activeCards[card1Index];
            Card card2 = activeCards[card2Index];
            Card card3 = activeCards[card3Index];
            
            // Check if all cards exist
            if (card1 == null || card2 == null || card3 == null)
            {
                return false;
            }
            
            // Check if it's a valid face card set (Jack, Queen, King)
            if (IsValidFaceCardSet(card1, card2, card3))
            {
                activeCards[card1Index] = null;
                activeCards[card2Index] = null;
                activeCards[card3Index] = null;
                return true;
            }
            
            return false;
        }
        
        public void RefillCards(Deck deck)
        {
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] == null && !deck.IsEmpty())
                {
                    activeCards[i] = deck.DealCard();
                }
            }
        }
        
        // Helper methods
        private bool IsValidPair(Card card1, Card card2)
        {
            // Check if the two cards sum to 11
            return card1.GetValue() + card2.GetValue() == 11;
        }
        
        private bool IsValidFaceCardSet(Card card1, Card card2, Card card3)
        {
            // Check if the three cards are a Jack, Queen, and King
            int[] ranks = {card1.GetRank(), card2.GetRank(), card3.GetRank()};
            Array.Sort(ranks);
            
            return ranks[0] == 11 && ranks[1] == 12 && ranks[2] == 13;
        }
        
        public bool AreAllCardsRemoved()
        {
            foreach (Card card in activeCards)
            {
                if (card != null)
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool IsValidMoveAvailable()
        {
            // Check for pairs that sum to 11
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] == null) continue;
                
                for (int j = i + 1; j < activeCards.Count; j++)
                {
                    if (activeCards[j] == null) continue;
                    
                    if (IsValidPair(activeCards[i], activeCards[j]))
                    {
                        return true;
                    }
                }
            }
            
            // Check for J-Q-K sets
            List<Card> faceCards = new List<Card>();
            
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] != null && activeCards[i].GetRank() >= 11)
                {
                    faceCards.Add(activeCards[i]);
                }
            }
            
            if (faceCards.Count >= 3)
            {
                // Check if we have one of each face card
                bool hasJack = false;
                bool hasQueen = false;
                bool hasKing = false;
                
                foreach (Card card in faceCards)
                {
                    if (card.GetRank() == 11) hasJack = true;
                    if (card.GetRank() == 12) hasQueen = true;
                    if (card.GetRank() == 13) hasKing = true;
                }
                
                if (hasJack && hasQueen && hasKing)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}