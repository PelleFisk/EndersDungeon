using EndersDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndersDungeon
{
    public class SkillTree
    {
        public static Player p = new Player();
        public static int hp = 0;
        public static int damage = 1;

        public static void SkillMenu()
        {
            Console.WriteLine(hp + ":" + " 5 more hp");
            Console.WriteLine(damage + ":" + " 2 more damage");
            Console.WriteLine("0's are for hp and 1's are for damage increasment");
            string data = Console.ReadLine();

            switch (data)
            {
                case "0":
                    HpUnlock();
                    break;
                case "1":
                    DamageUnlock();
                    break;
            }
            Console.ReadKey();
        }

        public static void HpUnlock()
        {
            if (Program.currentPlayer.skillPoints > 0) 
            {
                Program.currentPlayer.healthMax += 5;
                Program.currentPlayer.skillPoints--;
            }
            else
            {
                Console.WriteLine("You did not have enough skillpoints.");
            }
        }

        public static void DamageUnlock()
        {
            if (Program.currentPlayer.skillPoints > 0)
            {
                Program.currentPlayer.weaponValue += 2;
                Program.currentPlayer.skillPoints--;
            }
            else
            {
                Console.WriteLine("You did not have enough skillpoints.");
            }
        }
    }
}