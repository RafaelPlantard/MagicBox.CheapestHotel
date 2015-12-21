using MagicBox.CheapestHotel.Service;
using MagicBox.UWP.Services;
using Microsoft.ApplicationInsights;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace MagicBox.CheapestHotel
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default PrismUnityApplication class.
    /// </summary>
    public sealed partial class App
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();

            WindowsAppInitializer.InitializeAsync(WindowsCollectors.Metadata | WindowsCollectors.Session);
        }

        /// <summary>
        /// Register on the Unity Container the services.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Register the services that app is using.
            RegisterTypeIfMissing(typeof(IFileReaderService), typeof(FileReaderService), true);
            RegisterTypeIfMissing(typeof(IReservationService), typeof(ReservationService), true);
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);

            return Task.FromResult<object>(null);
        }
    }
}