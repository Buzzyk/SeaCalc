using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoShip.Models;
using DoShip.Models.Cannons;
using DoShip.Models.Paramaters;

namespace DoShip.Models
{
    public class Ship
    {
        private int _weaponSlots;
        private int _extantionSlots;
        private int _crewSlots;
        private int _cannonReloadTime;
        private int _cannonRange;
        private int _cannonDamage;
        private int _hitProbability;
        private int _hitProbabilityNPC;
        private int _criticalDamage;
        private int _criticalDamageChance;
        private int _negativeEffectChance;
        private int _hitPoints;
        private int _voodooPoints;
        private int _speed;
        private int _visavility;
        private int _armor;
        private int _damagePrevention;
        private int _dodgeChance;
        private int _dodgeRangeNPC;
        private int _dodgeChanceOnPVPArea;
        
        public void AddCannon()
        {
            Cannon cannon = ShipFactory.CreateCannon(ShipFactory.CannonType.Firestorm, 10);
            ((TierTwoCannon)cannon).EliteAmmunitionBonus = 10;

            foreach (Parameter param in cannon.Parameters)
            {

            }
        }
    }
}
