using System;
using Pattern_AbstractFactory.Individuals;

namespace Pattern_AbstractFactory.Races
{
    public class HumanWarrior : Warrior
    {
        public override string Info()
        {
            return "Warrior of Human civilization";
        }
    }

    public class HumanAristocrat : Aristocrat
    {
        public override string Info()
        {
            return "Aristocrat of Human Civilization";
        }
    }

    public class HumanWorker : Worker
    {
        public override string Info()
        {
            return "Worker of Human Civilization";
        }
    }
}
