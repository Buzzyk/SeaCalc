using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models.Paramaters
{
    internal class HitProbability : Parameter
    {
        public HitProbability(Type type)
            : base("Меткость", type)
        {
        }
    }
}
