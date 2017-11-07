using System;
namespace ArenaProjectConsole2
{
    public class Mage : Warrior
    {
        private int mana;
        private int maxMana;
        private int magicDamage;

        /// <summary>
        /// Constructor for mage that takes warrior class parameters as well using the base: keyword
        /// </summary>
        /// <param name="">.</param>
        /// <param name="health">Health.</param>
        /// <param name="damage">Damage.</param>
        /// <param name="defense">Defense.</param>
        /// <param name="die">Die.</param>
        /// <param name="maxMana">Max mana.</param>
        /// <param name="magicDamage">Magic damage.</param>
        public Mage(string name, int health, int damage, int defense, RollingDie die, int mana, int maxMana, int magicDamage) : base(name, health, damage, defense, die)
        {
            this.mana = mana;
            this.maxMana = maxMana;
            this.magicDamage = magicDamage;
        }

        public override void Attack(Warrior enemy)
        {
           
            //mana isnt full
            if (mana < maxMana)
            {
                mana += 10;
                if (mana > maxMana)
                    mana = maxMana;
                base.Attack(enemy);

            }
            else //magic damage
            {
                int hit = magicDamage + die.roll();
                setMessage(String.Format("{0} used a magic attack for {1} HP!", name, hit));
                enemy.Defend(hit);
                mana = 0;
            }


        }

        public string manaBar()
        {
            return GraphicalBar(mana, maxMana);
        }
    } 
}