namespace DurakCardGame
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Rank
    {
        Six = 6,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        public Button AssignedButton { get; set; }
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string GetSpritePath()
        {
            return $"DurakCardGame.assets.{Rank}-{Suit.ToString()[0]}.png";
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
 };
