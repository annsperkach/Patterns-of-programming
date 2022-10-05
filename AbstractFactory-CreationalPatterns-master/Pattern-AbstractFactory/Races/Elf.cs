using System;
using Pattern_AbstractFactory.Individuals;

namespace Pattern_AbstractFactory.Races
{
    public class ElfWarrior : Warrior
    {
        public override string Info()
        {
            return "Warrior of Elf civilization";
        }
    }

    public class ElfAristocrat : Aristocrat
    {
        public override string Info()
        {
            return "Aristocrat of Elf Civilization";
        }
    }

    public class ElfWorker : Worker
    {
        public override string Info()
        {
            return "Worker of Elf Civilization";
        }
    }
}
