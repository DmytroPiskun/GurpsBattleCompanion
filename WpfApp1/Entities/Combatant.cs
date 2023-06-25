using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurpsBattleCompanion.Entities
{
    public class Combatant
    {
        /// <summary>
        /// Strength
        /// </summary>
        public int ST { get; set; }

        /// <summary>
        /// dexterity
        /// </summary>
        public int DX { get; set; }

        /// <summary>
        /// Intelligence 
        /// </summary>
        public int IQ { get; set; }

        /// <summary>
        /// Health (NOT hit-points)
        /// </summary>
        public int HT { get; set; }

        /// <summary>
        /// The name of the character
        /// </summary>
        public string Character_Name { get; set; }

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Player_Name { get; set; }

        public int Max_HP { get; set; }
        public int Current_HP { get; set; }

        public int Max_FP { get; set; }
        public int Current_FP { get; set; }

        public int WillPower { get; set; }
        public int Move { get; set; }
        public decimal Speed { get; set; }

        /// <summary>
        /// perception
        /// </summary>
        public int Per { get; set; }
    }
}
