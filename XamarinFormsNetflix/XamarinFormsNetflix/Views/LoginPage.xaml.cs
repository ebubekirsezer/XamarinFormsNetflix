using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsNetflix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IntroductionPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new UserPage());
            App.Current.MainPage = new NavigationPage(new UserPage()) { BarBackgroundColor = Color.FromHex("#0D0D0D") };
        }
    }
}