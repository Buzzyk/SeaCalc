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
        private string _image;
        private List<Parameter> _parameters;
        private int _amount;
        

        public List<Parameter> Parameters { get; set; }
        public string Name { get; set; }
        public int Level { get;  }
        public int Amount { get; set; }
        public virtual string Image { get; }

        //TODO: fix LSP (enums with childs)
        public ShipItem(string name, int level, int amount, List<Parameter> parameters)
        {
            Name = name;
            Level = level;
            Parameters = parameters;
            Amount = amount;
        }
    }
}
