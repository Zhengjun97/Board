using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class Elevens : Board
    {
        public Elevens(int size) : base(size) { }

        public override bool checkForWin()
        {
            if (isEmpty()) {
                return true;
            }
            if (checkKQJ()|| checkTwoCardEqual11()) {
                Remove();
                replace();
                return false;
            }
            return false;
        }

        //check for J Q K 
        public bool checkKQJ() {

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
            if (kqj[0] == 1 && kqj[1] == 1 && kqj[2] == 1 && kqj[3] == 1)
            {
                return true;
            }
            return false;
        }

        //check the sum of two cards that user choose does match to 11.
        public bool checkTwoCardEqual11()
        {
            var selectcards = cardsDisplayOnBoard.Where(x => x.selected).ToList();
            if (selectcards.Count != 2)
            {
                return false;
            }
            if (selectcards[0].getCardValue() + selectcards[1].getCardValue() == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
