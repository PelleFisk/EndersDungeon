using EndersDungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndersDungeon
{
    public class Info
    {
        public static void InfoMenu()
        {
            Console.WriteLine("==============");
            Console.WriteLine("| (A)uthour:  Adrian  |");
            Console.WriteLine("| (V)ersion:  0.1.0   |");
            Console.WriteLine("| (I)nfo about stats: |");

            string data = Console.ReadLine();

            if (data == "i" || data == "info")
            {
                Console.WriteLine("===============");
                Console.WriteLine("| Buying a weapon increases your damage by 1                                    |");
                Console.WriteLine("| Buying armor increases your defence by 1                                      |");
                Console.WriteLine("| Buying potions increases your potion's gives you one healing potion           |");
                Console.WriteLine("| Buying diffuculty mod makes enemies harder to beat but they give more rewards |");
                Console.WriteLine("===============");
            }
            Console.ReadKey();
        }
    }
}