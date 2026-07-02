using Microsoft.Extensions.DependencyInjection;

namespace httpSpeed
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

            var window = new Window(new AppShell());
            window.Width = 400;
            window.Height = 300;
            window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
            window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
            return window;
        }
    }
}