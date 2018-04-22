using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Hand
    {
        public List<Card> Cards { get; set; }
        public Hand() { Cards = new List<Card>(); }
        public void Draw(Card card) { Cards.Add(card); }

      
        private bool HasFlush()
        {
            return Cards.All(c => c.Suit == Cards.First().Suit);
        }

        private bool HasStraight()
        {
            var sortedCards = Cards.OrderBy(c => c.Value);
            return sortedCards.Last().Value - sortedCards.First().Value == Cards.Count - 1;
        }

        private bool AllGreaterThanTen()
        {
            return Cards.All(c => c.Value > CardValue.Nine);
        }

        private bool OfAKind(int x, int y = 1)
        {
           return ContainsOccurence(x, y);
        }

        private bool ContainsOccurence(int val1,int val2)
        {
            return Cards.GroupBy(x => x.Value).Count(g => g.Count() == val1) == val2;
        }

        public HandRank GetHandRank()
        {
            if (AllGreaterThanTen() && HasFlush()) return HandRank.RoyalFlush;
            if (HasStraight() && HasFlush()) return HandRank.StraightFlush;
            if (OfAKind(4)) return HandRank.FourOfAKind;
            if (OfAKind(3) && OfAKind(2)) return HandRank.FullHouse;
            if (HasFlush()) return HandRank.Flush;
            if (HasStraight()) return HandRank.Straight;
            if (OfAKind(3)) return HandRank.ThreeOfAKind;
            if (OfAKind(2, 2)) return HandRank.TwoPairs;
            if (OfAKind(2)) return HandRank.Pair;
            return HandRank.HighCard;
        }
    }

   

    public class Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }
        public Card(CardSuit suit, CardValue value) { Suit = suit; Value = value; }
        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }

    }

    //All the enums that will be used in this application
    public enum CardSuit { Heart, Diamond, Club, Spade }
    public enum CardValue { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public enum HandRank { RoyalFlush, StraightFlush, FourOfAKind, FullHouse, Flush, Straight, ThreeOfAKind, TwoPairs, Pair, HighCard  }

}
