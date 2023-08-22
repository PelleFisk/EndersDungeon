using EndersDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndersDungeon
{
    public class Encounters
    {
        static Random rand = new Random();
        // Encounter Generic


        // Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door and grab a rusty metal sword while charging toward your captor");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat(false, false, "Human Rouge", 1, 4);
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Program.Print("You turn the corner and there you see a hulking beast...");
            Console.ReadKey();
            Combat(true, false, "", 0, 0);
        }

        public static void PuzzleEncounter()
        {
            Console.Clear();
            Program.Print("You encounter a puzzle...");
            Combat(false, true, "", 0, 0);
        }

        // Encounter Tools

        public static void BossFight()
        {
            Console.Clear();
            if (Program.currentPlayer.dungeonLevel == 10)
            {
                Program.Print("You stand infornt of the mighty Plantera");
                Console.ReadKey();
                Combat(false, false, "Plantera", 4, 15);
            }
            else if (Program.currentPlayer.dungeonLevel == 20)
            {
                Program.Print("You stand infornt of the mighty Skeltron");
                Console.ReadKey();
                Combat(false, false, "Skeletron", 10, 30);
            }
            else if (Program.currentPlayer.dungeonLevel == 30)
            {
                Program.Print("You stand infornt of the mighty Skeltron");
                Console.ReadKey();
                Combat(false, false, "The Might All Flame", 21, 60);
            }
            else if (Program.currentPlayer.dungeonLevel == 40)
            {
                Program.Print("You stand infornt of the mighty Kitava");
                Console.ReadKey();
                Combat(false, false, "Kitava", 28, 80);
            }
        }
        public static void RandomEncounter()
        {
            switch (rand.Next(0, 3))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    WizardEncounter();
                    break;
                case 2:
                    PuzzleEncounter();
                    break;
            }
        }

        public static void WizardEncounter()
        {
            Console.Clear();
            Program.Print("The door slowly creeks open as you peer into the dark room. You see a tall man with a ");
            Program.Print("long beard looking at a tome.");
            Console.ReadKey();
            Combat(false, false, "Dark Wizard", 3, 4);
        }

        public static void Combat(bool random, bool puzzle, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else if (puzzle)
            {
                Puzzle.main();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p+ "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un    (H)eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine("  Potions:  " + Program.currentPlayer.potions + "  Health:  " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    // Attack
                    Console.WriteLine("With haste you surge forth, your sword flying in your hands! As you pass, the " + n + " strikes you as you pass");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(1, Program.currentPlayer.weaponValue) + rand.Next(1, 4) + ((Program.currentPlayer.currentClass == Player.PlayerClass.Warrior) ? 2 : 0 );
                    Console.WriteLine("You lose " + damage + " health and you deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    // Defend
                    Console.WriteLine("As the " + n + " prepares to strike, you ready your sword in a definsive stance");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if(damage < 0)
                        damage = 0;
                    int attack = rand.Next(1, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine("You lose " + damage + " health and you deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    // Run
                    if (Program.currentPlayer.currentClass != Player.PlayerClass.Archer && rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint way from the " + n + ", it's strikes catches you in the back, sending you sprawling to teh ground");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the " + n + " and you successfully escape!");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // Heal
                    if (Program.currentPlayer.potions == 0)
                    {
                        Console.WriteLine("As you desperatly grasp for a potion in your bar, all that you feel are empty glass flasks.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if(damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " strikes you with a mighty blow and you lose " + damage + " health");
                        Program.currentPlayer.health -= damage;
                    }
                    else 
                    {
                        Console.WriteLine("You reach in to your bag and pull out a glowing, purple flask. You take a long drink");
                        int potionV = 5 + ((Program.currentPlayer.currentClass == Player.PlayerClass.Mage) ? + 4 : 0);
                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck");
                        int damage = (p/2) - Program.currentPlayer.armorValue;
                        if (damage < 0) 
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health.");
                        Program.currentPlayer.health -= damage;
                        if (Program.currentPlayer.health > Program.currentPlayer.healthMax)
                            Program.currentPlayer.health = 10;
                        Program.currentPlayer.potions--;
                    }
                    Console.ReadKey();
                }
                if (Program.currentPlayer.health <= 0)
                {
                    // Death Code
                    Console.WriteLine("As the " + n + " stands tall and comes down to strike. You have been slayn by the mighty " + n);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = Program.currentPlayer.GetCoins();
            int e = Program.currentPlayer.GetXp();
            Console.WriteLine("As you stand victorious over the " + n + ", it's body dissolves into " + c + " gold coins! You have gained " + e + " exp! You also advance 1 floor deeper in the catacombs");
            Program.currentPlayer.dungeonLevel++;
            Program.currentPlayer.coins += c;
            Program.currentPlayer.xp += e;

            if (Program.currentPlayer.dungeonLevel == 10)
            {
                Console.WriteLine("You have come to the last floor of the catacombs and you will have to fight your way trough");
                Console.WriteLine("Do you want to fight the boss or run away?(r, f)");
                string input = Console.ReadLine();

                if (input == "r") 
                {
                    Shop.LoadShop(Program.currentPlayer);
                }
                else if (input == "f") 
                {
                    BossFight();
                }
            }

            if (Program.currentPlayer.CanLevelUp())
                Program.currentPlayer.LevelUp();

            Console.ReadKey();
        }

        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Human Cultist";
                case 3:
                    return "Grave Robber";
            }
            return "Human Rouge";
        }
    }
}