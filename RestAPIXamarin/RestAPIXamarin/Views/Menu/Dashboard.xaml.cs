using RestAPIXamarin.Models;
using RestAPIXamarin.Views.DetailViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestAPIXamarin.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();
        }

        void Init(){
            BackgroundColor = Constants.BackgroundColor;
            //App.StartCheckIfInternet(labelNoInternet, this);
        }

        async void changeScreen(object sender, EventArgs e){
            await Navigation.PushAsync(new InfoPage());
        }
    }
}