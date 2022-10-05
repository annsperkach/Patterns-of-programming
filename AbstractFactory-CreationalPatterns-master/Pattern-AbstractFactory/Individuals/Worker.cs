using System;

namespace Pattern_AbstractFactory.Individuals
{
    public class Worker : Individual
    {
        public override string Info()
        {
            return "Worker";
        }

        public override int GetMoney()
        {
            Random rnd = new Random();
            Money = rnd.Next(15000, 30000);
            return Money;
        }

        public override string TerritoryDescription()
        {
            Random rnd = new Random();
            ForestSquare = rnd.Next(80, 150);
            FieldSquare = rnd.Next(120, 250);
            HouseCount = rnd.Next(50, 80);
            FactoriesCount = rnd.Next(20, 80);
            return $"ForestSquare: {ForestSquare}\nFieldSquare: {FieldSquare}\nDwellingCount: {HouseCount}\nFactoriesCount: {FactoriesCount}";
        }
    }
}
