using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment1.Services;
using Assignment1.Views;

namespace Assignment1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Akavache.Registrations.Start("Assignment1");
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
