using DoShip.Models.Paramaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models
{
    public class Buff : ShipItem
    {
        public Buff(string name, int level, int amount, List<Parameter> parameters) 
            : base(name, level, amount, parameters)
        {
        }

        public override string ToString()
        {
            string desription = $"{Name}\n";

            foreach (var parameter in Parameters)
            {
                desription += $"{parameter.Name}: {parameter.Value}";
            }

            return desription;
        }
    }
}
