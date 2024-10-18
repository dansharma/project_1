using System;
using System.Collections.Generic;

namespace DurakCardGame
{
    public class Deck
    {
        public delegate void CardDrawnEventHandler(int count);
        public event CardDrawnEventHandler CardDrawn;

        private List<Card> cards;
        private Random random;

        public Deck()
        {
            cards = new List<Card>();
            random = new Random();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int rank = (int)Rank.Six; rank <= (int)Rank.Ace; rank++)
                {
                    cards.Add(new Card(suit, (Rank)rank));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card Draw()
        {
            if (cards.Count == 0)
                return null;
            Card card = cards[0];
            cards.RemoveAt(0);
            CardDrawn?.Invoke(Count);
            return card;
        }

        public void Add(Card card) {
            cards.Add(card);
        }
        public int Count => cards.Count;
    }
}
