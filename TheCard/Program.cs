// Question: Why do you think we used a color enumeration here but made a color class in the previous challenge(The Color)?
// My Answer: Because RGB allows millions of combinations but an enum is enough for the few card colors

using System;
namespace TheCard;

class Program
{
    static void Main(string[] args)
    {
        CardColor[] colors = new CardColor[]
        {
            CardColor.Blue, CardColor.Green, CardColor.Red, CardColor.Yellow
        };

        CardRank[] ranks = new CardRank[]
        {
            CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, 
            CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, 
            CardRank.Ten, CardRank.DollarSign, CardRank.Persent, CardRank.Caret, CardRank.Ampersand
        };

        foreach(CardColor color in colors)
        {
            foreach(CardRank rank in ranks)
            {
                Card car = new Card(color, rank);
                Console.WriteLine($"{color} {rank}");
            }
        }
    }
}
class Card
{
    public CardColor Color{ get; }
    public CardRank Rank{ get; }

    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;
    }
}

enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}

enum CardRank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    DollarSign,
    Persent,
    Caret,
    Ampersand
}
