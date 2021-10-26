using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    public abstract class Board
    {
        public Deck deck;
        public List<Card> cardsDisplayOnBoard;
        public int size;
        public Board(int sizeBoard) {
            deck = new Deck();

            deck.Shuffle();

            cardsDisplayOnBoard = new List<Card>();
            for (int i = 0; i < sizeBoard; i++)
            {
                cardsDisplayOnBoard.Add(deck.TakeTopCard());
            }
            size = sizeBoard;
        }
        public void SelectCard(String userinput) {
            foreach (var item in cardsDisplayOnBoard)
            {
                var s = item.getSuit().ToString();
                var r = item.getRank().ToString();
                if (s + r.Substring(1)== userinput) {
                    item.selected = true;
                    return;
                }
            }
        }
        public  void Remove() {
            var selectcard = cardsDisplayOnBoard.Where(x => x.selected).ToList();
            for (int i = 0; i < selectcard.Count(); i++)
            {
                cardsDisplayOnBoard.Remove(selectcard[i]);
            }
        }
        public  void replace() {
            for (int i = cardsDisplayOnBoard.Count(); i < size; i++)
            {
              var card=  deck.TakeTopCard();
                cardsDisplayOnBoard.Add(card);
            }
        }
        public int CardAddUp(Card card1, Card card2) {
            return card1.getCardValue() + card2.getCardValue();
        }
        public abstract bool checkForWin();

        public  void printBoard() {
            foreach (var item in cardsDisplayOnBoard)
            {
                Console.Write(item.getSuit() +item.getRank().ToString().Substring(1)+"\t");
                
            }
            Console.WriteLine();
        }
        public  bool isEmpty()
        {
            return !deck.card.Any();
        }
        public  void remainingCard() {
            foreach (var item in deck.card)
            {
                Console.Write(item.getSuit() + "  " + item.getRank() + "\t");

            }
            Console.WriteLine();
        }

    }
}
