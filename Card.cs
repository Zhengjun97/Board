using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
  public  class Card
    {
        private Rank rank;
        private Suit suit;
        public bool selected { get; set; }
        public Card(Rank r,Suit s) {
            rank = r;
            suit = s;
        }
        public Rank getRank() {
            return rank;
        }
        public Suit getSuit()
        {
            return suit;
        }
        public int getCardValue() {
            return (int)rank;
        }
    }

    public enum Rank { 
        RA=1,
        R2,
        R3,
        R4,
        R5,
        R6,
        R7,
        R8,
        R9,
        RT,
        RJ,
        RQ,
        RK
    }
    public enum Suit {
        H,//Hearts
        S,//Spade
        C,//Club
        D,//Diamond
    }
}
