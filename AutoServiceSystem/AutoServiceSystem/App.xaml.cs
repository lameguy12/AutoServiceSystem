using AutoServiceSystem;
using Xamarin.Forms;

namespace AutoServiceSystem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set up the MainPage within a NavigationPage
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
