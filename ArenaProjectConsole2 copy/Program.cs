using System;

namespace ArenaProjectConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            RollingDie die = new RollingDie(10);
            Warrior warrior = new Warrior("Catboy",100, 20, 10, die);
            Warrior gandalf = new Mage("gandalf", 60, 15, 12, die, 30, 45, 45);
            Arena arena = new Arena(warrior, gandalf, die);
            //
            arena.Fight();
            Console.ReadKey();


        }
    }
}
