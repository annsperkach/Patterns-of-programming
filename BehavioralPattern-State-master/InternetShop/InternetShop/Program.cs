using Order.Menu;
using Order.Models;
using System;

namespace Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fio;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter your Name and Surname:");
            Console.ResetColor();
            fio = Console.ReadLine();
            var menu = new ConsoleMenu(new Client(fio));
            menu.StartShopping();
        }
    }
}