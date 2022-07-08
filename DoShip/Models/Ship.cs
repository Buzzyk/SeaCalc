using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoShip.Models;
using DoShip.Models.Paramaters;

namespace DoShip.Models
{
    public class Ship
    {
        private int _weaponSlots;
        private int _extantionSlots;
        private int _crewSlots;      
        private int _cannonDamage;        
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

        private CannonRange _cannonRange;//TODO: Добавить пересчет при изменении коллекции
        private CannonReloadTime _cannonReloadTime;
        private HitProbability _hitProbability;



        public ObservableCollection<Cannon> Cannons;
        public ObservableCollection<Buff> Buffs;
        public List<int> Extantions;
        public List<int> Crew;
        public int Pet;
        public List<int> ActionItems;
        public int Castles;
        public int Skills;
        public int Trophys;
        public int Gems;


        public Ship()
        {
            SetLists();
        }

        private void SetLists()
        {
            Cannons = new ObservableCollection<Cannon>();
        }
        
        public void AddCannon(Cannon.CannonType type, int level, int amount)
        {
            Cannon tempCannon = CannonFactory.CreateCannon(type, level, amount);

            foreach (Cannon cannon in Cannons)
            {
                if (cannon.Type == tempCannon.Type && cannon.Level == tempCannon.Level)
                {
                    cannon.Amount += amount;
                    return;
                }             
            }
            Cannons.Add(tempCannon);
        }

        public void RemoveCannon(Cannon cannon)
        {
            Cannons.Remove(cannon);
        }
    }
}
