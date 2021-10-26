using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    public class Tens : Board
    {
        public Tens(int size) : base(size) {
        
        }
       
        //check suit of 10 j q k
        public bool checkKQJ()
        {
            var selectcards = cardsDisplayOnBoard.Where(x => x.selected).ToList();
            if (selectcards.Count != 4) {
                return false;
            }
            int[] kqj = new int[4];
            foreach (var item in selectcards)
            {
                    int v = item.getCardValue();

                    if (v >= 10) {
                        kqj[v - 10]++;
                    }
                
            }
            if (kqj[0] == 1 && kqj[1] == 1 && kqj[2] == 1 && kqj[3] == 1) {
                return true;
            }
            return false;
        }

        //check rank of 10, j, q, k
        public bool checkFourRank()
        {
            var selectcards = cardsDisplayOnBoard.Where(x => x.selected).ToList();
            if (selectcards.Count != 4)
            {
                return false;
            }
            int[] kqj = new int[4];
            foreach (var item in selectcards)
            {
                int v = item.getCardValue();

                if (v >= 10)
                {
                    kqj[v - 10]++;
                }

            }
            if (kqj[0] == 4 || kqj[1] == 4 && kqj[2] == 4 && kqj[3] == 4)
            {
                return true;
            }
            return false;
        }

        //check the sum of two cards that user choose does match to 10
        public bool checkTwoCardEqualTen()
        {

            var selectcards = cardsDisplayOnBoard.Where(x => x.selected).ToList();
            if (selectcards.Count != 2)
            {
                return false;
            }
            if (selectcards[0].getCardValue() + selectcards[1].getCardValue() == 10)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public override bool checkForWin()
        {
            if (isEmpty())
            {
                return true;
            }
            if (checkKQJ() || checkTwoCardEqualTen())
            {
                Remove();
                replace();
                return false;
            }
            else {
                cardsDisplayOnBoard.Where(X => X.selected).ToList().ForEach(x=>x.selected=false);
            }
            return false;
        }
    }
}
