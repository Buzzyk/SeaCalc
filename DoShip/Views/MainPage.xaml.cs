using DoShip.Models;
using DoShip.ViewModels;
using DoShip.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace DoShip
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Ship Ship;
        public MainPageViewModel MainPageViewModel;
        public MainStatsViewModel StatsViewModel;
        public bool isOpen = false; // DELETE?
        public SplitViewDisplayMode isPinned = SplitViewDisplayMode.Overlay;
        private NavigationTransitionInfo _transitionInfo = null;

        public MainPage()
        {
            this.InitializeComponent();
            Ship = new Ship();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            UpdateTitleBarLayout(coreTitleBar);

            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(AppTitleBar);

            // Register a handler for when the size of the overlaid caption control changes.
            // For example, when the app moves to a screen with a different DPI.
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

            // Register a handler for when the title bar visibility changes.
            // For example, when the title bar is invoked in full screen mode.
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;

            //Register a handler for when the window changes focus
            Window.Current.Activated += Current_Activated;

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonForegroundColor = Colors.WhiteSmoke;

            MainPageViewModel = new MainPageViewModel(this);
            StatsViewModel = new MainStatsViewModel();
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            UpdateTitleBarLayout(sender);
        }

        private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
        {
            // Update title bar control size as needed to account for system size changes.
            AppTitleBar.Height = coreTitleBar.Height;

            // Ensure the custom title bar does not overlap window caption controls
            Thickness currMargin = AppTitleBar.Margin;
            AppTitleBar.Margin = new Thickness(currMargin.Left, currMargin.Top, coreTitleBar.SystemOverlayRightInset, currMargin.Bottom);
        }
        // Update the TitleBar based on the inactive/active state of the app
        private void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            SolidColorBrush defaultForegroundBrush = (SolidColorBrush)Application.Current.Resources["TextFillColorPrimaryBrush"];
            SolidColorBrush inactiveForegroundBrush = (SolidColorBrush)Application.Current.Resources["TextFillColorDisabledBrush"];

            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                AppTitle.Foreground = inactiveForegroundBrush;
            }
            else
            {
                AppTitle.Foreground = defaultForegroundBrush;
            }
        }

        private void NavigationViewControl_DisplayModeChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewDisplayModeChangedEventArgs args)
        {
            const int topIndent = 16;
            const int expandedIndent = 48;
            int minimalIndent = 104;

            // If the back button is not visible, reduce the TitleBar content indent.
            if (NavView.IsBackButtonVisible.Equals(Microsoft.UI.Xaml.Controls.NavigationViewBackButtonVisible.Collapsed))
            {
                minimalIndent = 48;
            }

            Thickness currMargin = AppTitleBar.Margin;

            // Set the TitleBar margin dependent on NavigationView display mode
            if (sender.PaneDisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewPaneDisplayMode.Top)
            {
                AppTitleBar.Margin = new Thickness(topIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
            else if (sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Minimal)
            {
                AppTitleBar.Margin = new Thickness(minimalIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
            else
            {
                AppTitleBar.Margin = new Thickness(expandedIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
        }
        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
            {
                AppTitleBar.Visibility = Visibility.Visible;
            }
            else
            {
                AppTitleBar.Visibility = Visibility.Collapsed;
            }
        }
        private void navView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                rootFrame.Navigate(typeof(SettingsView), null, new DrillInNavigationTransitionInfo());
            }
            else if (args.InvokedItemContainer != null)
            {
                var item = sender.MenuItems.OfType<Microsoft.UI.Xaml.Controls.NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                navView_Navigate(item as Microsoft.UI.Xaml.Controls.NavigationViewItem);

            }
        }

        private void navView_Navigate(Microsoft.UI.Xaml.Controls.NavigationViewItem item)
        {
            string[] withoutHeader = { "SeaPage", "HomePage" };
            //NavView.AlwaysShowHeader = !withoutHeader.Contains(item.Tag);
            //NavView.Header = item.Tag;

            switch (item.Tag)
            {
                case "Home":
                    rootFrame.Navigate(typeof(HomeView), null, new DrillInNavigationTransitionInfo());
                    MainPageViewModel.Header = "Home";
                    break;
                case "MyShip":
                    rootFrame.Navigate(typeof(MyShipPage), null, new DrillInNavigationTransitionInfo());
                    MainPageViewModel.Header = "My ship";
                    break;
                case "Statistic":
                    rootFrame.Navigate(typeof(StatisticPage), null, new DrillInNavigationTransitionInfo());
                    MainPageViewModel.Header = "Statistic";
                    break;
                default:
                    break;
            }


        }

        private void navView_BackRequested(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs args)
        {
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = this.RequestedTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
        }

        public void OpenMenu()
        {
        }

        public void CloseMenu()
        {
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _transitionInfo = new DrillInNavigationTransitionInfo();
            menuFrame.Navigate(typeof(MainStatsPage), this, _transitionInfo);
        }

        public void GoBack()
        {
            menuFrame.Navigate(typeof(MainStatsPage), this, _transitionInfo);
        }

        public void GoForward()
        {
            menuFrame.Navigate(typeof(AdditionalInfoPage), this, _transitionInfo);
        }
    }
}
