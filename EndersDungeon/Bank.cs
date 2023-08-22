using EndersDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndersDungeon
{
    [Serializable]
    public class Bank
    {
        public static void BankMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the bank! Here you can store your coins so you dont lose them while your'e travelling");
                Console.WriteLine("===================");
                Console.WriteLine("| (C)heck Balence |");
                Console.WriteLine("| (D)eposit       |");
                Console.WriteLine("| (W)ithdraw      |");
                Console.WriteLine("| (E)xit          |");
                Console.WriteLine("===================");

                string data = Console.ReadLine().ToLower();

                if (data == "c" || data == "check")
                    CheckBalance();
                else if (data == "d" || data == "deposit")
                    DepositMoney();
                else if (data == "w" || data == "withdraw")
                    WithdrawBalance();
                else if (data == "e" || data == "exit")
                    break;
            }   
            Console.ReadKey();
        }

        public static void CheckBalance()
        {
            Console.WriteLine("You have $" + Program.currentPlayer.balance + " in your bank!");
        }

        public static void DepositMoney()
        {
            Console.WriteLine("How much would you like to deposit?");
            int data = Convert.ToInt32(Console.ReadLine());

            if (data > Program.currentPlayer.coins)
            {
                Console.WriteLine("You dont have enough money to deposit that much!");
            }
            else
            {
                Program.currentPlayer.balance += data;
                Program.currentPlayer.coins -= data;
            }
        }

        public static void WithdrawBalance()
        {
            Console.WriteLine("Houw much would you like to withdraw?");
            int data = Convert.ToInt32(Console.ReadLine());

            if (data > Program.currentPlayer.balance)
            {
                Console.WriteLine("You dont have that much money in your bank!");
            }
            else
            {
                Program.currentPlayer.balance -= data;
                Program.currentPlayer.coins += data;
            }
        }
    }
}