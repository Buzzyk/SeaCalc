using DoShip.Models.Paramaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models
{
    public abstract class ShipItem
    {
        private string _name;
        private int _level;
        private List<Parameter> _parameters;

        public List<Parameter> Parameters { get; set; }

        public string Name { get; }
        public int Level { get;  }
        public ShipItem(string name, int level)
        {
            Name = name;
            Level = level;
            Parameters = new List<Parameter>();
        }

        protected void SetParameters(List<Parameter> parameters)
        {
            Parameters = parameters;
        }
    }
}
