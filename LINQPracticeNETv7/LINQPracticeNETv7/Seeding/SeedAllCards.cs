using LINQPracticeNETv7.DAL;
using LINQPracticeNETv7.Models;
using System.Text;

namespace LINQPracticeNETv7.Seeding
{
    public static class SeedAllCards
    {
        public static void SeedCards(AppDbContext _context)
        {
            //if there are already 52 cards in the deck, we can stop
            if (_context.Cards.Count() == 52)
            {
                return;
            }

            //otherwise, load the cards
            List<Card> AllCards = new List<Card>();


            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Ace", Value = 1 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Two", Value = 2 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Three", Value = 3 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Four", Value = 4 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Five", Value = 5 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Six", Value = 6 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Seven", Value = 7 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Eight", Value = 8 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Nine", Value = 9 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Ten", Value = 10 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Jack", Value = 11 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "Queen", Value = 12 });
            AllCards.Add(new Card { Suit = Suit.Spades, Rank = "King", Value = 13 });


            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Ace", Value = 1 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Two", Value = 2 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Three", Value = 3 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Four", Value = 4 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Five", Value = 5 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Six", Value = 6 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Seven", Value = 7 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Eight", Value = 8 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Nine", Value = 9 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Ten", Value = 10 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Jack", Value = 11 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "Queen", Value = 12 });
            AllCards.Add(new Card { Suit = Suit.Hearts, Rank = "King", Value = 13 });


            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Ace", Value = 1 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Two", Value = 2 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Three", Value = 3 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Four", Value = 4 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Five", Value = 5 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Six", Value = 6 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Seven", Value = 7 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Eight", Value = 8 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Nine", Value = 9 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Ten", Value = 10 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Jack", Value = 11 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "Queen", Value = 12 });
            AllCards.Add(new Card { Suit = Suit.Clubs, Rank = "King", Value = 13 });


            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Ace", Value = 1 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Two", Value = 2 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Three", Value = 3 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Four", Value = 4 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Five", Value = 5 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Six", Value = 6 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Seven", Value = 7 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Eight", Value = 8 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Nine", Value = 9 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Ten", Value = 10 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Jack", Value = 11 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "Queen", Value = 12 });
            AllCards.Add(new Card { Suit = Suit.Diamonds, Rank = "King", Value = 13 });

            //create a flag to help debug problems
            String strCardTitle = "Start";

            //loop through the list to add or update the movie
            try
            {
                foreach (Card seedCard in AllCards)
                {
                    //update the flag
                    strCardTitle = seedCard.ToString();

                    //see if card is in database
                    Card dbCard = _context.Cards.FirstOrDefault(c => c.Suit == seedCard.Suit && c.Rank == seedCard.Rank);

                    if (dbCard == null) //card doesn't exist - add it
                    {
                        _context.Cards.Add(seedCard);
                        _context.SaveChanges();
                    }

                    else //card is not in database - update it
                    {
                        dbCard.Suit = seedCard.Suit;
                        dbCard.Rank = seedCard.Rank;
                        dbCard.Value = seedCard.Value;
                    }
                }
            }
            catch (Exception ex) //throw error if there is a problem in the database
            {
                StringBuilder msg = new StringBuilder();
                msg.Append("There was a problem adding the card with the title: ");
                msg.Append(strCardTitle);
                msg.Append(")");

                throw new Exception(msg.ToString(), ex);
            }
        }

    }
}
