using System;
using Pattern_AbstractFactory.Individuals;

namespace Pattern_AbstractFactory.Races
{
    public class DragonAristocrat : Aristocrat
    {
        public override string Info()
        {
            return "Aristocrat of Dragon Civilization";
        }
    }

    public class DragonWarrior : Warrior
    {
        public override string Info()
        {
            return "Warrior of Dragon Civilization";
        }
    }

    public class DragonWorker : Worker
    {
        public override string Info()
        {
            return "Worker of Dragon Civilization";
        }
    }
}
