using DoShip.Models.Paramaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models
{
    public class CannonFactory
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

        private enum Tier
        {
            One,
            Two,
            Three
        }

        public static Cannon CreateCannon(Cannon.CannonType type, int level, int amount)
        {
            Cannon cannon = null;

            if (type == Cannon.CannonType.Firestorm)
            {
                cannon = Create("Firestorm", type, level, amount, Tier.Two);
            }
            return cannon;
        }

        private static Cannon Create(string name, Cannon.CannonType type, int level, int amount, Tier tier)
        {            
            List<Parameter> parameters = new List<Parameter>();

            if (tier == Tier.One)
            {
                parameters = SetTierOneParameters();
            } else if (tier == Tier.Two)
            {
                parameters = SetTierTwoParameters();
            } else if (tier == Tier.Three)
            {
                parameters = SetTierThreeParameters();
            }

            GetParametersFromDatabase(parameters);

            return new Cannon(name, type, level, amount, parameters);
        }
                
        private static List<Parameter> SetTierTwoParameters()
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new CannonRange(Parameter.Type.Double),
                new CannonReloadTime(Parameter.Type.Double),
                new HitProbability(Parameter.Type.Percent)
            };
            return parameters;
        }

        private static List<Parameter> SetTierOneParameters()
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new CannonRange(Parameter.Type.Double),
                new CannonReloadTime(Parameter.Type.Double),
                new HitProbability(Parameter.Type.Percent)
            };
            return parameters;
        }

        private static List<Parameter> SetTierThreeParameters()
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new CannonRange(Parameter.Type.Double),
                new CannonReloadTime(Parameter.Type.Double),
                new HitProbability(Parameter.Type.Percent)
            };
            return parameters;
        }

        private static void GetParametersFromDatabase(List<Parameter> parameters)
        {
            //TODO: Добавить выгрузку данных из базы
        }

    }
}
