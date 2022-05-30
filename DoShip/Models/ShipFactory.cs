using DoShip.Models.Cannons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models
{
    public class ShipFactory
    {
        public enum CannonType
        {
            Admiral,
            Firestorm,
            Doomhammer,
            Devastator,
            Painbringer,
            Worldbreaker,
            Bastion,
            Overlord
        }

        public static Cannon CreateCannon(CannonType type, int level)
        {
            Cannon cannon = null;

            if (type == CannonType.Firestorm)
            {
                cannon = new TierTwoCannon("Firestorm", level);
            }

            return cannon;
        }
    }
}
