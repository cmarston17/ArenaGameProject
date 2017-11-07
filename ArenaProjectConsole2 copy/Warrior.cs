using System;
namespace ArenaProjectConsole2
{
    
    public class Warrior
    {
        /// <summary>
        /// Warriors name
        /// </summary>
        protected string name;

        /// <summary>
        /// warriors current health in hp
        /// </summary>
        protected int health;

        /// <summary>
        /// warriors max health in hp
        /// </summary>
        protected int maxHealth;

        /// <summary>
        /// warriors damage in hp
        /// </summary>
        protected int damage;

        /// <summary>
        /// warriors defense
        /// </summary>
        protected int defense;

        /// <summary>
        /// the rolling die instance
        /// </summary>
        protected RollingDie die;

        /// <summary>
        /// Will put out message about what happened
        /// </summary>
        private string message;

        /// <summary>
        /// Constructor with parameters of the fields above
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="heath">Heath.</param>
        /// <param name="damage">Damage.</param>
        /// <param name="defense">Defense.</param>
        /// <param name="die">Die.</param>
        public Warrior(string name, int health, int damage, int defense, RollingDie die)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.damage = damage;
            this.defense = defense;
            this.die = die;
        }

        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// check if the warrior is alive with return instead of using if/else statement
        /// </summary>
        /// <returns>The alive.</returns>
        public bool alive()
        {
            return (health > 0);
             
        }

        public string GraphicalBar(int current, int maximum)
        {
             string s = "[";
            int total = 20;
            double count = Math.Round(((double)health / maxHealth) * total);
            if ((count == 0) && (alive()))
                count = 1;
            for (int i = 0; i < count; i++)
                s += "#";
            s = s.PadRight(total + 1);
            s += "]";
            return s;
        }

        public string healthBar()
        {
            return GraphicalBar(health, maxHealth);
        }

        /// <summary>
        /// warrior defended attack method, adds the defense of the warrior plus dice roll and checks if it killed warrior
        /// </summary>
        /// <returns>The defend.</returns>
        /// <param name="hit">Hit.</param>
        public void Defend(int hit)
        {
            int injury = hit - (defense + die.roll());
            if (injury > 0)
            {
                health -= injury;
                message = String.Format("{0} defended against the attack but still lost {1} hp", name, injury);
                if (health <= 0)
                {
                    health = 0;
                    message += " And died";
                }
            }
            else
                message = String.Format("{0} blocked the hit", name);
            setMessage(message);
        }

        /// <summary>
        /// Attack method for the warrior. adds the damage plus the dice roll to make hit points attacked
        /// </summary>
        /// <returns>The attack.</returns>
        /// <param name="enemy">Enemy.</param>
        public virtual void Attack(Warrior enemy)
        {
            int hit = damage + die.roll();
            setMessage(String.Format("{0} attacks with a hit worth {1} hp", name, hit));
            enemy.Defend(hit);
        }


        /// <summary>
        /// method to set the message
        /// </summary>
        /// <param name="message">Message.</param>
        protected void setMessage(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// method to get the message and return it to console
        /// </summary>
        /// <returns>The message.</returns>
        /// <param name="">.</param>
        public string getMessage()
        {
            return message;
        }

    }

} 

