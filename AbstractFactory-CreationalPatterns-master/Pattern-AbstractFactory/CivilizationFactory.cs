using System;
using Pattern_AbstractFactory.Individuals;
using Pattern_AbstractFactory.Races;

namespace Pattern_AbstractFactory
{
    //generating pattern design - abstract factory
    public abstract class CivilizationFactory
    {
        public abstract Warrior CreateWarrior();
        public abstract Worker CreateWorker();
        public abstract Aristocrat CreateAristocrat();
    }

        // Concrete Individuals are created by corresponding Concrete Factories
        public class DragonFactory : CivilizationFactory
        {
            public override Warrior CreateWarrior()
            {
                return new DragonWarrior();
            }

            public override Worker CreateWorker()
            {
                return new DragonWorker();
            }

            public override Aristocrat CreateAristocrat()
            {
                return new DragonAristocrat();
            }
        }

        // Concrete factory
        public class ElfFactory : CivilizationFactory
        {
            public override Warrior CreateWarrior()
            {
                return new ElfWarrior();
            }

            public override Worker CreateWorker()
            {
                return new ElfWorker();
            }

            public override Aristocrat CreateAristocrat()
            {
                return new ElfAristocrat();
            }
        }

        // Concrete factory
        public class HumanFactory : CivilizationFactory
        {
            public override Warrior CreateWarrior()
            {
                return new HumanWarrior();
            }

            public override Worker CreateWorker()
            {
                return new HumanWorker();
            }

            public override Aristocrat CreateAristocrat()
            {
                return new HumanAristocrat();
            }
        }
}
