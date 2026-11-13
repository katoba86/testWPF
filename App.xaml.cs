using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1.Services;
using T1.ViewModels;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using LaunchActivatedEventArgs = Microsoft.UI.Xaml.LaunchActivatedEventArgs;
using Path = System.IO.Path;




namespace T1;




/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{

    public static IHost? Host { get; private set; }

    private Window? _window;

    
    public App()
    {
        
        InitializeComponent();

        



        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        .UseContentRoot(AppContext.BaseDirectory)
        .ConfigureServices((context, services) =>
        {
            // Core Services (Singletons)
            services.AddSingleton<ISettingsService, SettingsService>();

            services.AddSingleton<IDbSession, SqlSession>();

            // ViewModels (Transient, damit jede Page ihr eigenes frisches ViewModel kriegt)
            services.AddTransient<HomeViewModel>();            
            
            services.AddTransient<MainWindow>();
        }).
        Build();
        

    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {

        base.OnLaunched(args);

        // Host starten
        await Host!.StartAsync();

        // Ein einziges Mal aus dem DI-Container holen, in _window speichern und aktivieren
        _window = Host.Services.GetRequiredService<MainWindow>();
        _window.Activate();

    }

    private async void OnExited(object sender, EventArgs e)
    {
        // Sauberes Herunterfahren des Hosts
        await Host!.StopAsync();
        Host.Dispose();
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // Globales Error Logging
    }


}
