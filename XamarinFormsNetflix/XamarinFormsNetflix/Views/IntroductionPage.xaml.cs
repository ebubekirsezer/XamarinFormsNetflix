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
    public partial class IntroductionPage : ContentPage
    {
        public IntroductionPage()
        {
            InitializeComponent();
            FillInfo();
        }
        class IntroductionModel
        {
            public string IntroBackground { get; set; }
            public string IntroLabel { get; set; }
            public string IntroDescription { get; set; }
        }
        private void FillInfo()
        {
            List<IntroductionModel> introductionModels = new List<IntroductionModel>
            {
                new IntroductionModel
                {
                    IntroBackground="intro1"
                },
                  new IntroductionModel
                {
                    IntroBackground="intro2"
                },
                new IntroductionModel
                {
                    IntroBackground="intro3"
                },
                  new IntroductionModel
                {
                    IntroBackground="intro4"
                }
            };
            myCarouselView.BindingContext = introductionModels;
        }

        private void BtnContinue_Clicked(object sender, EventArgs e)
        {
           // Navigation.PushAsync(new LoginPage());
            App.Current.MainPage = new NavigationPage(new LoginPage()) {BarBackgroundColor = Color.FromHex("#0D0D0D")};
        }
    }
}