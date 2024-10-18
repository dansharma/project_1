using System.Collections.Generic;

namespace DurakCardGame
{
    public class Player
    {
        public List<Card> Hand { get; }

        public Player()
        {
            Hand = new List<Card>();
        }

        public void DrawCard(Deck deck)
        {
            if (deck.Count > 0)
            {
                Hand.Add(deck.Draw());
            }
        }

        public void PlayCard(Card card)
        {
            Hand.Remove(card);
        }
    }
}
