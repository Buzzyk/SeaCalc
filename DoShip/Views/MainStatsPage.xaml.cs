using DoShip.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DoShip.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainStatsPage : Page
    {
        private MainPage _mainPage;
        public MainStatsViewModel viewModel;
        public MainStatsPage()
        {
            this.InitializeComponent();           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                _mainPage = e.Parameter as MainPage;
                viewModel = _mainPage.StatsViewModel;
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            _mainPage.GoForward();//TODO: Delete ?
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainPage.GoForward();
        }
    }
}
