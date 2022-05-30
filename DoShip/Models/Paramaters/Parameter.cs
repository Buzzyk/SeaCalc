using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models.Paramaters
{
    public abstract class Parameter
    {
        public enum Type
        {
            Double,
            Percent
        }

        private string _name;
        private Type _valueType;
        private double _value;

        public string Name { get; }
        public Type ValueType { get; }
        public double Value { get; set; }
        public Parameter(string name, Type type)
        {
            Name = name;
            ValueType = type;
        }
    }
}
