using System;
using System.Collections.Generic;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck mydeck = new Deck();
            Player nick = new Player("Nick", mydeck);
        }
    }
    class Card {
        public string suit;
        public string num;
        public int val;
        public Card(string suit, string num, int val)
        {
            this.suit = suit;
            this.num = num;
            this.val = val;
        }
        public void cardInfo()
        {
            System.Console.WriteLine($"Card Name: {num}, Suit: {suit}, Value: {val}");
        }
    }
    class Deck {
        public List<Card> cards;
        public Deck()
        {
            cards = newDeck();
        }
        public List<Card> newDeck()
        {
            List<Card> newdeck = new List<Card>();
            string[] suit = {"Hearts", "Spades", "Diamonds", "Clubs"};
            string[] num = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
            for (int i = 0; i < suit.Length; i++){
                for (int j = 0; j < num.Length; j++){
                    newdeck.Add(new Card(suit[i], num[j], j+1));
                }
            }
            return newdeck;
        }
        public Deck shuffleCards() {
            List<Card> shuffle(List<Card> list)
            {
                int m = list.Count;
                int i;
                Card t;
                while (m > 0)
                {
                    Random num = new Random();
                    i = num.Next(m--);
                    t = list[m];
                    list[m] = list[i];
                    list[i] = t;
                }
                return list;
            }
            cards = shuffle(cards);
            return this;
        }
        public Deck reset()
        {
            cards = newDeck();
            return this;
        }
        public void readRandomCard() 
        {
            Random num = new Random();
            int i = num.Next(cards.Count);
            cards[i].cardInfo();
        }
        public Card randomCard() 
        {
            Random num = new Random();
            int i = num.Next(cards.Count);
            removeCard(i);
            return cards[i];
        }
        public void removeCard(int num)
        {
            cards.RemoveAt(num);
        }
    }
    class Player {
        public string name;
        public Deck deck;
        public List<Card> hand;
        public Player(string name, Deck deck)
        {
            this.name = name;
            this.deck = deck;
            hand = makeHand();
        }
        public List<Card> makeHand()
        {
            List<Card> newhand = new List<Card>();
            for (int i = 1; i <= 5; i++)
            {
                newhand.Add(deck.randomCard());
            }
            return newhand;
        }
        public Player takeCard() 
        {
            hand.Add(deck.randomCard());
            return this;
        }
        public Player discardCard(int num) 
        {
            hand.RemoveAt(num);
            return this;
        }
    }
}
