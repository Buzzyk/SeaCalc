using DoShip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DoShip.Commands
{
    internal class OpenMenuCommand : Command
    {
        private readonly MainPage _mainPage;
        private readonly MainPageViewModel _viewModel;
        public OpenMenuCommand(MainPage mainPage, MainPageViewModel viewMovel)
        {
            _mainPage = mainPage;
            _viewModel = viewMovel;
        } 
        public override void Execute(object parameter)
        {
            if (_viewModel.IsOpen == true)
            {
                _viewModel.IsOpen = false;
                _viewModel.Glyph = "\xE8A0";
                _viewModel.GlyphLable = "Open pan";
            } 
            else
            {
                _viewModel.IsOpen = true;
                _viewModel.Glyph = "\xE89F";
                _viewModel.GlyphLable = "Close pan";
            }
        }

    }
}
