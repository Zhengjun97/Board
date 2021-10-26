using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    public class Thirteens : Board
    {
        public Thirteens(int size) : base(size) { }

        public override bool checkForWin()
        {
            if (isEmpty())
            {
                return true;
            }
            if (checkKing() || checkTwoCardEqual13())
            {
                Remove();
                replace();
                return false;
            }
            return false;
        }

        //only check for king
        public bool checkKing()
        {

            var selectcards = cardsDisplayOnBoard.Where(x => x.selected &&x.getCardValue()==13).ToList();
            return selectcards.Any();
        }

        //check the sum of two cards that user choose does match to 13
        public bool checkTwoCardEqual13()
        {
            var selectcards = cardsDisplayOnBoard.Where(x => x.selected).ToList();
            if (selectcards.Count != 2)
            {
                return false;
            }
            if (selectcards[0].getCardValue() + selectcards[1].getCardValue() == 13)
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
