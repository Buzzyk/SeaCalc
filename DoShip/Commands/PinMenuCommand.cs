using DoShip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoShip.Commands
{
    internal class PinMenuComman : Command
    {
        private readonly MainStatsViewModel _viewModel;
        public PinMenuComman(MainStatsViewModel viewModel)
        {
            _viewModel = viewModel;

        }
        public override void Execute(object parameter)
        {
            if (_viewModel.SplitViewDisplayMode == Windows.UI.Xaml.Controls.SplitViewDisplayMode.Inline)
            {
                _viewModel.SplitViewDisplayMode = Windows.UI.Xaml.Controls.SplitViewDisplayMode.Overlay;
                _viewModel.Glyph = "\xE718";
            }
            else
            {
                _viewModel.SplitViewDisplayMode = Windows.UI.Xaml.Controls.SplitViewDisplayMode.Inline;
                _viewModel.Glyph = "\xE77A";
            }

        }

    }
}
