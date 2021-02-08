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
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public List<MasterMenuItem> items;

        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("InfoScreen", "icon.png", Color.White, typeof(InfoScreen)));
            items.Add(new MasterMenuItem("InfoScreen2", "icon.png", Color.White, typeof(InfoScreen2)));
            ListView.ItemsSource = items;
        }

        async void SignOut(object sender, EventArgs e)
        {
            await DisplayAlert("Sing Out", "Good Bye", "Ok!");
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}