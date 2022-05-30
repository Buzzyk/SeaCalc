using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models.Cannons
{
    internal class TierTwoCannon : Cannon
    {
        private int _eliteAmmunitionBonus;
        private int _goldAmmunitionBonus;
        private int _criticalHitProbability;
        private int _criticalDamage;
        
        public int EliteAmmunitionBonus;
        public TierTwoCannon(string name, int level)
            : base(name, level)
        {

        }
    }
}
