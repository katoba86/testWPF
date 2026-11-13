using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace T1;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ExtendsContentIntoTitleBar = true;
        
    }
    // 1. Default-Routing beim Start der Anwendung
    private void NavView_Loaded(object sender, RoutedEventArgs e)
    {
        // Setzt den visuellen Fokus auf das erste Menüelement
        if (NavView.MenuItems.Count > 0)
        {
            NavView.SelectedItem = NavView.MenuItems[0];
        }

        // Lädt standardmäßig die HomePage in den Frame
        contentFrame.Navigate(typeof(Views.HomePage));
    }

    // 2. Routing-Logik bei Klick auf ein Menüelement
    private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItemContainer != null)
        {
            var navTag = args.InvokedItemContainer.Tag?.ToString();

            switch (navTag)
            {
                case "start":
                    contentFrame.Navigate(typeof(Views.HomePage));
                    break;
                case "settings":
                    contentFrame.Navigate(typeof(Views.TestPage));
                    break;
                default:
                    contentFrame.Navigate(typeof(Views.HomePage)); break;
            }
        }
    }
}


