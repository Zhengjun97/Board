using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    public class Deck
    {
        public List<Card> card;
        public Deck()
        {
            card = new List<Card>();
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                string strName = Enum.GetName(typeof(Rank), rank);//get name
                string strVaule = rank.ToString();//get value
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    card.Add(new Card(rank, suit));
                }
            }
        }
        public void Shuffle() {

            Random rand = new Random();
            int t = rand.Next(card.Count());
            for (int i = 0; i < 52; i++)
            {
                 t = rand.Next(card.Count());
                var c = card[t];
                card.RemoveAt(t);
                card.Add(c);
            }
        }
        public Card TakeTopCard() {
            if (card.Any())
            {
                var c = card[0];
                card.RemoveAt(0);
                return c;
            }
            return null;

        }

    }

}
