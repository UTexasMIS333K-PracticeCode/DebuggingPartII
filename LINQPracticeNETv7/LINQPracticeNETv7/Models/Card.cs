using System;

namespace LINQPracticeNETv7
{
    public enum Suit { Spades, Hearts, Clubs, Diamonds }
    public class Card
    {
        //this is the primary key for the database
        public Int32 CardID { get; set; }

        //this is the suit (as defined in the enum above)
        public Suit Suit { get; set; }

        //this is the rank of the card - ace through king
        public String Rank { get; set; }

        //this is the value of the card - 1 for ace through 13 for king
        public Int32 Value { get; set; }

        //display the symbol for each suit
        public String Symbol
        {
            get
            {
                switch (Suit)
                {
                    case Suit.Spades:
                        //9824 is the unicode value for spade 
                        return ((char)9824).ToString();
                    case Suit.Hearts:
                        //9829 is the unicode value for heart
                        return ((char)9829).ToString();
                    case Suit.Clubs:
                        //9827 is the unicode value for club
                        return ((char)9827).ToString();
                    default:
                        //this is for diamonds
                        //9830 is the unicode value for diamond
                        return ((char)9830).ToString();
                }
            }


        }

        //this will display the name of the card in a single line
        public override string ToString()
        {
            return Rank + " of " + Suit.ToString() + " " + Symbol;
        }
    }
}