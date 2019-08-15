using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsNetflix.CustomControls;
using XamarinFormsNetflix.Views.TabbedPages;

namespace XamarinFormsNetflix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage : CustomTabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
            Children.Add(new HomePage());
            Children.Add(new SearchPage());
            Children.Add(new DownloadedPage());
            Children.Add(new SettingsPage());
        }
    }
}