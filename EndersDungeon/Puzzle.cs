using EndersDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndersDungeon
{
    public class Puzzle
    {
        public static void main()
        {
            switch (Program.rand.Next(0, 1))
            {
                case 0:
                    RPS.main();
                    break;
            }
        }
    }
}
