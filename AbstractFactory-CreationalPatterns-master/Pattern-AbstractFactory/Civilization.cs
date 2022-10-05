using System;
using Pattern_AbstractFactory.Individuals;
using Pattern_AbstractFactory.Races;

namespace Pattern_AbstractFactory
{
    //Client 
    public class Civilization
    {
        private CivilizationFactory civilizationFactory;
        private Individual[] civilazations;
        public Civilization(CivilizationFactory currentFactory)
        {
            civilizationFactory = currentFactory;
        }
        public Individual[] CreateCivilization()
        {
            civilazations = new Individual[3];
            civilazations[0] = civilizationFactory.CreateWarrior();
            civilazations[1] = civilizationFactory.CreateWorker();
            civilazations[2] = civilizationFactory.CreateAristocrat();

            return civilazations;
        }
    }
}
