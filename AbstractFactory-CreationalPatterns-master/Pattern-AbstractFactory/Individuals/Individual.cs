using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern_AbstractFactory.Individuals
{
        /// Abstract product
        public abstract class Individual
        {
            //finance
            internal int Money { get; set; }
            //territory 
            internal int ForestSquare { get; set; }
            internal int FieldSquare { get; set; }
            internal int HouseCount { get; set; }
            internal int FactoriesCount { get; set; }
            public abstract string Info();
            public abstract string TerritoryDescription();
            public abstract int GetMoney();
        }
}
