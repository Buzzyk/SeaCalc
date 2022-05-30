using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models.Paramaters
{
    public class CannonReloadTime : Parameter
    {
        public CannonReloadTime(Type type) 
            : base("Время перезарядки", type)
        {

        }
    }
}
