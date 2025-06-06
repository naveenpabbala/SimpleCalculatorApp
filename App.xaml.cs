
//namespace SimpleCalculator
//{
//    public partial class App : Application
//    {
//        public App()
//        {
//            InitializeComponent();

//        }
//        protected override Window CreateWindow(IActivationState? activationState)
//        {
//            var window = new Window(new MainPage());

//# if WINDOWS
//      const int desiredWidth = 512;
//      const int desiredHeight = 680;

//      window.Width = desiredWidth;
//      window.Height = desiredHeight;
//#endif
//            return window;
//        }
//    }
//}

using Microsoft.Maui.Controls;

namespace SimpleCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
