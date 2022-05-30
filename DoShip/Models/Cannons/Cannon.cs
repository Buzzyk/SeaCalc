using DoShip.Models.Paramaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models
{
    public class Cannon1
    {
        private int _typeId;
        private string _name;
        private string _image;
        private int _level;

        private int _cannonRange;
        private int _reloadTime;
        private int _hitProbability;

        //private int _elitePointsBonus;
        //private int _experiencePointsBonus;        


        
        
        //TODO: Возможно, поведение пушки (урон или нет) нужно будет вынести как стратегию
        IList<Parameter> parameters; //TODO: Посмотреть, стоит ли параметры задать списком в фабрике ингридиенты

        public Cannon1(string name, int level)
        {
            _name = name;
            _level = level;

            SetParameters();
        }

        protected virtual void SetParameters()
        {

        }
    }
}
