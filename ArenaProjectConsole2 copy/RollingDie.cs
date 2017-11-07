using System;
namespace ArenaProjectConsole2
{
    /// <summary>
    /// Class representing a die in a board game
    /// </summary>
    public class RollingDie
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private Random random;

        /// <summary>
        /// Number of sides the dice has
        /// </summary>
        private int sidesCount;

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        public RollingDie(int sidesCount)
        {
            this.sidesCount = sidesCount;
            random = new Random();
        }

        /// <summary>
        /// Constructor with no parameter but sets side count in body
        /// </summary>
        public RollingDie()
        {
            sidesCount = 6;
            random = new Random();
        }

        /// <summary>
        /// Method to get sides count
        /// </summary>
        /// <returns>The sides count.</returns>
        public int GetSidesCount()
        {
            return sidesCount;
        }

        /// <summary>
        /// random dice roll method
        /// </summary>
        /// <returns>The roll.</returns>
        public int roll()
        {
            return random.Next(1, sidesCount + 1);
        }

        /// <summary>
        /// override the string to print out what we want and not the location/pathway
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ArenaProjectConsole2.RollingDie"/>.</returns>
        public override string ToString()
        {
            return string.Format("Rolling a die with {0} sides",sidesCount);
        }
    }
}