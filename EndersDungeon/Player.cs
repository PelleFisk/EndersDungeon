using EndersDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndersDungeon
{
    [Serializable]
    public class Player
    {
        public string name = "";
        public double balance = 0;
        public int id;
        public int dungeonLevel = 0;
        public int coins = 0;
        public int level = 1;
        public int xp = 0;
        public int health = 10;
        public int healthMax = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potions = 5;
        public int weaponValue = 1;
        public int skillPoints = 0;

        public int mods = 0;

        public enum PlayerClass {Mage, Archer, Warrior};
        public PlayerClass currentClass = PlayerClass.Warrior;

        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return Program.rand.Next(lower, upper);
        }

        public int GetCoins()
        {
            int upper = (10 * mods + 50);
            int lower = (10 * mods + 10);
            return Program.rand.Next(lower, upper);
        }

        public int GetXp()
        {
            int upper = (20 * mods + 50);
            int lower = (15 * mods + 10);
            return Program.rand.Next(lower, upper);
        }

        public int GetLevelValue()
        {
            return 100 * level + 400;
        }

        public bool CanLevelUp()
        {
            if (xp >= GetLevelValue())
                return true;
            else
                return false;
        }

        public void LevelUp()
        {
            while(CanLevelUp()) 
            {
                xp -= GetLevelValue();
                skillPoints++;
                healthMax += 5;
                level++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Program.Print("Congrats! You are now level " + level + "!!!");
            Console.ResetColor();
        }

    }
}