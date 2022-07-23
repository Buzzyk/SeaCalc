using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models.Paramaters
{
    internal interface IParamater
    {

        string Name { get; set; }
        string Type { get; set; }
        string Value { get; set; }
    }
}
