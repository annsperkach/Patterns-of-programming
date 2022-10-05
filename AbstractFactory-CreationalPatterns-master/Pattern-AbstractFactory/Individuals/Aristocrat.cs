using System;


namespace Pattern_AbstractFactory.Individuals
{
    //product
    public class Aristocrat : Individual
    {
        public override string Info()
        {
            return "Aristocrat";
        }
        public override int GetMoney()
        {
            Random rnd = new Random();
            Money = rnd.Next(100000, 300000);
            return Money;
        }

        public override string TerritoryDescription()
        {
            Random rnd = new Random();
            ForestSquare = rnd.Next(250, 400);
            FieldSquare = rnd.Next(250, 400);
            HouseCount = rnd.Next(60, 260);
            FactoriesCount = rnd.Next(60, 260);
            return $"ForestSquare: {ForestSquare}\nFieldSquare: {FieldSquare}\nDwellingCount: {HouseCount}\nFactoriesCount: {FactoriesCount}";
        }
    }
}
