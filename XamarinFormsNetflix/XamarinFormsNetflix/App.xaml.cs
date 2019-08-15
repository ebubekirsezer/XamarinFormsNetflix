using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsNetflix.Views;

namespace XamarinFormsNetflix
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new IntroductionPage()) { BarBackgroundColor = Color.FromHex("#0D0D0D")};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
