using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsNetflix.Views.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            FillInfo();
        }
        private void FillInfo()
        {
            List<Movies> movies = new List<Movies>
            {
                new Movies
                {
                    MovieImage="fury"
                },
                new Movies
                {
                    MovieImage="hakan"
                },
                new Movies
                {
                    MovieImage="howi"
                },
                new Movies
                {
                    MovieImage="harry"
                },
                new Movies
                {
                    MovieImage="inception"
                }
            };
            List<Movies> movies1 = new List<Movies>
            {
                new Movies
                {
                    MovieImage="lacasadepapel"
                },
                new Movies
                {
                    MovieImage="lordofrings"
                },
                new Movies
                {
                    MovieImage="mindhunter"
                },
                new Movies
                {
                    MovieImage="narcos"
                },
                new Movies
                {
                    MovieImage="prison"
                }
            };
            lstMovieCollection.BindingContext = movies;
            lstMovieCollection2.BindingContext = movies1;
        }

        class Movies
        {
            public string MovieImage { get; set; }
        }
    }
}