using DoShip.Models.Paramaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models
{
    public class Cannon : ShipItem
    {
        public enum CannonType
        {
            Firestorm,
        } 
        public CannonType Type { get; }
        public override string Image
        {
            get { return $"/Assets/Cannons/{Name}.png"; }
        }

        public Cannon(string name, CannonType type, int level, int amount, List<Parameter> parameters) 
            : base(name, level, amount, parameters)
        {
            Type = type;
        }

        public override string ToString()
        {
            string desription = $"{Name} cannon, level {Level}\n";

            foreach (var parameter in Parameters)
            {
                desription += $"{parameter.Name}: {parameter.Value}\n";
            }

            return desription;
        }

    }
}
