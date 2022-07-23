using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Models.Paramaters
{
    public class GlobalParameter : Parameter
    {
        private Parameter _parameter;
        private string param; // name of local param 
        private ObservableCollection<ShipItem> _items;//TODO: Переделать коллекцию параметров на коллекцию айтемов корабля.
        public ObservableCollection<Parameter> Items
        {
            get;
            private set;
        }
        
        public GlobalParameter(Parameter parameter)
            : base(parameter.Name, parameter.ValueType)
        {
            _parameter = parameter;
            Items = new ObservableCollection<Parameter>();
        }

        private void ItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= UpdateValue;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += UpdateValue;
            }
        }


        public void SetStats(ObservableCollection<Parameter> stats)
        {
            Items = stats;
        }

        private void UpdateValue(object sender, PropertyChangedEventArgs e)
        {
            double doubleValues = 0;
            double percentVelues = 0;

            foreach (var item in Items)
            {
                if (item.ValueType == Type.Double)
                {
                    doubleValues += item.Value;
                }
                else
                {
                    percentVelues += item.Value;
                }
            }

            Value = doubleValues * percentVelues / 100;
        }
    }
}
