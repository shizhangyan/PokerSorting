using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSorting
{
    internal class RankSort
    {
        public List<string> RankList { get; set; }
        public RankSort(List<string> list)
        {
            RankList = list;
        }
        public void SortRankList()
        {
            RankList.Sort(SuitComparer);
        }

        private int SuitComparer(string pokerA, string pokerB)
        {
            var a = GetPokerNumber(pokerA);
            var b = GetPokerNumber(pokerB);

            return a - b;
        }

        private int GetPokerNumber(string poker)
        {
            if (string.IsNullOrEmpty(poker))
            {
                return 0;
            }
            var numStr = poker.Substring(1);
            var num = 0;
            switch (numStr)
            {
                case "A":
                    num = 1;
                    break;
                case "K":
                    num = 13;
                    break;
                case "Q":
                    num = 12;
                    break;
                case "J":
                    num = 11;
                    break;
                default:
                    num = Convert.ToInt32(numStr);
                    break;
            }
            // 利用15-牌面值， 已达到大的排前面， 小的排后面
            // 此处为了区别同一数字的不同花色， 在此乘以了一个常数100（）一副扑克的牌数总数即可
            num = (15 - num) * 100;

            // 不同的花色再加上一个偏移量， 此处根据需要设置花色的大小， 我这里的suit排序顺序为： 黑 红 方 梅
            char c = poker[0];
            switch (c)
            {
                case '♠':
                    num += 1;
                    break;
                case '♥':
                    num += 2;
                    break;
                case '♦':
                    num += 3;
                    break;
                case '♣':
                    num += 4;
                    break;
                default :
                    break;
            }

            return num;
        }
    }
}
