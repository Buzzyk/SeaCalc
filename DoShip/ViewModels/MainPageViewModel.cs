using DoShip.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace DoShip.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public ICommand OpenMenu { get; }
        public ICommand PinPan { get; }
        private bool _isOpen;
        private string _glyph;
        private string _glyphLable;
        private string _header;
        public string Header
        {
            get => _header;
            set => Set(ref _header, value);
        }
        public string GlyphLable
        {
            get => _glyphLable;
            set => Set(ref _glyphLable, value);
        }
        public string Glyph
        {
            get => _glyph;
            set => Set(ref _glyph, value);
        }

        public bool IsOpen
        {
            get => _isOpen;
            set => Set(ref _isOpen, value);
        }

        private readonly MainPage _mainPage;
        public MainPageViewModel(MainPage mainPage) {
            
            _mainPage = mainPage;
            OpenMenu = new OpenMenuCommand(mainPage, this);
            Glyph = "\xE8A0";
            GlyphLable = "Open pan";
        }
    }
}
