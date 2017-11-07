using System;
using System.Threading;
namespace ArenaProjectConsole2
{
    public class Arena
    {
        private Warrior warrior1;
        private Warrior warrior2;
        private RollingDie die;

        public Arena(Warrior warrior1, Warrior warrior2, RollingDie die)
        {
            this.warrior1 = warrior1;
            this.warrior2 = warrior2;
            this.die = die;
        }

        /// <summary>
        /// Prints information about the round of the fight and each warriors health
        /// </summary>
        public void Render()
        {
            Console.Clear();
            Console.WriteLine("-----------------Arena------------------ \n");
            Console.WriteLine("Warriors Health: \n");
            printWarrior(warrior1);
            Console.WriteLine();
            printWarrior(warrior2);
            Console.WriteLine();

        }

        /// <summary>
        /// prints messages with a pasue(thread.sleep method) for dramatic effect
        /// </summary>
        /// <param name="message">Message.</param>
        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        public void Fight()
        {
            Warrior w1 = warrior1;
            Warrior w2 = warrior2;
            Console.WriteLine("Welcome to the arena!");
            Console.WriteLine("Today {0} will battle against {1}! \n", warrior1, warrior2);
        

            bool warrior2Starts = (die.roll() <= die.GetSidesCount() / 2);
            if (warrior2Starts)
            {
                w1 = warrior2;
                w2 = warrior1;
            }
            Console.WriteLine("{0} goes first! \n Let the battle begin!", w1);
            Console.ReadKey();
            //fight loop
            while(warrior1.alive() && warrior2.alive())
            {
                warrior1.Attack(warrior2);
                Render();
                PrintMessage(warrior1.getMessage()); //attack message
                PrintMessage(warrior2.getMessage()); // defend message
                warrior2.Attack(warrior1);
                Render();
                PrintMessage(warrior2.getMessage()); // attack message
                PrintMessage(warrior1.getMessage()); // defend message
                Console.WriteLine();
            }
        }
        private void printWarrior(Warrior W)
        {
            Console.WriteLine(W);
            Console.Write("Health: ");
            Console.WriteLine(W.healthBar());
            if (W is Mage)
            {
                Console.Write("Mana: ");
                Console.WriteLine(((Mage)W).manaBar());
            }
        }

    }
}
