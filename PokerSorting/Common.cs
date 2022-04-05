using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSorting
{
    internal class Common
    {
        public static List<string> ReadFile(string srcFileName)
        {
            var list = new List<string>();
            using (var sr = new StreamReader(srcFileName, Encoding.UTF8))
            {
                string s = "";
                while ( (s = sr.ReadLine()) != null)
                {
                    list.Add(s);
                }
            }
            return list;
        }
        public static void WriteFile(string desFileName, List<string> list)
        {
            using(var sw = new StreamWriter(desFileName,true, Encoding.UTF8))
            {
                foreach(var item in list)
                {
                    sw.WriteLine(item);
                }
            }
        }
        //J,Q,A,
        public static void GenerateRandPoker()
        {
            List<string> list = new List<string>();
            for(int i = 1; i <= 13; i++)
            {
               if (i == 1)
                {
                    list.Add("♠A");
                    list.Add("♣A");
                    list.Add("♥A");
                    list.Add("♦A");
                }
                else if( i<=10 && i > 1)
                {
                    list.Add("♠" + i);
                    list.Add("♣" + i);
                    list.Add("♥" + i);
                    list.Add("♦" + i);
                }
                else if (i == 11)
                {
                    list.Add("♠J");
                    list.Add("♣J");
                    list.Add("♥J");
                    list.Add("♦J");
                }
                else if (i == 12)
                {
                    list.Add("♠Q");
                    list.Add("♣Q");
                    list.Add("♥Q");
                    list.Add("♦Q");
                }
                else if (i == 13)
                {
                    list.Add("♠K");
                    list.Add("♣K");
                    list.Add("♥K");
                    list.Add("♦K");
                }
            }
            Random r= new Random();
            for(int i = 0; i < 100; i++)
            {
                int n = r.Next(0, 51);
                int m = r.Next(0, 51);
                if (n != m)
                {
                    string tmp = list[m];
                    list[m] = list[n];
                    list[n] = tmp;
                }
            }
            WriteFile(@"c:\try\cardsuit.txt", list);
        }
    }
}
