namespace MenuTest
{
    public partial class App : Application
    {
        public static string AppName => AppInfo.Name; // Pulls from <ApplicationTitle>

        public App()
        {
            InitializeComponent();
            UserAppTheme = AppTheme.Dark;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}