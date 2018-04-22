using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardLibrary;

namespace UnitTestPoker
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDrawHand()
        {
            Card card = new Card(CardSuit.Club, CardValue.Eight);
            Hand hand = new Hand();
            hand.Draw(card);

            CardValue expectedValue = card.Value;
            CardSuit expectedSuit = card.Suit;

            CardValue actualValue = hand.Cards[0].Value;
            CardSuit actualSuit = hand.Cards[0].Suit;

            Assert.AreEqual(expectedValue, actualValue, "Card value do not match");
            Assert.AreEqual(expectedSuit, actualSuit, "Card suit do not match");
        }
        [TestMethod]
        public void TestRoyalFlush()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Heart, CardValue.Queen));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Ace));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Jack));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Ten));
            hand.Draw(new Card(CardSuit.Heart, CardValue.King));
            HandRank expected = HandRank.RoyalFlush;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "Royalflush not detected");
        }
        [TestMethod]
        public void TestStraightFlush()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Club, CardValue.Four));
            hand.Draw(new Card(CardSuit.Club, CardValue.Three));
            hand.Draw(new Card(CardSuit.Club, CardValue.Six));
            hand.Draw(new Card(CardSuit.Club, CardValue.Five));
            hand.Draw(new Card(CardSuit.Club, CardValue.Seven));
            HandRank expected = HandRank.StraightFlush;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "StraightFlush not detected");
        }
        [TestMethod]
        public void TestFourOfAKind()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Club, CardValue.Six));
            hand.Draw(new Card(CardSuit.Spade, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Club, CardValue.Seven));
            HandRank expected = HandRank.FourOfAKind;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "FourOfAKind not detected");
        }
        [TestMethod]
        public void TestFullHouse()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Queen));
            hand.Draw(new Card(CardSuit.Club, CardValue.Queen));
            hand.Draw(new Card(CardSuit.Spade, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Spade, CardValue.Queen));
            HandRank expected = HandRank.FullHouse;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "FullHouse not detected");
        }
        [TestMethod]
        public void TestFlush()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Ace));
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Four));
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Two));
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Eight));
            HandRank expected = HandRank.Flush;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "Flush not detected");
        }
        [TestMethod]
        public void TestStraight()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Eight));
            hand.Draw(new Card(CardSuit.Club, CardValue.Six));
            hand.Draw(new Card(CardSuit.Spade, CardValue.Ten));
            hand.Draw(new Card(CardSuit.Club, CardValue.Nine));
            HandRank expected = HandRank.Straight;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "Straight not detected");
        }
        [TestMethod]
        public void TestThreeOfAKind()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Two));
            hand.Draw(new Card(CardSuit.Club, CardValue.Six));
            hand.Draw(new Card(CardSuit.Spade, CardValue.Two));
            hand.Draw(new Card(CardSuit.Club, CardValue.Two));
            HandRank expected = HandRank.ThreeOfAKind;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "ThreeOfAKind not detected");
        }
        [TestMethod]
        public void TestTwoPairs()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Queen));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Seven));
            hand.Draw(new Card(CardSuit.Club, CardValue.Six));
            hand.Draw(new Card(CardSuit.Spade, CardValue.Queen));
            hand.Draw(new Card(CardSuit.Club, CardValue.Seven));
            HandRank expected = HandRank.TwoPairs;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "TwoPairs not detected");
        }
        [TestMethod]
        public void TestPair()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.King));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Ace));
            hand.Draw(new Card(CardSuit.Club, CardValue.Two));
            hand.Draw(new Card(CardSuit.Spade, CardValue.King));
            hand.Draw(new Card(CardSuit.Club, CardValue.Seven));
            HandRank expected = HandRank.Pair;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "Pair not detected");
        }
        [TestMethod]
        public void TestHighCard()
        {
            Hand hand = new Hand();
            hand.Draw(new Card(CardSuit.Diamond, CardValue.Two));
            hand.Draw(new Card(CardSuit.Heart, CardValue.Eight));
            hand.Draw(new Card(CardSuit.Club, CardValue.Four));
            hand.Draw(new Card(CardSuit.Spade, CardValue.Ten));
            hand.Draw(new Card(CardSuit.Club, CardValue.Six));
            HandRank expected = HandRank.HighCard;
            HandRank actual = hand.GetHandRank();
            Assert.AreEqual(expected, actual, "HighCard not detected");
        }
    }
}
