using System;

namespace Pattern_AbstractFactory.Individuals
{
    //product
    public class Warrior : Individual
    {
        public override string Info()
        {
            return "Warrior";
        }

        public override int GetMoney()
        {
            Random rnd = new Random();
            Money = rnd.Next(30000, 60000);
            return Money;
        }

        public override string TerritoryDescription()
        {
            Random rnd = new Random();
            ForestSquare = rnd.Next(100, 200);
            FieldSquare = rnd.Next(100, 200);
            HouseCount = rnd.Next(50, 80);
            FactoriesCount = rnd.Next(2, 10);
            return $"ForestSquare: {ForestSquare}\nFieldSquare: {FieldSquare}\nDwellingCount: {HouseCount}\nFactoriesCount: {FactoriesCount}";
        }
    }
}
