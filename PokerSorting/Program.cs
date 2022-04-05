using System;
using System.Collections.Generic;

namespace PokerSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Common.GenerateRandPoker();
            var fileName = @"C:\try\CardSuit.txt";
            List<String> list = new List<String>();

            SuitPokerTest(fileName);
            RankPokerTest(fileName);

            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }

        private static void RankPokerTest(string fileName)
        {
            var destFilename = @"C:\try\SortSuitCard.txt";
            var list = Common.ReadFile(fileName); 
            SuitSort suitObj = new SuitSort(list);

            suitObj.SortSuitList();
            Common.WriteFile(destFilename, suitObj.SuitList);
        }

        private static void SuitPokerTest(string fileName)
        {
            var destFilename = @"C:\try\SortedRankCard.txt";
            var list = Common.ReadFile(fileName);
            RankSort rankObj = new RankSort(list);

            rankObj.SortRankList();
            Common.WriteFile(destFilename, rankObj.RankList);
        }
    }
}
