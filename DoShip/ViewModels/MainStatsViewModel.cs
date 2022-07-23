using DoShip.Commands;
using DoShip.Models.Paramaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace DoShip.ViewModels
{
    public class MainStatsViewModel : ViewModelBase
    {
        public ICommand PinMenu { get; }
        private SplitViewDisplayMode _splitViewDisplayMode;
        private string _glyph;

        #region Stats
        private GlobalParameter _hitProbability;
        


        public GlobalParameter HitProbability
        {
            get;
            private set;
        }

        #endregion

        public string Glyph
        {
            get => _glyph;
            set => Set(ref _glyph, value);
        }
        public SplitViewDisplayMode SplitViewDisplayMode
        {
            get => _splitViewDisplayMode;
            set => Set(ref _splitViewDisplayMode, value);
        }
        public MainStatsViewModel()
        {
            PinMenu = new PinMenuComman(this);
            SplitViewDisplayMode = SplitViewDisplayMode.Inline;
            Glyph = "\xE718";
            SetStats();
        }

        private void SetStats()
        {
            HitProbability = new GlobalParameter(new HitProbability(Parameter.Type.Percent));
            HitProbability.Stats.Add(new HitProbability(Parameter.Type.Double));
        }
    }
}
