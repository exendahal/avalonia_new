using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Preferences;
using avalonia_new.Region;
using avalonia_new.ViewModels;
using avalonia_new.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using System;

namespace avalonia_new;

public class App : PrismApplication
{
    public new static App? Current => Application.Current as App;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    public IServiceProvider? Services { get; private set; }
    /// <summary>App entry point.</summary>
    public App()
    {
        Console.WriteLine("Constructor()");
    }
    public override void Initialize()
    {
        Console.WriteLine("Initialize()");
        AvaloniaXamlLoader.Load(this);
        base.Initialize();
    }
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        #region Services 
        // Services
        #endregion

        // Views - Region Navigation
        containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
        containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
        containerRegistry.RegisterForNavigation<LandingView, LandingViewModel>();
        containerRegistry.RegisterForNavigation<WelcomeView, WelcomeViewModel>();
        containerRegistry.RegisterForNavigation<HomePageContainerView, HomePageContainerViewModel>();
    }

    protected override AvaloniaObject CreateShell()
    {
        Console.WriteLine("CreateShell()");
        return ApplicationLifetime switch
        {
            IClassicDesktopStyleApplicationLifetime => Container.Resolve<MainWindow>(),
            _ => Container.Resolve<MainView>()
        };
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //services.AddSingleton<IFilesService>(x => new FilesService(desktop.MainWindow));
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            //services.AddSingleton<IFilesService>(x => new FilesService(TopLevel.GetTopLevel(singleViewPlatform.MainView)));
        }


        Services = services.BuildServiceProvider();
        services.AddSingleton<Preferences>();
        base.OnFrameworkInitializationCompleted();
    }
    protected override void OnInitialized()
    {
        var regionManager = Container.Resolve<IRegionManager>();
        RegionManager.SetRegionManager(MainWindow, regionManager);
        regionManager.RegisterViewWithRegion(RegionNames.CONTENT_REGION, typeof(LandingView));
    }

    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        regionAdapterMappings.RegisterMapping<ItemsControl,
            Region.ItemsControlRegionAdapter>();
        regionAdapterMappings.RegisterMapping<ContentControl, ContentControlRegionAdapter>();
    }
}
