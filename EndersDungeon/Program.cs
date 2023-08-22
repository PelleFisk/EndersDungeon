using EndersDungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EndersDragon
{
    public class Program
    {
        public static Random rand = new Random();
        public static Player currentPlayer = new Player();
        public static Bank currentBank = new Bank();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
                Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            Print("Ender's Dungeon");
            Console.Write("Name: ");
            p.name = Console.ReadLine();
            Print("Class: Mage  Archer  Warrior");
            bool flag = false;
            while (!flag)
            {
                flag = true;
                string input = Console.ReadLine().ToLower();
                if (input == "mage")
                    p.currentClass = Player.PlayerClass.Mage;
                else if (input == "archer")
                    p.currentClass = Player.PlayerClass.Archer;
                else if (input == "warrior")
                    p.currentClass = Player.PlayerClass.Warrior;
                else
                {
                    Print("Please choose an existing class!");
                    flag = false;
                }
            }
            p.id = i;
            Console.Clear();
            Print("You awake in a cold, stone, dark room. You feel dazed and are having trouble remembering");
            Print("anything about your past.");
            if (p.name == " ")
            {
                Print("You don't even remember your name...");
            }
            else
            {
                Print("You know your name is " + p.name);
            }
            Console.ReadKey();
            Console.Clear();
            Print("You grope around in the darkness until you find a door handel. You feel some resisitiance as");
            Print("you turn the door handle, but the rusty lock breaks with little effort. You see your captor");
            Print("standing with his back to you outside the door.");
            return p;
        }
        
        public static void Quit()
        {
            save();
            Environment.Exit(0);
        }

        public static void save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }

            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Print("Choose your player: ");

                foreach (Player p in players)
                {
                    Print(p.id + ": " + p.name);
                }

                Print("Please input player name or id (id:# or player name). Additionally, 'create' will start a new save: ");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }
                            Print("There is no player with that id!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Print("Your id needs to be a number! Press any key to continue!");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if (player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Print("There is no player with that name!");
                        Console.ReadKey();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Print("Your id needs to be a number! Press any key to continue!");
                    Console.ReadKey();
                }
            }

        }
        public static void Print(string text, int speed = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backgroundChar);
            }
        }
    }
}