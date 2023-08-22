using EndersDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EndersDungeon
{
    public class Shop
    {
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armorP = 100 * (p.armorValue + 1);
                weaponP = 100 * p.weaponValue;
                difP = 300 + 100 * p.mods;

                Console.Clear();
                Console.WriteLine("        Shop        ");
                Console.WriteLine("====================");
                Console.WriteLine("(W)eapon :         $" + weaponP);
                Console.WriteLine("(A)rmor :          $" + armorP);
                Console.WriteLine("(P)otions :        $" + potionP);
                Console.WriteLine("(D)ifficulty Mod : $" + difP);
                Console.WriteLine("====================");
                Console.WriteLine("(E)xit:   // Exits the Shop");
                Console.WriteLine("(Q)uit:   // Quits the Game and Saves");
                Console.WriteLine("(T)ree:  // Goes to the skill tree");
                Console.WriteLine("(S)ave:  // Saves the game without quitting");
                Console.WriteLine("(B)ank:  // Goes To The Bank");
                Console.WriteLine("(I)nfo:  // shows Info About All The Stats");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(p.name + "'s  Stats  ");
                Console.WriteLine("====================");
                Console.WriteLine("Current Health: " + p.health);
                Console.WriteLine("Max Health: " + p.healthMax);
                Console.WriteLine("Coins: " + p.coins);
                Console.WriteLine("Dungeon Level: " + p.dungeonLevel);
                Console.WriteLine("Weapon Strength: " + p.weaponValue);
                Console.WriteLine("Armor Toughness: " + p.armorValue);
                Console.WriteLine("Potions: " + p.potions);
                Console.WriteLine("Difficulty Mod: " + p.mods);

                Console.WriteLine("Xp: ");
                Console.Write("[");
                Program.ProgressBar("+", " ", ((decimal)p.xp / (decimal)p.GetLevelValue()), 25);
                Console.WriteLine("]");

                Console.WriteLine("Level: " + p.level);
                Console.WriteLine("====================");

                string input = Console.ReadLine().ToLower();
                if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "d" || input == "difficulty mod")
                {
                    TryBuy("dif", difP, p);
                }
                else if (input == "t" || input == "tree")
                    SkillTree.SkillMenu();
                else if (input == "s" || input == "save")
                {
                    Program.save();
                }
                else if (input == "b" || input == "bank")
                    Bank.BankMenu();
                else if (input == "i" || input == "info")
                    Info.InfoMenu();
                else if (input == "q" || input == "quit")
                {
                    Program.Quit();
                }
                else if (input == "e" || input == "exit")
                    break;
            }
        }
        
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
            {
                if (item == "potion")
                    p.potions++;
                else if (item == "weapon")
                    p.weaponValue++;
                else if (item == "armor")
                    p.armorValue++;
                else if (item == "dif")
                    p.mods++;
                p.coins -= cost;
            }
            else
            {
                Console.WriteLine("You do not have enough gold");
                Console.ReadKey();
            }
        }
    }
}