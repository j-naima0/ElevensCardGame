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
            Console.WriteLine("\nCurrent Board:");
            Console.WriteLine("-------------");
            
            // Improved display format for second submission
            // First row: positions
            Console.Write("Position: ");
            for (int i = 0; i < activeCards.Count; i++)
            {
                Console.Write($"{i + 1}  ");
            }
            Console.WriteLine();
            
            // Second row: card display
            Console.Write("Card:     ");
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] != null)
                {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = activeCards[i].GetColor();
                    Console.Write($"{activeCards[i].GetShortName()} ");
                    Console.ForegroundColor = originalColor;
                }
                else
                {
                    Console.Write("-- ");
                }
            }
            Console.WriteLine("\n");
            
            // Detailed card information
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] != null)
                {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = activeCards[i].GetColor();
                    Console.WriteLine($"{i + 1}: {activeCards[i]}");
                    Console.ForegroundColor = originalColor;
                }
                else
                {
                    Console.WriteLine($"{i + 1}: [Empty]");
                }
            }
            
            Console.WriteLine();
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
                card2Index < 0 || card2Index >= activeCards.Count ||
                card1Index == card2Index) // Added check for same card (second submission)
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
                card3Index < 0 || card3Index >= activeCards.Count ||
                card1Index == card2Index || card1Index == card3Index || card2Index == card3Index) // Added check for duplicates
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
        
        // New method for second submission - find a valid move
        public List<int[]> FindValidMoves()
        {
            List<int[]> validMoves = new List<int[]>();
            
            // Find pairs that sum to 11
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] == null) continue;
                
                for (int j = i + 1; j < activeCards.Count; j++)
                {
                    if (activeCards[j] == null) continue;
                    
                    if (IsValidPair(activeCards[i], activeCards[j]))
                    {
                        validMoves.Add(new int[] { i, j });
                    }
                }
            }
            
            // Find J-Q-K sets
            List<int> jackIndices = new List<int>();
            List<int> queenIndices = new List<int>();
            List<int> kingIndices = new List<int>();
            
            for (int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i] == null) continue;
                
                if (activeCards[i].GetRank() == 11) jackIndices.Add(i);
                if (activeCards[i].GetRank() == 12) queenIndices.Add(i);
                if (activeCards[i].GetRank() == 13) kingIndices.Add(i);
            }
            
            if (jackIndices.Count > 0 && queenIndices.Count > 0 && kingIndices.Count > 0)
            {
                validMoves.Add(new int[] { jackIndices[0], queenIndices[0], kingIndices[0] });
            }
            
            return validMoves;
        }
    }
}