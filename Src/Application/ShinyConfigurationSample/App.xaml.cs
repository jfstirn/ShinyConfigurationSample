using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;
using ShinyConfigurationSample.Views;
using Xamarin.Essentials.Implementation;
using ShinyConfigurationSample.ViewModels;
using ShinyConfigurationSample.Configuration;
using System;

namespace ShinyConfigurationSample
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage").HandleNavigationErrorAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            // Register pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            // Shell and module configuration
            var configuration = containerRegistry.AddConfiguration();

            // ...
            var foo = configuration["Foo"];
        }
    }
}
