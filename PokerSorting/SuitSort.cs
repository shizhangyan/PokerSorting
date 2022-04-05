using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSorting
{
    internal class SuitSort
    {
        public List<string> SuitList { get; set; }
        public SuitSort(List<string> list)
        {
            SuitList = list;
        }
        public void SortSuitList()
        {
            SuitList.Sort(SuitComparer);
        }

        private int SuitComparer(string pokerA, string pokerB)
        {
            var a = getPokerNumber(pokerA);
            var b = getPokerNumber(pokerB);

            return a - b;
        }

        private int getPokerNumber(string poker)
        {
            if (string.IsNullOrEmpty(poker))
            {
                return 0;
            }

            var suitvalue = 0;
            char c = poker[0];
            // here first sorting about suit, so first multiple suit with a constant
            switch (c)
            {
                case '♠':
                    suitvalue = 100;
                    break;
                case '♥':
                    suitvalue = 200;
                    break;
                case '♦':
                    suitvalue = 300;
                    break;
                case '♣':
                    suitvalue = 400;
                    break;
                default:
                    break;
            }
            var numStr = poker.Substring(1);
            var number = 0;
            // assign the special poker to int value
            switch (numStr)
            {
                case "A":
                    number = 1;
                    break;
                case "K":
                    number = 13;
                    break;
                case "Q":
                    number = 12;
                    break;
                case "J":
                    number = 11;
                    break;
                default :
                    number = Convert.ToInt32(numStr);
                    break;
            }

            // keep every suit stay in different area
            number = (15 - number) + suitvalue;

            return number;
        }
    }
}
