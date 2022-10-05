using System;
using Pattern_AbstractFactory.Individuals;
using Pattern_AbstractFactory.Races;

namespace Pattern_AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            CivilizationFactory DragonFactory = new DragonFactory();
            ElfFactory ElfFactory = new ElfFactory();
            HumanFactory HumanFactory = new HumanFactory();

            //civilization of elfs
            Civilization Elf = new Civilization(ElfFactory);
            Individual[] ElfRaces = Elf.CreateCivilization();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Civilization of Elfs:");
            Console.ResetColor();
            foreach (Individual ind in ElfRaces)
            {
                Console.WriteLine($"{ind.Info()} has {ind.GetMoney()} $");
                Console.WriteLine(ind.TerritoryDescription());
            }
            Console.WriteLine();

            //civilization of dragons
            Civilization Dragon = new Civilization(DragonFactory);
            Individual[] DragonRaces = Elf.CreateCivilization();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Civilization of Dragons:");
            Console.ResetColor();
            foreach (Individual ind in DragonRaces)
            {
                Console.WriteLine($"{ind.Info()} has {ind.GetMoney()} $");
                Console.WriteLine(ind.TerritoryDescription());
            }
            Console.WriteLine();

            //civilization of people
            Civilization Human = new Civilization(HumanFactory);
            Individual[] HumanRaces = Elf.CreateCivilization();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Civilization of People:");
            Console.ResetColor();
            foreach (Individual ind in HumanRaces)
            {
                Console.WriteLine($"{ind.Info()} has {ind.GetMoney()} $");
                Console.WriteLine(ind.TerritoryDescription());
            }
            Console.WriteLine();
        }
    }
}
